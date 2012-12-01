using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAS.Shared.AddIns;
using SAS.Tasks.Toolkit;
using System.Data.OleDb;
using SAS.Tasks.Toolkit.Controls;
using System.Runtime.InteropServices;

namespace SAS.MacroViewer
{
    /// <summary>
    /// Tool-style window to show the macro variables
    /// </summary>
    public partial class MacroViewerDlg : BaseToolsForm
    {

        List<MacroVar> MacroVars { get; set; }

        int widthChScope = 70;
        public MacroViewerDlg(ISASTaskConsumer3 consumer, string taskID)
            : base(consumer, taskID)
        {

            InitializeComponent();

            this.ShowInTaskbar = false;

            // for sorting in the list view
            lvMacros.ColumnClick += new ColumnClickEventHandler(lvMacros_ColumnClick);
            chScope.Width = lvMacros.ShowGroups ? 0 : widthChScope;
            
            LoadServers();
            RefreshValues();

            SendMessage(txtFilter.Handle, EM_SETCUEBANNER, 0, "Filter results");
        }

        #region Event handlers and overrides
        protected override void OnClosed(EventArgs e)
        {
            MacroTask.isOneShowing = false;
            base.OnClosed(e);
        }


        private void cmbServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshValues();
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            SolveExpression(txtExpression.Text, cmbServers.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshValues();
        }

        
        private void btnGroupToggle_Click(object sender, EventArgs e)
        {
            if (!lvMacros.ShowGroups)
                widthChScope = chScope.Width;
           
            lvMacros.ShowGroups = !lvMacros.ShowGroups;
            chScope.Width = lvMacros.ShowGroups ? 0 : Math.Min(widthChScope,70);

        }

        private void OnSelectionChanged(object sender, EventArgs e)
        {
            copyMenuItem.Enabled = lvMacros.SelectedItems.Count > 0;
        }

        // update the list with the matching macros/values
        private void OnFilterTextChanged(object sender, EventArgs e)
        {
            UpdateMacroListView(lvMacros.ShowGroups);
        }

        // clear the filter text box
        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtFilter.Text = String.Empty;
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
        #endregion

        #region Sorting in the list view

        // Sort handlers for the list view columns
        private int sortColumn = -1;
        void lvMacros_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                lvMacros.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (lvMacros.Sorting == SortOrder.Ascending)
                    lvMacros.Sorting = SortOrder.Descending;
                else
                    lvMacros.Sorting = SortOrder.Ascending;
            }

            // Call the sort method to manually sort.
            lvMacros.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
            this.lvMacros.ListViewItemSorter = new ListItemComparer(e.Column,
                                                              lvMacros.Sorting);
        }

        #endregion

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

        /// <summary>
        /// Get the list of macro variables to show,
        /// applying a filter if one is specified.
        /// </summary>
        /// <returns></returns>
        private List<MacroVar> GetFilteredVars()
        {
            List<MacroVar> list = new List<MacroVar>();

            // no filter, so return all macro variables
            if (txtFilter.Text.Trim().Length == 0)
            {
                var results = from m in MacroVars
                              select m;
                foreach (MacroVar mv in results) list.Add(mv);
                return list;
            }
            else
            {
                // filter is specified, so match
                // the filter value on the macro name
                // and the macro value
                // Using "Contains" for a simple match,
                // but RegEx could provide more flexibility
                var results = from m in MacroVars
                    where
                        (m.Name.ToUpper().Contains(txtFilter.Text.ToUpper())) ||
                        (m.CurrentValue.ToUpper().Contains(txtFilter.Text.ToUpper()))
                    select m;
                foreach (MacroVar mv in results) list.Add(mv);
                return list;
            }
        }

        // Refresh the list of macro variables
        private void RefreshValues()
        {
            bool bGroups = lvMacros.ShowGroups;
            try
            {
                RetrieveMacroValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Unable to retrieve macro variables from {0}: {1}", cmbServers.Text, ex.Message), "Error");
            }
            
            UpdateMacroListView(bGroups);
        }

        private void UpdateMacroListView(bool bGroups)
        {
            lvMacros.ShowGroups = true;

            lvMacros.BeginUpdate();
            lvMacros.Items.Clear();
            lvMacros.Groups.Clear();

            ListViewGroup global = new ListViewGroup("Global");
            ListViewGroup auto = new ListViewGroup("Automatic");
            ListViewGroup local = new ListViewGroup("Local");
            lvMacros.Groups.Add(global);
            lvMacros.Groups.Add(auto);
            lvMacros.Groups.Add(local);
            foreach (MacroVar m in GetFilteredVars())
            {
                ListViewGroup g;
                switch (m.Scope.Trim().ToUpper())
                {
                    case ("AUTOMATIC"): g = auto; break;
                    case ("GLOBAL"): g = global; break;
                    case ("LOCAL"): g = local; break;
                    default: g = null; break;
                }
                ListViewItem lvi = new ListViewItem(new string[] { m.Name, m.CurrentValue, m.Scope }, g);
                lvi.Tag = m;
                lvMacros.Items.Add(lvi);
            }

            lvMacros.EndUpdate();
            lvMacros.ShowGroups = bGroups;

            stsMsgLabel.Text = string.Format("Showing {0} macro values", GetFilteredVars().Count);
        }

        /// <summary>
        /// Query to retrieve the macro values from the active server
        /// </summary>
        private void RetrieveMacroValues()
        {
            SasServer s = cmbServers.SelectedItem as SasServer;
            using (System.Data.OleDb.OleDbConnection dbConnection = s.GetOleDbConnection())
            {

                //----- make provider connection
                dbConnection.Open();

                //----- Read values from query command
                string sql = @"select * from sashelp.vmacro order by name";
                OleDbCommand cmdDB = new OleDbCommand(sql, dbConnection);
                OleDbDataReader dataReader = cmdDB.ExecuteReader(CommandBehavior.CloseConnection);
                try
                {
                    MacroVars = new List<MacroVar>();
                    while (dataReader.Read())
                    {
                        MacroVar var = new MacroVar()
                        {
                            Name = dataReader["name"].ToString(),
                            CurrentValue = dataReader["value"].ToString(),
                            Scope = dataReader["scope"].ToString()
                        };
                        MacroVars.Add(var);
                    }

                }

                finally
                {
                    dataReader.Close();
                    dbConnection.Close();
                }

            }
        }

        /// <summary>
        /// Submit a bit of code to assign a macro var to with the
        /// expression, and then retrieve the resulting value.
        /// If ERROR, show the error in the field instead
        /// </summary>
        /// <param name="expression">
        /// Expression to evaluate as macro expression
        /// </param>
        /// <param name="sasServer">
        /// Name of the SAS server
        /// </param>
        private void SolveExpression(string expression, string sasServer)
        {
            // set UI elements to default state
            txtEval.ForeColor = SystemColors.WindowText;
            Cursor c = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            // prepare to measure the time it takes to run
            DateTime start = DateTime.Now;
            try
            {
                if (!string.IsNullOrEmpty(expression))
                {
                    // disable solve button while running
                    btnSolve.Enabled = false;

                    string resolveProgram = 
                        string.Format("%let _egMacroQuickEval = {0};", 
                          expression);
                    string outLog;
                    SAS.Tasks.Toolkit.SasSubmitter submitter = new SasSubmitter(sasServer);

                    // show busy message if needed
                    if (submitter.IsServerBusy())
                    {
                        MessageBox.Show(
                            string.Format("Unable evaluate expression using {0}: Server is running another program.", 
                              sasServer), 
                              "Server busy");
                    }
                    else
                    {
                        // submit expression and wait
                        bool success = submitter.SubmitSasProgramAndWait(resolveProgram, out outLog);
                        if (success)
                        {
                            SasServer s = new SasServer(sasServer);
                            txtEval.Text = s.GetSasMacroValue("_EGMACROQUICKEVAL");

                            // scan output log for warning messages
                            string[] lines = outLog.Split('\n');
                            string msg = "";
                            foreach (string l in lines)
                            {
                                // WARNING lines prefixed with 'w'
                                if (l.StartsWith("w"))
                                {
                                    // color WARNINGs blue
                                    msg = msg + l.Substring(2) + Environment.NewLine;
                                    txtEval.ForeColor = Color.Blue;
                                }
                            }
                            txtEval.Text += Environment.NewLine + msg;
                        }
                        else
                        {
                            // scan output log for error lines
                            string[] lines = outLog.Split('\n');
                            string msg = "";
                            foreach (string l in lines)
                            {
                                // ERROR lines prefixed with 'e', WARNING with 'w'
                                if (l.StartsWith("w") || l.StartsWith("e"))
                                    msg = msg + l.Substring(2) + Environment.NewLine;
                            }
                            // color ERRORs red
                            txtEval.Text = msg;
                            txtEval.ForeColor = Color.Red;
                        }
                    }
                }
            }
            // catch any errant exceptions
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("Unable evaluate expression using {0}: {1}", 
                      sasServer, 
                      ex.Message), 
                      "Error");
            }
            // finally block to clean/reset UI controls
            finally
            {
                btnSolve.Enabled = true;
                Cursor.Current = c;
                // add summary with timing
                TimeSpan s = new TimeSpan(DateTime.Now.Ticks - start.Ticks);
                stsMsgLabel.Text = 
                    string.Format("Evaluated expression in {0} seconds", 
                      Convert.ToInt32(s.TotalSeconds));
            }
        }

        /// <summary>
        /// Capture the selected macro variables as a series
        /// of LET statements, to provide a simple template
        /// for setting these values within a program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCopyMacroAssignments(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (ListViewItem lvi in lvMacros.SelectedItems)
            {
                MacroVar mv = lvi.Tag as MacroVar;
                if (mv != null)
                {
                    if (mv.Scope == "AUTOMATIC")
                        sb.AppendFormat("/* AUTOMATIC variable {0} */\n%let {0} = {1};\n", mv.Name, mv.CurrentValue);
                    else
                        sb.AppendFormat("%let {0} = {1}; \n", mv.Name, mv.CurrentValue);
                }
            }
            try
            {
                Clipboard.SetData(System.Windows.Forms.DataFormats.Text, sb.ToString());
            }
            catch { }
        }

        private void tsBtnAbout_Click(object sender, EventArgs e)
        {
            AboutDlg dlg = new AboutDlg("SAS Macro Variable viewer");
            dlg.ShowDialog(this);
        }

        private void tsbtnToggleExpression_Click(object sender, EventArgs e)
        {
            splitContainer.Panel2Collapsed = !splitContainer.Panel2Collapsed;
            ShowDetails = !splitContainer.Panel2Collapsed;
        }



    }
}
