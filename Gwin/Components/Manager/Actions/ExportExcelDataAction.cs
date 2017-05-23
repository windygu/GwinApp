using App.Gwin.Application.BAL;
using App.Gwin.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            IList ListData = EntityBLO.Recherche(FilterValues);

            // FileDialog
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "xsl files (*.xls)|*.xls|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog1.FileName += ".xls";
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    CreateFile(new StreamWriter(myStream), ListData);
                    myStream.Close();
                }
            }
        }

        private void CreateFile(StreamWriter wr,IList ListData)
        {

            try
            {
                // Titles
                foreach (var item in this.EntityBLO.TypeEntity.GetProperties())
                {
                    wr.Write(item.Name.ToString().ToUpper() + "\t");
                }

                wr.WriteLine();

                //write Entites to excel file
                foreach (var itemEntity in ListData)
                {
                    var obj = Convert.ChangeType(itemEntity, this.EntityBLO.TypeEntity);

                    foreach (var itemProperty in this.EntityBLO.TypeEntity.GetProperties())
                    {
                        if (itemProperty.GetValue(obj) != null)
                            wr.Write(itemProperty.GetValue(obj).ToString().ToUpper() + "\t");
                        else
                            wr.Write("\t");
                    }
                    //go to next line
                    wr.WriteLine();

                }
                //close file
                wr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
