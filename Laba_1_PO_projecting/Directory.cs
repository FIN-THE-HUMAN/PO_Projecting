using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_1_PO_projecting
{
    public class Directory : IContent
    {

        public string Name { get; set; }
        private List<IContent> Content;

        public Directory(string name)
        {
            Content = new List<IContent>();
            Name = name;
        }

        public void Add(IContent content)
        {
            Content.Add(content);
        }

        public void Remove(IContent content)
        {
            Content.Remove(content);
        }

        public List<IContent> GetContent()
        {
            return Content;
        }
    }
}
