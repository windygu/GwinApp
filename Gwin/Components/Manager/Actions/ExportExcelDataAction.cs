using App.Gwin.Application.BAL;
using App.Gwin.DataModel.ModelInfo;
using App.Gwin.Entities;
using FastExcel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Gwin.Components.Manager.Actions
{
    public class ExportExcelDataAction : BaseDataAction
    {
        public IGwinBaseBLO EntityBLO { set; get; }
        public Dictionary<string, object> FilterValues { get; private set; }

        public ExportExcelDataAction(IGwinBaseBLO EntityBLO, Dictionary<string, object> FilterValues)
        {
            this.EntityBLO = EntityBLO;
            this.FilterValues = FilterValues;

            this.Text = "Export to Excel";
            this.Width = 120;
            this.Height = 45;
           
            this.Click += ExportExcelDataAction_Click;
        }

        private void ExportExcelDataAction_Click(object sender, EventArgs e)
        {
            List<BaseEntity> ListData = EntityBLO.Recherche(FilterValues).Cast<BaseEntity>().ToList();

            // FileDialog
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "xsl files (*.xls)|*.xls|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = EntityBLO.ConfigEntity.GwinEntity.PluralName;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog1.FileName += ".xlsx";
                saveFileDialog1.OpenFile().Close() ;

                this.CreateExcelFile(saveFileDialog1.FileName, ListData);

                // Save CSV File  
                //saveFileDialog1.FileName += ".xls";
                //if ((myStream = saveFileDialog1.OpenFile()) != null)
                //{
                //    CreateFile(new StreamWriter(myStream), ListData);
                //    myStream.Close();
                //}
            }
        }

        /// <summary>
        /// Excel Version
        /// </summary>
        /// <param name="wr"></param>
        /// <param name="ListData"></param>
        private void CreateExcelFile(string fileName, List<BaseEntity> ListData)
        {
           
            FileInfo outputFile = new FileInfo(fileName);
            FileInfo templateFile = new FileInfo("Template.xlsx");

            // Read Lisr Properties
            List<PropertyInfo> ListProperties = new GwinPropertiesManager()
                .GetPropertiesShowenInEntryForm(this.EntityBLO.TypeEntity);

            if (outputFile.Exists)
            {
                outputFile.Delete();
                outputFile = new FileInfo(fileName);
            }

            Console.WriteLine();
            Console.WriteLine("DEMO WRITE 1");

          //  Stopwatch stopwatch = new Stopwatch();

            using (FastExcel.FastExcel fastExcel = new FastExcel.FastExcel(templateFile, outputFile))
            {
                Worksheet worksheet = new Worksheet();
                List<Row> rows = new List<Row>();

                int RowNumber = 1;

                // Write  Titles
                int columnNumber = 1;
                List<Cell> cells = new List<Cell>();
                foreach (var item in ListProperties)
                {
                    cells.Add(new Cell(columnNumber, item.Name.ToString().ToUpper()));
                    columnNumber++;
                }
                rows.Add(new Row(RowNumber, cells));


                // Write List Data
                RowNumber++;
                foreach (BaseEntity itemEntity in ListData)
                {

                    cells = new List<Cell>();
                    columnNumber = 1;
                    foreach (var itemProperty in ListProperties)
                    {
                        // if Property is Simple type or ManyToOne type 
                        if (itemProperty.PropertyType.Name != "List`1")
                        {
                            if (itemProperty.GetValue(itemEntity) != null)
                            {
                                Cell cell = new Cell(columnNumber, itemProperty.GetValue(itemEntity).ToString());
                                cells.Add(cell);
                            }

                            else
                                cells.Add(new Cell(columnNumber, ""));
                        }else
                        {
                            // Many To Many Cell
                            if (itemProperty.GetValue(itemEntity) != null)
                            {
                                IList liste_ManytoManyValue = (IList) itemProperty.GetValue(itemEntity);

                                if(liste_ManytoManyValue != null)
                                {
                                    string ManyToManyDataString = "";
                                    foreach (var item in liste_ManytoManyValue)
                                    {
                                        ManyToManyDataString += item + " - \r\n";
                                    }
                                    Cell cell = new Cell(columnNumber, ManyToManyDataString);
                                    cells.Add(cell);

                                }else
                                {
                                    Cell cell = new Cell(columnNumber, "");
                                    cells.Add(cell);
                                }
                               

                                // Save ManyToMany List to anther Sheet
                            }

                            else
                                cells.Add(new Cell(columnNumber, ""));

                        }
                       

                        // if Property id List : ManyToMany
                        columnNumber++;
                    }

                    rows.Add(new Row(RowNumber, cells));
                    RowNumber++;

                }

                worksheet.Rows = rows;

                fastExcel.Write(worksheet, "Data");
            }
        }



      


        /// <summary>
        /// Create CSV File Data
        /// </summary>
        /// <param name="wr"></param>
        /// <param name="ListData"></param>
        private void CreateCSVFile(StreamWriter wr, List<BaseEntity> ListData)
        {


            // Titles
            foreach (var item in this.EntityBLO.TypeEntity.GetProperties())
            {
                wr.Write(item.Name.ToString().ToUpper() + "\t");
            }

            wr.WriteLine();

            //write Entites to excel file
            foreach (BaseEntity itemEntity in ListData)
            {


                foreach (var itemProperty in this.EntityBLO.TypeEntity.GetProperties())
                {
                    if (itemProperty.GetValue(itemEntity) != null)
                        wr.Write(itemProperty.GetValue(itemEntity).ToString().ToUpper() + "\t");
                    else
                        wr.Write("\t");
                }
                //go to next line
                wr.WriteLine();

            }
            //close file
            wr.Close();


        }
    }
}
