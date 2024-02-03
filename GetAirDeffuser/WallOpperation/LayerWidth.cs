using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallMaterial.WallOpperation
{
    public class LayerWidth
    {
        public string OperateLayer(IEnumerable<CompoundStructureLayer> layerCollection, Document doc, string laireName)
        {
            int count = 0;
            double totalWidth = 0;

            foreach (CompoundStructureLayer layer in layerCollection) 
            {
                ElementId elId = layer.MaterialId;
                Material exemplaireLayerMaterial = doc.GetElement(elId) as Material;
                laireName = laireName + exemplaireLayerMaterial.Name + '-' + Math.Round(layer.Width * 304.8).ToString();
                count++;
                totalWidth = totalWidth + Math.Round(layer.Width * 304.8);

            }

            return new FinaiReNameType().GetLayerForm(count, laireName, totalWidth);
        }
    }
}
