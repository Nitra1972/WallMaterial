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
        //public void GetLayerForm() 
        //{
        //    try
        //    {
        //        wallName = string.Empty;
        //        count = 0;
        //        totalExemplaireWidth = 0;
        //        foreach (CompoundStructureLayer layer in wallType.GetCompoundStructure().GetLayers().Where(v => v.Width != 0))
        //        {

        //            ElementId elId = layer.MaterialId;
        //            Material exemplaireLayerMaterial = doc.GetElement(elId) as Material;
        //            wallName = wallName + exemplaireLayerMaterial.Name + '-' + Math.Round(layer.Width * 304.8).ToString();
        //            count++;
        //            totalExemplaireWidth = totalExemplaireWidth + Math.Round(layer.Width * 304.8);

        //        }
        //        if (count == 1 && wallName.Contains("Бетон"))
        //        {
        //            wallName = "КЖ_" + wallName;
        //        }
        //        else
        //        {
        //            wallName = "АР_" + wallName;
        //        }

        //        wallType.Name = wallName + "_" + totalExemplaireWidth.ToString();


        //    }
        //    catch
        //    {
        //    }
        //}
        
        public void GetWallMaterial(Document doc)
        {
            int count = 0;
            string wallName = string.Empty;
            string floorName = string.Empty;
            string roofName = string.Empty;
            string ceilingName = string.Empty;
            double exemplaireWidth = 0;
            double totalExemplaireWidth = 0;

            foreach (var bultInCat in new BuiltInCategory[] {BuiltInCategory.OST_Walls, BuiltInCategory.OST_Floors, BuiltInCategory.OST_Roofs })
            {
                foreach (Element elType in new ElemensCollectionOfType().GetCollection(doc, bultInCat))
                {
                    if (elType is WallType wallType)
                    {

                        try
                        {
                            wallName = string.Empty;
                            count = 0;
                            totalExemplaireWidth = 0;
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
                    }

                    if (elType is FloorType floorType)
                    {
                        try
                        {
                            floorName = string.Empty;
                            count = 0;
                            totalExemplaireWidth = 0;
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
                    }

                    if (elType is RoofType roofType)
                    {
                        try
                        {
                            roofName = string.Empty;
                            count = 0;
                            totalExemplaireWidth = 0;
                            foreach (CompoundStructureLayer layer in roofType.GetCompoundStructure().GetLayers().Where(v => v.Width != 0))
                            {

                                ElementId elId = layer.MaterialId;
                                Material exemplaireLayerMaterial = doc.GetElement(elId) as Material;
                                roofName = roofName + exemplaireLayerMaterial.Name + '-' + Math.Round(layer.Width * 304.8).ToString();
                                count++;
                                totalExemplaireWidth = totalExemplaireWidth + Math.Round(layer.Width * 304.8);

                            }
                            if (count == 1 && roofName.Contains("Бетон"))
                            {
                                roofName = "КЖ_" + roofName;
                            }
                            else
                            {
                                roofName = "АР_" + roofName;
                            }

                            roofType.Name = roofName + "_" + totalExemplaireWidth.ToString();


                        }
                        catch
                        {
                        }
                    }

                    if (elType is CeilingType ceilingType)
                    {
                        try
                        {
                            ceilingName = string.Empty;
                            count = 0;
                            totalExemplaireWidth = 0;
                            foreach (CompoundStructureLayer layer in ceilingType.GetCompoundStructure().GetLayers().Where(v => v.Width != 0))
                            {

                                ElementId elId = layer.MaterialId;
                                Material exemplaireLayerMaterial = doc.GetElement(elId) as Material;
                                ceilingName = ceilingName + exemplaireLayerMaterial.Name + '-' + Math.Round(layer.Width * 304.8).ToString();
                                count++;
                                totalExemplaireWidth = totalExemplaireWidth + Math.Round(layer.Width * 304.8);

                            }
                            if (count == 1 && ceilingName.Contains("Бетон"))
                            {
                                ceilingName = "КЖ_" + ceilingName;
                            }
                            else if (count == 1)
                            {
                                roofName = "АР_" + ceilingName;
                            }
                            else
                            {
                                roofName = "АР_" + ceilingName;
                            }

                            ceilingType.Name = ceilingName + "_" + totalExemplaireWidth.ToString();


                        }
                        catch
                        {
                        }

                    }



                    //wallName = string.Empty;
                    //count = 0;
                    //totalExemplaireWidth = 0;

 
                     
                    
                }

            }



           
        }
    }
}
