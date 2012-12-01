using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAS.Tasks.Toolkit.Controls;
using System.Runtime.InteropServices;
using SAS.Shared.AddIns;
using System.Drawing;
using System.Windows.Forms;

namespace SAS.MacroViewer
{
    /// <summary>
    /// Base class for the utility display forms that are used in these tasks
    /// </summary>
    public class BaseToolsForm : TaskForm
    {
        // necessary constants for the 'filter' cue display
        // that is shown in the filter text box
        internal const int EM_SETCUEBANNER = 0x1501;
        internal const int EM_GETCUEBANNER = 0x1502;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern Int32 SendMessage(IntPtr hWnd, int msg,
                int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        // each task has a task ID
        private string TaskClassID = "";

        // each task tracks whether the Details portion is showing
        protected bool ShowDetails = true;

        // default constructor to help with the Designer view
        public BaseToolsForm() : base()
        {}

        /// <summary>
        /// Constructor to get a handle to the app (Consumer)
        /// and the current task class ID
        /// </summary>
        /// <param name="consumer">Handle to application</param>
        /// <param name="taskID">unique class ID for this type of task</param>
        public BaseToolsForm(ISASTaskConsumer3 consumer, string taskID) 
        {
            Consumer = consumer;
            TaskClassID = taskID;
        }

        /// <summary>
        /// Check to see if there are saved settings, and if so, restore them
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            // check if there are any settings stored for this task
            if (!string.IsNullOrEmpty
                (SAS.Tasks.Toolkit.Helpers.TaskUserSettings.ReadValue
                  (TaskClassID, "XCOORD")
                )
               )
            {
                // restore settings, if any, from previous invocations
                try
                {
                    int x = Convert.ToInt32
                        (SAS.Tasks.Toolkit.Helpers.TaskUserSettings.ReadValue
                          (TaskClassID, "XCOORD")
                        );
                    int y = Convert.ToInt32
                        (SAS.Tasks.Toolkit.Helpers.TaskUserSettings.ReadValue
                          (TaskClassID, "YCOORD")
                        );
                    Point p = new Point(x, y);
                    if (isPointOnScreen(p))
                    {
                        int w = Convert.ToInt32
                            (SAS.Tasks.Toolkit.Helpers.TaskUserSettings.ReadValue
                              (TaskClassID, "WIDTH")
                            );
                        int h = Convert.ToInt32
                            (SAS.Tasks.Toolkit.Helpers.TaskUserSettings.ReadValue
                              (TaskClassID, "HEIGHT")
                            );
                        this.Width = w;
                        this.Height = h;
                        this.Location = p;
                    }

                    this.ShowDetails = Convert.ToBoolean
                        (SAS.Tasks.Toolkit.Helpers.TaskUserSettings.ReadValue
                          (TaskClassID, "DETAILS")
                        );
                }
                catch
                { }
            }

            base.OnLoad(e);
        }

        /// <summary>
        /// Save the settings for this task
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            SAS.Tasks.Toolkit.Helpers.TaskUserSettings.WriteValue
                (TaskClassID, "XCOORD", Convert.ToString(this.Location.X));
            SAS.Tasks.Toolkit.Helpers.TaskUserSettings.WriteValue
                (TaskClassID, "YCOORD", Convert.ToString(this.Location.Y));
            SAS.Tasks.Toolkit.Helpers.TaskUserSettings.WriteValue
                (TaskClassID, "WIDTH", Convert.ToString(this.Size.Width));
            SAS.Tasks.Toolkit.Helpers.TaskUserSettings.WriteValue
                (TaskClassID, "HEIGHT", Convert.ToString(this.Size.Height));
            SAS.Tasks.Toolkit.Helpers.TaskUserSettings.WriteValue
                (TaskClassID, "DETAILS", Convert.ToString(this.ShowDetails));

            base.OnClosing(e);
        }

        /// <summary>
        /// Helper to determine of a coordinate point
        /// is visible on the screen
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        bool isPointOnScreen(Point p)
        {
            Screen[] screens = Screen.AllScreens;
            foreach (Screen screen in screens)
            {
                if (screen.WorkingArea.Contains(p))
                {
                    return true;
                }
            }
            return false;
        }
        
    }
}
