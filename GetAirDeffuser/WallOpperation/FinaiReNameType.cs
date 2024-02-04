using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallMaterial.WallOpperation
{
    public class FinaiReNameType
    {
        public void GetLayerForm(int count, ref string laireName, double totalWidth)
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

            totalName = totalName + "_" + totalWidth.ToString();

            laireName =  totalName;
        }
    }
}
