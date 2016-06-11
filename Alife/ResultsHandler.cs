using ClosedXML.Excel;
using DotImaging;
using Spire.Xls;
using Spire.Xls.Charts;
using Splicer.Renderer;
using Splicer.Timeline;
using Splicer.WindowsMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alife
{
    public class ResultsHandler //This class writes the results in specified folder. Also launches data analysis
    {
        public string folder_path; //Destination path
        public Simulation simulation; //The simulation to export
        public List<Driver.Result> results; //The results of the simulation
        public static object lock_common_writing = new object(); //Lock for writing in a shared file
        public int progress_export_data;
        public int progress_images;
        public int progress_video;


        public ResultsHandler(Simulation simulation) //Constructor
        {
            this.simulation = simulation;
            this.folder_path = simulation.parameters.path;
            results = new List<Driver.Result>();
            foreach (Driver.Result res in simulation.driver.queueresults)
            {
                results.Add(res); //Add the queue from the simulation driver to this result list. 
            }
            progress_images = 0;
            progress_video = 0;

        }

        public string GetProgress_Write_Images()
        {
            return progress_images.ToString() + "%";
        }

        public string GetProgress_Make_Video()
        {
            return progress_video.ToString() + "%";
        }

        public string GetProgress_Write_Data()
        {
            return progress_export_data.ToString() + "%";
        }

        public void WriteData()// Main function for export. Is called from outside
        {
            lock (lock_common_writing)
            {
                Export_Biomass();
                Kills_Evaluation_Message();
            }

        }



        public void Make_Video()
        {
            Generate_Video();
        }

        public void Kills_Evaluation_Message()
        {
            //Kills the evaluation message
            string simname;
            if (simulation.name != "")//if the name of the simulation is defined, append "_name" to the simulation number
            {
                simname = simulation.name + "_" + simulation.index.ToString();
            }
            else
            {
                simname = simulation.index.ToString();
            }


            XLWorkbook workbook = new XLWorkbook(folder_path + "\\" + simname + "\\" + "Biomass" + simname + ".xlsx");
            var worksheet = workbook.Worksheet("Evaluation Warning");
            worksheet.Delete();
            workbook.SaveAs(folder_path + "\\" + simname + "\\" + "Biomass" + simname + ".xlsx"); //Save the file

            workbook = new XLWorkbook(folder_path + "\\common\\" + "Prey_Predator_Biomass_Common.xlsx");
            worksheet = workbook.Worksheet("Evaluation Warning");
            worksheet.Delete();
            workbook.SaveAs(folder_path + "\\common\\" + "Prey_Predator_Biomass_Common.xlsx"); //Save
        }

        public String GetStringName()
        {
            string simname;
            if (simulation.name != "")//if the name of the simulation is defined, append "_name" to the simulation number
            {
                simname = simulation.name + "_" + simulation.index.ToString();
            }
            else
            {
                simname = simulation.index.ToString();
            }
            return simname;
        }


        private void Export_Biomass() //Export biomass data and creates plot in XLS file. Also creates a common file for all simulations
        {

            progress_export_data = 0;
            //To write and work in XLS file, ClosedXML and Spire are used
            XLWorkbook workbook = new XLWorkbook(); //Creates new excel document with ClosedXML
            IXLWorksheet worksheet = workbook.Worksheets.Add(GetStringName());  //Creates sheet
            Write_Biomass_XLS(ref worksheet);//Writes data and parameters
            workbook.SaveAs(folder_path + "\\" + GetStringName() + "\\" + "Biomass" + GetStringName() + ".xlsx"); //Save the file
            progress_export_data = 25;
            //Graphs are not supported by ClosedXML, so we use Spire.
            Workbook book;//Open new Spire file
            book = new Workbook();
            book.LoadFromFile(folder_path + "\\" + GetStringName() + "\\" + "Biomass" + GetStringName() + ".xlsx"); //Load the file we just saved woth ClosedXML
            Worksheet sheet = book.Worksheets[GetStringName().ToString()]; //Open sheet

            Generate_Graphs(ref sheet); //Generate the graphs
            Generate_Formulas(ref sheet); //Generate the formulas for data analysis

            book.SaveToFile(folder_path + "\\" + GetStringName() + "\\" + "Biomass" + GetStringName() + ".xlsx"); //Save the file back

            progress_export_data = 50;

            // Writes in the common file

            XLWorkbook workbook_common;
            try
            {
                workbook_common = new XLWorkbook(folder_path + "\\common\\" + "Prey_Predator_Biomass_Common.xlsx"); //Open common file
            }
            catch
            {
                workbook_common = new XLWorkbook(); //If not defined, create a new one
            }
            IXLWorksheet worksheet_common;
            IXLWorksheet worksheet_common_shared;
            try
            {
                worksheet_common = workbook_common.Worksheets.Add(GetStringName(), simulation.index); //Add sheet with simulation name
                worksheet_common_shared = workbook_common.Worksheets.Add("Shared", 0);
            }
            catch
            {
                worksheet_common = workbook_common.Worksheet(GetStringName());
                worksheet_common_shared = workbook_common.Worksheet("Shared");
            }
            Write_Biomass_XLS(ref worksheet_common); //Write biomass in this sheet
            // Write_Shared(ref worksheet_common_shared);
            workbook_common.SaveAs(folder_path + "\\common\\" + "Prey_Predator_Biomass_Common.xlsx"); //Save
            Workbook book_common = new Workbook(); //Open new Spire file
            progress_export_data = 75;
            book_common.LoadFromFile(folder_path + "\\common\\" + "Prey_Predator_Biomass_Common.xlsx"); //Load the file we just saved woth ClosedXML
            Worksheet sheet_common = book_common.Worksheets[GetStringName().ToString()]; //Open sheet
            Worksheet sheet_shared = book_common.Worksheets["Shared"]; //Open sheet
            Generate_Graphs(ref sheet_common); //Generate the graphs

            Generate_Formulas(ref sheet_common); //Generate the formulas for data analysis
            Generate_Shared(ref sheet_common, ref sheet_shared);

            book_common.SaveToFile(folder_path + "\\common\\" + "Prey_Predator_Biomass_Common.xlsx"); //Save the file back
            progress_export_data = 100;


        }


        public void Generate_Graphs(ref Worksheet sheet) //Generates the graphs in the sheet
        {
            Generate_Biomass_Time_Graph(ref sheet); //PreyBiomass / Time     and PredatorBiomass /time
            Generate_Biomass_Phase_Graph(ref sheet); //PreyBiomass / PredatorBiomass


        }

        public void Generate_Video()
        {
            System.IO.Directory.CreateDirectory(folder_path + "\\" + GetStringName() + "\\video\\");
            Bgr<byte>[,] bgrIm;

            ImageStreamWriter videoWriter = new VideoWriter(folder_path + "\\" + GetStringName() + "\\video\\out.avi", new DotImaging.Primitives2D.Size(800, 800), 25, true);

            for (int i = 0; i < results.Count; i++)
            {
                try
                {
                    bgrIm = ImageIO.LoadColor(folder_path + "\\" + GetStringName() + "\\images\\" + i + ".png").ToBgr();
                    videoWriter.Write(bgrIm.Lock()); //write a single frame
                    progress_video = (int)Math.Floor(100.0 * i / (double)results.Count);
                }
                catch
                {

                }
            }




            videoWriter.Close();

















        }


        public void Generate_Formulas(ref Worksheet sheet) //Generates formulas for Data Analysis
        {
            //We want to compute Average, deviation, ... for the full data and for only the second half (to analyze only steady states)
            string range = (results.Count + 1).ToString(); //Last index
            string halfrange = Math.Floor((results.Count + 1) / 2.0).ToString(); //Index for half-data

            //Prey Analysis
            sheet.Range[3, 8].Formula = "=AVERAGE(B" + halfrange + ":B" + range + ")";
            sheet.Range[4, 8].Formula = "=STDEV.S(B" + halfrange + ":B" + range + ")";
            sheet.Range[5, 8].Formula = "=MIN(B" + halfrange + ":B" + range + ")";
            sheet.Range[6, 8].Formula = "=MAX(B" + halfrange + ":B" + range + ")";
            sheet.Range[3, 11].Formula = "=AVERAGE(B" + "2" + ":B" + range + ")";
            sheet.Range[4, 11].Formula = "=STDEV.S(B" + "2" + ":B" + range + ")";
            sheet.Range[5, 11].Formula = "=MIN(B" + "2" + ":B" + range + ")";
            sheet.Range[6, 11].Formula = "=MAX(B" + "2" + ":B" + range + ")";
            //Predator Analysis
            sheet.Range[3, 9].Formula = "=AVERAGE(C" + halfrange + ":C" + range + ")";
            sheet.Range[4, 9].Formula = "=STDEV.S(C" + halfrange + ":C" + range + ")";
            sheet.Range[5, 9].Formula = "=MIN(C" + halfrange + ":C" + range + ")";
            sheet.Range[6, 9].Formula = "=MAX(C" + halfrange + ":C" + range + ")";
            sheet.Range[3, 12].Formula = "=AVERAGE(C" + "2" + ":C" + range + ")";
            sheet.Range[4, 12].Formula = "=STDEV.S(C" + "2" + ":C" + range + ")";
            sheet.Range[5, 12].Formula = "=MIN(C" + "2" + ":C" + range + ")";
            sheet.Range[6, 12].Formula = "=MAX(C" + "2" + ":C" + range + ")";


        }


        public void Generate_Shared(ref Worksheet sheet, ref Worksheet sheet_shared) //Generates formulas for Data Analysis
        {
            sheet_shared.Range[1, 1].Value = "Simulation Index";
            sheet_shared.Range[1, 3].Value = "Prey Average";
            sheet_shared.Range[1, 4].Value = "Prey Deviation";
            sheet_shared.Range[1, 5].Value = "Prey Minimum";
            sheet_shared.Range[1, 6].Value = "Prey Maximum";

            sheet_shared.Range[1, 8].Value = "Predator Average";
            sheet_shared.Range[1, 9].Value = "Predator Deviation";
            sheet_shared.Range[1, 10].Value = "Predator Minimum";
            sheet_shared.Range[1, 11].Value = "Predator Maximum";

            sheet_shared.Range[simulation.index + 2, 1].NumberValue = simulation.index;

            sheet_shared.Range[simulation.index + 2, 3].Formula = "='" + sheet.Name + "'" + "!H3";
            sheet_shared.Range[simulation.index + 2, 4].Formula = "='" + sheet.Name + "'" + "!H4";
            sheet_shared.Range[simulation.index + 2, 5].Formula = "='" + sheet.Name + "'" + "!H5";
            sheet_shared.Range[simulation.index + 2, 6].Formula = "='" + sheet.Name + "'" + "!H6";

            sheet_shared.Range[simulation.index + 2, 8].Formula = "='" + sheet.Name + "'" + "!I3";
            sheet_shared.Range[simulation.index + 2, 9].Formula = "='" + sheet.Name + "'" + "!I4";
            sheet_shared.Range[simulation.index + 2, 10].Formula = "='" + sheet.Name + "'" + "!I5";
            sheet_shared.Range[simulation.index + 2, 11].Formula = "='" + sheet.Name + "'" + "!I6";


        }

        public void Generate_Biomass_Time_Graph(ref Worksheet sheet) //Generate Biomass/Time graph in given sheet
        {
            //Add chart and set chart data range  
            Chart chart = sheet.Charts.Add(ExcelChartType.ScatterLine);

            string range = (results.Count + 1).ToString();
            chart.DataRange = sheet.Range["B1:E" + range];
            chart.SeriesDataFromRange = false;

            ////Define series
            //data series
            chart.Series[0].CategoryLabels = sheet.Range["A2:A" + range];
            chart.Series[0].Values = sheet.Range["B2:B" + range];
            chart.Series[1].CategoryLabels = sheet.Range["A2:A" + range];
            chart.Series[1].Values = sheet.Range["C2:C" + range];

            //Equilibrium values series
            chart.Series[2].CategoryLabels = sheet.Range["A2:A" + range];
            chart.Series[2].Values = sheet.Range["D2:D" + range];
            chart.Series[2].Format.LineProperties.Weight = ChartLineWeightType.Narrow;
            chart.Series[3].CategoryLabels = sheet.Range["A2:A" + range];
            chart.Series[3].Values = sheet.Range["E2:E" + range];
            chart.Series[3].Format.LineProperties.Weight = ChartLineWeightType.Narrow;

            //Chart position  
            chart.LeftColumn = 20;
            chart.TopRow = 1;
            chart.RightColumn = 30;
            chart.BottomRow = 26;

            //Chart title  
            chart.ChartTitle = "Prey - Predator Biomass with time";
            chart.ChartTitleArea.Font.FontName = "Calibri";
            chart.ChartTitleArea.Font.Size = 13;
            chart.ChartTitleArea.Font.IsBold = true;

            //Chart axis  
            chart.PrimaryValueAxis.Title = "Biomass";
            chart.PrimaryCategoryAxis.Title = "Time";
            chart.PrimaryValueAxis.HasMajorGridLines = false;
            // chart.PrimaryValueAxis.MaxValue = 10000;
            chart.PrimaryValueAxis.TitleArea.TextRotationAngle = 90;

            //Chart legend  
            chart.Legend.Position = LegendPositionType.Right;
            chart.SeriesDataFromRange = false;
        }

        public void Generate_Biomass_Phase_Graph(ref Worksheet sheet) //Generate PreyBiomass/PredatorBiomass graph
        {
            //Add chart and set chart data range  
            Chart chart = sheet.Charts.Add(ExcelChartType.ScatterLine);

            string range = (results.Count + 1).ToString();
            chart.DataRange = sheet.Range["B1:C" + range];

            ////Define series
            //Data
            chart.SeriesDataFromRange = false;
            chart.Series[0].CategoryLabels = sheet.Range["B2:B" + range];
            chart.Series[0].Values = sheet.Range["C2:C" + range];
            //Equilibrium point
            chart.Series[1].CategoryLabels = sheet.Range["D2:D" + range];
            chart.Series[1].Values = sheet.Range["E2:E" + range];
            chart.Series[1].SerieType = ExcelChartType.ScatterMarkers;
            chart.Series[1].Format.MarkerStyle = ChartMarkerType.Star;

            //Chart position  
            chart.LeftColumn = 20;
            chart.TopRow = 30;
            chart.RightColumn = 30;
            chart.BottomRow = 55;

            //Chart title  
            chart.ChartTitle = "Prey - Predator Phase plot";
            chart.ChartTitleArea.Font.FontName = "Calibri";
            chart.ChartTitleArea.Font.Size = 13;
            chart.ChartTitleArea.Font.IsBold = true;

            //Chart axis  
            chart.PrimaryValueAxis.Title = "Predator Biomass";
            chart.PrimaryCategoryAxis.Title = "Prey Biomass";
            chart.PrimaryValueAxis.HasMajorGridLines = false;
            //chart.PrimaryValueAxis.MaxValue = 10000;
            chart.PrimaryValueAxis.TitleArea.TextRotationAngle = 90;

            //Chart legend  
            chart.Series[0].Name = "Prey-Predator";
            chart.Series[1].Name = "Equilibrium Point";
            chart.Legend.Position = LegendPositionType.Right;
            chart.SeriesDataFromRange = false;
        }

        public void Write_Biomass_XLS(ref IXLWorksheet worksheet) //writes biomass data and parameters in worksheet
        {
            //Writes results
            worksheet.Cell(1, 1).Value = "Time";
            worksheet.Cell(2, 1).Value = results.Select(r => r.time).ToList();

            worksheet.Cell(1, 2).Value = "Prey";
            worksheet.Cell(2, 2).Value = results.Select(r => r.preybiomass).ToList();

            worksheet.Cell(1, 3).Value = "Predator";
            worksheet.Cell(2, 3).Value = results.Select(r => r.predatorbiomass).ToList();

            //Writes the equilibrium values (is written in full column to generate a serie for the graph in excel)
            worksheet.Cell(1, 4).Value = "Prey equilibrium";
            worksheet.Cell(1, 5).Value = "Predator equilibrium";
            for (int i = 2; i <= results.Count + 1; i++)
            {
                worksheet.Cell(i, 4).Value = simulation.parameters.prey_eq;
                worksheet.Cell(i, 5).Value = simulation.parameters.pred_eq;
            }

            //Writes Data Analysis strings
            worksheet.Cell(1, 8).Value = "Half Dataset";
            worksheet.Cell(2, 8).Value = "Prey";
            worksheet.Cell(2, 9).Value = "Predator";
            worksheet.Cell(1, 11).Value = "Full Dataset";
            worksheet.Cell(2, 11).Value = "Prey";
            worksheet.Cell(2, 12).Value = "Predator";
            worksheet.Cell(3, 7).Value = "Average";
            worksheet.Cell(4, 7).Value = "Deviation";
            worksheet.Cell(5, 7).Value = "Min";
            worksheet.Cell(6, 7).Value = "Max";

            worksheet.Columns("N").Width = 10;
            //Writes parameters
            Parameters p = simulation.parameters;
            worksheet.Cell(1, 15).Value = "Parameters";
            worksheet.Cell(2, 14).Value = "Lx";
            worksheet.Cell(2, 15).Value = p.Length_x;
            worksheet.Cell(3, 14).Value = "Ly";
            worksheet.Cell(3, 15).Value = p.Length_y;
            worksheet.Cell(4, 14).Value = "timestep";
            worksheet.Cell(4, 15).Value = p.timestep;
            worksheet.Cell(5, 14).Value = "Final time";
            worksheet.Cell(5, 15).Value = p.final_time;

            worksheet.Cell(8, 14).Value = "Hunting Surface";
            worksheet.Cell(8, 15).Value = p.hunting_area;
            worksheet.Cell(9, 14).Value = "Hunting fertility";
            worksheet.Cell(9, 15).Value = p.hunting_fertility;

            worksheet.Cell(11, 15).Value = "Prey";
            worksheet.Cell(11, 16).Value = "Predator";
            worksheet.Cell(12, 14).Value = "Fertility";
            worksheet.Cell(12, 15).Value = p.prey_fertility;
            worksheet.Cell(12, 16).Value = p.predator_fertility;

            worksheet.Cell(13, 14).Value = "Death rate";
            worksheet.Cell(13, 15).Value = p.prey_deathrate;
            worksheet.Cell(13, 16).Value = p.predator_deathrate;

            worksheet.Cell(14, 14).Value = "Competition";
            worksheet.Cell(14, 15).Value = p.prey_competition;
            worksheet.Cell(14, 16).Value = p.predator_competition;

            worksheet.Cell(15, 14).Value = "Competition area";
            worksheet.Cell(16, 14).Value = "Competition strength";
            if (p.prey_competition)
            {
                worksheet.Cell(15, 15).Value = p.prey_competition_area;
                worksheet.Cell(16, 15).Value = p.prey_competition_strength;
            }
            if (p.predator_competition)
            {
                worksheet.Cell(15, 16).Value = p.predator_competition_area;
                worksheet.Cell(16, 16).Value = p.predator_competition_strength;
            }


            worksheet.Cell(17, 14).Value = "Speed";
            worksheet.Cell(17, 15).Value = p.prey_speed;
            worksheet.Cell(17, 16).Value = p.predator_speed;

            worksheet.Cell(18, 14).Value = "Chemotaxis";
            worksheet.Cell(18, 15).Value = p.prey_chemotaxis;
            worksheet.Cell(18, 16).Value = p.predator_chemotaxis;

            worksheet.Cell(19, 14).Value = "Chemotactic speed";
            worksheet.Cell(20, 14).Value = "Chemotactic area";
            if (p.prey_chemotaxis)
            {
                worksheet.Cell(19, 15).Value = p.prey_chemotaxis_speed;
                worksheet.Cell(20, 15).Value = p.prey_chemotaxis_area;
            }
            if (p.predator_chemotaxis)
            {
                worksheet.Cell(19, 16).Value = p.predator_chemotaxis_speed;
                worksheet.Cell(20, 16).Value = p.predator_chemotaxis_area;
            }



            worksheet.Cell(22, 14).Value = "Equilibrium Biomass";
            worksheet.Cell(22, 15).Value = p.prey_eq;
            worksheet.Cell(22, 16).Value = p.pred_eq;

            worksheet.Cell(24, 14).Value = "Ratio";
            worksheet.Cell(24, 15).Value = p.ratio;

            worksheet.Cell(25, 14).Value = "a";
            worksheet.Cell(25, 15).Value = p.a;

            worksheet.Cell(26, 14).Value = "b";
            worksheet.Cell(26, 15).Value = p.b;

            worksheet.Cell(27, 14).Value = "c";
            worksheet.Cell(27, 15).Value = p.c;

            worksheet.Cell(28, 14).Value = "d";
            worksheet.Cell(28, 15).Value = p.d;

            worksheet.Cell(29, 14).Value = "e";
            worksheet.Cell(29, 15).Value = p.e;

            worksheet.Cell(30, 14).Value = "f";
            worksheet.Cell(30, 15).Value = p.f;

            worksheet.Cell(32, 14).Value = "Prey Fertility (age)";
            worksheet.Cell(32, 15).Value = p.fertility_age[0];
            worksheet.Cell(32, 16).Value = p.fertility_age[1];
            worksheet.Cell(32, 17).Value = p.fertility_age[2];
            worksheet.Cell(32, 18).Value = p.fertility_age[3];
            worksheet.Cell(32, 19).Value = p.fertility_age[4];

            worksheet.Cell(33, 14).Value = "Prey Death Rate (age)";
            worksheet.Cell(33, 15).Value = p.deathrate_age[0];
            worksheet.Cell(33, 16).Value = p.deathrate_age[1];
            worksheet.Cell(33, 17).Value = p.deathrate_age[2];
            worksheet.Cell(33, 18).Value = p.deathrate_age[3];
            worksheet.Cell(33, 19).Value = p.deathrate_age[4];

            worksheet.Cell(34, 14).Value = "Prey Speed(age)";
            worksheet.Cell(34, 15).Value = p.speed_age[0];
            worksheet.Cell(34, 16).Value = p.speed_age[1];
            worksheet.Cell(34, 17).Value = p.speed_age[2];
            worksheet.Cell(34, 18).Value = p.speed_age[3];
            worksheet.Cell(34, 19).Value = p.speed_age[4];

            worksheet.Cell(36, 14).Value = "Time between hunts";
            worksheet.Cell(37, 14).Value = "Gestation";
            worksheet.Cell(38, 14).Value = "Time between reproduction";

            worksheet.Cell(36, 15).Value = p.time_between_hunts;
            worksheet.Cell(37, 15).Value = p.gestation;
            worksheet.Cell(38, 15).Value = p.time_between_reproduction;
        }
    }
}