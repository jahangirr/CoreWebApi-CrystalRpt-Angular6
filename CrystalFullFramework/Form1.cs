using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CrystalFullFramework.DataSetReport;

namespace CrystalFullFramework
{
    public partial class Form1 : Form
    {
        string[] _args ;

        public Form1(string[] args)
        {
            _args = args;
           
            InitializeComponent();



        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if(_args[1] == "Milton")
            {
                Milton mi = new Milton();

                DataSetReport dsr = new DataSetReport();

                MyCustomerDataTable mcdt = new MyCustomerDataTable();
                var row = mcdt.NewRow();
                row[0] = "1";
                row[1] = "Md. Shail Raha";
                row[2] = "45";
                row[3] = "Rangpur";
                mcdt.Rows.Add(row);

                var row1 = mcdt.NewRow();
                row1[0] = "2";
                row1[1] = "Md. Kuddus Boyati";
                row1[2] = "55";
                row1[3] = "Kishorgonj";
                mcdt.Rows.Add(row1);

                var row2 = mcdt.NewRow();
                row2[0] = "3";
                row2[1] = "Md. Leon Ark";
                row2[2] = "60";
                row2[3] = "Jossore";
                mcdt.Rows.Add(row2);


                dsr.Tables[0].Merge(mcdt);
                mi.SetDataSource(dsr);

                using (var stream = mi.ExportToStream(ExportFormatType.PortableDocFormat))
                {
                    
                    Properties.Settings.Default["FileValue"] = stream.ConvertToBase64();
                    Properties.Settings.Default.Save();          
                }
  
                string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                string Sql = "INSERT INTO Reports(ReportName, UserName,ReportTime, ReportData) VALUES ('"+ _args[1] + "', '" + _args[2] + "','"+DateTime.Now.ToString()+"', '"+ Properties.Settings.Default["FileValue"] .ToString()+ "')";

                using (SqlConnection oSqlConnection = new SqlConnection(ConnectionString))
                {
                    SqlCommand oSqlCommand = new SqlCommand(Sql, oSqlConnection);
                    try
                    {
                        oSqlConnection.Open();
                        oSqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message.ToString());
                    }
                    finally
                    {
                        oSqlCommand.Dispose();
                        oSqlConnection.Close();
                        oSqlConnection.Dispose();
                    }
                }




            }

            this.Close();
          

        }

         
        public string GetFileInfo(string reportName , string reportParameter)
        {
            CrystalReportCla crc = new CrystalReportCla();
           return  crc.CrytaReportShow(reportName, reportParameter);
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
