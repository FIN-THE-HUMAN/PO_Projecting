using System;

namespace Laba_1_PO_projecting
{
    class Program
    {
        static TextFile AddTextFileInDirectory(Directory directory)
        {
            Console.WriteLine("Введите название файла");
            var name = Console.ReadLine();

            Console.WriteLine("Введите содержимое файла");
            var text = Console.ReadLine();
            var t = new TextFile(name, text);
            directory.Add(t);

            return t;
        }

        static Directory AddDirectoryInDirectory(Directory directory)
        {
            Console.WriteLine("Введите название дирректории");
            var name = Console.ReadLine();
            var d = new Directory(name);
            directory.Add(d);

            return d;
        }

        static void OpenFile(IContent content)
        {
            if (content is TextFile)
                OpenText((TextFile)content);
            else if (content is Directory)
                OpenDirectory((Directory)content);
            else Console.WriteLine("Неизвестный тип файла");
        }

        static Menu getDirectoryMenu(Directory directory)
        {
            Menu openFileMenu = new Menu("Выберите файл для открытия");
            Menu addFileMenu = new Menu("Выберите тип файла:");
            Menu deleteFileMenu = new Menu("Выберите файл для удаления:");

            var list = directory.GetContent();
            for (int i = 0; i < list.Count; i++)
            {
                var temp = list[i];
                openFileMenu.Add(temp.Name, () => {
                    OpenFile(temp);
                    openFileMenu.Close();
                });
            }
            
            for (int i = 0; i < list.Count; i++)
            {
                var temp = list[i];
                var j = i;
                deleteFileMenu.Add(temp.Name, () => {
                    directory.Remove(temp);
                    openFileMenu.RemoveById(j + 1);
                    deleteFileMenu.RemoveById(j + 1);
                    deleteFileMenu.Close();
                });
            }


            addFileMenu.Add(
                "Добавить Текстовый файл",
                () =>
                {
                    var textFile = AddTextFileInDirectory(directory);
                    openFileMenu.Add(textFile.Name, () => { OpenText(textFile); openFileMenu.Close(); });
                    int id = openFileMenu.Nodes.Count;
                    deleteFileMenu.Add(textFile.Name, () => {

                        directory.Remove(textFile);
                        openFileMenu.RemoveById(id);
                        deleteFileMenu.RemoveById(id);
                        deleteFileMenu.Close(); });
                    addFileMenu.Close();
                }
            );
            addFileMenu.Add(
               "Добавить Каталог",
                () =>
                {
                    var _directory = AddDirectoryInDirectory(directory);
                    openFileMenu.Add(_directory.Name, () => { OpenDirectory(_directory); openFileMenu.Close(); });
                    int id = openFileMenu.Nodes.Count;
                    deleteFileMenu.Add(_directory.Name, () => {

                        directory.Remove(_directory);
                        openFileMenu.RemoveById(id);
                        deleteFileMenu.RemoveById(id);
                        deleteFileMenu.Close(); });
                    addFileMenu.Close();
                }
            );

            Menu menu = new Menu("Дирректория " + directory.Name + "\nВыберите действие: ");
            menu.Add("Открыть содержимое файла", () => openFileMenu.Start());
            menu.Add("Добавить файл или каталог", () => addFileMenu.Start());
            menu.Add("Удалить файл или каталог", () => deleteFileMenu.Start());
            return menu;
        }

        static void OpenText(TextFile file)
        {
            Menu subMenu = new Menu($"Действия для этого файла {file.Name}:");
            Console.WriteLine(file.Text);
            subMenu.Start();
        }

        static void OpenDirectory(Directory directory)
        {
            Console.WriteLine("Дирректория " + directory.Name);
            directory.GetContent().ForEach((e) => Console.WriteLine(e.Name));
            Console.WriteLine();
            Menu menu = getDirectoryMenu(directory);
            menu.Start();
        }

        static void Main(string[] args)
        {
            Directory MainDirectory = new Directory("MainDirectory");

            var MainMenu = getDirectoryMenu(MainDirectory);
            MainMenu.Start();

            //var s = Extentions.ReadUntilCTRL(); Console.WriteLine();
            //Console.WriteLine(s);


            Console.ReadKey();
        }
    }
}
