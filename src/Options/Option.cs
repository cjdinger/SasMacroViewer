using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAS.MacroViewer
{
    public class Option
    {
        /// <summary>
        /// Option name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Value type (boolean, number, char)
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Current value
        /// </summary>
        public string Setting { get; set; }
        /// <summary>
        /// Description of the option
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Implementation level: host, portable, GRAPH
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// Where you can issue it: startup or anytime
        /// </summary>
        public string Start { get; set; }
        /// <summary>
        /// Option group
        /// </summary>
        public string Group { get; set; }
    }
}
