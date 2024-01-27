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
            foreach (Element elType in new ElemensCollectionOfType().GetCollection(doc, BuiltInCategory.OST_Walls))
            {
                WallType wallType = elType as WallType;

                string wallName = string.Empty;
                var temp = wallType.GetCompoundStructure().GetLayers().FirstOrDefault();
                try
                {
                    foreach (CompoundStructureLayer layer in wallType.GetCompoundStructure().GetLayers())
                    {
                        ElementId elId = layer.MaterialId;
                        Material wallLayerMaterial = doc.GetElement(elId) as Material;
                        wallName = wallName + wallLayerMaterial.Name;

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
