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
            string floorName = string.Empty;
            string roofName = string.Empty;
            double exemplaireWidth = 0;
            double totalExemplaireWidth = 0;

            foreach (var bultInCat in new BuiltInCategory[] {BuiltInCategory.OST_Walls, BuiltInCategory.OST_Floors, BuiltInCategory.OST_Roofs })
            {
                foreach (Element elType in new ElemensCollectionOfType().GetCollection(doc, bultInCat))
                {
                    WallType wallType = elType as WallType;
                    FloorType floorType = elType as FloorType;
                    RoofType roofType = elType as RoofType;

                    // переименовал все, что связано со стенами. Пример: wallWidth -> exemplaireWidth, totalWallWidth -> TotalExemplaireWidth

                    wallName = string.Empty;
                    count = 0;
                    totalExemplaireWidth = 0;

                    try
                    {
                        foreach (CompoundStructureLayer layer in wallType.GetCompoundStructure().GetLayers().Where(v => v.Width != 0))
                        {

                            ElementId elId = layer.MaterialId;
                            Material exemplaireLayerMaterial = doc.GetElement(elId) as Material;
                            wallName = wallName + exemplaireLayerMaterial.Name + '-' + Math.Round(layer.Width * 304.8).ToString();
                            count++;
                            totalExemplaireWidth = totalExemplaireWidth + Math.Round(layer.Width * 304.8);

                        }
                        if (count == 1 && wallName.Contains("Бетон"))
                        {
                            wallName = "КЖ_" + wallName;
                        }
                        else
                        {
                            wallName = "АР_" + wallName;
                        }

                        wallType.Name = wallName + "_" + totalExemplaireWidth.ToString();


                    }
                    catch
                    {
                    }
 
                     try
                    {
                        foreach (CompoundStructureLayer layer in floorType.GetCompoundStructure().GetLayers().Where(v => v.Width != 0))
                        {

                            ElementId elId = layer.MaterialId;
                            Material exemplaireLayerMaterial = doc.GetElement(elId) as Material;
                            floorName = floorName + exemplaireLayerMaterial.Name + '-' + Math.Round(layer.Width * 304.8).ToString();
                            count++;
                            totalExemplaireWidth = totalExemplaireWidth + Math.Round(layer.Width * 304.8);

                        }
                        if (count == 1 && floorName.Contains("Бетон"))
                        {
                            floorName = "КЖ_" + floorName;
                        }
                        else
                        {
                            floorName = "АР_" + floorName;
                        }

                        floorType.Name = floorName + "_" + totalExemplaireWidth.ToString();


                    }
                    catch
                    {
                    }

                    try
                    {
                        foreach (CompoundStructureLayer layer in roofType.GetCompoundStructure().GetLayers().Where(v => v.Width != 0))
                        {

                            ElementId elId = layer.MaterialId;
                            Material exemplaireLayerMaterial = doc.GetElement(elId) as Material;
                            roofName = roofName + exemplaireLayerMaterial.Name + '-' + Math.Round(layer.Width * 304.8).ToString();
                            count++;
                            totalExemplaireWidth = totalExemplaireWidth + Math.Round(layer.Width * 304.8);

                        }
                        if (count == 1 && floorName.Contains("Бетон"))
                        {
                            roofName = "КЖ_" + roofName;
                        }
                        else
                        {
                            roofName = "АР_" + roofName;
                        }

                        floorType.Name = roofName + "_" + totalExemplaireWidth.ToString();


                    }
                    catch
                    {
                    }
                }

            }



           
        }
    }
}
