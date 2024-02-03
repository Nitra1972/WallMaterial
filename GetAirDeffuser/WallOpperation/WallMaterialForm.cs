using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using GetAirDeffuser.GetElementFrome_Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WallMaterial.WallOpperation;

namespace GetAirDeffuser.DiffuserOpperation
{

    public class WallMaterialForm
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


        public void GetWallMaterial(Document doc)
        {

            foreach (var bultInCat in new BuiltInCategory[] { BuiltInCategory.OST_Walls, BuiltInCategory.OST_Floors, BuiltInCategory.OST_Roofs })
            {
                foreach (Element elType in new ElemensCollectionOfType().GetCollection(doc, bultInCat))
                {

                    if (elType is WallType wallType)
                    {
                        try
                        {
                            wallType.Name = new LayerWidth().OperateLayer(wallType.GetCompoundStructure().GetLayers().Where(v => v.Width != 0), doc, string.Empty);
                            
                        }
                        catch { }
                        
                    }

                    if (elType is FloorType floorType)
                    {
                        try
                        {
                            floorType.Name = new LayerWidth().OperateLayer(floorType.GetCompoundStructure().GetLayers().Where(v => v.Width != 0), doc, string.Empty);
                        }
                        catch { }
                    }
                    if (elType is RoofType roofType)
                    {
                        try
                        {
                            roofType.Name = new LayerWidth().OperateLayer(roofType.GetCompoundStructure().GetLayers().Where(v => v.Width != 0), doc, string.Empty);
                    }
                        catch { }
                }
                    if (elType is CeilingType ceilingType)
                    {
                        //foreach (CompoundStructureLayer layer in ceilingType.GetCompoundStructure().GetLayers().Where(v => v.Width != 0))
                        //{
                        //    CeilingType.Name = GetLayerForm(count, laireName) + "_" + OperateLayer(layer, doc, exemplaireName);
                        //}
                    }


                }
            }
        }
    }
}
           

                
    







//        if (elType is WallType wallType)
//    {
//        var exType = wallType as WallType;
//    }
//    if (elType is FloorType floorType)
//    {
//        var exType = floorType as FloorType;
//    }
//    if (elType is RoofType roofType)
//    {
//        var exType = roofType as RoofType;
//    }
//    if (elType is CeilingType ceilingType)
//    {
//        var exType = ceilingType as CeilingType;
//    }

//        foreach (CompoundStructureLayer layer in colletion)
//    {
//        wallType.GetCompoundStructure().GetLayers().Where(v => v.Width != 0);
//        wallType.Name = GetLayerForm(count, exemplaireName) + "_" + totalExemplaireWidth.ToString();
//    }

//    if (elType is WallType wallType)
//        WallType.Name = GetLayerForm(count, laireName) + "_" + totalExemplaireWidth.ToString();
//    return WallType.Name;
//}






//public void GetWallMaterial(Document doc)
//{
//    int count = 0;
//    string exemplaireName = string.Empty;
//    string exemplaireNameWithPref = string.Empty;
//    string wallName = string.Empty;
//    string floorName = string.Empty;
//    string roofName = string.Empty;
//    string ceilingName = string.Empty;
//    double exemplaireWidth = 0;
//    double totalExemplaireWidth = 0;

//    foreach (var bultInCat in new BuiltInCategory[] { BuiltInCategory.OST_Walls, BuiltInCategory.OST_Floors, BuiltInCategory.OST_Roofs })
//    {
//        foreach (Element elType in new ElemensCollectionOfType().GetCollection(doc, bultInCat))
//        {

//            if (elType is WallType wallType)
//            {
//                try
//                {
//                    wallName = string.Empty;
//                    exemplaireName = string.Empty;
//                    count = 0;
//                    totalExemplaireWidth = 0;

//                    wallType.GetCompoundStructure().GetLayers().Where(v => v.Width != 0);
//                    wallType.Name = GetLayerForm(count, exemplaireName) + "_" + totalExemplaireWidth.ToString();
//                }
//                catch
//                {
//                }
//            }

//            if (elType is FloorType floorType)
//            {
//                try
//                {
//                    floorName = string.Empty;
//                    count = 0;
//                    totalExemplaireWidth = 0;
//                    floorType.GetCompoundStructure().GetLayers().Where(v => v.Width != 0);

//                    floorType.Name = GetLayerForm(count, exemplaireName) + "_" + totalExemplaireWidth.ToString();
//                }
//                catch
//                {
//                }
//            }

//            if (elType is RoofType roofType)
//            {
//                try
//                {
//                    roofName = string.Empty;
//                    count = 0;
//                    totalExemplaireWidth = 0;
//                    roofType.GetCompoundStructure().GetLayers().Where(v => v.Width != 0);

//                    roofType.Name = GetLayerForm(count, exemplaireName) + "_" + totalExemplaireWidth.ToString();


//                }
//                catch
//                {
//                }
//            }

//            if (elType is CeilingType ceilingType)
//            {
//                try
//                {
//                    ceilingName = string.Empty;
//                    count = 0;
//                    totalExemplaireWidth = 0;
//                    foreach (CompoundStructureLayer layer in ceilingType.GetCompoundStructure().GetLayers().Where(v => v.Width != 0))
//                    {

//                        ElementId elId = layer.MaterialId;
//                        Material exemplaireLayerMaterial = doc.GetElement(elId) as Material;
//                        exemplaireName = ceilingName + exemplaireLayerMaterial.Name + '-' + Math.Round(layer.Width * 304.8).ToString();
//                        count++;
//                        totalExemplaireWidth = totalExemplaireWidth + Math.Round(layer.Width * 304.8);

//                    }
//                    ceilingType.Name = GetLayerForm(count, exemplaireName) + "_" + totalExemplaireWidth.ToString();
//                }
//                catch
//                {
//                }

//            }



//            //wallName = string.Empty;
//            //count = 0;
//            //totalExemplaireWidth = 0;







