using Autodesk.Revit.DB.ExtensibleStorage;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetAirDeffuser.GetElementFrome_Model
{
    internal class GetLinkDocument
    {
        public static Document linkDocument = null;
        public static void GetLink(Document doc)
        {
           
            foreach (RevitLinkInstance link in new ElemensCollectionOfClass().GetCollection(doc, typeof(RevitLinkInstance)))
            {
                if (link.GetLinkDocument() != null)
                {
                    linkDocument=link.GetLinkDocument();
                }
            }
        }
    }
}
