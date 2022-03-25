using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections;
using System.IO;

namespace CrystalFullFramework
{
    public static class Extensions
    {
        public static string ConvertToBase64(this Stream stream)
        {
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }

            string base64 = Convert.ToBase64String(bytes);
            return base64;
        }
    }


    public class ReportFactory
    {
        protected static Queue reportQueue = new Queue();

        protected static ReportClass CreateReport(Type reportClass)
        {
            object report = Activator.CreateInstance(reportClass);
            reportQueue.Enqueue(report);
            return (ReportClass)report;
        }

        public static ReportClass GetReport(Type reportClass)
        {
            //75 is my print job limit.
            if (reportQueue.Count > 75) ((ReportClass)reportQueue.Dequeue()).Dispose();
            return CreateReport(reportClass);
        }
    }


    public class CrystalReportCla
    {
        public string GetCrystalReport()
        {
            return Properties.Settings.Default["FileValue"].ToString();
        }
        public string CrytaReportShow(string reportName = "", string reportParamer = "")
        {


            //ReportClass cusRep = ReportFactory.GetReport(typeof(CrystalFullFramework.Milton));

            //string kk = "";


            // CrystalIntegreate.ReportDataSet 
            // var rd = new ReportDocument();

            //var url = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            ////correction in path to point it in Root directory
            //var mainFilepath = url.Replace("\\bin\\Debug", "") + "\\ReportFile\\" + reportName+".rpt";
            //rd.Load(mainFilepath);
            //CoreLibToCrystalReport.Report.DataSetResting repotDs = new Report.DataSetResting();
            //CoreLibToCrystalReport.Report.



            //var table = rds.Tables[0];
            //CrystalIntegreate.ReportDataSet.MyCustomerRow row = null;
            //row[0] = 1;
            //row[1] = "jaha";
            //row[2] = "Hossain";
            //myCustomerDataTable.AddMyCustomerRow(row);
            //rds.Tables[0].Merge(myCustomerDataTable);
            //cusRep.SetDataSource(rds);

            //using (var stream = cusRep.ExportToStream(ExportFormatType.PortableDocFormat))
            //{
            //    return stream.ConvertToBase64();
            //}

            return "";

        }

    }
}

