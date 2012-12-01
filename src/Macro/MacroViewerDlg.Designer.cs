namespace SAS.MacroViewer
{
    partial class MacroViewerDlg
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MacroViewerDlg));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.stsMsgLabel = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.tsbtnToggleExpression = new System.Windows.Forms.ToolStripButton();
            this.tsBtnAbout = new System.Windows.Forms.ToolStripButton();
            this.cmbServers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvMacros = new System.Windows.Forms.ListView();
            this.chVariable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chScope = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.gbEvaluate = new System.Windows.Forms.GroupBox();
            this.txtEval = new System.Windows.Forms.TextBox();
            this.btnSolve = new System.Windows.Forms.Button();
            this.lblValue = new System.Windows.Forms.Label();
            this.txtExpression = new System.Windows.Forms.TextBox();
            this.btnSolveTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip.SuspendLayout();
            this.pnlServer.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.gbEvaluate.SuspendLayout();
            this.SuspendLayout();
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
            this.btnSolveTip.SetToolTip(this.btnClearFilter, resources.GetString("btnClearFilter.ToolTip"));
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
            this.tsbtnToggleExpression,
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
            // tsbtnToggleExpression
            // 
            this.tsbtnToggleExpression.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbtnToggleExpression, "tsbtnToggleExpression");
            this.tsbtnToggleExpression.Name = "tsbtnToggleExpression";
            this.tsbtnToggleExpression.Click += new System.EventHandler(this.tsbtnToggleExpression_Click);
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
            this.cmbServers.SelectedIndexChanged += new System.EventHandler(this.cmbServers_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lvMacros
            // 
            this.lvMacros.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chVariable,
            this.chValue,
            this.chScope});
            this.lvMacros.ContextMenuStrip = this.contextMenu;
            resources.ApplyResources(this.lvMacros, "lvMacros");
            this.lvMacros.FullRowSelect = true;
            this.lvMacros.GridLines = true;
            this.lvMacros.Name = "lvMacros";
            this.lvMacros.UseCompatibleStateImageBehavior = false;
            this.lvMacros.View = System.Windows.Forms.View.Details;
            // 
            // chVariable
            // 
            resources.ApplyResources(this.chVariable, "chVariable");
            // 
            // chValue
            // 
            resources.ApplyResources(this.chValue, "chValue");
            // 
            // chScope
            // 
            resources.ApplyResources(this.chScope, "chScope");
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyMenuItem});
            this.contextMenu.Name = "contextMenu";
            resources.ApplyResources(this.contextMenu, "contextMenu");
            // 
            // copyMenuItem
            // 
            this.copyMenuItem.Name = "copyMenuItem";
            resources.ApplyResources(this.copyMenuItem, "copyMenuItem");
            this.copyMenuItem.Click += new System.EventHandler(this.OnCopyMacroAssignments);
            // 
            // splitContainer
            // 
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lvMacros);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.gbEvaluate);
            // 
            // gbEvaluate
            // 
            this.gbEvaluate.Controls.Add(this.txtEval);
            this.gbEvaluate.Controls.Add(this.btnSolve);
            this.gbEvaluate.Controls.Add(this.lblValue);
            this.gbEvaluate.Controls.Add(this.txtExpression);
            resources.ApplyResources(this.gbEvaluate, "gbEvaluate");
            this.gbEvaluate.Name = "gbEvaluate";
            this.gbEvaluate.TabStop = false;
            // 
            // txtEval
            // 
            resources.ApplyResources(this.txtEval, "txtEval");
            this.txtEval.BackColor = System.Drawing.SystemColors.Info;
            this.txtEval.Name = "txtEval";
            this.txtEval.ReadOnly = true;
            // 
            // btnSolve
            // 
            resources.ApplyResources(this.btnSolve, "btnSolve");
            this.btnSolve.Name = "btnSolve";
            this.btnSolveTip.SetToolTip(this.btnSolve, resources.GetString("btnSolve.ToolTip"));
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // lblValue
            // 
            resources.ApplyResources(this.lblValue, "lblValue");
            this.lblValue.Name = "lblValue";
            // 
            // txtExpression
            // 
            resources.ApplyResources(this.txtExpression, "txtExpression");
            this.txtExpression.Name = "txtExpression";
            // 
            // MacroViewerDlg
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.pnlServer);
            this.Controls.Add(this.statusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "MacroViewerDlg";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.pnlServer.ResumeLayout(false);
            this.pnlServer.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.gbEvaluate.ResumeLayout(false);
            this.gbEvaluate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Panel pnlServer;
        private System.Windows.Forms.ComboBox cmbServers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvMacros;
        private System.Windows.Forms.ColumnHeader chVariable;
        private System.Windows.Forms.ColumnHeader chValue;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnGroupToggle;
        private System.Windows.Forms.ToolStripStatusLabel stsMsgLabel;
        private System.Windows.Forms.ToolStripDropDownButton transButton;
        private System.Windows.Forms.ToolStripMenuItem tsTran50;
        private System.Windows.Forms.ToolStripMenuItem tsTran75;
        private System.Windows.Forms.ToolStripMenuItem tsTran100;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox gbEvaluate;
        private System.Windows.Forms.TextBox txtEval;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txtExpression;
        private System.Windows.Forms.ToolTip btnSolveTip;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyMenuItem;
        private System.Windows.Forms.ColumnHeader chScope;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.ToolStripButton tsBtnAbout;
        private System.Windows.Forms.ToolStripButton tsbtnToggleExpression;
    }
}