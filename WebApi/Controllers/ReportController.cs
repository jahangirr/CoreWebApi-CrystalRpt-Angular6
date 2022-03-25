using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CrystalFullFramework;
using WebApi.Data;

namespace WebApi.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {


        private readonly DataContext _context;

        public ReportController(DataContext context)
        {
            _context = context;
        }

        string? CrystalReportExePath = "";

        [HttpGet]
        [Route("Report/{ReportName}/{UserName=''}")]
        public IActionResult GetReportInof(string ReportName , string UserName)    
        {
            CrytalSupportedLibrary.LoadEmptyString les = new CrytalSupportedLibrary.LoadEmptyString();
            les.GetMyEmptyString();
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                this.LoadReferencedAssembly(assembly);
            }

            using (Process myProcess = new Process())
            {
                Process process = new Process();
                StringBuilder outputStringBuilder = new StringBuilder();

                try
                {
                    process.StartInfo.FileName = CrystalReportExePath;
                    process.StartInfo.Arguments = ReportName + " " + UserName;
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.UseShellExecute = false;
                    process.Start();
                  
                }
                finally
                {
                    process.Close();
                }
            }

           var rep =  _context.Reports.OrderByDescending(o => o.ReportId).Where(w => w.ReportName.ToUpper() == ReportName.ToUpper() && w.UserName.ToUpper() == UserName.ToUpper()).FirstOrDefault();
           return Ok(rep);
        }

        string? CrystalFullFramework = "CrystalFullFramework";
        private void LoadReferencedAssembly(Assembly assembly)
        {
            bool yesProceed = true;
            if(assembly.GetName().Name == CrystalFullFramework)
            {
                CrystalReportExePath = assembly.Location;
                yesProceed = false;
            }
            foreach (AssemblyName name in assembly.GetReferencedAssemblies())
            {
               if(!yesProceed)
                {
                    break;
                }
                if (!AppDomain.CurrentDomain.GetAssemblies().Any(a => a.FullName == name.FullName))
                {
                    try
                    {
                        this.LoadReferencedAssembly(Assembly.Load(name));
                    }
                    catch (Exception ex)
                    {
                       
                    }

                }
            }

           
        }
    }
}
