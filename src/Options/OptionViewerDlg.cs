using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAS.Tasks.Toolkit;
using SAS.Shared.AddIns;
using System.Data.OleDb;

namespace SAS.MacroViewer
{
    public partial class OptionViewerDlg : BaseToolsForm
    {
        int widthChGroup = 100;
        double dServerVer = 9.2;
        List<Option> Options = new List<Option>();
        public OptionViewerDlg(ISASTaskConsumer3 consumer, string taskID) : base(consumer,taskID)
        {
            InitializeComponent();

            // for sorting in the list view
            lvOptions.ColumnClick += new ColumnClickEventHandler(OnOptionsColumnClick);
            chGroup.Width = lvOptions.ShowGroups ? 0 : widthChGroup;

            LoadServers();
            RefreshValues();

            SendMessage(txtFilter.Handle, EM_SETCUEBANNER, 0, "Filter results");
            
            UpdateSelectedOptionInfo();
        }

        /// <summary>
        /// Handler for changing the opacity of the dialog window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTransparencyChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = sender as ToolStripMenuItem;
            if (menu == tsTran100)
            {
                this.Opacity = 1;
                tsTran100.Checked = true;
                tsTran75.Checked = false;
                tsTran50.Checked = false;
            }
            if (menu == tsTran50)
            {
                this.Opacity = 0.5;
                tsTran100.Checked = false;
                tsTran50.Checked = true;
                tsTran75.Checked = false;
            }
            if (menu == tsTran75)
            {
                this.Opacity = 0.75;
                tsTran100.Checked = false;
                tsTran50.Checked = false;
                tsTran75.Checked = true;
            }

        }

        private void btnGroupToggle_Click(object sender, EventArgs e)
        {
            if (!lvOptions.ShowGroups)
                widthChGroup = chGroup.Width;

            lvOptions.ShowGroups = !lvOptions.ShowGroups;
            chGroup.Width = lvOptions.ShowGroups ? 0 : Math.Min(widthChGroup, 100);

        }

        // clear the filter text box
        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtFilter.Text = String.Empty;
        }

        void OnOptionsColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                lvOptions.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (lvOptions.Sorting == SortOrder.Ascending)
                    lvOptions.Sorting = SortOrder.Descending;
                else
                    lvOptions.Sorting = SortOrder.Ascending;
            }

            // Call the sort method to manually sort.
            lvOptions.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
            this.lvOptions.ListViewItemSorter = new ListItemComparer(e.Column,
                                                              lvOptions.Sorting);

        }
        /// <summary>
        /// Initialize the combobox with servers
        /// </summary>
        private void LoadServers()
        {
            cmbServers.BeginUpdate();
            cmbServers.Items.Clear();
            cmbServers.DisplayMember = "Name";
            foreach (SasServer s in SasServer.GetSasServers())
            {
                cmbServers.Items.Add(s);
            }
            cmbServers.Text = Consumer.AssignedServer;
            cmbServers.EndUpdate();
        }

        #region Event handlers and overrides
        protected override void OnClosed(EventArgs e)
        {
            OptionsTask.isOneShowing = false;
            base.OnClosed(e);
        }
        #endregion

        // Refresh the list of options variables
        private void RefreshValues()
        {
            bool bGroups = lvOptions.ShowGroups;
            try
            {
                RetrieveOptionValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Unable to retrieve option values from {0}: {1}", cmbServers.Text, ex.Message), "Error");
            }

            UpdateOptionsListView(bGroups);
        }

        private void UpdateOptionsListView(bool bGroups)
        {
            Dictionary<string, ListViewGroup> groups = new Dictionary<string, ListViewGroup>();
            lvOptions.ShowGroups = true;
            lvOptions.BeginUpdate();
            lvOptions.Items.Clear();
            lvOptions.Groups.Clear();
            foreach (Option o in GetFilteredOptions())
            {
                ListViewGroup g = null;
                ListViewItem lvi = new ListViewItem(new string[] { o.Name, o.Setting, o.Group }, g);
                lvi.Tag = o;
                if (!groups.ContainsKey(o.Group))
                {
                    groups.Add(o.Group, new ListViewGroup(o.Group));
                    lvOptions.Groups.Add(groups[o.Group]);
                }
                lvi.Group = groups[o.Group];
                lvOptions.Items.Add(lvi);
            }
            lvOptions.EndUpdate();
            lvOptions.ShowGroups = bGroups;

            stsMsgLabel.Text = string.Format("Showing {0} option values", GetFilteredOptions().Count);
        }

        // update the list with the matching options/values
        private void OnFilterTextChanged(object sender, EventArgs e)
        {
            UpdateOptionsListView(lvOptions.ShowGroups);
        }

        private List<Option> GetFilteredOptions()
        {
            List<Option> list = new List<Option>();
            if (txtFilter.Text.Trim().Length == 0)
            {
                var results = from o in Options
                              select o;
                foreach (Option opt in results) list.Add(opt);
                return list;
            }
            else
            {
                var results = from o in Options
                              where
                                  (o.Name.ToUpper().Contains(txtFilter.Text.ToUpper())) ||
                                  (o.Setting.ToUpper().Contains(txtFilter.Text.ToUpper())) ||
                                  (o.Group.ToUpper().Contains(txtFilter.Text.ToUpper()))
                              select o;
                foreach (Option opt in results) list.Add(opt);
                return list;
            }
        }

        #region Sorting in the list view

        // Sort handlers for the list view columns
        private int sortColumn = -1;
        void lvOptions_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                lvOptions.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (lvOptions.Sorting == SortOrder.Ascending)
                    lvOptions.Sorting = SortOrder.Descending;
                else
                    lvOptions.Sorting = SortOrder.Ascending;
            }

            // Call the sort method to manually sort.
            lvOptions.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
            this.lvOptions.ListViewItemSorter = new ListItemComparer(e.Column,
                                                              lvOptions.Sorting);
        }

        #endregion
        private void RetrieveOptionValues()
        {

            SasServer s = cmbServers.SelectedItem as SasServer;
            dServerVer = 9.2;
            string ver = s.GetSasMacroValue("SYSVER");
            try
            {
                dServerVer = Convert.ToDouble(ver);
            }
            catch { }

            
            using (System.Data.OleDb.OleDbConnection dbConnection = s.GetOleDbConnection())
            {

                //----- make provider connection
                dbConnection.Open();

                //----- Read values from query command
                string sql = @"select * from sashelp.vallopt order by optname";
                OleDbCommand cmdDB = new OleDbCommand(sql, dbConnection);
                OleDbDataReader dataReader = cmdDB.ExecuteReader(CommandBehavior.CloseConnection);
                try
                {
                    Options = new List<Option>();
                    while (dataReader.Read())
                    {
                        Option opt = new Option()
                        {
                            Name = dataReader["optname"].ToString(),
                            Setting = dataReader["setting"].ToString(),
                            Type = dataReader["opttype"].ToString(),
                            Description = dataReader["optdesc"].ToString(),
                            Level = dataReader["level"].ToString(),
                            Start = dServerVer > 9.2 ? dataReader["optstart"].ToString() : "",
                            Group = dataReader["group"].ToString()
                        };

                         if (opt.Level.ToUpper() == "GRAPH")
                        {
                            opt.Group = "GRAPH";
                            opt.Level = "Portable";
                            opt.Start = "OPTIONS or GOPTIONS statement";
                        }
                         switch (opt.Start.ToLower())
                        {
                            case "anytime": opt.Start = "OPTIONS statement or startup";
                                break;
                            case "startup": opt.Start = "Startup only";
                                break;
                            case "": opt.Start = opt.Start = "(requires SAS 9.3 or later to determine)";
                                break;
                            default: break;
                        };


                        Options.Add(opt);
                    }

                }

                finally
                {
                    dataReader.Close();
                    dbConnection.Close();
                }

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshValues();
        }

        private void OnSelectionChanged(object sender, EventArgs e)
        {
            UpdateSelectedOptionInfo();
        }

        private void UpdateSelectedOptionInfo()
        {
            if (lvOptions.SelectedItems.Count == 1)
            {
                pnlValues.Visible = true;
                lblOptValue.Visible = true;
                txtDesc.Visible = true;
                Option o = lvOptions.SelectedItems[0].Tag as Option;
                gbOptionInfo.Text = string.Format("About {0}", o.Name);
                txtWhere.Text = o.Start;
                txtCurrentValue.Text = o.Setting;
                txtDesc.Text = o.Description;

                if (gbOptionInfo.Visible)
                    fetchAdditionalDetails(o);
            }
            else if (lvOptions.SelectedItems.Count > 1)
            {
                gbOptionInfo.Text = "<multiple options selected>";
                pnlValues.Visible = false;
            }
            else if (lvOptions.SelectedItems.Count == 0)
            {
                gbOptionInfo.Text = "<no option selected>";
                pnlValues.Visible = false;
            }
        }

        private void fetchAdditionalDetails(Option o)
        {
            string whereset = "", startup = "", fullval="";
            if (o.Group == "GRAPH")
            {
                txtHowset.Text = "<not applicable for Graph options>";
                txtStartup.Text = "<not applicable for Graph options>";
            }
            else
            {
                getOptionInfo(o.Name, ref whereset, ref startup, ref fullval);
                txtHowset.Text = whereset;
                txtStartup.Text = startup;
                txtCurrentValue.Text = fullval;
            }
        }

        string optionDetails = 
            "%let _egopthowset = %sysfunc(getoption({0},,howset)); \n" +
            "%let _egoptfullval = %sysfunc(getoption({0})); \n";    
        string optionStartup = "%let _egoptstartup = %sysfunc(getoption({0},,startupvalue));";
        /// <summary>
        /// Get the details about the SAS option 
        /// and its value
        /// </summary>
        /// <param name="optionName">Name of the option</param>
        /// <param name="whereset">return value: where the value was set</param>
        /// <param name="startup">return value: value at startup</param>
        /// <param name="fullval">return value: full value of the option</param>
        private void getOptionInfo(string optionName, 
            ref string whereset, 
            ref string startup, 
            ref string fullval)
        {
            whereset = "<cannot determine>";
            startup = "<cannot determine>";
            try
            {
                SAS.Tasks.Toolkit.SasSubmitter submitter = 
                    new SasSubmitter(cmbServers.Text);
                if (!submitter.IsServerBusy())
                {
                    string outLog;
                    string program = string.Format(
                        optionDetails +
                        (dServerVer > 9.2 ? optionStartup : ""), 
                        optionName);
                    bool success = submitter.SubmitSasProgramAndWait(program, out outLog);
                    if (success)
                    {
                        SasServer s = new SasServer(cmbServers.Text);
                        whereset = s.GetSasMacroValue("_EGOPTHOWSET");
                        fullval = s.GetSasMacroValue("_EGOPTFULLVAL");
                        if (dServerVer > 9.2) startup = s.GetSasMacroValue("_EGOPTSTARTUP");
                    }
                }
            }
            catch 
            { 
            }
        }

        private void tsbtnToggleDetails_Click(object sender, EventArgs e)
        {
            gbOptionInfo.Visible = !gbOptionInfo.Visible;
            ShowDetails = gbOptionInfo.Visible;
        }

        private void onSelectedServerChanged(object sender, EventArgs e)
        {
            RefreshValues();
        }

        private void tsBtnAbout_Click(object sender, EventArgs e)
        {
            AboutDlg dlg = new AboutDlg("SAS Options viewer");
            dlg.ShowDialog(this);
        }
    }
}
