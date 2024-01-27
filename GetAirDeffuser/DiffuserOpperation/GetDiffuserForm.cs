using Autodesk.Revit.DB;
using GetAirDeffuser.GetElementFrome_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetAirDeffuser.DiffuserOpperation
{
   public class GetDiffuserForm
    {
        
        public void GetDiffuser(Document doc)
        {
            View view = doc.ActiveView;
            Level elementLevel = new ElemensCollection().GetCollection(doc, BuiltInCategory.OST_Levels)
                .Where(v => v.LookupParameter("Фасад").AsDouble() == 0).FirstOrDefault() as Level;
            foreach (Element element in new ElemensCollection().GetCollection(doc, BuiltInCategory.OST_DuctTerminal))
            {
                
            }

        }
    }
}
