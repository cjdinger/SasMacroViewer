using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAS.MacroViewer
{
    /// <summary>
    /// Simple structure to keep the macro variable names/values
    /// </summary>
    public class MacroVar
    {
        /// <summary>
        /// Variable name
        /// </summary>
        public string Name {get; set;}
        /// <summary>
        /// Scope: GLOBAL or AUTOMATIC
        /// </summary>
        public string Scope { get; set; }
        /// <summary>
        /// Current assigned value
        /// </summary>
        public string CurrentValue { get; set; }
    }


}
