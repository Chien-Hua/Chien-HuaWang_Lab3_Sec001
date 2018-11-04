using System;
using System.Text;
using System.Threading.Tasks;
using LinkedListLibrary;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            List<double> list = new List<double>();

            list.InsertAtFront(44.55);
            list.Display();
            list.InsertAtFront(66.48);
            list.Display();
            list.InsertAtBack(777.3311);
            list.Display();
            list.InsertAtBack(234.11);
            list.Display();
            list.Search(44.2);
            list.Count();
            list.Avg();

            Console.WriteLine("The First element is :" + list.GetFirst());
            Console.WriteLine();
            Console.WriteLine("The Last element is :" + list.GetLast());
            Console.WriteLine();
        }
    }
    public static class Extentions
    {
        public static object GetFirst<T>(this List<T> list)
        {
            return list.FirstNode.Data;
        }
        public static object GetLast<T>(this List<T> list)
        {
            return list.LastNode.Data;
        }
    }
}
