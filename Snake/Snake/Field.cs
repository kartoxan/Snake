﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Field
    {
        private int height;
        private int width;
        private char[,] field;

        public Field(int H,int W)
        {
            height = H;
            width = W;
            field = new char[height + 2, (width * 2) + 3];
            CreateField();
        }

        private void CreateField()
        {

            for(int i = 0; i < field.GetLength(1); i++)
            {
                field[0, i] = '▄';
                field[field.GetLength(0) - 1, i] = '▀';
            }

            for(int i = 1; i < field.GetLength(0) - 1;i++)
            {
                field[i, 0] = '█';
                field[i, field.GetLength(1) - 1] = '█';
                for (int j = 2; j < field.GetLength(1) - 1; j += 2)
                {
                    field[i, j] = '·';
                }
            }

        }



        public void DrawField()
        {
            for(int i = 0; i < field.GetLength(0); i++)
            {
                for(int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void DrawField(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            DrawField();
        }


    }
}