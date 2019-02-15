using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace Snake
{
    class Game
    {
        Field field = new Field(20, 20);
        Snake Snake;

        public ConsoleKeyInfo keypress = new ConsoleKeyInfo();

        bool gameOver;

        //string dir, pre_dir;

        void CheckInput()
        {
            while (Console.KeyAvailable)
            {
                keypress = Console.ReadKey(true);
                if (keypress.Key == ConsoleKey.Escape)
                    Environment.Exit(0);

                if (keypress.Key == ConsoleKey.S)
                {
                    //pre_dir = dir;
                    //dir = "STOP";
                }
                else if (keypress.Key == ConsoleKey.LeftArrow)
                {
                    Snake.setDirection(direction.left);

                }
                else if (keypress.Key == ConsoleKey.RightArrow)
                {
                    Snake.setDirection(direction.right);
                }
                else if (keypress.Key == ConsoleKey.UpArrow)
                {
                    Snake.setDirection(direction.up);
                }
                else if (keypress.Key == ConsoleKey.DownArrow)
                {
                    Snake.setDirection(direction.down);
                }
            }

            
        }

        public void StartGmae()
        {
            gameOver = false;

            Snake = new Snake(10,10);

            field.DrawSnake(Snake.snake);
            field.addEat();
            field.DrawField();

            Gmae();
        }

        public void Gmae()
        {
            while(!gameOver)
            {
                CheckInput();
                Snake.Step();

                Step();

                field.DrawSnake(Snake.snake);
                field.DrawField();
                Thread.Sleep(100);
            }
        }

        private void Step()
        {
            char c = field.getChar(Snake.snake[0].x,Snake.snake[0].y);
            switch (c)
            {
                case '▄':
                case '▀':
                case '█':
                case '■':
                    {
                        gameOver = true;
                        break;
                    }
                case 'x':
                    {
                        Snake.Eat(Snake.snake[0].x, Snake.snake[0].y);
                        field.addEat();
                        break;
                    }
            }
        }
            





    }
}
