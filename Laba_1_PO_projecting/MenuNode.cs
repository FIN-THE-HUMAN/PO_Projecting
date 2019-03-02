using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_1_PO_projecting
{
    public class MenuNode
    {
        public string Description;
        public Action Action;

        public MenuNode(string description, Action action)
        {
            Description = description;
            Action = action;
        }
    }
}
