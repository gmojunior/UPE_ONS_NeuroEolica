unit Itemorc;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, Buttons, ExtCtrls, Fpal, DB, DBTables, Grids, DBGrids, Animate;

type
  TItOrc = class(TForm)
    Label1: TLabel;
    DBGrid1: TDBGrid;
    DataSource1: TDataSource;
    Table1: TTable;
    DataSource2: TDataSource;
    Table2: TTable;
    DataSource3: TDataSource;
    Table3: TTable;
    Table1Area: TStringField;
    Table1CCusto: TIntegerField;
    Table1NOrcam: TStringField;
    Table1PChesf: TStringField;
    Table1Ativ: TStringField;
    Table1OCurso: TStringField;
    Table1Realizado: TFloatField;
    Table1Orado: TFloatField;
    Table1Saldo: TFloatField;
    Table1Perc: TFloatField;
    procedure ComboBox1Change(Sender: TObject);
    procedure Memo1Change(Sender: TObject);
    procedure ListBox1DblClick(Sender: TObject);
    procedure ListBox2DblClick(Sender: TObject);
    procedure AplicarClick(Sender: TObject);
    procedure AnularClick(Sender: TObject);
    procedure SairClick(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure PrintClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  ItOrc: TItOrc;
  wMes : array[0..11] of string;
  PixelsPoX,PixelsPoY,wLin : integer;
implementation

uses printers,breakimp;
var
PDC : HDC;
SW : TScrollingWinControl;

{$R *.DFM}
procedure PrintHeader;
begin
 with printer do begin
   canvas.rectangle(50,wlin,2320,wlin+pixelsPoY*3);
   wlin := wlin+pixelsPoY;
   canvas.textout(100,wlin,'Area');
   canvas.textout(250,wlin,'C.Custo');
   canvas.textout(400,wlin,'N. Orçam.');
   canvas.textout(600,wlin,'P. Chesf');
   canvas.textout(750,wlin,'Ativ');
   canvas.textout(850,wlin,'O. Curso');
   canvas.textout(1170,wlin,'Realizado');
   canvas.textout(1550,wlin,'Orçado');
   canvas.textout(1920,wlin,'Saldo');
   canvas.textout(2190,wlin,'Perc.');
 end;
end;

procedure TItOrc.ComboBox1Change(Sender: TObject);
begin
  Memo1.Lines.Clear;
  if Combobox1.text <> '' then
     Memo1.Lines.Add(ComboBox1.Text);
end;

procedure TItOrc.Memo1Change(Sender: TObject);
var
 I: Integer;
begin
  ComboBox1.Text := Memo1.Lines[0];
  for I := 1 to Memo1.Lines.Count - 1 do
    ComboBox1.Text := ComboBox1.Text + ' ' + Memo1.Lines[I];
end;

procedure TItOrc.ListBox1DblClick(Sender: TObject);
begin
  if Memo1.Text <> '' then
    Memo1.Text := Memo1.Text + ' ';
  Memo1.Text := Memo1.Text + ListBox1.Items[ListBox1.ItemIndex];
end;

procedure TItOrc.ListBox2DblClick(Sender: TObject);
begin
  if Memo1.Text <> '' then
    Memo1.Text := Memo1.Text + ' '+ ListBox2.Items[ListBox2.ItemIndex];
end;

procedure TItOrc.AplicarClick(Sender: TObject);
var
 I,wI,wUltMes : integer;
 wReal,wOrca,wAcumul,wPerc : Real;
begin
  dbgrid1.visible := false;
  wUltMes := TabMes.itemindex+1;
  if tabmes.itemindex = -1 then begin
     showmessage('Selecione o mes');
     tabmes.setfocus;
     exit;
  end;
  if acumulado.itemindex = -1 then begin
     showmessage('Selecione Sim ou Não para o acumulado');
     acumulado.setfocus;
     exit;
  end;
  with table1 do begin
       active := false;
       exclusive := true;
       emptytable;
       exclusive := false;
       active := true;
  end;
  with table2 do begin
       if ComboBox1.Text <> '' then begin
         if (combobox1.itemindex<6) then begin
             combobox1.items.add('');
            for I := combobox1.items.count-1 downto 1 do
                combobox1.items[I] := combobox1.items[I-1];
         end;
         combobox1.items[0] := combobox1.text;
         for I := 0 to combobox1.items.count-1 do           if combobox1.items[i] = ''then
             if combobox1.items[I] = '' then
                combobox1.items.delete(I);
         Filter := ComboBox1.Text;
         Filtered := True;
       end
       else begin
         Filter := '';
         Filtered := False;
       end;
  end;
  table2.first;
  if table2.eof then begin
     showmessage('Não existe dados para o critério escolhido.');
     exit;
  end;
  screen.cursor := crhourglass;
  pencil.visible := true;
  table2.disablecontrols;
  table1.disablecontrols;
  while not table2.eof do begin
     application.processmessages;
     wOrca := 0;
     wReal := 0;
     if acumulado.items[acumulado.itemindex]='Sim' then begin
        for wI := 1 to wUltMes do begin
            wOrca := wOrca + table2.fields[wI+19].asfloat;
            wReal := wReal + table2.fields[wI+6].asfloat;
        end;
     end
     else begin
        wOrca := table2.fields[wUltMes+19].asfloat;
        wReal := table2.fields[wUltMes+6].asfloat;
     end;
     if (SOrcam.items[SOrcam.itemindex]='Sim') and (wOrca<>0) then begin
        table2.next;
        continue;
     end;
     if (wOrca=0) and (wReal=0) then begin
        table2.next;
        continue;
     end;
     wAcumul := (wOrca) + (wOrca*strtoint(Perc.text));
     if wOrca <> 0 then
        wPerc := (wReal-wOrca)/wOrca*100
     else
        wPerc := 9999;
     if strtoint(Perc.text) >= 0 then begin
        if wPerc >= strtoint(Perc.text) then begin
           table1.append;
           for wI := 0 to 5 do
               table1.fields[wI]:=table2.fields[wI+1];
           table1.fields[6].asfloat := wReal;
           table1.fields[7].asfloat := wOrca;
           table1.fields[8].asfloat := wOrca-wReal;
           table1.fields[9].asfloat := wPerc;
           table1.post;
        end;
     end
     else begin
        if (wPerc>=strtoint(Perc.text)) and (wPerc<0) then begin
           table1.append;
           for wI := 0 to 5 do
               table1.fields[wI]:=table2.fields[wI+1];
           table1.fields[6].asfloat := wReal;
           table1.fields[7].asfloat := wOrca;
           table1.fields[8].asfloat := wOrca-wReal;
           table1.fields[9].asfloat := wPerc;
           table1.post;
        end;
     end;
     table2.next;
  end;
  table2.enablecontrols;
  table1.enablecontrols;
  table1.first;
  pencil.visible := false;
  dbgrid1.visible := true;
  anular.enabled := true;
  print.enabled := true;
  screen.cursor := crdefault;
end;

procedure TItOrc.AnularClick(Sender: TObject);
var
  st : string;
  wI : integer;
begin
  print.enabled := false;
  aplicar.enabled := true;
  table1.disablecontrols;
  with Table1 do
  begin
    Filter := '';
    Filtered := False;
    memo1.lines.clear;
    st := combobox1.text;
    combobox1.text :='';
    if Combobox1.items.indexof(st)=-1 then
       combobox1.items.add(st);
  end;
  table1.enablecontrols;
  dbgrid1.visible := false;
end;

procedure TItOrc.SairClick(Sender: TObject);
begin
 itorc.close;
end;

procedure TItOrc.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  table1.active := false;
  table1.exclusive := true;
  table1.emptytable;
  table1.exclusive := false;
  table2.active := false;
  table3.active := false;
end;

procedure Imprime(wVal:extended;wEsq,wDir:integer;pict:Pchar);
var
cLen : integer;
wlinha : array[0..255] of char;
R : TRect;
begin
  R.left := wEsq;
  R.right := wDir;
  R.Top := wlin;
  R.Bottom := R.Top + PixelsPoY*2;
  cLen := floattotextfmt(wlinha,wVal,fvExtended,Pict);
  windows.drawtext(pdc,wlinha,cLen,R,dt_right);
end;


procedure TItOrc.PrintClick(Sender: TObject);
var
wVal : extended;
wI : integer;
wPagina : string[10];
begin
  CancelaImp.gauge.progress := 0;
  CancelaImp.gauge.maxvalue := table1.recordcount;
  cancelaImp.label1.caption := 'Imprimindo Página - '+ '1';
  CancelaImp.show;
  table1.disablecontrols;
  table1.first;
  with printer do begin
   application.processmessages;
   PixelsPoX := GetDeviceCaps(printer.handle,LOGPIXELSX);
   PixelsPoY := GetDeviceCaps(printer.handle,LOGPIXELSY) div 10;
   wlin := canvas.Textheight('X')+ PixelsPoY;
   begindoc;
   canvas.font.name := 'times new roman';
   canvas.font.color := clblue;
   canvas.font.size := 18;
   wlin := wlin + pixelsPoY*2;
   canvas.textout(550,wlin,'Relatório de Item Orçamentário - GEF');
   canvas.font.size := 10;
   wlin := wlin + pixelsPoY*7;
   canvas.textout(250,wlin,'Condição: ');
   for wI := 0 to memo1.lines.count-1 do begin
       canvas.textout(470,wlin,memo1.lines[wI]);
       wlin := wlin + pixelsPoY*2;
   end;
   wlin := wlin + pixelsPoY*2;
   canvas.textout(250,wlin,'Mes: '+ tabmes.items[tabmes.itemindex]);
   wlin := wlin + pixelsPoY*2;
   canvas.textout(250,wlin,'Acumulado ?: '+ acumulado.items[acumulado.itemindex]);
   wlin := wlin + pixelsPoY*2;
   canvas.textout(250,wlin,'Percentual: '+ Perc.text);
   wlin := wlin + pixelsPoY*2;
   canvas.textout(250,wlin,'Realizado sem Orçamento ?: '+ SOrcam.items[SOrcam.itemindex]);
   canvas.font.size := 8;
   wlin := wlin + pixelsPoY*5;
   PDC := canvas.handle;
   PrintHeader;
   wlin := wlin + pixelsPoY*3;
   while not table1.eof do begin
       application.processmessages;
       if aborted then begin
          enddoc;
          exit;
       end;
       canvas.textout(100,wlin,table1.fields[0].asstring);
       canvas.textout(250,wlin,table1.fields[1].asstring);
       canvas.textout(400,wlin,table1.fields[2].asstring);
       canvas.textout(600,wlin,table1.fields[3].asstring);
       canvas.textout(750,wlin,table1.fields[4].asstring);
       canvas.textout(850,wlin,table1.fields[5].asstring);
       wVal := table1.fields[6].asfloat;
       Imprime(wVal,1000,1300,'###,###.00');
       wVal := table1.fields[7].asfloat;
       Imprime(wVal,1350,1650,'###,###.00');
       wVal := table1.fields[8].asfloat;
       Imprime(wVal,1700,2000,'###,###.00');
       wVal := table1.fields[9].asfloat;
       Imprime(wVal,2050,2250,'###,###.00');
       table1.next;
       wlin := wlin + pixelsPoY*2;
       cancelaimp.gauge.progress := cancelaimp.gauge.progress + 1;
       if wlin + pixelsPoY*3 > pageheight then begin
          wpagina := 'Página '+ inttostr(PageNumber);
          canvas.font.style := [fsBold];
          canvas.textout(1000,wlin,wPagina);
          newpage;
          cancelaImp.label1.caption := 'Imprimindo Página - '+ inttostr(PageNumber);
          wLin := pixelsPoY*2;
          printheader;
          wlin := wlin + pixelsPoY*2;
       end;

  end;
   enddoc;
   table1.first;
   table1.enablecontrols;
   cancelaimp.close;
  end;
end;


procedure TItOrc.FormCreate(Sender: TObject);
var wI : integer;
begin
  dbgrid1.left := 2;
  dbGrid1.top := 40;
  wMes[0]  := 'Janeiro';
  wMes[1]  := 'Fevereiro';
  wMes[2]  := 'Março';
  wMes[3]  := 'Abril';
  wMes[4]  := 'Maio';
  wMes[5]  := 'Junho';
  wMes[6]  := 'Julho';
  wMes[7]  := 'Agosto';
  wMes[8]  := 'Setembro';
  wMes[9]  := 'Outubro';
  wMes[10] := 'Novembro';
  wMes[11] := 'Dezembro';
  tabMes.clear;
  for wI := 0 to table3.fields[0].asinteger-1 do begin
      tabMes.items.Add(wMes[wI]);
  end;
end;

end.
