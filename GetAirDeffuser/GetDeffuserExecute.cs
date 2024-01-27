﻿using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;




namespace GetAirDeffuser
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]

    public class GetDeffuserExecute : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication App = commandData.Application;
            Document doc = App.ActiveUIDocument.Document;
            UIDocument uidoc = new UIDocument(doc);

            using (Transaction tx01 = new Transaction(doc))
            {
                tx01.Start("Family activate");
               
                tx01.Commit();
            }

            return Result.Succeeded;
        }
    }
}
