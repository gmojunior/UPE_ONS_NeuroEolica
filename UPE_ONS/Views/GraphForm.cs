using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPE_ONS.Views
{

    using GraphLib;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Windows;
    using UPE_ONS.Controllers;
    using UPE_ONS.Model;

    public partial class GraphForm : Form
    {
        private String[] files = null;

        private int NumGraphs = 1;

        private String CurExample = "TILED_VERTICAL_AUTO";
        private String CurColorSchema = "GRAY";

        private PrecisionTimer.Timer mTimer = null;
        private DateTime lastTimerTick = DateTime.Now;

        private const string PREVISOR_TR_DIRECTORY_NAME = "PrevisorTR";
        private const string PASTA_ENTRADAS = "/Entradas";
        private const string PASTA_TRABALHO = "/TRABALHO";


        public GraphForm()
        {
            InitializeComponent();

            display.Smoothing = System.Drawing.Drawing2D.SmoothingMode.None;

            fillComboBox();

            CalcDataGraphs();
             
            display.Refresh();
            this.Invalidate();
            this.Refresh();
            
            UpdateGraphCountMenu();

            UpdateColorSchemaMenu();
            
            this.FormClosing += Graph_FormClosing;
        }

        private void Graph_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Realmente deseja fechar esta janela?", "Neuro Eólica", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                display.DataSources.Clear();
                display.SuspendLayout();
                this.Dispose();
                this.mTimer.Dispose();
                //this.lastTimerTick = null;
            }
        }

        private void fillComboBox()
        {
            //Posteriormente, essa lista devera ser preenchida com a leitura do banco de dados
            //ObservableCollection<ParqueEolico> parquesPrevistosLista = new ObservableCollection<ParqueEolico>();
           // parquesPrevistosLista.Add(new ParqueEolico("uecq", "uecq", "uecq", 12, 12, null));
           // parquesPrevistosLista.Add(new ParqueEolico("uebv", "uebv", "uebv", 12, 12, null));
            ObservableCollection<ParqueEolico> parquesPrevistosLista = new ObservableCollection<ParqueEolico>(FactoryController.getInstance().ParqueEolicoController.getParquesPrevistos("TR"));
            Double[] outputData;
            Double[] inputData;
            Double[] inputDataWithSinAndCos;
            Util.Util.matrixDeValoresPrevistos = new Double[parquesPrevistosLista.Count][];
            for (int i = 0; i < parquesPrevistosLista.Count; i++)
            {
                inputDataWithSinAndCos = lerArquivoEntradaPrevisor(parquesPrevistosLista[i]);
                inputData = new Double[inputDataWithSinAndCos.Count() - 2];
                int count = 0;
                for (int j = 0; j < inputDataWithSinAndCos.Count(); j++)
                {
                    if ((j == 0) || (j == 1))
                    {
                        continue;
                    }
                    inputData[count] = inputDataWithSinAndCos[j];
                    count++;
                }

                outputData = lerArquivoSaidaPrevisor(parquesPrevistosLista[i]);
                int sizeOfGraphData = inputData.Count() + outputData.Count();
                Double[] graphData = new Double[sizeOfGraphData];
                inputData.CopyTo(graphData, 0);
                outputData.CopyTo(graphData, inputData.Count());

                Util.Util.matrixDeValoresPrevistos[i] = graphData;
                
            }
                
            ComboBox cb = this.Controls.Find("cb_grafico", true).FirstOrDefault() as ComboBox;
            cb.AllowDrop = true;

            cb.SelectedIndexChanged += cb_SelectedIndexChanged;
            /*
            ObservableCollection<ParqueEolico> parquesPrevistos1 = new ObservableCollection<ParqueEolico>();
            ParqueEolico p = new ParqueEolico("uebv", "uebv", "uebv", 12, 12, null);
            ParqueEolico p2 = new ParqueEolico("uebv2", "uebv2", "uebv2", 12, 12, null);

            parquesPrevistos1.Add(p);
            parquesPrevistos1.Add(p2);
            
            Util.Util.parquesPrevistos = parquesPrevistos1;
            */

            Util.Util.parquesPrevistos = parquesPrevistosLista;
            cb.DisplayMember = "nome";
            cb.DataSource = Util.Util.parquesPrevistos;

            cb.SelectedIndex = 0;
        }

        private Double[] lerArquivoSaidaPrevisor(ParqueEolico p)
        {

            DirectoryInfo dir = new DirectoryInfo(PREVISOR_TR_DIRECTORY_NAME + "/" + p.SiglaPrevEOL + "/" + PASTA_TRABALHO);
            FileInfo[] fileInfo = dir.GetFiles();
            Double[] outputData = new Double[0];
            if (fileInfo.Length != 0)
            {
                foreach (FileInfo file in fileInfo)
                {

                    StreamReader outputFile = file.OpenText();
                    String linha = outputFile.ReadLine(); //linha em branco
                    linha = outputFile.ReadLine(); //data
                    linha = outputFile.ReadLine(); //linha em branco
                    linha = outputFile.ReadLine(); //dados
                    
                    string[] linha2 = linha.Split(';');
                    outputData = new Double[linha2.Count() - 1];
                    for (int i = 0; i < linha2.Count() - 1; i++)
                    {
                        outputData[i] = Double.Parse(linha2[i].Replace('.', ','));
                    }
                }
            }

            return outputData;

        }

        private Double[] lerArquivoEntradaPrevisor(ParqueEolico p)
        {
            DirectoryInfo dir = new DirectoryInfo(PREVISOR_TR_DIRECTORY_NAME + "/" + p.SiglaPrevEOL + "/" + PASTA_ENTRADAS);
            FileInfo[] fileInfo = dir.GetFiles();
            Double[] inputData = new Double[0];
            if (fileInfo.Length != 0)
            {
                foreach (FileInfo file in fileInfo)
                {

                    StreamReader inputFile = file.OpenText();
                    String linha = inputFile.ReadLine(); //data
                    linha = inputFile.ReadLine(); //dados
                  

                    string[] linha2 = linha.Split('\t');
                    inputData = new Double[linha2.Count() - 1];
                    for (int i = 0; i < linha2.Count() - 1; i++)
                    {
                        inputData[i] = Double.Parse(linha2[i].Replace('.',','));
                    }
                }
            }

            return inputData;
        }

        void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = this.Controls.Find("cb_grafico", true).FirstOrDefault() as ComboBox;

           // Util.Util.matrixDeValoresPrevistos = new Double[cb.Items.Count][];
           
            //Util.Util.matrixDeValoresPrevistos[0] = new double[] { 44.66, 21.75, 55.7, 21.69, 71.64, 21.25, 20.03, 1.14, 20.27, 21.12, 50.42, 51.29, 21, 21.07, 39.28, 10.25, 20.4, 19.82, 61.66, 71.75, 81.7, 21.69, 51.64, 21.25, 20.03, 19.14, 20.27, 21.12, 20.42, 21.29, 21, 21.07, 19.28, 20.25, 20.4, 19.82, 21.66, 21.75, 21.7, 21.69, 21.64, 21.25, 20.03, 19.14, 20.27, 21.12, 20.42, 21.29, 21, 21.07, 19.28, 20.25, 20.4, 19.82, 21.25, 20.03, 19.14, 20.27, 21.12, 20.42, 21.29, 21, 21.07, 19.28, 20.25, 20.4, 19.82, 21.66, 21.75, 21.7, 21.69, 21.64, 21.25, 20.03, 19.14, 20.27, 21.12, 20.42, 21.29, 21, 21.07, 19.28, 20.25, 20.4, 19.82, 21.66, 21.75, 21.7, 21.69, 21.64, 21.25, 20.03, 19.14, 20.27, 21.12, 20.42, 21.29, 21, 21.07, 19.28, 20.25, 20.4, 19.82, 21.66, 21.75, 21.7, 21.69, 21.25, 20.03, 19.14, 20.27, 21.12, 20.42, 21.29, 21, 21.07, 19.28, 20.25, 20.4, 19.82, 21.66, 21.75, 21.7, 21.69, 21.64, 21.25, 20.03, 19.14, 20.27, 21.12, 20.42, 21.29, 21, 21.07, 19.28, 20.25, 20.4, 19.82, 21.66, 21.75, 21.7, 21.69, 21.64, 21.25, 20.03, 19.14, 20.27, 21.12, 20.42, 21.29, 21, 21.07, 19.28, 20.25, 20.4, 19.82, 21.66, 21.75, 21.7, 21.69 };
            //Util.Util.matrixDeValoresPrevistos[1] = new double[] { 21.64, 21.25, 20.03, 19.14, 20.27, 21.12, 20.42, 21.29, 21, 21.07, 19.28, 20.25, 20.4, 19.82, 21.66, 21.75, 21.7, 21.69, 21.64, 21.25, 20.03, 19.14, 20.27, 21.12, 20.42, 21.29, 21, 21.07, 19.28, 20.25, 20.4, 19.82, 21.66, 21.75, 21.7, 21.69, 21.64, 21.25, 20.03, 19.14, 20.27, 21.12, 20.42, 21.29, 21, 21.07, 19.28, 20.25, 20.4, 19.82, 21.66, 21.75, 21.7, 21.69 }; 

            int index = cb.SelectedIndex;

            this.CurExample = "NORMAL";

            CalcDataGraphs();
            display.Refresh();
            this.Invalidate();
            this.Refresh();

        }

        

        private void UpdateGraphCountMenu()
        {
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
            toolStripMenuItem7.Checked = false;

            switch (NumGraphs)
            {
                case 1: toolStripMenuItem2.Checked = true; break;
                case 2: toolStripMenuItem3.Checked = true; break;
                case 3: toolStripMenuItem4.Checked = true; break;
                case 4: toolStripMenuItem5.Checked = true; break;
                case 5: toolStripMenuItem6.Checked = true; break;
                case 6: toolStripMenuItem7.Checked = true; break;

            }
        }

        private void UpdateColorSchemaMenu()
        {
            blueToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = false;
            grayToolStripMenuItem.Checked = false;
            lightBlueToolStripMenuItem.Checked = false;
            blackToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = false;

            if (CurColorSchema == "WHITE") whiteToolStripMenuItem.Checked = true;
            if (CurColorSchema == "BLUE") blueToolStripMenuItem.Checked = true;
            if (CurColorSchema == "GRAY") grayToolStripMenuItem.Checked = true;
            if (CurColorSchema == "LIGHT_BLUE") lightBlueToolStripMenuItem.Checked = true;
            if (CurColorSchema == "BLACK") blackToolStripMenuItem.Checked = true;
            if (CurColorSchema == "RED") redToolStripMenuItem.Checked = true;
            if (CurColorSchema == "DARK_GREEN") greenToolStripMenuItem.Checked = true;
        }


        protected void CalcDataGraphs()
        {

            this.SuspendLayout();

            ComboBox cb2 = this.Controls.Find("cb_grafico", true).FirstOrDefault() as ComboBox;

            display.DataSources.Clear();
            display.SetDisplayRangeX(0, 48);

            for (int j = 0; j < NumGraphs; j++)
            {
                

                display.DataSources.Add(new DataSource());
                display.DataSources[j].Name = "Gráfico de Previsão -" + cb2.Text;
                display.DataSources[j].OnRenderXAxisLabel += RenderXLabel;
                
                switch (CurExample)
                {
                    case "NORMAL":
                        
                        ComboBox cb3 = this.Controls.Find("cb_grafico", true).FirstOrDefault() as ComboBox;
                        double[] data2 = Util.Util.matrixDeValoresPrevistos[cb3.SelectedIndex];

                        this.Text = "Neuro Eólica";

                        int max = (int)data2.Max();

                        display.SetGridDistanceX(6);
                        display.SetDisplayRangeX(-1, 48);

                        display.DataSources[j].Length = data2.Length;

                        display.PanelLayout = PlotterGraphPaneEx.LayoutMode.NORMAL;
                        display.DataSources[j].AutoScaleY = false;
                        display.DataSources[j].SetDisplayRangeY(-1, max + 5);
                        display.DataSources[j].SetGridDistanceY(10);
                        display.DataSources[j].OnRenderYAxisLabel = RenderYLabel;
                        addDataSources(display.DataSources[j], j, data2);

                      // CalcSinusFunction_0(display.DataSources[j], j);
                        break;

                    case "NORMAL_AUTO":
                        this.Text = "Normal Graph Autoscaled";
                        display.DataSources[j].Length = 5800;
                        display.PanelLayout = PlotterGraphPaneEx.LayoutMode.NORMAL;
                        display.DataSources[j].AutoScaleY = true;
                        display.DataSources[j].SetDisplayRangeY(-300, 300);
                        display.DataSources[j].SetGridDistanceY(100);
                        display.DataSources[j].OnRenderYAxisLabel = RenderYLabel;
                        CalcSinusFunction_0(display.DataSources[j], j);
                        break;

                    case "STACKED":
                        this.Text = "Stacked Graph";
                        display.PanelLayout = PlotterGraphPaneEx.LayoutMode.STACKED;
                        display.DataSources[j].Length = 5800;
                        display.DataSources[j].AutoScaleY = false;
                        display.DataSources[j].SetDisplayRangeY(-250, 250);
                        display.DataSources[j].SetGridDistanceY(100);
                        CalcSinusFunction_1(display.DataSources[j], j);
                        break;

                    case "VERTICAL_ALIGNED":
                        this.Text = "Vertical aligned Graph";
                        display.PanelLayout = PlotterGraphPaneEx.LayoutMode.VERTICAL_ARRANGED;
                        display.DataSources[j].Length = 5800;
                        display.DataSources[j].AutoScaleY = false;
                        display.DataSources[j].SetDisplayRangeY(-300, 300);
                        display.DataSources[j].SetGridDistanceY(100);
                        CalcSinusFunction_2(display.DataSources[j], j);
                        break;

                    case "VERTICAL_ALIGNED_AUTO":
                        this.Text = "Vertical aligned Graph autoscaled";
                        display.PanelLayout = PlotterGraphPaneEx.LayoutMode.VERTICAL_ARRANGED;
                        display.DataSources[j].Length = 5800;
                        display.DataSources[j].AutoScaleY = true;
                        display.DataSources[j].SetDisplayRangeY(-300, 300);
                        display.DataSources[j].SetGridDistanceY(100);
                        CalcSinusFunction_2(display.DataSources[j], j);
                        break;

                    case "TILED_VERTICAL":
                        this.Text = "Tiled Graphs (vertical prefered)";
                        display.PanelLayout = PlotterGraphPaneEx.LayoutMode.TILES_VER;
                        display.DataSources[j].Length = 5800;
                        display.DataSources[j].AutoScaleY = false;
                        display.DataSources[j].SetDisplayRangeY(-300, 600);
                        display.DataSources[j].SetGridDistanceY(100);
                        CalcSinusFunction_2(display.DataSources[j], j);
                        break;

                    case "TILED_VERTICAL_AUTO":
                        
                        //this.Text = "Tiled Graphs (vertical prefered) autoscaled";

                        ComboBox cb = this.Controls.Find("cb_grafico", true).FirstOrDefault() as ComboBox;
                        double[] data = Util.Util.matrixDeValoresPrevistos[cb.SelectedIndex];

                        display.PanelLayout = PlotterGraphPaneEx.LayoutMode.TILES_VER;
                        display.DataSources[j].Length = data.Length;
                        //display.DataSources[j].AutoScaleY = true;
                        display.DataSources[j].SetDisplayRangeY(0, 60);
                        display.DataSources[j].SetGridDistanceY(10);
                        display.DataSources[j].VisibleDataRange_X = 40;
                       
                        if (j == 0)
                        {
                            
                        addDataSources(display.DataSources[j], j, data);
                        }
                        else
                        {
                        CalcSinusFunction_2(display.DataSources[j], j);
                        }

                        break;

                    case "TILED_HORIZONTAL":
                        this.Text = "Tiled Graphs (horizontal prefered)";
                        display.PanelLayout = PlotterGraphPaneEx.LayoutMode.TILES_HOR;
                        display.DataSources[j].Length = 5800;
                        display.DataSources[j].AutoScaleY = false;
                        display.DataSources[j].SetDisplayRangeY(-300, 600);
                        display.DataSources[j].SetGridDistanceY(100);
                        CalcSinusFunction_2(display.DataSources[j], j);
                        break;

                    case "TILED_HORIZONTAL_AUTO":
                        this.Text = "Tiled Graphs (horizontal prefered) autoscaled";
                        display.PanelLayout = PlotterGraphPaneEx.LayoutMode.TILES_HOR;
                        display.DataSources[j].Length = 5800;
                        display.DataSources[j].AutoScaleY = true;
                        display.DataSources[j].SetDisplayRangeY(-300, 600);
                        display.DataSources[j].SetGridDistanceY(100);
                        CalcSinusFunction_2(display.DataSources[j], j);
                        break;

                    case "ANIMATED_AUTO":

                        this.Text = "Animated graphs fixed x range";
                        display.PanelLayout = PlotterGraphPaneEx.LayoutMode.TILES_HOR;
                        display.DataSources[j].Length = 402;
                        display.DataSources[j].AutoScaleY = false;
                        display.DataSources[j].AutoScaleX = true;
                        display.DataSources[j].SetDisplayRangeY(-300, 500);
                        display.DataSources[j].SetGridDistanceY(100);
                        display.DataSources[j].XAutoScaleOffset = 50;
                        CalcSinusFunction_3(display.DataSources[j], j, 0);
                        display.DataSources[j].OnRenderYAxisLabel = RenderYLabel;
                        break;
                }
            }
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (CurExample == "ANIMATED_AUTO" )
            {
                    try
                    {
                        TimeSpan dt = DateTime.Now - lastTimerTick;

                        for (int j = 0; j < NumGraphs; j++)
                        {
                            
                            CalcSinusFunction_3(display.DataSources[j], j, (float)dt.TotalMilliseconds);
                            
                        }
                   
                        this.Invoke(new MethodInvoker(RefreshGraph));
                    }
                    catch (ObjectDisposedException ex)
                    {
                        // we get this on closing of form
                    }
                    catch (Exception ex)
                    {
                        Console.Write("exception invoking refreshgraph(): " + ex.Message);
                    }   
            }
        }

        private void RefreshGraph()
        {
            display.Refresh();
        }

        protected void addDataSources(DataSource src, int idx, Double[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                src.Samples[i].x = i;
                src.Samples[i].y = ((float)data[i]);   
            }
        }

        protected void CalcSinusFunction_0(DataSource src, int idx)
        {
            for (int i = 0; i < src.Length; i++)
            {
                src.Samples[i].x = i;
                src.Samples[i].y = (float)(((float)200 * Math.Sin((idx + 1) * (i + 1.0) * 48 / src.Length)));
            }
        }

        protected void CalcSinusFunction_1(DataSource src, int idx)
        {
            for (int i = 0; i < src.Length; i++)
            {
                src.Samples[i].x = i;

                src.Samples[i].y = (float)(((float)20 *
                                            Math.Sin(20 * (idx + 1) * (i + 1) * Math.PI / src.Length)) *
                                            Math.Sin(40 * (idx + 1) * (i + 1) * Math.PI / src.Length)) +
                                            (float)(((float)200 *
                                            Math.Sin(200 * (idx + 1) * (i + 1) * Math.PI / src.Length)));
            }
            src.OnRenderYAxisLabel = RenderYLabel;
        }

        protected void CalcSinusFunction_2(DataSource src, int idx)
        {
            for (int i = 0; i < src.Length; i++)
            {
                src.Samples[i].x = i;

                src.Samples[i].y = (float)(((float)20 *
                                            Math.Sin(40 * (idx + 1) * (i + 1) * Math.PI / src.Length)) *
                                            Math.Sin(160 * (idx + 1) * (i + 1) * Math.PI / src.Length)) +
                                            (float)(((float)200 *
                                            Math.Sin(4 * (idx + 1) * (i + 1) * Math.PI / src.Length)));
            }
            src.OnRenderYAxisLabel = RenderYLabel;
        }

        private String RenderYLabel(DataSource s, float value)
        {
            return String.Format("{0:0.0}", value);
        }

        protected void CalcSinusFunction_3(DataSource ds, int idx, float time)
        {
            cPoint[] src = ds.Samples;
            for (int i = 0; i < src.Length; i++)
            {
                src[i].x = i;
                src[i].y = 200 + (float)((200 * Math.Sin((idx + 1) * (time + i * 100) / 8000.0))) +
                                +(float)((40 * Math.Sin((idx + 1) * (time + i * 200) / 2000.0)));
                /**
                            (float)( 4* Math.Sin( ((time + (i+8) * 100) / 900.0)))+
                            (float)(28 * Math.Sin(((time + (i + 8) * 100) / 290.0))); */
            }

        }

        private void stackedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            display.PanelLayout = PlotterGraphPaneEx.LayoutMode.NORMAL;
        }

        private void verticalALignedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            display.PanelLayout = PlotterGraphPaneEx.LayoutMode.VERTICAL_ARRANGED;
        }

        private void tiledVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            display.PanelLayout = PlotterGraphPaneEx.LayoutMode.TILES_VER;
        }

        private void tiledHorizontalyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            display.PanelLayout = PlotterGraphPaneEx.LayoutMode.TILES_HOR;
        }

        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            display.Smoothing = System.Drawing.Drawing2D.SmoothingMode.None;
        }

        private void antiAliasedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            display.Smoothing = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        private void highSpeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            display.Smoothing = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        }

        private void highQualityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            display.Smoothing = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurExample = "NORMAL";
            CalcDataGraphs();
        }

        private void normalAutoscaledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurExample = "NORMAL_AUTO";
            CalcDataGraphs();
        }

        private void stackedToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CurExample = "STACKED";
            CalcDataGraphs();
        }

        private void verticallyAlignedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurExample = "VERTICAL_ALIGNED";
            CalcDataGraphs();
        }
        private void verticallyAlignedAutoscaledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurExample = "VERTICAL_ALIGNED_AUTO";
            CalcDataGraphs();
        }

        private void tiledVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurExample = "TILED_VERTICAL";
            CalcDataGraphs();
        }
        private void tiledVerticalAutoscaledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurExample = "TILED_VERTICAL_AUTO";
            CalcDataGraphs();
        }

        private void tiledHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurExample = "TILED_HORIZONTAL";
            CalcDataGraphs();
        }

        private void tiledHorizontalAutoscaledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurExample = "TILED_HORIZONTAL_AUTO";
            CalcDataGraphs();
        }

        private void animatedGraphDemoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurExample = "ANIMATED_AUTO";
            CalcDataGraphs();
        }


        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurColorSchema = "BLUE";
            CalcDataGraphs();
            UpdateColorSchemaMenu();
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurColorSchema = "WHITE";
            CalcDataGraphs();
            UpdateColorSchemaMenu();
        }

        private void grayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurColorSchema = "GRAY";
            CalcDataGraphs();
            UpdateColorSchemaMenu();
        }

        private void lightBlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurColorSchema = "LIGHT_BLUE";
            CalcDataGraphs();
            UpdateColorSchemaMenu();

        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurColorSchema = "BLACK";
            CalcDataGraphs();
            UpdateColorSchemaMenu();
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurColorSchema = "RED";
            CalcDataGraphs();
            UpdateColorSchemaMenu();
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurColorSchema = "DARK_GREEN";
            CalcDataGraphs();
            UpdateColorSchemaMenu();

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            NumGraphs = 1;
            CalcDataGraphs();
            UpdateGraphCountMenu();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            NumGraphs = 2;
            CalcDataGraphs();
            UpdateGraphCountMenu();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            NumGraphs = 3;
            CalcDataGraphs();
            UpdateGraphCountMenu();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            NumGraphs = 4;
            CalcDataGraphs();
            UpdateGraphCountMenu();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            NumGraphs = 5;
            CalcDataGraphs();
            UpdateGraphCountMenu();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            NumGraphs = 6;
            CalcDataGraphs();
            UpdateGraphCountMenu();
        }

        private String RenderXLabel(DataSource s, int idx)
        {
            if (s.AutoScaleX)
            {
                //if (idx % 2 == 0)
                {
                    int Value = (int)(s.Samples[idx].x);
                    return "" + Value;
                }
                return "";
            }
            else
            {
                int Value = (int)(s.Samples[idx].x / 6)+1;
                String Label = "" + Value + "";
                return Label;
            }
        }

        private void display_Load(object sender, EventArgs e)
        {
           
            display.Smoothing = System.Drawing.Drawing2D.SmoothingMode.None;

            CalcDataGraphs();

            display.Refresh();

            UpdateGraphCountMenu();

            UpdateColorSchemaMenu();

            mTimer = new PrecisionTimer.Timer();
            mTimer.Period = 40;                         // 20 fps
            mTimer.Tick += new EventHandler(OnTimerTick);
            lastTimerTick = DateTime.Now;
            mTimer.Start();  
        }      

        private void button1_Click(object sender, EventArgs e)
        {
            display.Smoothing = System.Drawing.Drawing2D.SmoothingMode.None;
            
            CalcDataGraphs();
            CurColorSchema = "GRAY";

            display.Refresh();

            UpdateGraphCountMenu();

            UpdateColorSchemaMenu();

            mTimer = new PrecisionTimer.Timer();
            mTimer.Period = 40;                         // 20 fps
            mTimer.Tick += new EventHandler(OnTimerTick);
            lastTimerTick = DateTime.Now;
            mTimer.Start();

            this.Invalidate();
        }
        


    }
}
