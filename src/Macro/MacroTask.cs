using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SAS.Tasks.Toolkit;
using SAS.Shared.AddIns;

namespace SAS.MacroViewer
{
    [ClassId("d67af4a1-1628-455d-a411-8cf074318ef5")]
    [IconLocation("SAS.MacroViewer.macro.ico")]
    [InputRequired(InputResourceType.None)]
    [Version(4.3)]
    public class MacroTask : SAS.Tasks.Toolkit.SasTask
    {
        #region Initialization
        public MacroTask()
        {
            InitializeComponent();
            TaskCategory = Properties.Resources.TaskCategory;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MacroTask));
            // 
            // MacroTask
            // 
            this.GeneratesReportOutput = false;
            this.GeneratesSasCode = false;
            this.ProcsUsed = "Macro";
            this.ProductsRequired = "BASE";
            this.RequiresData = false;
            resources.ApplyResources(this, "$this");

        }

        #endregion

        // use a static flag to ensure we show only one instance (per process)
        internal static bool isOneShowing = false;
        public override ShowResult Show(System.Windows.Forms.IWin32Window Owner)
        {
            if (!isOneShowing)
            {
                MacroViewerDlg win = new MacroViewerDlg(Consumer,this.Clsid);
                isOneShowing = true;
                win.Show(Owner);
            }
            return ShowResult.Canceled;
        }
    }
}
