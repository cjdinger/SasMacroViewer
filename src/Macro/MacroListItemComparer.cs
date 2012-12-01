using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace SAS.MacroViewer
{
    // Implements the manual sorting of items by column.
    class ListItemComparer : IComparer
    {
        private int col;
        private SortOrder order;
        public ListItemComparer()
        {
            col = 0;
            order = SortOrder.Ascending;
        }
        public ListItemComparer(int column, SortOrder order)
        {
            col = column;
            this.order = order;
        }
        public int Compare(object x, object y)
        {
            int returnVal = -1;
            returnVal = 
                String.Compare(((ListViewItem)x).SubItems[col].Text,
                               ((ListViewItem)y).SubItems[col].Text);
            // Determine whether the sort order is descending.
            if (order == SortOrder.Descending)
                // Invert the value returned by String.Compare.
                returnVal *= -1;
            return returnVal;
        }

    }
}
