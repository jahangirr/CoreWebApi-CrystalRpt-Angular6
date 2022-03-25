using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrytalSupportedLibrary
{
     public class LoadEmptyString
    {
         public string GetMyEmptyString()
        {
            CrystalFullFramework.LoadEmptyString les = new CrystalFullFramework.LoadEmptyString();
            return les.GetEmptyString();
        }
    }
}
