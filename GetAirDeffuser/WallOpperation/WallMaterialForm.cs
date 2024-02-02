using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
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
        public string GetLayerForm(int count, string laireName)
        {
            string totalName = string.Empty;
            if (count == 1 && laireName.Contains("Бетон"))
            {
                totalName = "КЖ_" + laireName;
            }
            else if (count == 1)
            {
                totalName = "АР_" + totalName;
            }
            else
            {
                totalName = "АР_" + laireName;
            }

            return totalName;
        }

        public string OperateLayer(IEnumerable<CompoundStructureLayer> colletion, Document doc, string wallName)
        {
            int count = 0;
            double totalExemplaireWidth = 0;
            string laireName = string.Empty;

            foreach (CompoundStructureLayer layer in colletion)
            {
                string exemplaireName = string.Empty;
                ElementId elId = layer.MaterialId;
                Material layerMaterial = doc.GetElement(elId) as Material;
                exemplaireName = wallName + layerMaterial.Name + '-' + Math.Round(layer.Width * 304.8).ToString();
                count++;
                totalExemplaireWidth = totalExemplaireWidth + Math.Round(layer.Width * 304.8);
            }

            if (elType is WallType wallType)
                WallType.Name = GetLayerForm(count, laireName) + "_" + totalExemplaireWidth.ToString();
            return WallType.Name;
        }


        public void GetWallMaterial(Document doc)
        {
            int count = 0;
            string exemplaireName = string.Empty;
            string exemplaireNameWithPref = string.Empty;
            string wallName = string.Empty;
            string floorName = string.Empty;
            string roofName = string.Empty;
            string ceilingName = string.Empty;
            double exemplaireWidth = 0;
            double totalExemplaireWidth = 0;

            foreach (var bultInCat in new BuiltInCategory[] { BuiltInCategory.OST_Walls, BuiltInCategory.OST_Floors, BuiltInCategory.OST_Roofs })
            {
                foreach (Element elType in new ElemensCollectionOfType().GetCollection(doc, bultInCat))
                {

                    if (elType is WallType wallType)
                    {
                        try
                        {
                            wallName = string.Empty;
                            exemplaireName = string.Empty;
                            count = 0;
                            totalExemplaireWidth = 0;

                            wallType.GetCompoundStructure().GetLayers().Where(v => v.Width != 0);
                            wallType.Name = GetLayerForm(count, exemplaireName) + "_" + totalExemplaireWidth.ToString();
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
                            floorType.GetCompoundStructure().GetLayers().Where(v => v.Width != 0);

                            floorType.Name = GetLayerForm(count, exemplaireName) + "_" + totalExemplaireWidth.ToString();
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
                            roofType.GetCompoundStructure().GetLayers().Where(v => v.Width != 0);

                            roofType.Name = GetLayerForm(count, exemplaireName) + "_" + totalExemplaireWidth.ToString();


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
                                exemplaireName = ceilingName + exemplaireLayerMaterial.Name + '-' + Math.Round(layer.Width * 304.8).ToString();
                                count++;
                                totalExemplaireWidth = totalExemplaireWidth + Math.Round(layer.Width * 304.8);

                            }
                            ceilingType.Name = GetLayerForm(count, exemplaireName) + "_" + totalExemplaireWidth.ToString();
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