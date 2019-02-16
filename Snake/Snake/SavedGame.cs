using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace Snake
{
    [Serializable]
    class SavedGame
    {
        public Snake snake;

        public Eat eat;

        public int height;
        public int width;

        public int Score;
        public int Speed;

        public SavedGame(Snake snake,Field field, int Score , int Speed )
        {
            this.snake = snake;

            eat = field.eat;
            height = field.height;
            width = field.width;

            this.Score = Score;
            this.Speed = Speed;
        }




    }
}
