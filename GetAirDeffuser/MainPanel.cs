using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GetAirDeffuser
{
    internal class MainPanel : IExternalApplication
    {
        static AddInId addInId = new AddInId(new System.Guid("0c60b2d9-6f37-41c0-a552-9f90f82f99c6"));

        public Result OnStartup(UIControlledApplication application)
        {
            string assemblyPath = Assembly.GetExecutingAssembly().Location;

            string tabName = "My Castom Tab";
            application.CreateRibbonTab(tabName);
            RibbonPanel ribbonPanel = application.CreateRibbonPanel(tabName, "Автоматизация");
            AddButton(ribbonPanel, "Button_1", assemblyPath, "GetAirDeffuser.WallMaterial", "Всплывающая подсказка");
            return Result.Succeeded;
        }

        private void AddButton(RibbonPanel ribbonPanel, string buttonName, string path, string linkToCommand, string toolTip)
        {
            var buttonData = new PushButtonData(buttonName, buttonName, path, linkToCommand);
            var button = ribbonPanel.AddItem(buttonData) as PushButton;
            button.ToolTip = toolTip;
            button.LargeImage = (ImageSource)new BitmapImage(new Uri(@"/MainPanel; component/Resources/icons8-инженерия-32.png", UriKind.RelativeOrAbsolute));
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}