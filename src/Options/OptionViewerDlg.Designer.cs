namespace SAS.MacroViewer
{
    partial class OptionViewerDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionViewerDlg));
            this.pnlServer = new System.Windows.Forms.Panel();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnGroupToggle = new System.Windows.Forms.ToolStripButton();
            this.transButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsTran50 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTran75 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTran100 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbtnToggleDetails = new System.Windows.Forms.ToolStripButton();
            this.tsBtnAbout = new System.Windows.Forms.ToolStripButton();
            this.cmbServers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbOptionInfo = new System.Windows.Forms.GroupBox();
            this.pnlValues = new System.Windows.Forms.Panel();
            this.txtWhere = new System.Windows.Forms.Label();
            this.txtHowset = new System.Windows.Forms.Label();
            this.txtStartup = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtCurrentValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblOptValue = new System.Windows.Forms.Label();
            this.lblCurrentValue = new System.Windows.Forms.Label();
            this.lvOptions = new System.Windows.Forms.ListView();
            this.chOption = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.stsMsgLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.pnlServer.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.gbOptionInfo.SuspendLayout();
            this.pnlValues.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlServer
            // 
            this.pnlServer.Controls.Add(this.btnClearFilter);
            this.pnlServer.Controls.Add(this.txtFilter);
            this.pnlServer.Controls.Add(this.toolStrip);
            this.pnlServer.Controls.Add(this.cmbServers);
            this.pnlServer.Controls.Add(this.label1);
            resources.ApplyResources(this.pnlServer, "pnlServer");
            this.pnlServer.Name = "pnlServer";
            // 
            // btnClearFilter
            // 
            resources.ApplyResources(this.btnClearFilter, "btnClearFilter");
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // txtFilter
            // 
            resources.ApplyResources(this.txtFilter, "txtFilter");
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.TextChanged += new System.EventHandler(this.OnFilterTextChanged);
            // 
            // toolStrip
            // 
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnGroupToggle,
            this.transButton,
            this.tsbtnToggleDetails,
            this.tsBtnAbout});
            this.toolStrip.Name = "toolStrip";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnGroupToggle
            // 
            this.btnGroupToggle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnGroupToggle, "btnGroupToggle");
            this.btnGroupToggle.Name = "btnGroupToggle";
            this.btnGroupToggle.Click += new System.EventHandler(this.btnGroupToggle_Click);
            // 
            // transButton
            // 
            this.transButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.transButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsTran50,
            this.tsTran75,
            this.tsTran100});
            resources.ApplyResources(this.transButton, "transButton");
            this.transButton.Name = "transButton";
            // 
            // tsTran50
            // 
            this.tsTran50.CheckOnClick = true;
            this.tsTran50.Name = "tsTran50";
            resources.ApplyResources(this.tsTran50, "tsTran50");
            this.tsTran50.Click += new System.EventHandler(this.OnTransparencyChanged);
            // 
            // tsTran75
            // 
            this.tsTran75.CheckOnClick = true;
            this.tsTran75.Name = "tsTran75";
            resources.ApplyResources(this.tsTran75, "tsTran75");
            this.tsTran75.Click += new System.EventHandler(this.OnTransparencyChanged);
            // 
            // tsTran100
            // 
            this.tsTran100.Checked = true;
            this.tsTran100.CheckOnClick = true;
            this.tsTran100.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsTran100.Name = "tsTran100";
            resources.ApplyResources(this.tsTran100, "tsTran100");
            this.tsTran100.Click += new System.EventHandler(this.OnTransparencyChanged);
            // 
            // tsbtnToggleDetails
            // 
            this.tsbtnToggleDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbtnToggleDetails, "tsbtnToggleDetails");
            this.tsbtnToggleDetails.Name = "tsbtnToggleDetails";
            this.tsbtnToggleDetails.Click += new System.EventHandler(this.tsbtnToggleDetails_Click);
            // 
            // tsBtnAbout
            // 
            this.tsBtnAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsBtnAbout, "tsBtnAbout");
            this.tsBtnAbout.Name = "tsBtnAbout";
            this.tsBtnAbout.Click += new System.EventHandler(this.tsBtnAbout_Click);
            // 
            // cmbServers
            // 
            this.cmbServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServers.FormattingEnabled = true;
            resources.ApplyResources(this.cmbServers, "cmbServers");
            this.cmbServers.Name = "cmbServers";
            this.cmbServers.SelectedIndexChanged += new System.EventHandler(this.onSelectedServerChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // gbOptionInfo
            // 
            this.gbOptionInfo.Controls.Add(this.pnlValues);
            resources.ApplyResources(this.gbOptionInfo, "gbOptionInfo");
            this.gbOptionInfo.Name = "gbOptionInfo";
            this.gbOptionInfo.TabStop = false;
            // 
            // pnlValues
            // 
            this.pnlValues.Controls.Add(this.txtWhere);
            this.pnlValues.Controls.Add(this.txtHowset);
            this.pnlValues.Controls.Add(this.txtStartup);
            this.pnlValues.Controls.Add(this.txtDesc);
            this.pnlValues.Controls.Add(this.txtCurrentValue);
            this.pnlValues.Controls.Add(this.label3);
            this.pnlValues.Controls.Add(this.label2);
            this.pnlValues.Controls.Add(this.lblOptValue);
            this.pnlValues.Controls.Add(this.lblCurrentValue);
            resources.ApplyResources(this.pnlValues, "pnlValues");
            this.pnlValues.Name = "pnlValues";
            // 
            // txtWhere
            // 
            resources.ApplyResources(this.txtWhere, "txtWhere");
            this.txtWhere.Name = "txtWhere";
            // 
            // txtHowset
            // 
            resources.ApplyResources(this.txtHowset, "txtHowset");
            this.txtHowset.Name = "txtHowset";
            // 
            // txtStartup
            // 
            resources.ApplyResources(this.txtStartup, "txtStartup");
            this.txtStartup.Name = "txtStartup";
            this.txtStartup.ReadOnly = true;
            // 
            // txtDesc
            // 
            resources.ApplyResources(this.txtDesc, "txtDesc");
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            // 
            // txtCurrentValue
            // 
            resources.ApplyResources(this.txtCurrentValue, "txtCurrentValue");
            this.txtCurrentValue.Name = "txtCurrentValue";
            this.txtCurrentValue.ReadOnly = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lblOptValue
            // 
            resources.ApplyResources(this.lblOptValue, "lblOptValue");
            this.lblOptValue.Name = "lblOptValue";
            // 
            // lblCurrentValue
            // 
            resources.ApplyResources(this.lblCurrentValue, "lblCurrentValue");
            this.lblCurrentValue.Name = "lblCurrentValue";
            // 
            // lvOptions
            // 
            this.lvOptions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chOption,
            this.chValue,
            this.chGroup});
            resources.ApplyResources(this.lvOptions, "lvOptions");
            this.lvOptions.FullRowSelect = true;
            this.lvOptions.GridLines = true;
            this.lvOptions.Name = "lvOptions";
            this.lvOptions.UseCompatibleStateImageBehavior = false;
            this.lvOptions.View = System.Windows.Forms.View.Details;
            this.lvOptions.SelectedIndexChanged += new System.EventHandler(this.OnSelectionChanged);
            // 
            // chOption
            // 
            resources.ApplyResources(this.chOption, "chOption");
            // 
            // chValue
            // 
            resources.ApplyResources(this.chValue, "chValue");
            // 
            // chGroup
            // 
            resources.ApplyResources(this.chGroup, "chGroup");
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsMsgLabel});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // stsMsgLabel
            // 
            this.stsMsgLabel.Name = "stsMsgLabel";
            resources.ApplyResources(this.stsMsgLabel, "stsMsgLabel");
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.lvOptions);
            resources.ApplyResources(this.pnlOptions, "pnlOptions");
            this.pnlOptions.Name = "pnlOptions";
            // 
            // OptionViewerDlg
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.gbOptionInfo);
            this.Controls.Add(this.pnlServer);
            this.Controls.Add(this.statusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionViewerDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.pnlServer.ResumeLayout(false);
            this.pnlServer.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.gbOptionInfo.ResumeLayout(false);
            this.pnlValues.ResumeLayout(false);
            this.pnlValues.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.pnlOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlServer;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnGroupToggle;
        private System.Windows.Forms.ToolStripDropDownButton transButton;
        private System.Windows.Forms.ToolStripMenuItem tsTran50;
        private System.Windows.Forms.ToolStripMenuItem tsTran75;
        private System.Windows.Forms.ToolStripMenuItem tsTran100;
        private System.Windows.Forms.ComboBox cmbServers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbOptionInfo;
        private System.Windows.Forms.ListView lvOptions;
        private System.Windows.Forms.ColumnHeader chOption;
        private System.Windows.Forms.ColumnHeader chValue;
        private System.Windows.Forms.ColumnHeader chGroup;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel stsMsgLabel;
        private System.Windows.Forms.Panel pnlValues;
        private System.Windows.Forms.Label txtWhere;
        private System.Windows.Forms.Label txtHowset;
        private System.Windows.Forms.TextBox txtStartup;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtCurrentValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblOptValue;
        private System.Windows.Forms.Label lblCurrentValue;
        private System.Windows.Forms.ToolStripButton tsbtnToggleDetails;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.ToolStripButton tsBtnAbout;
    }
}