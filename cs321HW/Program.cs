using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpts321HW
{
    public class Program
    {
        static void Main(string[] args)
        {
            string userInput = null;
            Cpts321HW.BST values = new BST();
            Console.WriteLine("Please enter any amount of numbers all separated by a space");

            userInput = Console.ReadLine();

            //Console.WriteLine(userInput);

            values.Add(userInput);

            values.PrintInOrder();
            values.Statistics();
         }
    }
}
