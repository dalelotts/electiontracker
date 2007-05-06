using System;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.ui;
using ExceptionManager;
using log4net;
using log4net.Config;
using Spring.Context;
using Spring.Context.Support;

namespace edu.uwec.cs.cs355.group4.et.core {
    internal static class Program {
        private static readonly ILog LOG = LogManager.GetLogger(typeof (Program));

        [STAThread]
        public static void Main(string[] args) {
            try {
                UnhandledExceptionManager.AddHandler(false);
                UnhandledExceptionManager.TakeScreenshot = true;
                UnhandledExceptionManager.LogToFile = true;
                Application.EnableVisualStyles();
                XmlConfigurator.Configure();
                IApplicationContext ctx = ContextRegistry.GetContext();
                UIController controller = (UIController) ctx.GetObject("UIController");
                Application.Run(controller.getMDIForm());
            } catch (Exception ex) {
                LOG.Error(ex.Message, ex);
                HandledExceptionManager.ShowDialog(
                    "Unexpected Error - " + ex.GetType().Name + ".  This may be due to a programming bug.",
                    "When you click OK, applicaiton will close.",
                    "Restart the application, and try repeating your last action. Try alternative methods of performing the same action.",
                    ex, MessageBoxButtons.OK, MessageBoxIcon.Error,
                    HandledExceptionManager.UserErrorDefaultButton.Default);
            }
        }
    }
}