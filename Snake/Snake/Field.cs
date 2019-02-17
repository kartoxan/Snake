using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Snake
{
    [Serializable]
    struct Eat//нужно для сохранения
    {
        public int x;
        public int y;

        public Eat(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Field
    {
        public int height;
        public int width;
        private Fragment_Field[,] field;

        public Eat eat;//нужно для сохранения

            


        public Field(int H,int W)
        {
            height = H;
            width = W;
            field = new Fragment_Field[height + 2, (width * 2) + 3];



            
            CreateField();
        }

        private void CreateField()
        {

            for (int i = 0; i < field.GetLength(1); i++)
            {
                field[0, i] = new Fragment_Field('▄', ConsoleColor.Gray,i, 0);
                field[field.GetLength(0) - 1, i] = new Fragment_Field('▀', ConsoleColor.Gray,i, field.GetLength(0) - 1);
            }

            for (int i = 1; i < field.GetLength(0) - 1; i++)
            {
                field[i, 0] = new Fragment_Field('█' , ConsoleColor.Gray, 0,i);
                field[i, field.GetLength(1) - 1] = new Fragment_Field('█', ConsoleColor.Gray, field.GetLength(1) - 1,i);
                for (int j = 2; j < field.GetLength(1) - 1; j += 2)
                {
                    field[i, j] = new Fragment_Field('·',ConsoleColor.Gray, j,i);
                }
            }

            for (int i = 0; i < field.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < field.GetLength(1) - 1; j++)
                {
                    if(field[i,j] == null)
                    {
                        field[i, j] = new Fragment_Field(j, i);
                    }
                }
            }

            DrawField(5, 0);

            //if(eat.x != 0 && eat.y != 0)
            //    field[eat.x, eat.y] = 'x';

        }



        public void DrawField()
        {
            
            //Console.SetCursorPosition(0, 0);
            
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for(int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j].Print();
                }
                //Console.WriteLine();
            }
            
        }

        public void ResetChanges()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j].ChangesTrue();
                }
            }
        }

        public void DrawField(int x, int y)
        {
            Console.Clear();
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j].setPosition(j + x, i + y);
                }
            }
            DrawField();
        }

        public void DrawSnake(List<ElementSnake> snake)
        {
            RemoveSnake();
            
            foreach(ElementSnake s in snake)
            {
                if(s.draw)
                {
                    
                    field[s.y, s.x * 2].setCaracter('■');
                    field[s.y, s.x * 2].setColor(ConsoleColor.Green);
                }
            }
        }

        public void RemoveSnake()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    
                    if (field[i, j].c == '■')
                    {
                        field[i, j].setCaracter('·');
                        field[i, j].setColor(ConsoleColor.Gray);
                    }
                    
                }
            }
        }


        public void addEat()
        {
            Random r = new Random();
            int x,y;
            do
            {

                x = r.Next(1, height);
                y = r.Next(1, width) * 2;
            } while (field[x, y].c != '·');
            eat = new Eat(x,y);
            field[x,y].setCaracter('x');
            field[x, y].setColor(ConsoleColor.Yellow);

        }

        public void AddEat(Eat eat)
        {
            if (eat.x != 0 && eat.y != 0)
                field[eat.x, eat.y].setCaracter('x');
            this.eat = eat;
        }

        


        

        public char getChar(int x, int y)
        {
            return field[y , x * 2].c;
        }




    }
}
