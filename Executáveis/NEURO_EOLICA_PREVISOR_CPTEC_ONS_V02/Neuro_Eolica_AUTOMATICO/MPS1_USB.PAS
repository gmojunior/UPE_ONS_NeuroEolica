unit Mps1_usb;

interface

uses
  SysUtils, WinTypes, WinProcs, Messages, Classes, Graphics, Controls,
  Forms, Dialogs, StdCtrls, Buttons, ExtCtrls, Menus,printers;

type
CrefType = Class of TControl;
  TMainForm = class(TForm)
    MainMenu: TMainMenu;
    FileNewItem: TMenuItem;
    FileOpenItem: TMenuItem;
    FileSaveItem: TMenuItem;
    FileSaveAsItem: TMenuItem;
    FilePrintItem: TMenuItem;
    FilePrintSetupItem: TMenuItem;
    FileExitItem: TMenuItem;
    EditUndoItem: TMenuItem;
    EditCutItem: TMenuItem;
    EditCopyItem: TMenuItem;
    EditPasteItem: TMenuItem;
    HelpContentsItem: TMenuItem;
    HelpSearchItem: TMenuItem;
    HelpHowToUseItem: TMenuItem;
    HelpAboutItem: TMenuItem;
    OpenDialog: TOpenDialog;
    SaveDialog: TSaveDialog;
    PrintDialog: TPrintDialog;
    PrintSetupDialog: TPrinterSetupDialog;
    SpeedBar: TPanel;
    SpeedButton1: TSpeedButton;  { &New }
    SpeedButton2: TSpeedButton;  { &Open... }
    SpeedButton3: TSpeedButton;  { &Save }
    SpeedButton4: TSpeedButton;  { Save &As... }
    SpeedButton5: TSpeedButton;  { &Print... }
    SpeedButton6: TSpeedButton;  { &Print... }
    SpeedButton7: TSpeedButton;  { P&rint Setup... }
    SpeedButton8: TSpeedButton;  { E&xit }
    SpeedButton9: TSpeedButton;  { &Undo }
    SpeedButton10: TSpeedButton;  { &Copy }
    SpeedButton11: TSpeedButton;  { &Paste }
    SpeedButton12: TSpeedButton;  { &Contents }
    SpeedButton13: TSpeedButton;
    Edit1: TEdit;
    Edit2: TEdit;
    Edit3: TEdit;
    Edit4: TEdit;
    Label8: TLabel;
    Label7: TLabel;
    Label6: TLabel;
    Label2: TLabel;
    Labelp1: TLabel;
    Labelp2: TLabel;
    Labelp3: TLabel;
    Labelp4: TLabel;
    Labelp5: TLabel;
    Labelp6: TLabel;
    meP195: TLabel;
    MIP195: TLabel;
    maP195: TLabel;
    BitBtn1: TBitBtn;
    Button1: TButton;
    Label1: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    Label9: TLabel;
    MEP150: TLabel;
    MAP150: TLabel;
    MIP150: TLabel;
    MEP295: TLabel;
    MAP295: TLabel;
    MIP295: TLabel;
    MEP250: TLabel;
    MAP250: TLabel;
    MIP250: TLabel;
    MEP395: TLabel;
    MAP395: TLabel;
    MIP395: TLabel;
    MEP350: TLabel;
    MAP350: TLabel;
    MIP350: TLabel;
    MEP495: TLabel;
    MAP495: TLabel;
    MIP495: TLabel;
    MEP450: TLabel;
    MAP450: TLabel;
    MIP450: TLabel;
    Label10: TLabel;
    MEP595: TLabel;
    MAP595: TLabel;
    MIP595: TLabel;
    MEP550: TLabel;
    MAP550: TLabel;
    MIP550: TLabel;
    MEP695: TLabel;
    MAP695: TLabel;
    MIP695: TLabel;
    MEP650: TLabel;
    MAP650: TLabel;
    MIP650: TLabel;
    Label11: TLabel;
    Label12: TLabel;
    Label13: TLabel;
    Label14: TLabel;
    Label15: TLabel;
    Label16: TLabel;
    Label17: TLabel;
    Label18: TLabel;
    Label19: TLabel;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    Button7: TButton;
    Button8: TButton;
    Button9: TButton;
    Button10: TButton;
    Button11: TButton;
    Button12: TButton;
    Button13: TButton;
    Button14: TButton;
    Button15: TButton;
    Button16: TButton;
    Button17: TButton;
    Button18: TButton;
    Button19: TButton;
    Button20: TButton;
    Button21: TButton;
    Button22: TButton;
    Button23: TButton;
    Button24: TButton;
    Button25: TButton;
    Button26: TButton;
    Button27: TButton;
    Button28: TButton;
    Button29: TButton;
    Button30: TButton;
    Button31: TButton;
    Button32: TButton;
    Button33: TButton;
    Button34: TButton;
    Button35: TButton;
    Button36: TButton;
    Button37: TButton;
    Button38: TButton;
    Button39: TButton;
    Label20: TLabel;
    Label21: TLabel;
    Button40: TButton;
    Button41: TButton;
    Button42: TButton;
    Button43: TButton;
    Button44: TButton;
    Button45: TButton;
    Button46: TButton;
    Button47: TButton;
    Button48: TButton;
    Button49: TButton;
    Button50: TButton;
    Button51: TButton;
    Button52: TButton;
    PrintDialog1: TPrintDialog;
    Label22: TLabel;  { &About... }
    procedure FileNew(Sender: TObject);
    procedure FileOpen(Sender: TObject);
    procedure FileSave(Sender: TObject);
    procedure FileSaveAs(Sender: TObject);
    procedure FilePrint(Sender: TObject);
    procedure FilePrintSetup(Sender: TObject);
    procedure FileExit(Sender: TObject);
    procedure EditUndo(Sender: TObject);
    procedure EditCut(Sender: TObject);
    procedure EditCopy(Sender: TObject);
    procedure EditPaste(Sender: TObject);
    procedure HelpContents(Sender: TObject);
    procedure HelpSearch(Sender: TObject);
    procedure HelpHowToUse(Sender: TObject);
    procedure HelpAbout(Sender: TObject);
    procedure BitBtn1Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Button7Click(Sender: TObject);
    procedure Button8Click(Sender: TObject);
    procedure Button9Click(Sender: TObject);
    procedure Button10Click(Sender: TObject);
    procedure Button11Click(Sender: TObject);
    procedure Button12Click(Sender: TObject);
    procedure Button13Click(Sender: TObject);
    procedure Button14Click(Sender: TObject);
    procedure Button15Click(Sender: TObject);
    procedure Button16Click(Sender: TObject);
    procedure Button17Click(Sender: TObject);
    procedure Button18Click(Sender: TObject);
    procedure Button19Click(Sender: TObject);
    procedure Button20Click(Sender: TObject);
    procedure Button21Click(Sender: TObject);
    procedure Button22Click(Sender: TObject);
    procedure Button23Click(Sender: TObject);
    procedure Button24Click(Sender: TObject);
    procedure Button25Click(Sender: TObject);
    procedure Button26Click(Sender: TObject);
    procedure Button27Click(Sender: TObject);
    procedure Button28Click(Sender: TObject);
    procedure Button29Click(Sender: TObject);
    procedure Button30Click(Sender: TObject);
    procedure Button31Click(Sender: TObject);
    procedure Button32Click(Sender: TObject);
    procedure Button33Click(Sender: TObject);
    procedure Button34Click(Sender: TObject);
    procedure Button35Click(Sender: TObject);
    procedure Button36Click(Sender: TObject);
    procedure Button37Click(Sender: TObject);
    procedure Button38Click(Sender: TObject);
    procedure Button39Click(Sender: TObject);
    procedure Button40Click(Sender: TObject);
    procedure Button41Click(Sender: TObject);
    procedure Button42Click(Sender: TObject);
    procedure Button43Click(Sender: TObject);
    procedure Button44Click(Sender: TObject);
    procedure Button45Click(Sender: TObject);
    procedure Button46Click(Sender: TObject);
    procedure Button47Click(Sender: TObject);
    procedure Button48Click(Sender: TObject);
    procedure Button49Click(Sender: TObject);
    procedure Button50Click(Sender: TObject);
    procedure Button51Click(Sender: TObject);
    procedure Button52Click(Sender: TObject);
    procedure FormCloseQuery(Sender: TObject;
    var CanClose:Boolean);
    procedure Edit1KeyPress(Sender: TObject;var Key:char);

    private
    Classref : CReftype;
    contador : integer;
nomearquivo:string;
modified:bool;

   end;

var
  MainForm: TMainForm;
  cp11,cp12,cp13,cp14,ctp1,ep1:real;
  cp21,cp22,cp23,cp24,ctp2,ep2:Real;
  cp31,cp32,cp33,cp34,ctp3,ep3:real;
  cp41,cp42,cp43,cp44,ctp4,ep4:real;
  cp51,cp52,cp53,cp54,ctp5,ep5:real;
  cp61,cp62,cp63,cp64,ctp6,ep6:real;
const
c95=1.645;c50=0.68;
c11=0.249454;c12=0.294498;c13=-0.561497;c14=1.09511;ct1=-0.45435;e1=0.2184;
c21=0.011200;c22=0.043068;c23=-0.383136;c24=0.89099;ct2=2.74455;e2=0.1800;
c31=0.08957;c32=-0.28996;c33=0.13526;c34=0.74625;ct3=2.1727;e3=0.3274;
c41=-0.13623;c42=0.23427;c43=-0.60449;c44=0.96165;ct4=3.47577;e4=0.3661;
c51=-0.24863;c52=0.41479;c53=-0.09076;c54=0.83311;ct5=0.500;e5=0.25975;
c61=0.026451;c62=0.34273;c63=-0.75011;c64=1.19476;ct6=1.31134;e6=0.24511;
c71=0.097782;c72=-0.05541;c73=0.0002;c74=0.6873;ct7=1.795865;e7=0.25738;
c81=0.05406;c82=0.06655;c83=0.01265;c84=0.59196;ct8=1.76514;e8=0.2546;
c91=-0.05578;c92=0.021096;c93=-0.25015;c94=1.05063;ct9=1.80388;e9=0.2466;
c101=0.22887;c102=-0.01418;c103=-0.58953;c104=1.14503;ct10=1.54481;e10=0.2577;
c111=-0.13168;c112=0.20704;c113=-0.52768;c114=0.88525;ct11=3.71541;e11=0.2718;
c121=0.13917;c122=-0.14296;c123=-0.18256;c124=0.80801;ct12=2.49819;e12=0.2831;
c131=-0.27423;c132=0.32076;c133=-0.08338;c134=0.64638;ct13=2.50687;e13=0.2789;
c141=-0.03092;c142=0.10787;c143=-0.17755;c144=0.89579;ct14=1.36434;e14=0.2034;
c151=0.06899;c152=0.110078;c153=-0.11608;c154=0.638539;ct15=1.92437;e15=0.2498;
c161=0.00078;c162=0.43918;c163=-0.32129;c164=0.85252;ct16=0.12334;e16=0.2215;
c171=-0.05498;c172=0.49936;c173=-0.26496;c174=0.59868;ct17=1.34855;e17=0.2590;
c181=0.00053;c182=0.48259;c183=-0.62933;c184=1.05779;ct18=0.45867;e18=0.21026;
c191=0.132573;c192=0.13128;c193=-0.27073;c194=0.76407;ct19=1.37376;e19=0.17566;
c201=0.01624;c202=0.10265;c203=-0.08003;c204=0.72983;ct20=1.2839;e20=0.12989;
c211=-0.01073;c212=0.09782;c213=-0.16511;c214=0.95107;ct21=0.68778;e21=0.08457;
c221=0.065317;c222=-0.06985;c223=0.29591;c224=0.52104;ct22=1.02289;e22=0.0940;
c231=0.21055;c232=0.05155;c233=-0.37514;c234=0.97962;ct23=0.68704;e23=0.0910;
c241=-0.10372;c242=0.45291;c243=-0.56624;c244=1.1061;ct24=0.6000;e24=0.05365;
c251=0.167783;c252=-0.10801;c253=-0.16112;c254=0.95505;ct25=0.7868;e25=0.0554;
c261=0.06525;c262=-0.13501;c263=0.09889;c264=0.90377;ct26=0.35338;e26=0.04531;
c271=0.094059;c272=0.13709;c273=-0.592913;c274=1.21877;ct27=0.76623;e27=0.0796;
c281=0.24275;c282=-0.05139;c283=-0.25629;c284=1.02667;ct28=0.1838;e28=0.0517;
c291=0.22245;c292=-0.14395;c293=0.4794;c294=0.44153;ct29=-0.0573;e29=0.0472;
c301=-0.04205;c302=-0.04529;c303=-0.2082;c304=1.2285;ct30=0.365;e30=0.05417;
c311=0.064698;c312=0.2739;c313=-0.12564;c314=0.66665;ct31=0.63793;e31=0.04833;
c321=-0.47367;c322=1.14594;c323=-0.80489;c324=1.06147;ct32=0.39196;e32=0.0393;
c331=0.069647;c332=-0.14089;c333=0.38318;c334=0.69313;ct33=-0.062334;e33=0.035;
c341=-0.03792;c342=0.1020;c343=-0.2766;c344=1.23572;ct34=-0.1440;e34=0.02269;
c351=0.1146;c352=-0.1409;c353=0.3249;c354=0.5983;ct35=0.54434;e35=0.0459;
c361=0.07991;c362=-0.3509;c363=-0.1778;c364=1.3758;ct36=0.4055;e36=0.058;
c371=-0.1503;c372=-0.2494;c373=0.73496;c374=0.6638;ct37=0.01434;e37=0.0592;
c381=0.2016;c382=0.05599;c383=-0.02473;c384=0.7919;ct38=-0.1451;e38=0.0658;
c391=0.5542;c392=-0.4384;c393=-0.4175;c394=1.3452;ct39=-0.2091;e39=0.09823;
c401=0.2633;c402=0.2366;c403=-0.9112;c404=1.1611;ct40=1.41865;e40=0.1775;
c411=-0.1315;c412=0.2825;c413=0.0743;c414=0.7027;ct41=0.4644;e41=0.1241;
c421=0.6331;c422=-0.2722;c423=-0.0012;c424=0.799;ct42=-0.7443;e42=0.1764;
c431=0.1230;c432=0.3186;c433=-0.4587;c434=0.9226;ct43=0.5990;e43=0.1555;
c441=0.1532;c442=-0.0492;c443=0.02212;c444=0.6995;ct44=1.0952;e44=0.1536;
c451=0.1609;c452=-0.0154;c453=0.1390;c454=0.4161;ct45=1.82974;e45=0.1898;
c461=0.0171;c462=0.3771;c463=-0.4097;c464=0.9893;ct46=0.2862;e46=0.1673;
c471=0.02453;c472=0.05973;c473=-0.3005;c474=0.7162;ct47=2.9954;e47=0.1574;
c481=0.2186;c482=0.5112;c483=-0.6923;c484=0.7851;ct48=1.2728;e48=0.1727;
c491=0.7777;c492=-0.3466;c493=0.2740;c494=0.5478;ct49=-1.3744;e49=0.2409;
c501=0.3856;c502=-0.6212;c503=0.2242;c504=0.8484;ct50=0.9621;e50=0.15508;
c511=0.21406;c512=-0.2216;c513=0.3475;c514=0.39037;ct51=1.7627;e51=0.2326;
c521=-0.1368;c522=-0.2095;c523=-0.2190;c524=1.0519;ct52=3.22830;e52=0.2587;
 


implementation

{$R *.DFM}

procedure TMainForm.FileNew(Sender: TObject);
var
  I: Integer;
begin
  {deleta todos os componentes existentes, exceto o painel}
  for I := ControlCount - 1 downto 0 do
    if Controls[I].ClassName <> 'TPanel' then
      Controls[I].Free;
  Contador := 0;
 { Add code to create a new file }
end;

procedure TMainForm.FileOpen(Sender: TObject);

var
  S: TFileStream;
  New: TComponent;
begin
  if OpenDialog.Execute then
  begin
    {remove controles existente}
    NewFile(self);

    S := TFileStream.Create (OpenDialog.FileName,
      fmOpenRead);
    try
      while S.Position < S.Size do
      begin
        {le um componente e o adiciona ao form}
        New := S.ReadComponent (nil);
        InsertControl (New as TControl);
        Inc (Contador);
      end;
    finally
      S.Free;
    end;
  end;
end;

procedure TMainForm.FileSave(Sender: TObject);
begin
   { Add code to save current file under current name }
   if modified then

end;

procedure TMainForm.FileSaveAs(Sender: TObject);

var
  S: TFileStream;
  I: Integer;
begin
  if SaveDialog.Execute then
  begin
    S := TFileStream.Create (SaveDialog.FileName,
      fmOpenWrite or fmCreate);
    try
      {salva cada componente exceto o painel}
      for I := 0 to ControlCount - 1 do
        if Controls[I].ClassName <> 'TPanel' then
          S.WriteComponent (Controls[I]);
    finally
      S.Free;
    end;
  end;
end;


procedure TMainForm.FilePrint(Sender: TObject);
   var
  PrintFile: TextFile;
begin
  if PrintDialog.Execute then
  begin
  {atribui a impressora a um arquivo}
  AssignPrn (PrintFile);
  Rewrite (PrintFile);
  try
    {define o fonte fo form, e reproduz cada elemento}
    Font.size := 14;
    Printer.Canvas.Font := Font;

      Writeln(PrintFile,'');  Writeln(PrintFile,'');
    Writeln (PrintFile,'      ','  ',Labelp1.caption,'    ',labelp2.caption,
    '    ',Labelp3.Caption,'    ',
     labelp4.caption,'    ',labelp5.caption,'    ',labelp6.caption);
    Writeln (PrintFile,Label1.Caption,' ',mep195.caption,' ',mep150.caption,
    ' ',mep295.caption,' ',
     mep250.caption,' ',mep395.caption,' ',mep350.caption,' ',mep495.caption,
     ' ',mep450.caption,' ',
     mep595.caption,' ',mep550.caption,' ',mep695.caption,' ',mep650.caption);
  finally
  Font.size := 8;
    {fecha o processo de impressão}
    System.CloseFile (PrintFile);
  end;
end; { Add code to print current file }
 end;
 procedure TMainForm.FilePrintSetup(Sender: TObject);
begin
  PrintSetupDialog.Execute;
end;

procedure TMainForm.FormCloseQuery(Sender: TObject;
var CanClose:Boolean);
begin
  if MessageDlg ('tem certeza que quer sair?',
  mtinformation,[mbyes,mbno],0) = idno then
  CanClose := false;
  end;

procedure TMainForm.EditUndo(Sender: TObject);
begin
  { Add code to perform Edit Undo }
end;

procedure TMainForm.EditCut(Sender: TObject);
begin
  { Add code to perform Edit Cut }
end;

procedure TMainForm.EditCopy(Sender: TObject);
begin
  { Add code to perform Edit Copy }
end;

procedure TMainForm.EditPaste(Sender: TObject);
begin
  { Add code to perform Edit Paste }
end;

procedure TMainForm.HelpContents(Sender: TObject);
begin
  Application.HelpCommand(HELP_CONTENTS, 0);
end;

procedure TMainForm.HelpSearch(Sender: TObject);
const
  EmptyString: PChar = '';
begin
  Application.HelpCommand(HELP_PARTIALKEY, Longint(EmptyString));
end;

procedure TMainForm.HelpHowToUse(Sender: TObject);
begin
  Application.HelpCommand(HELP_HELPONHELP, 0);
end;

procedure TMainForm.HelpAbout(Sender: TObject);
begin
  { Add code to show program's About Box }
  MessageDlg ('O programa MPS foi escrito por Meuser Valença com o '+
   'Delphi para a DORH - Divisão de Gestão  ' +
  'dos Recursos Hídricos',mtInformation,[mbok],0);
end;

procedure TMainForm.BitBtn1Click(Sender: TObject);
var
lvazao1:real;
lvazao2:real;
lvazao3:real;
lvazao4:real;
lvazao5:real;
lvazao6:real;

begin
lvazao1:= cp11*Ln(StrToFloat(edit1.text))+ cp12*Ln(StrToFloat(edit2.text))+
cp13*Ln(StrToFloat(edit3.text))+cp14*Ln(StrToFloat(edit4.text))+ctp1;
MeP195.Caption:= IntTostr(Round(exp(lvazao1)));
MaP195.Caption:= IntTostr(Round(exp(lvazao1+ep1*c95)));
MiP195.Caption:= IntTostr(Round(exp(lvazao1-ep1*c95)));
MeP150.Caption:= IntTostr(Round(exp(lvazao1)));
MaP150.Caption:= IntTostr(Round(exp(lvazao1+c50*ep1)));
MiP150.Caption:= IntTostr(Round(exp(lvazao1-c50*ep1)));

lvazao2:= cp21*Ln(StrToFloat(edit2.text))+ cp22*Ln(StrToFloat(edit3.text))+
cp23*Ln(StrToFloat(edit4.text))+cp24*lvazao1+ctp2;
MeP295.Caption:= IntTostr(Round(exp(lvazao2)));
MaP295.Caption:= IntTostr(Round(exp(lvazao2+ep2*c95)));
MiP295.Caption:= IntTostr(Round(exp(lvazao2-ep2*c95)));
MeP250.Caption:= IntTostr(Round(exp(lvazao2)));
MaP250.Caption:= IntTostr(Round(exp(lvazao2+c50*ep2)));
MiP250.Caption:= IntTostr(Round(exp(lvazao2-c50*ep2)));

lvazao3:= cp31*Ln(StrToFloat(edit3.text))+ cp32*Ln(StrToFloat(edit4.text))+
cp33*lvazao1+cp34*lvazao2+ctp3;
MeP395.Caption:= IntTostr(Round(exp(lvazao3)));
MaP395.Caption:= IntTostr(Round(exp(lvazao3+ep3*c95)));
MiP395.Caption:= IntTostr(Round(exp(lvazao3-ep3*c95)));
MeP350.Caption:= IntTostr(Round(exp(lvazao3)));
MaP350.Caption:= IntTostr(Round(exp(lvazao3+c50*ep3)));
MiP350.Caption:= IntTostr(Round(exp(lvazao3-c50*ep3)));


 lvazao4:= cp41*Ln(StrToFloat(edit4.text))+ cp42*lvazao1+
cp43*lvazao2+cp44*lvazao3+ctp4;
MeP495.Caption:= IntTostr(Round(exp(lvazao4)));
MaP495.Caption:= IntTostr(Round(exp(lvazao4+ep4*c95)));
MiP495.Caption:= IntTostr(Round(exp(lvazao4-ep4*c95)));
MeP450.Caption:= IntTostr(Round(exp(lvazao4)));
MaP450.Caption:= IntTostr(Round(exp(lvazao4+c50*ep4)));
MiP450.Caption:= IntTostr(Round(exp(lvazao4-c50*ep4)));

   lvazao5:= cp51*lvazao1+ cp52*lvazao2+
cp53*lvazao3+cp54*lvazao4+ctp5;
MeP595.Caption:= IntTostr(Round(exp(lvazao5)));
MaP595.Caption:= IntTostr(Round(exp(lvazao5+ep5*c95)));
MiP595.Caption:= IntTostr(Round(exp(lvazao5-ep5*c95)));
MeP550.Caption:= IntTostr(Round(exp(lvazao5)));
MaP550.Caption:= IntTostr(Round(exp(lvazao5+c50*ep5)));
MiP550.Caption:= IntTostr(Round(exp(lvazao5-c50*ep5)));

    lvazao6:= cp61*lvazao2+ cp62*lvazao3+
cp63*lvazao4+cp64*lvazao5+ctp6;
MeP695.Caption:= IntTostr(Round(exp(lvazao6)));
MaP695.Caption:= IntTostr(Round(exp(lvazao6+ep6*c95)));
MiP695.Caption:= IntTostr(Round(exp(lvazao6-ep6*c95)));
MeP650.Caption:= IntTostr(Round(exp(lvazao6)));
MaP650.Caption:= IntTostr(Round(exp(lvazao6+c50*ep6)));
MiP650.Caption:= IntTostr(Round(exp(lvazao6-c50*ep6)));



end;

procedure TMainForm.Button1Click(Sender: TObject);
  Const
 Semana1 = '24/12';
 Semana2 = '17/12';
 Semana3 = '10/12';
 Semana4 = '03/12';
 Semanap1 = '01/01';
 Semanap2 = '08/01';
 Semanap3 = '15/01';
 Semanap4 = '22/01';
 Semanap5 = '29/01';
 Semanap6 = '05/02';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c11;cp12:=c12;cp13:=c13;cp14:=c14;ctp1:=ct1;ep1:=e1;
 cp21:=c21;cp22:=c22;cp23:=c23;cp24:=c24;ctp2:=ct2;ep2:=e1;
 cp31:=c31;cp32:=c32;cp33:=c33;cp34:=c34;ctp3:=ct3;ep3:=e3;
 cp41:=c41;cp42:=c42;cp43:=c43;cp44:=c44;ctp4:=ct4;ep4:=e4;
 cp51:=c51;cp52:=c52;cp53:=c53;cp54:=c54;ctp5:=ct5;ep5:=e5;
 cp61:=c61;cp62:=c62;cp63:=c63;cp64:=c64;ctp6:=ct6;ep6:=e6;
end;
   procedure TMainForm.Button2Click(Sender: TObject);
  Const
 Semana1 = '01/01';
 Semana2 = '24/12';
 Semana3 = '17/12';
 Semana4 = '10/12';
 Semanap1 = '08/01';
 Semanap2 = '15/01';
 Semanap3 = '22/01';
 Semanap4 = '29/01';
 Semanap5 = '05/02';
 Semanap6 = '12/02';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c21;cp12:=c22;cp13:=c23;cp14:=c24;ctp1:=ct2;ep1:=e2;
 cp21:=c31;cp22:=c32;cp23:=c33;cp24:=c34;ctp2:=ct3;ep2:=e3;
 cp31:=c41;cp32:=c42;cp33:=c43;cp34:=c44;ctp3:=ct4;ep3:=e4;
 cp41:=c51;cp42:=c52;cp43:=c53;cp44:=c54;ctp4:=ct5;ep4:=e5;
 cp51:=c61;cp52:=c62;cp53:=c63;cp54:=c64;ctp5:=ct6;ep5:=e6;
 cp61:=c71;cp62:=c72;cp63:=c73;cp64:=c74;ctp6:=ct7;ep6:=e7;
end;

  procedure TMainForm.Button3Click(Sender: TObject);
  Const
 Semana1 = '08/01';
 Semana2 = '01/01';
 Semana3 = '24/12';
 Semana4 = '17/12';
 Semanap1 = '15/01';
 Semanap2 = '22/01';
 Semanap3 = '29/01';
 Semanap4 = '05/02';
 Semanap5 = '12/02';
 Semanap6 = '19/02';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c31;cp12:=c32;cp13:=c33;cp14:=c34;ctp1:=ct3;ep1:=e3;
 cp21:=c41;cp22:=c42;cp23:=c43;cp24:=c44;ctp2:=ct4;ep2:=e4;
 cp31:=c51;cp32:=c52;cp33:=c53;cp34:=c54;ctp3:=ct5;ep3:=e5;
 cp41:=c61;cp42:=c62;cp43:=c63;cp44:=c64;ctp4:=ct6;ep4:=e6;
 cp51:=c71;cp52:=c72;cp53:=c73;cp54:=c74;ctp5:=ct7;ep5:=e7;
 cp61:=c81;cp62:=c82;cp63:=c83;cp64:=c84;ctp6:=ct8;ep6:=e8;
end;

  procedure TMainForm.Button4Click(Sender: TObject);
  Const
 Semana1 = '15/01';
 Semana2 = '08/01';
 Semana3 = '01/01';
 Semana4 = '24/12';
 Semanap1 = '22/01';
 Semanap2 = '29/01';
 Semanap3 = '05/02';
 Semanap4 = '12/02';
 Semanap5 = '19/02';
 Semanap6 = '26/02';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c41;cp12:=c42;cp13:=c43;cp14:=c44;ctp1:=ct4;ep1:=e4;
 cp21:=c51;cp22:=c52;cp23:=c53;cp24:=c54;ctp2:=ct5;ep2:=e5;
 cp31:=c61;cp32:=c62;cp33:=c63;cp34:=c64;ctp3:=ct6;ep3:=e6;
 cp41:=c71;cp42:=c72;cp43:=c73;cp44:=c74;ctp4:=ct7;ep4:=e7;
 cp51:=c81;cp52:=c82;cp53:=c83;cp54:=c84;ctp5:=ct8;ep5:=e8;
 cp61:=c91;cp62:=c92;cp63:=c93;cp64:=c94;ctp6:=ct9;ep6:=e9;
end;

  procedure TMainForm.Button5Click(Sender: TObject);
  Const
 Semana1 = '22/01';
 Semana2 = '15/01';
 Semana3 = '08/01';
 Semana4 = '01/01';
 Semanap1 = '29/01';
 Semanap2 = '05/02';
 Semanap3 = '12/02';
 Semanap4 = '19/02';
 Semanap5 = '26/02';
 Semanap6 = '05/03';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c51;cp12:=c52;cp13:=c53;cp14:=c54;ctp1:=ct5;ep1:=e5;
 cp21:=c61;cp22:=c62;cp23:=c63;cp24:=c64;ctp2:=ct6;ep2:=e6;
 cp31:=c71;cp32:=c72;cp33:=c73;cp34:=c74;ctp3:=ct7;ep3:=e7;
 cp41:=c81;cp42:=c82;cp43:=c83;cp44:=c84;ctp4:=ct8;ep4:=e8;
 cp51:=c91;cp52:=c92;cp53:=c93;cp54:=c94;ctp5:=ct9;ep5:=e9;
 cp61:=c101;cp62:=c102;cp63:=c103;cp64:=c104;ctp6:=ct10;ep6:=e10;
end;

  procedure TMainForm.Button6Click(Sender: TObject);
  Const
 Semana1 = '29/01';
 Semana2 = '22/01';
 Semana3 = '15/01';
 Semana4 = '08/01';
 Semanap1 = '05/02';
 Semanap2 = '12/02';
 Semanap3 = '19/02';
 Semanap4 = '26/02';
 Semanap5 = '05/03';
 Semanap6 = '12/03';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c61;cp12:=c62;cp13:=c63;cp14:=c64;ctp1:=ct6;ep1:=e6;
 cp21:=c71;cp22:=c72;cp23:=c73;cp24:=c74;ctp2:=ct7;ep2:=e7;
 cp31:=c81;cp32:=c82;cp33:=c83;cp34:=c84;ctp3:=ct8;ep3:=e8;
 cp41:=c91;cp42:=c92;cp43:=c93;cp44:=c94;ctp4:=ct9;ep4:=e9;
 cp51:=c101;cp52:=c102;cp53:=c103;cp54:=c104;ctp5:=ct10;ep5:=e10;
 cp61:=c111;cp62:=c112;cp63:=c113;cp64:=c114;ctp6:=ct11;ep6:=e11;
 end;


   procedure TMainForm.Button7Click(Sender: TObject);
  Const
 Semana1 = '05/02';
 Semana2 = '29/01';
 Semana3 = '22/01';
 Semana4 = '15/01';
 Semanap1 = '12/02';
 Semanap2 = '19/02';
 Semanap3 = '26/02';
 Semanap4 = '05/02';
 Semanap5 = '12/03';
 Semanap6 = '19/03';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c71;cp12:=c72;cp13:=c73;cp14:=c74;ctp1:=ct7;ep1:=e7;
 cp21:=c81;cp22:=c82;cp23:=c83;cp24:=c84;ctp2:=ct8;ep2:=e8;
 cp31:=c91;cp32:=c92;cp33:=c93;cp34:=c94;ctp3:=ct9;ep3:=e9;
 cp41:=c101;cp42:=c102;cp43:=c103;cp44:=c104;ctp4:=ct10;ep4:=e10;
 cp51:=c111;cp52:=c112;cp53:=c113;cp54:=c114;ctp5:=ct11;ep5:=e11;
 cp61:=c121;cp62:=c122;cp63:=c123;cp64:=c124;ctp6:=ct12;ep6:=e12;
 end;


  procedure TMainForm.Button8Click(Sender: TObject);
  Const
 Semana1 = '12/02';
 Semana2 = '05/02';
 Semana3 = '29/01';
 Semana4 = '22/01';
 Semanap1 = '19/02';
 Semanap2 = '26/02';
 Semanap3 = '05/03';
 Semanap4 = '12/03';
 Semanap5 = '19/03';
 Semanap6 = '26/03';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c81;cp12:=c82;cp13:=c83;cp14:=c84;ctp1:=ct8;ep1:=e8;
 cp21:=c91;cp22:=c92;cp23:=c93;cp24:=c94;ctp2:=ct9;ep2:=e9;
 cp31:=c101;cp32:=c102;cp33:=c103;cp34:=c104;ctp3:=ct10;ep3:=e10;
 cp41:=c111;cp42:=c112;cp43:=c113;cp44:=c114;ctp4:=ct11;ep4:=e11;
 cp51:=c121;cp52:=c122;cp53:=c123;cp54:=c124;ctp5:=ct12;ep5:=e12;
 cp61:=c131;cp62:=c132;cp63:=c133;cp64:=c134;ctp6:=ct13;ep6:=e13;
 end;

  procedure TMainForm.Button9Click(Sender: TObject);
  Const
 Semana1 = '19/02';
 Semana2 = '12/02';
 Semana3 = '05/02';
 Semana4 = '05/02';
 Semanap1 = '26/02';
 Semanap2 = '05/03';
 Semanap3 = '12/03';
 Semanap4 = '19/03';
 Semanap5 = '26/03';
 Semanap6 = '02/04';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c91;cp12:=c92;cp13:=c93;cp14:=c94;ctp1:=ct9;ep1:=e9;
 cp21:=c101;cp22:=c102;cp23:=c103;cp24:=c104;ctp2:=ct10;ep2:=e10;
 cp31:=c111;cp32:=c112;cp33:=c113;cp34:=c114;ctp3:=ct11;ep3:=e11;
 cp41:=c121;cp42:=c122;cp43:=c123;cp44:=c124;ctp4:=ct12;ep4:=e12;
 cp51:=c131;cp52:=c132;cp53:=c133;cp54:=c134;ctp5:=ct13;ep5:=e13;
 cp61:=c141;cp62:=c142;cp63:=c143;cp64:=c144;ctp6:=ct14;ep6:=e14;
 end;

   procedure TMainForm.Button10Click(Sender: TObject);
  Const
 Semana1 = '26/02';
 Semana2 = '19/02';
 Semana3 = '12/02';
 Semana4 = '05/02';
 Semanap1 = '05/03';
 Semanap2 = '12/03';
 Semanap3 = '19/03';
 Semanap4 = '26/03';
 Semanap5 = '02/04';
 Semanap6 = '09/04';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c101;cp12:=c102;cp13:=c103;cp14:=c104;ctp1:=ct10;ep1:=e10;
 cp21:=c111;cp22:=c112;cp23:=c113;cp24:=c114;ctp2:=ct11;ep2:=e11;
 cp31:=c121;cp32:=c122;cp33:=c123;cp34:=c124;ctp3:=ct12;ep3:=e12;
 cp41:=c131;cp42:=c132;cp43:=c133;cp44:=c134;ctp4:=ct13;ep4:=e13;
 cp51:=c141;cp52:=c142;cp53:=c143;cp54:=c144;ctp5:=ct14;ep5:=e14;
 cp61:=c151;cp62:=c152;cp63:=c153;cp64:=c154;ctp6:=ct15;ep6:=e15;
 end;

  procedure TMainForm.Button11Click(Sender: TObject);
  Const
 Semana1 = '05/03';
 Semana2 = '26/02';
 Semana3 = '19/02';
 Semana4 = '12/02';
 Semanap1 = '12/03';
 Semanap2 = '19/03';
 Semanap3 = '26/03';
 Semanap4 = '02/04';
 Semanap5 = '09/04';
 Semanap6 = '16/04';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c111;cp12:=c112;cp13:=c113;cp14:=c114;ctp1:=ct11;ep1:=e11;
 cp21:=c121;cp22:=c122;cp23:=c123;cp24:=c124;ctp2:=ct12;ep2:=e12;
 cp31:=c131;cp32:=c132;cp33:=c133;cp34:=c134;ctp3:=ct13;ep3:=e13;
 cp41:=c141;cp42:=c142;cp43:=c143;cp44:=c144;ctp4:=ct14;ep4:=e14;
 cp51:=c151;cp52:=c152;cp53:=c153;cp54:=c154;ctp5:=ct15;ep5:=e15;
 cp61:=c161;cp62:=c162;cp63:=c163;cp64:=c164;ctp6:=ct16;ep6:=e16;
 end;

 procedure TMainForm.Button12Click(Sender: TObject);
  Const
 Semana1 = '12/03';
 Semana2 = '05/03';
 Semana3 = '26/02';
 Semana4 = '19/02';
 Semanap1 = '19/03';
 Semanap2 = '26/03';
 Semanap3 = '02/04';
 Semanap4 = '09/04';
 Semanap5 = '16/04';
 Semanap6 = '23/04';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c121;cp12:=c122;cp13:=c123;cp14:=c124;ctp1:=ct12;ep1:=e12;
 cp21:=c131;cp22:=c132;cp23:=c133;cp24:=c134;ctp2:=ct13;ep2:=e13;
 cp31:=c141;cp32:=c142;cp33:=c143;cp34:=c144;ctp3:=ct14;ep3:=e14;
 cp41:=c151;cp42:=c152;cp43:=c153;cp44:=c154;ctp4:=ct15;ep4:=e15;
 cp51:=c161;cp52:=c162;cp53:=c163;cp54:=c164;ctp5:=ct16;ep5:=e16;
 cp61:=c171;cp62:=c172;cp63:=c173;cp64:=c174;ctp6:=ct17;ep6:=e17;
  end;

  procedure TMainForm.Button13Click(Sender: TObject);
  Const
 Semana1 = '19/03';
 Semana2 = '12/03';
 Semana3 = '05/02';
 Semana4 = '26/02';
 Semanap1 = '26/03';
 Semanap2 = '02/04';
 Semanap3 = '09/04';
 Semanap4 = '16/04';
 Semanap5 = '23/04';
 Semanap6 = '30/04';

 begin

 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c131;cp12:=c132;cp13:=c133;cp14:=c134;ctp1:=ct13;ep1:=e13;
 cp21:=c141;cp22:=c142;cp23:=c143;cp24:=c144;ctp2:=ct14;ep2:=e14;
 cp31:=c151;cp32:=c152;cp33:=c153;cp34:=c154;ctp3:=ct15;ep3:=e15;
 cp41:=c161;cp42:=c162;cp43:=c163;cp44:=c164;ctp4:=ct16;ep4:=e16;
 cp51:=c171;cp52:=c172;cp53:=c173;cp54:=c174;ctp5:=ct17;ep5:=e17;
 cp61:=c181;cp62:=c182;cp63:=c183;cp64:=c184;ctp6:=ct18;ep6:=e18;
 end;

 procedure TMainForm.Button14Click(Sender: TObject);
 Const
 Semana1 = '26/03';
 Semana2 = '19/03';
 Semana3 = '12/03';
 Semana4 = '05/03';
 Semanap1 = '02/04';
 Semanap2 = '09/04';
 Semanap3 = '16/04';
 Semanap4 = '23/04';
 Semanap5 = '30/04';
 Semanap6 = '07/05';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c141;cp12:=c142;cp13:=c143;cp14:=c144;ctp1:=ct14;ep1:=e14;
 cp21:=c151;cp22:=c152;cp23:=c153;cp24:=c154;ctp2:=ct15;ep2:=e15;
 cp31:=c161;cp32:=c162;cp33:=c163;cp34:=c164;ctp3:=ct16;ep3:=e16;
 cp41:=c171;cp42:=c172;cp43:=c173;cp44:=c174;ctp4:=ct17;ep4:=e17;
 cp51:=c181;cp52:=c182;cp53:=c183;cp54:=c184;ctp5:=ct18;ep5:=e18;
 cp61:=c191;cp62:=c192;cp63:=c193;cp64:=c194;ctp6:=ct19;ep6:=e19;

 end;


 procedure TMainForm.Button15Click(Sender: TObject);
 Const
 Semana1 = '02/04';
 Semana2 = '26/03';
 Semana3 = '19/03';
 Semana4 = '12/03';
 Semanap1 = '09/03';
 Semanap2 = '16/04';
 Semanap3 = '23/04';
 Semanap4 = '30/04';
 Semanap5 = '07/04';
 Semanap6 = '14/05';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c151;cp12:=c152;cp13:=c153;cp14:=c154;ctp1:=ct15;ep1:=e15;
 cp21:=c161;cp22:=c162;cp23:=c163;cp24:=c164;ctp2:=ct16;ep2:=e16;
 cp31:=c171;cp32:=c172;cp33:=c173;cp34:=c174;ctp3:=ct17;ep3:=e17;
 cp41:=c181;cp42:=c182;cp43:=c183;cp44:=c184;ctp4:=ct18;ep4:=e18;
 cp51:=c191;cp52:=c192;cp53:=c193;cp54:=c194;ctp5:=ct19;ep5:=e19;
 cp61:=c201;cp62:=c202;cp63:=c203;cp64:=c204;ctp6:=ct20;ep6:=e20;
  end;


 procedure TMainForm.Button16Click(Sender: TObject);
 Const
 Semana1 = '09/04';
 Semana2 = '02/04';
 Semana3 = '26/03';
 Semana4 = '19/03';
 Semanap1 = '16/04';
 Semanap2 = '23/04';
 Semanap3 = '30/04';
 Semanap4 = '07/05';
 Semanap5 = '14/05';
 Semanap6 = '21/05';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c161;cp12:=c162;cp13:=c163;cp14:=c164;ctp1:=ct16;ep1:=e16;
 cp21:=c171;cp22:=c172;cp23:=c173;cp24:=c174;ctp2:=ct17;ep2:=e17;
 cp31:=c181;cp32:=c182;cp33:=c183;cp34:=c184;ctp3:=ct18;ep3:=e18;
 cp41:=c191;cp42:=c192;cp43:=c193;cp44:=c194;ctp4:=ct19;ep4:=e19;
 cp51:=c201;cp52:=c202;cp53:=c203;cp54:=c204;ctp5:=ct20;ep5:=e20;
 cp61:=c211;cp62:=c212;cp63:=c213;cp64:=c214;ctp6:=ct21;ep6:=e21;
  end;

 procedure TMainForm.Button17Click(Sender: TObject);
 Const
 Semana1 = '16/04';
 Semana2 = '09/04';
 Semana3 = '02/04';
 Semana4 = '26/03';
 Semanap1 = '23/04';
 Semanap2 = '30/04';
 Semanap3 = '07/05';
 Semanap4 = '14/05';
 Semanap5 = '21/05';
 Semanap6 = '28/05';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c171;cp12:=c172;cp13:=c173;cp14:=c174;ctp1:=ct17;ep1:=e17;
 cp21:=c181;cp22:=c182;cp23:=c183;cp24:=c184;ctp2:=ct18;ep2:=e18;
 cp31:=c191;cp32:=c192;cp33:=c193;cp34:=c194;ctp3:=ct19;ep3:=e19;
 cp41:=c201;cp42:=c202;cp43:=c203;cp44:=c204;ctp4:=ct20;ep4:=e20;
 cp51:=c211;cp52:=c212;cp53:=c213;cp54:=c214;ctp5:=ct21;ep5:=e21;
 cp61:=c221;cp62:=c222;cp63:=c223;cp64:=c224;ctp6:=ct22;ep6:=e22;
  end;

   procedure TMainForm.Button18Click(Sender: TObject);
 Const
 Semana1 = '23/04';
 Semana2 = '16/04';
 Semana3 = '09/04';
 Semana4 = '02/04';
 Semanap1 = '30/04';
 Semanap2 = '07/05';
 Semanap3 = '14/05';
 Semanap4 = '21/05';
 Semanap5 = '28/05';
 Semanap6 = '04/06';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c181;cp12:=c182;cp13:=c183;cp14:=c184;ctp1:=ct18;ep1:=e18;
 cp21:=c191;cp22:=c192;cp23:=c193;cp24:=c194;ctp2:=ct19;ep2:=e19;
 cp31:=c201;cp32:=c202;cp33:=c203;cp34:=c204;ctp3:=ct20;ep3:=e20;
 cp41:=c211;cp42:=c212;cp43:=c213;cp44:=c214;ctp4:=ct21;ep4:=e21;
 cp51:=c221;cp52:=c222;cp53:=c223;cp54:=c224;ctp5:=ct22;ep5:=e22;
 cp61:=c231;cp62:=c232;cp63:=c233;cp64:=c234;ctp6:=ct23;ep6:=e23;
  end;

    procedure TMainForm.Button19Click(Sender: TObject);
 Const
 Semana1 = '30/04';
 Semana2 = '23/04';
 Semana3 = '16/04';
 Semana4 = '09/04';
 Semanap1 = '07/05';
 Semanap2 = '14/05';
 Semanap3 = '21/05';
 Semanap4 = '28/05';
 Semanap5 = '04/06';
 Semanap6 = '11/06';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c191;cp12:=c192;cp13:=c193;cp14:=c194;ctp1:=ct19;ep1:=e19;
 cp21:=c201;cp22:=c202;cp23:=c203;cp24:=c204;ctp2:=ct20;ep2:=e20;
 cp31:=c211;cp32:=c212;cp33:=c213;cp34:=c214;ctp3:=ct21;ep3:=e21;
 cp41:=c221;cp42:=c222;cp43:=c223;cp44:=c224;ctp4:=ct22;ep4:=e22;
 cp51:=c231;cp52:=c232;cp53:=c233;cp54:=c234;ctp5:=ct23;ep5:=e23;
 cp61:=c241;cp62:=c242;cp63:=c243;cp64:=c244;ctp6:=ct24;ep6:=e24;
  end;

    procedure TMainForm.Button20Click(Sender: TObject);
 Const
 Semana1 = '07/05';
 Semana2 = '30/04';
 Semana3 = '23/04';
 Semana4 = '16/04';
 Semanap1 = '14/05';
 Semanap2 = '21/05';
 Semanap3 = '28/05';
 Semanap4 = '04/06';
 Semanap5 = '11/06';
 Semanap6 = '18/06';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c201;cp12:=c202;cp13:=c203;cp14:=c204;ctp1:=ct20;ep1:=e20;
 cp21:=c211;cp22:=c212;cp23:=c213;cp24:=c214;ctp2:=ct21;ep2:=e21;
 cp31:=c221;cp32:=c222;cp33:=c223;cp34:=c224;ctp3:=ct22;ep3:=e22;
 cp41:=c231;cp42:=c232;cp43:=c233;cp44:=c234;ctp4:=ct23;ep4:=e23;
 cp51:=c241;cp52:=c242;cp53:=c243;cp54:=c244;ctp5:=ct24;ep5:=e24;
 cp61:=c251;cp62:=c252;cp63:=c253;cp64:=c254;ctp6:=ct25;ep6:=e25;
  end;

    procedure TMainForm.Button21Click(Sender: TObject);
 Const
 Semana1 = '14/05';
 Semana2 = '07/05';
 Semana3 = '30/04';
 Semana4 = '23/04';
 Semanap1 = '21/05';
 Semanap2 = '28/05';
 Semanap3 = '04/06';
 Semanap4 = '11/06';
 Semanap5 = '18/06';
 Semanap6 = '25/06';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c211;cp12:=c212;cp13:=c213;cp14:=c214;ctp1:=ct21;ep1:=e21;
 cp21:=c221;cp22:=c222;cp23:=c223;cp24:=c224;ctp2:=ct22;ep2:=e22;
 cp31:=c231;cp32:=c232;cp33:=c233;cp34:=c234;ctp3:=ct23;ep3:=e23;
 cp41:=c241;cp42:=c242;cp43:=c243;cp44:=c244;ctp4:=ct24;ep4:=e24;
 cp51:=c251;cp52:=c252;cp53:=c253;cp54:=c254;ctp5:=ct25;ep5:=e25;
 cp61:=c261;cp62:=c262;cp63:=c263;cp64:=c264;ctp6:=ct26;ep6:=e26;
  end;

    procedure TMainForm.Button22Click(Sender: TObject);
 Const
 Semana1 = '21/05';
 Semana2 = '14/05';
 Semana3 = '07/05';
 Semana4 = '30/04';
 Semanap1 = '28/05';
 Semanap2 = '04/06';
 Semanap3 = '11/06';
 Semanap4 = '18/06';
 Semanap5 = '25/06';
 Semanap6 = '02/07';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c221;cp12:=c222;cp13:=c223;cp14:=c224;ctp1:=ct22;ep1:=e22;
 cp21:=c231;cp22:=c232;cp23:=c233;cp24:=c234;ctp2:=ct23;ep2:=e23;
 cp31:=c241;cp32:=c242;cp33:=c243;cp34:=c244;ctp3:=ct24;ep3:=e24;
 cp41:=c251;cp42:=c252;cp43:=c253;cp44:=c254;ctp4:=ct25;ep4:=e25;
 cp51:=c261;cp52:=c262;cp53:=c263;cp54:=c264;ctp5:=ct26;ep5:=e26;
 cp61:=c271;cp62:=c272;cp63:=c273;cp64:=c274;ctp6:=ct27;ep6:=e27;
  end;

      procedure TMainForm.Button23Click(Sender: TObject);
 Const
 Semana1 = '28/05';
 Semana2 = '21/05';
 Semana3 = '14/05';
 Semana4 = '07/05';
 Semanap1 = '04/06';
 Semanap2 = '11/06';
 Semanap3 = '18/06';
 Semanap4 = '25/06';
 Semanap5 = '02/07';
 Semanap6 = '09/07';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c231;cp12:=c232;cp13:=c233;cp14:=c234;ctp1:=ct23;ep1:=e23;
 cp21:=c241;cp22:=c242;cp23:=c243;cp24:=c244;ctp2:=ct24;ep2:=e24;
 cp31:=c251;cp32:=c252;cp33:=c253;cp34:=c254;ctp3:=ct25;ep3:=e25;
 cp41:=c261;cp42:=c262;cp43:=c263;cp44:=c264;ctp4:=ct26;ep4:=e26;
 cp51:=c271;cp52:=c272;cp53:=c273;cp54:=c274;ctp5:=ct27;ep5:=e27;
 cp61:=c281;cp62:=c282;cp63:=c283;cp64:=c284;ctp6:=ct28;ep6:=e28;
  end;
      procedure TMainForm.Button24Click(Sender: TObject);
 Const
 Semana1 = '04/06';
 Semana2 = '28/05';
 Semana3 = '21/05';
 Semana4 = '14/05';
 Semanap1 = '11/06';
 Semanap2 = '18/06';
 Semanap3 = '25/06';
 Semanap4 = '02/07';
 Semanap5 = '09/07';
 Semanap6 = '16/07';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c241;cp12:=c242;cp13:=c243;cp14:=c244;ctp1:=ct24;ep1:=e24;
 cp21:=c251;cp22:=c252;cp23:=c253;cp24:=c254;ctp2:=ct25;ep2:=e25;
 cp31:=c261;cp32:=c262;cp33:=c263;cp34:=c264;ctp3:=ct26;ep3:=e26;
 cp41:=c271;cp42:=c272;cp43:=c273;cp44:=c274;ctp4:=ct27;ep4:=e27;
 cp51:=c281;cp52:=c282;cp53:=c283;cp54:=c284;ctp5:=ct28;ep5:=e28;
 cp61:=c291;cp62:=c292;cp63:=c293;cp64:=c294;ctp6:=ct29;ep6:=e29;
  end;

        procedure TMainForm.Button25Click(Sender: TObject);
 Const
 Semana1 = '11/06';
 Semana2 = '04/06';
 Semana3 = '28/05';
 Semana4 = '21/05';
 Semanap1 = '18/06';
 Semanap2 = '25/06';
 Semanap3 = '02/07';
 Semanap4 = '09/07';
 Semanap5 = '16/07';
 Semanap6 = '23/07';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c251;cp12:=c252;cp13:=c253;cp14:=c254;ctp1:=ct25;ep1:=e25;
 cp21:=c261;cp22:=c262;cp23:=c263;cp24:=c264;ctp2:=ct26;ep2:=e26;
 cp31:=c271;cp32:=c272;cp33:=c273;cp34:=c274;ctp3:=ct27;ep3:=e27;
 cp41:=c281;cp42:=c282;cp43:=c283;cp44:=c284;ctp4:=ct28;ep4:=e28;
 cp51:=c291;cp52:=c292;cp53:=c293;cp54:=c294;ctp5:=ct29;ep5:=e29;
 cp61:=c301;cp62:=c302;cp63:=c303;cp64:=c304;ctp6:=ct30;ep6:=e30;
  end;

        procedure TMainForm.Button26Click(Sender: TObject);
 Const
 Semana1 = '18/06';
 Semana2 = '11/06';
 Semana3 = '04/06';
 Semana4 = '28/05';
 Semanap1 = '25/06';
 Semanap2 = '02/07';
 Semanap3 = '09/07';
 Semanap4 = '16/07';
 Semanap5 = '23/07';
 Semanap6 = '30/07';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c261;cp12:=c262;cp13:=c263;cp14:=c264;ctp1:=ct26;ep1:=e26;
 cp21:=c271;cp22:=c272;cp23:=c273;cp24:=c274;ctp2:=ct27;ep2:=e27;
 cp31:=c281;cp32:=c282;cp33:=c283;cp34:=c284;ctp3:=ct28;ep3:=e28;
 cp41:=c291;cp42:=c292;cp43:=c293;cp44:=c294;ctp4:=ct29;ep4:=e29;
 cp51:=c301;cp52:=c302;cp53:=c303;cp54:=c304;ctp5:=ct30;ep5:=e30;
 cp61:=c311;cp62:=c312;cp63:=c313;cp64:=c314;ctp6:=ct31;ep6:=e31;
  end;

        procedure TMainForm.Button27Click(Sender: TObject);
 Const
 Semana1 = '25/06';
 Semana2 = '18/06';
 Semana3 = '11/06';
 Semana4 = '04/06';
 Semanap1 = '02/07';
 Semanap2 = '09/07';
 Semanap3 = '16/07';
 Semanap4 = '23/07';
 Semanap5 = '30/07';
 Semanap6 = '06/08';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c271;cp12:=c272;cp13:=c273;cp14:=c274;ctp1:=ct27;ep1:=e27;
 cp21:=c281;cp22:=c282;cp23:=c283;cp24:=c284;ctp2:=ct28;ep2:=e28;
 cp31:=c291;cp32:=c292;cp33:=c293;cp34:=c294;ctp3:=ct29;ep3:=e29;
 cp41:=c301;cp42:=c302;cp43:=c303;cp44:=c304;ctp4:=ct30;ep4:=e30;
 cp51:=c311;cp52:=c312;cp53:=c313;cp54:=c314;ctp5:=ct31;ep5:=e31;
 cp61:=c321;cp62:=c322;cp63:=c323;cp64:=c324;ctp6:=ct32;ep6:=e32;
  end;

        procedure TMainForm.Button28Click(Sender: TObject);
 Const
 Semana1 = '02/07';
 Semana2 = '25/06';
 Semana3 = '18/06';
 Semana4 = '11/06';
 Semanap1 = '09/07';
 Semanap2 = '16/07';
 Semanap3 = '23/07';
 Semanap4 = '30/07';
 Semanap5 = '06/08';
 Semanap6 = '13/08';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c281;cp12:=c282;cp13:=c283;cp14:=c284;ctp1:=ct28;ep1:=e28;
 cp21:=c291;cp22:=c292;cp23:=c293;cp24:=c294;ctp2:=ct29;ep2:=e29;
 cp31:=c301;cp32:=c302;cp33:=c303;cp34:=c304;ctp3:=ct30;ep3:=e30;
 cp41:=c311;cp42:=c312;cp43:=c313;cp44:=c314;ctp4:=ct31;ep4:=e31;
 cp51:=c321;cp52:=c322;cp53:=c323;cp54:=c324;ctp5:=ct32;ep5:=e32;
 cp61:=c331;cp62:=c332;cp63:=c333;cp64:=c334;ctp6:=ct33;ep6:=e33;
  end;

        procedure TMainForm.Button29Click(Sender: TObject);
 Const
 Semana1 = '09/07';
 Semana2 = '02/07';
 Semana3 = '25/06';
 Semana4 = '18/06';
 Semanap1 = '16/07';
 Semanap2 = '23/07';
 Semanap3 = '30/07';
 Semanap4 = '06/08';
 Semanap5 = '13/08';
 Semanap6 = '20/08';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c291;cp12:=c292;cp13:=c293;cp14:=c294;ctp1:=ct29;ep1:=e29;
 cp21:=c301;cp22:=c302;cp23:=c303;cp24:=c304;ctp2:=ct30;ep2:=e30;
 cp31:=c311;cp32:=c312;cp33:=c313;cp34:=c314;ctp3:=ct31;ep3:=e31;
 cp41:=c321;cp42:=c322;cp43:=c323;cp44:=c324;ctp4:=ct32;ep4:=e32;
 cp51:=c331;cp52:=c332;cp53:=c333;cp54:=c334;ctp5:=ct33;ep5:=e33;
 cp61:=c341;cp62:=c342;cp63:=c343;cp64:=c344;ctp6:=ct34;ep6:=e34;
  end;

        procedure TMainForm.Button30Click(Sender: TObject);
 Const
 Semana1 = '16/07';
 Semana2 = '09/07';
 Semana3 = '02/07';
 Semana4 = '25/06';
 Semanap1 = '23/07';
 Semanap2 = '30/07';
 Semanap3 = '06/08';
 Semanap4 = '13/08';
 Semanap5 = '20/08';
 Semanap6 = '27/08';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c301;cp12:=c302;cp13:=c303;cp14:=c304;ctp1:=ct30;ep1:=e30;
 cp21:=c311;cp22:=c312;cp23:=c313;cp24:=c314;ctp2:=ct31;ep2:=e31;
 cp31:=c321;cp32:=c322;cp33:=c323;cp34:=c324;ctp3:=ct32;ep3:=e32;
 cp41:=c331;cp42:=c332;cp43:=c333;cp44:=c334;ctp4:=ct33;ep4:=e33;
 cp51:=c341;cp52:=c342;cp53:=c343;cp54:=c344;ctp5:=ct34;ep5:=e34;
 cp61:=c351;cp62:=c352;cp63:=c353;cp64:=c354;ctp6:=ct35;ep6:=e35;
  end;


 procedure TMainForm.Button31Click(Sender: TObject);
 Const
 Semana1 = '23/07';
 Semana2 = '16/07';
 Semana3 = '09/07';
 Semana4 = '02/07';
 Semanap1 = '30/07';
 Semanap2 = '06/08';
 Semanap3 = '13/08';
 Semanap4 = '20/08';
 Semanap5 = '27/08';
 Semanap6 = '03/09';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c311;cp12:=c312;cp13:=c313;cp14:=c314;ctp1:=ct31;ep1:=e31;
 cp21:=c321;cp22:=c322;cp23:=c323;cp24:=c324;ctp2:=ct32;ep2:=e32;
 cp31:=c331;cp32:=c332;cp33:=c333;cp34:=c334;ctp3:=ct33;ep3:=e33;
 cp41:=c341;cp42:=c342;cp43:=c343;cp44:=c344;ctp4:=ct34;ep4:=e34;
 cp51:=c351;cp52:=c352;cp53:=c353;cp54:=c354;ctp5:=ct35;ep5:=e35;
 cp61:=c361;cp62:=c362;cp63:=c363;cp64:=c364;ctp6:=ct36;ep6:=e36;
  end;
 procedure TMainForm.Button32Click(Sender: TObject);
 Const
 Semana1 = '30/07';
 Semana2 = '23/07';
 Semana3 = '16/07';
 Semana4 = '09/07';
 Semanap1 = '06/08';
 Semanap2 = '13/08';
 Semanap3 = '20/08';
 Semanap4 = '27/08';
 Semanap5 = '03/09';
 Semanap6 = '10/09';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c321;cp12:=c322;cp13:=c323;cp14:=c324;ctp1:=ct32;ep1:=e32;
 cp21:=c331;cp22:=c332;cp23:=c333;cp24:=c334;ctp2:=ct33;ep2:=e33;
 cp31:=c341;cp32:=c342;cp33:=c343;cp34:=c344;ctp3:=ct34;ep3:=e34;
 cp41:=c351;cp42:=c352;cp43:=c353;cp44:=c354;ctp4:=ct35;ep4:=e35;
 cp51:=c361;cp52:=c362;cp53:=c363;cp54:=c364;ctp5:=ct36;ep5:=e36;
 cp61:=c371;cp62:=c372;cp63:=c373;cp64:=c374;ctp6:=ct37;ep6:=e37;
  end;

 procedure TMainForm.Button33Click(Sender: TObject);
 Const
 Semana1 = '06/08';
 Semana2 = '30/07';
 Semana3 = '23/07';
 Semana4 = '16/07';
 Semanap1 = '13/08';
 Semanap2 = '20/08';
 Semanap3 = '27/08';
 Semanap4 = '03/09';
 Semanap5 = '10/09';
 Semanap6 = '17/09';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c331;cp12:=c332;cp13:=c333;cp14:=c334;ctp1:=ct33;ep1:=e33;
 cp21:=c341;cp22:=c342;cp23:=c343;cp24:=c344;ctp2:=ct34;ep2:=e34;
 cp31:=c351;cp32:=c352;cp33:=c353;cp34:=c354;ctp3:=ct35;ep3:=e35;
 cp41:=c361;cp42:=c362;cp43:=c363;cp44:=c364;ctp4:=ct36;ep4:=e36;
 cp51:=c371;cp52:=c372;cp53:=c373;cp54:=c374;ctp5:=ct37;ep5:=e37;
 cp61:=c381;cp62:=c382;cp63:=c383;cp64:=c384;ctp6:=ct38;ep6:=e38;
  end;

 procedure TMainForm.Button34Click(Sender: TObject);
 Const
 Semana1 = '13/08';
 Semana2 = '06/08';
 Semana3 = '30/07';
 Semana4 = '23/07';
 Semanap1 = '20/08';
 Semanap2 = '27/08';
 Semanap3 = '03/09';
 Semanap4 = '10/09';
 Semanap5 = '17/09';
 Semanap6 = '24/09';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c341;cp12:=c342;cp13:=c343;cp14:=c344;ctp1:=ct34;ep1:=e34;
 cp21:=c351;cp22:=c352;cp23:=c353;cp24:=c354;ctp2:=ct35;ep2:=e35;
 cp31:=c361;cp32:=c362;cp33:=c363;cp34:=c364;ctp3:=ct36;ep3:=e36;
 cp41:=c371;cp42:=c372;cp43:=c373;cp44:=c374;ctp4:=ct37;ep4:=e37;
 cp51:=c381;cp52:=c382;cp53:=c383;cp54:=c384;ctp5:=ct38;ep5:=e38;
 cp61:=c391;cp62:=c392;cp63:=c393;cp64:=c394;ctp6:=ct39;ep6:=e39;
  end;


 procedure TMainForm.Button35Click(Sender: TObject);
 Const
 Semana1 = '20/08';
 Semana2 = '13/08';
 Semana3 = '06/08';
 Semana4 = '30/07';
 Semanap1 = '27/08';
 Semanap2 = '03/09';
 Semanap3 = '10/09';
 Semanap4 = '17/09';
 Semanap5 = '24/09';
 Semanap6 = '01/10';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c351;cp12:=c352;cp13:=c353;cp14:=c354;ctp1:=ct35;ep1:=e35;
 cp21:=c361;cp22:=c362;cp23:=c363;cp24:=c364;ctp2:=ct36;ep2:=e36;
 cp31:=c371;cp32:=c372;cp33:=c373;cp34:=c374;ctp3:=ct37;ep3:=e37;
 cp41:=c381;cp42:=c382;cp43:=c383;cp44:=c384;ctp4:=ct38;ep4:=e38;
 cp51:=c391;cp52:=c392;cp53:=c393;cp54:=c394;ctp5:=ct39;ep5:=e39;
 cp61:=c401;cp62:=c402;cp63:=c403;cp64:=c404;ctp6:=ct40;ep6:=e40;
  end;

  procedure TMainForm.Button36Click(Sender: TObject);
 Const
 Semana1 = '27/08';
 Semana2 = '20/08';
 Semana3 = '13/08';
 Semana4 = '06/08';
 Semanap1 = '03/09';
 Semanap2 = '10/09';
 Semanap3 = '17/09';
 Semanap4 = '24/09';
 Semanap5 = '01/10';
 Semanap6 = '08/10';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c361;cp12:=c362;cp13:=c363;cp14:=c364;ctp1:=ct36;ep1:=e36;
 cp21:=c371;cp22:=c372;cp23:=c373;cp24:=c374;ctp2:=ct37;ep2:=e37;
 cp31:=c381;cp32:=c382;cp33:=c383;cp34:=c384;ctp3:=ct38;ep3:=e38;
 cp41:=c391;cp42:=c392;cp43:=c393;cp44:=c394;ctp4:=ct39;ep4:=e39;
 cp51:=c401;cp52:=c402;cp53:=c403;cp54:=c404;ctp5:=ct40;ep5:=e40;
 cp61:=c411;cp62:=c412;cp63:=c413;cp64:=c414;ctp6:=ct41;ep6:=e41;
  end;
  procedure TMainForm.Button37Click(Sender: TObject);
 Const
 Semana1 = '03/09';
 Semana2 = '27/08';
 Semana3 = '20/08';
 Semana4 = '13/08';
 Semanap1 = '10/09';
 Semanap2 = '17/09';
 Semanap3 = '24/09';
 Semanap4 = '01/10';
 Semanap5 = '08/10';
 Semanap6 = '15/10';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c371;cp12:=c372;cp13:=c373;cp14:=c374;ctp1:=ct37;ep1:=e37;
 cp21:=c381;cp22:=c382;cp23:=c383;cp24:=c384;ctp2:=ct38;ep2:=e38;
 cp31:=c391;cp32:=c392;cp33:=c393;cp34:=c394;ctp3:=ct39;ep3:=e39;
 cp41:=c401;cp42:=c402;cp43:=c403;cp44:=c404;ctp4:=ct40;ep4:=e40;
 cp51:=c411;cp52:=c412;cp53:=c413;cp54:=c414;ctp5:=ct41;ep5:=e41;
 cp61:=c421;cp62:=c422;cp63:=c423;cp64:=c424;ctp6:=ct42;ep6:=e42;
  end;

  procedure TMainForm.Button38Click(Sender: TObject);
 Const
 Semana1 = '10/09';
 Semana2 = '03/09';
 Semana3 = '27/08';
 Semana4 = '20/08';
 Semanap1 = '17/09';
 Semanap2 = '24/09';
 Semanap3 = '01/10';
 Semanap4 = '08/10';
 Semanap5 = '15/10';
 Semanap6 = '22/10';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c381;cp12:=c382;cp13:=c383;cp14:=c384;ctp1:=ct38;ep1:=e38;
 cp21:=c391;cp22:=c392;cp23:=c393;cp24:=c394;ctp2:=ct39;ep2:=e39;
 cp31:=c401;cp32:=c402;cp33:=c403;cp34:=c404;ctp3:=ct40;ep3:=e40;
 cp41:=c411;cp42:=c412;cp43:=c413;cp44:=c414;ctp4:=ct41;ep4:=e41;
 cp51:=c421;cp52:=c422;cp53:=c423;cp54:=c424;ctp5:=ct42;ep5:=e42;
 cp61:=c431;cp62:=c432;cp63:=c433;cp64:=c434;ctp6:=ct43;ep6:=e43;
  end;

  procedure TMainForm.Button39Click(Sender: TObject);
 Const
 Semana1 = '17/09';
 Semana2 = '10/09';
 Semana3 = '03/09';
 Semana4 = '27/08';
 Semanap1 = '24/09';
 Semanap2 = '01/10';
 Semanap3 = '08/10';
 Semanap4 = '15/10';
 Semanap5 = '22/10';
 Semanap6 = '29/10';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c391;cp12:=c392;cp13:=c393;cp14:=c394;ctp1:=ct39;ep1:=e39;
 cp21:=c401;cp22:=c402;cp23:=c403;cp24:=c404;ctp2:=ct40;ep2:=e40;
 cp31:=c411;cp32:=c412;cp33:=c413;cp34:=c414;ctp3:=ct41;ep3:=e41;
 cp41:=c421;cp42:=c422;cp43:=c423;cp44:=c424;ctp4:=ct42;ep4:=e42;
 cp51:=c431;cp52:=c432;cp53:=c433;cp54:=c434;ctp5:=ct43;ep5:=e43;
 cp61:=c441;cp62:=c442;cp63:=c443;cp64:=c444;ctp6:=ct44;ep6:=e44;
  end;
   procedure TMainForm.Button40Click(Sender: TObject);
 Const
 Semana1 = '24/09';
 Semana2 = '17/09';
 Semana3 = '10/09';
 Semana4 = '03/09';
 Semanap1 = '01/10';
 Semanap2 = '08/10';
 Semanap3 = '15/10';
 Semanap4 = '22/10';
 Semanap5 = '29/10';
 Semanap6 = '05/11';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c401;cp12:=c402;cp13:=c403;cp14:=c404;ctp1:=ct40;ep1:=e40;
 cp21:=c411;cp22:=c412;cp23:=c413;cp24:=c414;ctp2:=ct41;ep2:=e41;
 cp31:=c421;cp32:=c422;cp33:=c423;cp34:=c424;ctp3:=ct42;ep3:=e42;
 cp41:=c431;cp42:=c432;cp43:=c433;cp44:=c434;ctp4:=ct43;ep4:=e43;
 cp51:=c441;cp52:=c442;cp53:=c443;cp54:=c444;ctp5:=ct44;ep5:=e44;
 cp61:=c451;cp62:=c452;cp63:=c453;cp64:=c454;ctp6:=ct45;ep6:=e45;
  end;
    procedure TMainForm.Button41Click(Sender: TObject);
 Const
 Semana1 = '01/10';
 Semana2 = '24/09';
 Semana3 = '17/09';
 Semana4 = '10/09';
 Semanap1 = '08/10';
 Semanap2 = '15/10';
 Semanap3 = '22/10';
 Semanap4 = '29/10';
 Semanap5 = '05/11';
 Semanap6 = '12/11';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c411;cp12:=c412;cp13:=c413;cp14:=c414;ctp1:=ct41;ep1:=e41;
 cp21:=c421;cp22:=c422;cp23:=c423;cp24:=c424;ctp2:=ct42;ep2:=e42;
 cp31:=c431;cp32:=c432;cp33:=c433;cp34:=c434;ctp3:=ct43;ep3:=e43;
 cp41:=c441;cp42:=c442;cp43:=c443;cp44:=c444;ctp4:=ct44;ep4:=e44;
 cp51:=c451;cp52:=c452;cp53:=c453;cp54:=c454;ctp5:=ct45;ep5:=e45;
 cp61:=c461;cp62:=c462;cp63:=c463;cp64:=c464;ctp6:=ct46;ep6:=e46;
  end;
     procedure TMainForm.Button42Click(Sender: TObject);
 Const
 Semana1 = '08/10';
 Semana2 = '01/10';
 Semana3 = '24/09';
 Semana4 = '17/09';
 Semanap1 = '15/10';
 Semanap2 = '22/10';
 Semanap3 = '29/10';
 Semanap4 = '05/11';
 Semanap5 = '12/11';
 Semanap6 = '19/11';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c421;cp12:=c422;cp13:=c423;cp14:=c424;ctp1:=ct42;ep1:=e42;
 cp21:=c431;cp22:=c432;cp23:=c433;cp24:=c434;ctp2:=ct43;ep2:=e43;
 cp31:=c441;cp32:=c442;cp33:=c443;cp34:=c444;ctp3:=ct44;ep3:=e44;
 cp41:=c451;cp42:=c452;cp43:=c453;cp44:=c454;ctp4:=ct45;ep4:=e45;
 cp51:=c461;cp52:=c462;cp53:=c463;cp54:=c464;ctp5:=ct46;ep5:=e46;
 cp61:=c471;cp62:=c472;cp63:=c473;cp64:=c474;ctp6:=ct47;ep6:=e47;
  end;

    procedure TMainForm.Button43Click(Sender: TObject);
 Const
 Semana1 = '15/10';
 Semana2 = '08/10';
 Semana3 = '01/10';
 Semana4 = '24/09';
 Semanap1 = '22/10';
 Semanap2 = '29/10';
 Semanap3 = '05/11';
 Semanap4 = '12/11';
 Semanap5 = '19/11';
 Semanap6 = '26/11';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c431;cp12:=c432;cp13:=c433;cp14:=c434;ctp1:=ct43;ep1:=e43;
 cp21:=c441;cp22:=c442;cp23:=c443;cp24:=c444;ctp2:=ct44;ep2:=e44;
 cp31:=c451;cp32:=c452;cp33:=c453;cp34:=c454;ctp3:=ct45;ep3:=e45;
 cp41:=c461;cp42:=c462;cp43:=c463;cp44:=c464;ctp4:=ct46;ep4:=e46;
 cp51:=c471;cp52:=c472;cp53:=c473;cp54:=c474;ctp5:=ct47;ep5:=e47;
 cp61:=c481;cp62:=c482;cp63:=c483;cp64:=c484;ctp6:=ct48;ep6:=e48;
  end;

     procedure TMainForm.Button44Click(Sender: TObject);
 Const
 Semana1 = '22/10';
 Semana2 = '15/10';
 Semana3 = '08/10';
 Semana4 = '01/10';
 Semanap1 = '29/10';
 Semanap2 = '05/11';
 Semanap3 = '12/11';
 Semanap4 = '19/11';
 Semanap5 = '26/11';
 Semanap6 = '03/12';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c441;cp12:=c442;cp13:=c443;cp14:=c444;ctp1:=ct44;ep1:=e44;
 cp21:=c451;cp22:=c452;cp23:=c453;cp24:=c454;ctp2:=ct45;ep2:=e45;
 cp31:=c461;cp32:=c462;cp33:=c463;cp34:=c464;ctp3:=ct46;ep3:=e46;
 cp41:=c471;cp42:=c472;cp43:=c473;cp44:=c474;ctp4:=ct47;ep4:=e47;
 cp51:=c481;cp52:=c482;cp53:=c483;cp54:=c484;ctp5:=ct48;ep5:=e48;
 cp61:=c491;cp62:=c492;cp63:=c493;cp64:=c494;ctp6:=ct49;ep6:=e49;
  end;
     procedure TMainForm.Button45Click(Sender: TObject);
 Const
 Semana1 = '29/10';
 Semana2 = '22/10';
 Semana3 = '15/10';
 Semana4 = '08/10';
 Semanap1 = '05/11';
 Semanap2 = '12/11';
 Semanap3 = '19/11';
 Semanap4 = '26/11';
 Semanap5 = '03/12';
 Semanap6 = '10/12';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c451;cp12:=c452;cp13:=c453;cp14:=c454;ctp1:=ct45;ep1:=e45;
 cp21:=c461;cp22:=c462;cp23:=c463;cp24:=c464;ctp2:=ct46;ep2:=e46;
 cp31:=c471;cp32:=c472;cp33:=c473;cp34:=c474;ctp3:=ct47;ep3:=e47;
 cp41:=c481;cp42:=c482;cp43:=c483;cp44:=c484;ctp4:=ct48;ep4:=e48;
 cp51:=c491;cp52:=c492;cp53:=c493;cp54:=c494;ctp5:=ct49;ep5:=e49;
 cp61:=c501;cp62:=c502;cp63:=c503;cp64:=c504;ctp6:=ct50;ep6:=e50;
  end;
     procedure TMainForm.Button46Click(Sender: TObject);
 Const
 Semana1 = '05/11';
 Semana2 = '29/10';
 Semana3 = '22/10';
 Semana4 = '15/10';
 Semanap1 = '12/11';
 Semanap2 = '19/11';
 Semanap3 = '26/11';
 Semanap4 = '03/12';
 Semanap5 = '10/12';
 Semanap6 = '17/12';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c461;cp12:=c462;cp13:=c463;cp14:=c464;ctp1:=ct46;ep1:=e46;
 cp21:=c471;cp22:=c472;cp23:=c473;cp24:=c474;ctp2:=ct47;ep2:=e47;
 cp31:=c481;cp32:=c482;cp33:=c483;cp34:=c484;ctp3:=ct48;ep3:=e48;
 cp41:=c491;cp42:=c492;cp43:=c493;cp44:=c494;ctp4:=ct49;ep4:=e49;
 cp51:=c501;cp52:=c502;cp53:=c503;cp54:=c504;ctp5:=ct50;ep5:=e50;
 cp61:=c511;cp62:=c512;cp63:=c513;cp64:=c514;ctp6:=ct51;ep6:=e51;
  end;
     procedure TMainForm.Button47Click(Sender: TObject);
 Const
 Semana1 = '12/11';
 Semana2 = '05/11';
 Semana3 = '29/10';
 Semana4 = '22/10';
 Semanap1 = '19/11';
 Semanap2 = '26/11';
 Semanap3 = '03/12';
 Semanap4 = '10/12';
 Semanap5 = '17/12';
 Semanap6 = '24/12';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c471;cp12:=c472;cp13:=c473;cp14:=c474;ctp1:=ct47;ep1:=e47;
 cp21:=c481;cp22:=c482;cp23:=c483;cp24:=c484;ctp2:=ct48;ep2:=e48;
 cp31:=c491;cp32:=c492;cp33:=c493;cp34:=c494;ctp3:=ct49;ep3:=e49;
 cp41:=c501;cp42:=c502;cp43:=c503;cp44:=c504;ctp4:=ct50;ep4:=e50;
 cp51:=c511;cp52:=c512;cp53:=c513;cp54:=c514;ctp5:=ct51;ep5:=e51;
 cp61:=c521;cp62:=c522;cp63:=c523;cp64:=c524;ctp6:=ct52;ep6:=e52;
  end;
     procedure TMainForm.Button48Click(Sender: TObject);
 Const
 Semana1 = '19/11';
 Semana2 = '12/11';
 Semana3 = '05/11';
 Semana4 = '29/10';
 Semanap1 = '26/11';
 Semanap2 = '03/12';
 Semanap3 = '10/12';
 Semanap4 = '17/12';
 Semanap5 = '24/12';
 Semanap6 = '01/01';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c481;cp12:=c482;cp13:=c483;cp14:=c484;ctp1:=ct48;ep1:=e48;
 cp21:=c491;cp22:=c492;cp23:=c493;cp24:=c494;ctp2:=ct49;ep2:=e49;
 cp31:=c501;cp32:=c502;cp33:=c503;cp34:=c504;ctp3:=ct50;ep3:=e50;
 cp41:=c511;cp42:=c512;cp43:=c513;cp44:=c514;ctp4:=ct51;ep4:=e51;
 cp51:=c521;cp52:=c522;cp53:=c523;cp54:=c524;ctp5:=ct52;ep5:=e52;
 cp61:=c11;cp62:=c12;cp63:=c13;cp64:=c14;ctp6:=ct1;ep6:=e1;
  end;

     procedure TMainForm.Button49Click(Sender: TObject);
 Const
 Semana1 = '26/11';
 Semana2 = '19/11';
 Semana3 = '12/11';
 Semana4 = '05/11';
 Semanap1 = '03/12';
 Semanap2 = '10/12';
 Semanap3 = '17/12';
 Semanap4 = '24/12';
 Semanap5 = '01/01';
 Semanap6 = '08/01';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c491;cp12:=c492;cp13:=c493;cp14:=c494;ctp1:=ct49;ep1:=e49;
 cp21:=c501;cp22:=c502;cp23:=c503;cp24:=c504;ctp2:=ct50;ep2:=e50;
 cp31:=c511;cp32:=c512;cp33:=c513;cp34:=c514;ctp3:=ct51;ep3:=e51;
 cp41:=c521;cp42:=c522;cp43:=c523;cp44:=c524;ctp4:=ct52;ep4:=e52;
 cp51:=c11;cp52:=c12;cp53:=c13;cp54:=c14;ctp5:=ct1;ep5:=e1;
 cp61:=c21;cp62:=c22;cp63:=c23;cp64:=c24;ctp6:=ct2;ep6:=e2;
  end;

 procedure TMainForm.Button50Click(Sender: TObject);
 Const
 Semana1 = '03/12';
 Semana2 = '26/11';
 Semana3 = '19/11';
 Semana4 = '12/11';
 Semanap1 = '10/12';
 Semanap2 = '17/12';
 Semanap3 = '24/12';
 Semanap4 = '01/12';
 Semanap5 = '08/01';
 Semanap6 = '15/01';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c501;cp12:=c502;cp13:=c503;cp14:=c504;ctp1:=ct50;ep1:=e50;
 cp21:=c511;cp22:=c512;cp23:=c513;cp24:=c514;ctp2:=ct51;ep2:=e51;
 cp31:=c521;cp32:=c522;cp33:=c523;cp34:=c524;ctp3:=ct52;ep3:=e52;
 cp41:=c11;cp42:=c12;cp43:=c13;cp44:=c14;ctp4:=ct1;ep4:=e1;
 cp51:=c21;cp52:=c22;cp53:=c23;cp54:=c24;ctp5:=ct2;ep5:=e2;
 cp61:=c31;cp62:=c32;cp63:=c33;cp64:=c34;ctp6:=ct3;ep6:=e3;
  end;

    procedure TMainForm.Button51Click(Sender: TObject);
 Const
 Semana1 = '10/12';
 Semana2 = '03/12';
 Semana3 = '26/11';
 Semana4 = '19/11';
 Semanap1 = '17/12';
 Semanap2 = '24/12';
 Semanap3 = '01/01';
 Semanap4 = '08/01';
 Semanap5 = '15/01';
 Semanap6 = '22/01';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c511;cp12:=c512;cp13:=c513;cp14:=c514;ctp1:=ct51;ep1:=e51;
 cp21:=c521;cp22:=c522;cp23:=c523;cp24:=c524;ctp2:=ct52;ep2:=e52;
 cp31:=c11;cp32:=c12;cp33:=c13;cp34:=c14;ctp3:=ct1;ep3:=e1;
 cp41:=c21;cp42:=c22;cp43:=c23;cp44:=c24;ctp4:=ct2;ep4:=e2;
 cp51:=c31;cp52:=c32;cp53:=c33;cp54:=c34;ctp5:=ct3;ep5:=e3;
 cp61:=c41;cp62:=c42;cp63:=c43;cp64:=c44;ctp6:=ct4;ep6:=e4;
  end;

 procedure TMainForm.Button52Click(Sender: TObject);
 Const
 Semana1 = '17/12';
 Semana2 = '10/12';
 Semana3 = '03/12';
 Semana4 = '26/11';
 Semanap1 = '24/12';
 Semanap2 = '01/01';
 Semanap3 = '08/01';
 Semanap4 = '15/01';
 Semanap5 = '22/01';
 Semanap6 = '29/01';
  begin
 Label2.Caption := semana1;
 Label6.Caption := semana2;
 Label7.Caption := semana3;
 Label8.Caption := semana4;
 Labelp1.Caption := semanap1;
 Labelp2.Caption := semanap2;
 Labelp3.Caption := semanap3;
 Labelp4.Caption := semanap4;
 Labelp5.Caption := semanap5;
 Labelp6.Caption := semanap6;
 cp11:=c521;cp12:=c522;cp13:=c523;cp14:=c524;ctp1:=ct52;ep1:=e52;
 cp21:=c11;cp22:=c12;cp23:=c13;cp24:=c14;ctp2:=ct1;ep2:=e1;
 cp31:=c21;cp32:=c22;cp33:=c23;cp34:=c24;ctp3:=ct2;ep3:=e2;
 cp41:=c31;cp42:=c32;cp43:=c33;cp44:=c34;ctp4:=ct3;ep4:=e3;
 cp51:=c41;cp52:=c42;cp53:=c43;cp54:=c44;ctp5:=ct4;ep5:=e4;
 cp61:=c51;cp62:=c52;cp63:=c53;cp64:=c54;ctp6:=ct5;ep6:=e5;
  end;

procedure TMainForm.Edit1KeyPress(Sender: TObject;var Key:char);
begin
 if not (key in ['0'..'9',#8]) then
 begin
 key := #0;
 MessageBeep ($FFFF);
 end;
end;


   procedure TMainForm.FileExit(Sender: TObject);
begin
  Mainform.Close;
  end;

initialization
  RegisterClasses ([TLabel, TButton,TBitbtn]);
end.

