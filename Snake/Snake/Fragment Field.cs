using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Fragment_Field
    {
        public char c { get; private set;}
        public ConsoleColor color { get; private set;}

        int x;
        int y;

        public bool changes { get; private set; }



        public Fragment_Field(char c, ConsoleColor color, int x, int y)
        {
            this.c = c;
            this.color = color;
            this.x = x;
            this.y = y;
            changes = true;
        }

        public Fragment_Field(int x, int y) : this(' ', ConsoleColor.Gray, x, y) { }

        public void setCaracter(char c)
        {
            this.c = c;
            changes = true;
        }

        public void setColor(ConsoleColor color)
        {
            this.color = color;
            changes = true;
        }

        public void setPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
            changes = true;

        }

        public void Print()
        {
            if (changes)
            {
                Console.CursorVisible = false;
                Console.ForegroundColor = color;
                Console.SetCursorPosition(x, y);
                Console.Write(c);
                Console.ForegroundColor = ConsoleColor.Gray;
                changes = false;
            }
        }

    }
}
