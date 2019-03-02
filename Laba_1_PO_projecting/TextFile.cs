using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_1_PO_projecting
{
    public class TextFile : IContent
    {
        public string Name { get; set; }
        public string Text;

        public TextFile(string name, string text)
        {
            Name = name;
            Text = text;
        }

    }
}
