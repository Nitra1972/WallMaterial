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
        public void OperateLayer(IEnumerable<CompoundStructureLayer> layerCollection, Document doc, out string laireName)
        {
            int count = 0;
            double totalWidth = 0;
            laireName = string.Empty;

            foreach (CompoundStructureLayer layer in layerCollection) 
            {
                ElementId elId = layer.MaterialId;
                Material exemplaireLayerMaterial = doc.GetElement(elId) as Material;
                laireName = laireName + exemplaireLayerMaterial.Name + '-' + Math.Round(layer.Width * 304.8).ToString();
                count++;
                totalWidth = totalWidth + Math.Round(layer.Width * 304.8);

            }

            new FinaiReNameType().GetLayerForm(count, ref laireName, totalWidth);
        }
    }
}
