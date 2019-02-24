using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Fragment_Field
    {
        public char oldCharacter { get; private set;}
        public char newCharacter;
        public ConsoleColor oldColor { get; private set;}
        public ConsoleColor newColor;
        int x;
        int y;

        public bool changes { get; private set; }

        public void ChangesTrue()
        {
            changes = true;
            newCharacter = oldCharacter;
            newColor = oldColor;
            oldCharacter = ' ';
            oldColor = ConsoleColor.Gray;
        }

        public Fragment_Field(char Character, ConsoleColor color, int x, int y)
        {
            newCharacter = Character;
            newColor = color;
            this.x = x;
            this.y = y;
            changes = true;
        }

        public Fragment_Field(int x, int y) : this(' ', ConsoleColor.Gray, x, y) { }

        public void setCaracter(char newCharacter)
        {
            this.newCharacter = newCharacter;
            changes = !(newCharacter == oldCharacter);
        }

        public void setColor(ConsoleColor color)
        {
            newColor = color;
            
            changes = !(newColor == oldColor);
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
                Console.ForegroundColor = newColor;
                oldColor = newColor;
                Console.SetCursorPosition(x, y);
                Console.Write(newCharacter);
                oldCharacter = newCharacter;
                Console.ForegroundColor = ConsoleColor.Gray;
                changes = false;
            }
        }

    }
}
