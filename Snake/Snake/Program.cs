using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Field f = new Field(25,25);

            f.DrawField();

            Console.ReadKey();
        }
    }
}
