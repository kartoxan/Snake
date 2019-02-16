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
        Field field;
        Snake Snake;
        TableRecords table;
        int Score;


        public ConsoleKeyInfo keypress = new ConsoleKeyInfo();

        bool gameOver;

        int Speed;


        public void PrintMenu()
        {
            if (table == null)
                table = new TableRecords();

            bool Exit = true;
            do
            {

                Console.Clear();
                Console.WriteLine("Press any button to start.");
                Console.WriteLine("Press E to exit.");
                Console.WriteLine("Press R to show records.");
                //Console.WriteLine("Press O to show options");



                keypress = Console.ReadKey(true);

                switch (keypress.Key)
                {
                    case ConsoleKey.R:
                        {
                            table.ShowTable();
                            break;
                        }
                    case ConsoleKey.E:
                        {
                            Exit = false;
                            break;
                        }
                    default:
                        {
                            StartGame();
                            break;
                        }
                }
            } while (Exit);

        }

        void CheckInput()
        {
            while (Console.KeyAvailable)
            {
                keypress = Console.ReadKey(true);
                if (keypress.Key == ConsoleKey.Escape)
                    Environment.Exit(0);

                if (keypress.Key == ConsoleKey.S)
                {

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

        public void StartGame()
        {
            gameOver = false;
            Score = 0;
            Speed = 100;
            field = new Field(25, 25);
            Snake = new Snake(10,10);
            field.DrawSnake(Snake.snake);
            field.addEat();
            field.DrawField();

            game();
        }

        public void game()
        {
            while(!gameOver)
            {
                CheckInput();
                Snake.Step();

                Step();

                field.DrawSnake(Snake.snake);
                field.DrawField();
                Thread.Sleep(Speed);
            }

            GameOver();
        }

        public void GameOver()
        {
            Console.Clear();
            //Console.WriteLine("Your score: {0}.", Score );
            //Console.WriteLine("Press any button.");
            
            if(table == null)
                table = new TableRecords();
            table.addScore(Score);

            table.ShowTable();

           
            Console.ReadKey();
            
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
                        Score += 20;
                        if (Score % 100 == 0 && Speed != 0)
                        {
                            Speed -= 5;
                        }


                        break;
                    }
            }
        }
            





    }
}
