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
        string laireName;


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
                            new LayerWidth().OperateLayer(wallType.GetCompoundStructure().GetLayers().Where(v => v.Width != 0), doc, out laireName);
                            wallType.Name = laireName;
                        }
                        catch { }
                        
                    }
                    if (elType is FloorType floorType)
                    {
                        try
                        {
                            new LayerWidth().OperateLayer(floorType.GetCompoundStructure().GetLayers().Where(v => v.Width != 0), doc, out laireName);
                            floorType.Name = laireName;
                        }
                        catch { }
                    }
                    //if (elType is RoofType roofType)
                    //{
                    //    try
                    //    {
                    //        roofType.Name = new LayerWidth().OperateLayer(roofType.GetCompoundStructure().GetLayers().Where(v => v.Width != 0), doc, ref laireName);
                    //    }
                    //    catch { }
                    //}
                    //if (elType is CeilingType ceilingType)
                    //{
                    //    try
                    //    {
                    //        ceilingType.Name = new LayerWidth().OperateLayer(ceilingType.GetCompoundStructure().GetLayers().Where(v => v.Width != 0), doc, ref laireName);
                    //    }
                    //    catch { }
                    //}
                   
                }
            }
        }
    }
}
           

                
    






