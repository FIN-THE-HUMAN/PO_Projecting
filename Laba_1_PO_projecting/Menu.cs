using System;
using System.Collections.Generic;

namespace Laba_1_PO_projecting
{
    public class Menu
    {
        public int end { get; protected set; } = 0;
        public string MenuText { get; protected set; }
        public bool IsClosed = false;
        public List<MenuNode> Nodes { get; protected set;}

        public Menu(string menuText)
        {
            MenuText = menuText;
            Nodes = new List<MenuNode>();
        }

        public void Add(string description, Action action)
        {
            Nodes.Add(new MenuNode(description, action));
        }

        public void RemoveById(int id)
        {
            Nodes.RemoveAt(id - 1);
        }

        public void Show()
        {
            Console.WriteLine(MenuText);
            Console.WriteLine(end + ") Закрыть меню");
            for(int i = 0; i < Nodes.Count; i++)
                Console.WriteLine(i + 1 + ") " + Nodes[i].Description);
        }

        public void Start()
        {
            IsClosed = false;
            int key = -1;
            while (true)
            {
                Show();
                if(!Int32.TryParse(Console.ReadLine(), out key) || key < 0 || key > Nodes.Count)
                {
                    Console.WriteLine($"{key} вне диапазона значений");
                    continue;
                }

                if (key == end) break;

                Nodes[key - 1].Action();

                if (IsClosed) break;

            }
            Console.WriteLine();
        }

        public void Close()
        {
            IsClosed = true;
        }
    }
}
