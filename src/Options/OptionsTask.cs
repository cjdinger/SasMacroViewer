using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SAS.Tasks.Toolkit;
using SAS.Shared.AddIns;

namespace SAS.MacroViewer
{
    [ClassId("F1613AFE-AA29-47E7-9920-DC80941AF440")]
    [IconLocation("SAS.MacroViewer.options.ico")]
    [InputRequired(InputResourceType.None)]
    [Version(4.3)]
    public class OptionsTask : SAS.Tasks.Toolkit.SasTask
    {
        #region Initialization
        public OptionsTask()
        {
            InitializeComponent();
            TaskCategory = Properties.Resources.TaskCategory;

        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsTask));
            // 
            // OptionsTask
            // 
            this.GeneratesReportOutput = false;
            this.GeneratesSasCode = false;
            this.ProcsUsed = "OPTIONS";
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
                OptionViewerDlg win = new OptionViewerDlg(Consumer, this.Clsid);
                isOneShowing = true;
                win.Show(Owner);
            }
            return ShowResult.Canceled;
        }
    }
}

