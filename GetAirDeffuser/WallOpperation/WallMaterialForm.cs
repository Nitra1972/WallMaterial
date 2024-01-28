using Autodesk.Revit.DB;
using GetAirDeffuser.GetElementFrome_Model;
using System;
using System.CodeDom;
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
            int count = 0;
            string wallName = string.Empty;

            foreach (Element elType in new ElemensCollectionOfType().GetCollection(doc, BuiltInCategory.OST_Walls))
            {
                WallType wallType = elType as WallType;

                wallName = string.Empty;
                count = 0;

                try
                {
                    foreach (CompoundStructureLayer layer in wallType.GetCompoundStructure().GetLayers())
                    {
                        ElementId elId = layer.MaterialId;
                        Material wallLayerMaterial = doc.GetElement(elId) as Material;
                        wallName = wallName + wallLayerMaterial.Name;
                        count++;

                    }
                     if (count ==1 && wallName.Contains("Бетон"))
                    {
                        wallName = "КЖ_" + wallName;
                    }
                    else
                    {
                        wallName = "АР_" + wallName; 
                    }
                    
                    wallType.Name = wallName;


                }
                catch
                {
                }
            }
        }
    }
}
