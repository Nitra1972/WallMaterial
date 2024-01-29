﻿using Autodesk.Revit.DB;
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
            double wallWidth = 0;
            double totalWallWidth = 0;

            foreach (var bultInCat in new BuiltInCategory[] {BuiltInCategory.OST_Walls, BuiltInCategory.OST_Floors, BuiltInCategory.OST_Roofs })
            {
                foreach (Element elType in new ElemensCollectionOfType().GetCollection(doc, bultInCat))
                {
                    WallType wallType = elType as WallType;
                    FloorType floorType = elType as FloorType;
                    RoofType roofType = elType as RoofType;

                    // переименовал все, что связано со стенами. Пример: wallName -> exemplaireName, wallWidth -> exemplaireWidth, totalWallWidth -> TotalExemplaireWidth

                    wallName = string.Empty;
                    count = 0;
                    totalWallWidth = 0;

                    try
                    {
                        foreach (CompoundStructureLayer layer in wallType.GetCompoundStructure().GetLayers().Where(v => v.Width != 0))
                        {

                            ElementId elId = layer.MaterialId;
                            Material wallLayerMaterial = doc.GetElement(elId) as Material;
                            wallName = wallName + wallLayerMaterial.Name + '-' + Math.Round(layer.Width * 304.8).ToString();
                            count++;
                            totalWallWidth = totalWallWidth + Math.Round(layer.Width * 304.8);

                        }
                        if (count == 1 && wallName.Contains("Бетон"))
                        {
                            wallName = "КЖ_" + wallName;
                        }
                        else
                        {
                            wallName = "АР_" + wallName;
                        }

                        wallType.Name = wallName + "_" + totalWallWidth.ToString();


                    }
                    catch
                    {
                    }
                }

            }



           
        }
    }
}
