using Autodesk.Revit.DB;
using GetAirDeffuser.GetElementFrome_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetAirDeffuser.DiffuserOpperation
{
   public class WallMaterialForm
    {
        
        public void GetWallMaterial(Document doc)
        {
            foreach (Element element in new ElemensCollection().GetCollection(doc, BuiltInCategory.OST_Walls))
            {
                Wall wall = element as Wall;
                WallType wallType = wall.WallType;  
            }

            foreach (Element elType in new ElemensCollectionOfType().GetCollection(doc, BuiltInCategory.OST_Walls))
            {
                WallType wallType = elType as WallType;
            }
        }
    }
}
