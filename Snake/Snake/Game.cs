using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Snake
{
    class Game
    {
        Field field;
        Snake Snake;
        TableRecords table = new TableRecords();



        int Score;


        //ConsoleKeyInfo keypress = new ConsoleKeyInfo();


        public ConsoleKeyInfo keypress = new ConsoleKeyInfo();

        bool gameOver;

        int Speed;

        int CursorPosition;

        public void MainMenu()
        {



            bool Exit = true;
            do
            {

                Console.Clear();
                Console.WriteLine("Press any button to start new game.");
                Console.WriteLine("Press E to exit.");
                Console.WriteLine("Press R to show records.");
                if(File.Exists("SavedGame.dat"))
                {
                    Console.WriteLine("Press L to load game.");
                }
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
                    case ConsoleKey.L:
                        {
                            if (File.Exists("SavedGame.dat"))
                            {
                                LoadGame();
                            }
                            
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

        public bool Pause()
        {
            Console.CursorTop = CursorPosition + 1;
            Console.WriteLine("Press any button to continue.");
            Console.WriteLine("Press E to exit to menu.");
            Console.WriteLine("Press S to save and exit.");


            keypress = Console.ReadKey(true);

            switch (keypress.Key)
            {
                case ConsoleKey.S:
                    {
                        SaveGame();
                        return true;
                    }
                case ConsoleKey.E:
                    {
                        return true;
                    }
                default:
                    {
                        
                        break;
                    }
            }

            return false;
        }

        public void SaveGame()
        {
            SavedGame S = new SavedGame(Snake, field , Score, Speed);

            FileStream fileStream = File.Create("SavedGame.dat");
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(fileStream, S);
            fileStream.Close();





        }

        public void LoadGame()
        {
            try
            {
                SavedGame S;
                FileStream fileStream = File.OpenRead("SavedGame.dat");
                BinaryFormatter binaryFormatter = new BinaryFormatter();


                S = binaryFormatter.Deserialize(fileStream) as SavedGame;
                fileStream.Close();

                if(S != null)
                {
                    Snake = S.snake;
                    field = new Field(S.height,S.width);
                    
                    Score = S.Score;
                    Speed = S.Speed;
                    field.DrawField();
                    field.AddEat(S.eat);

                    gameOver = false;



                    
                    game();
                    File.Delete("SavedGame.dat");
                }
                
            }
            catch
            {
                
            }
        }

        bool CheckInput()
        {
            while (Console.KeyAvailable)
            {
                keypress = Console.ReadKey(true);
                if (keypress.Key == ConsoleKey.Escape)
                    Environment.Exit(0);

                if (keypress.Key == ConsoleKey.S)
                {
                    return true;
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

            return false;
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
            CursorPosition = Console.CursorTop;
            Console.WriteLine("You score: {0}", Score);
            Console.WriteLine("Press S to pause.");
            while (!gameOver)
            {
                if(CheckInput())
                {
                    if(Pause())
                    {
                        break;
                    }
                    Console.Clear();
                    Console.CursorTop = CursorPosition;
                    Console.WriteLine("You score: {0}", Score);
                    Console.WriteLine("Press S to pause.");
                }
                Snake.Step();

                Step();

                field.DrawSnake(Snake.snake);
                field.DrawField();
                Thread.Sleep(Speed);
            }
            if(gameOver)
            {
                GameOver();
            }

            
        }

        public void GameOver()
        {
            Console.Clear();
            
            if(table == null)
                table = new TableRecords();
            table.addScore(Score);

            table.ShowTable();

           
            
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
                        Console.CursorTop = CursorPosition;
                        Console.WriteLine("You score: {0}", Score);
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
