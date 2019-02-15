using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    enum direction
    {
        up,
        down,
        left,
        right,
    }

    struct ElementSnake
    {
        public int x;
        public int y;
        public bool draw;

        public ElementSnake(int x, int y, bool draw)
        {
            this.x = x;
            this.y = y;
            this.draw = draw;
        }

        public ElementSnake(int x, int y) : this(x, y, true) { }
    }

    class Snake
    {
        public direction preDirection;
        public direction newDirection;

        public List<ElementSnake> snake;

        public Snake()
        {
            preDirection = direction.right;
            newDirection = direction.right;

            snake = new List<ElementSnake>();

            snake.Add(new ElementSnake(4, 1));
            snake.Add(new ElementSnake(3, 1));
            snake.Add(new ElementSnake(2, 1));


        }

        public Snake(int x, int y)
        {
            preDirection = direction.right;
            newDirection = direction.right;

            snake = new List<ElementSnake>();
            for(int i = 0; i < 3; i ++)
                snake.Add(new ElementSnake(x - i, y));

        }

        public void Eat(int x,int y)
        {
            snake.Add(new ElementSnake(x, y, false));
        }

        public void Step()
        {

            for (int i = snake.Count - 1; i > 0; i--)
            {
                ElementSnake PreviousItem = snake[i];
                ElementSnake NextItem = snake[i - 1];
                if (!snake[i].draw)
                {
                    if(PreviousItem.x == NextItem.x && PreviousItem.y == NextItem.y)
                    {
                        PreviousItem.draw = true;
                    }
                }
                else
                {
                    PreviousItem.x = NextItem.x;
                    PreviousItem.y = NextItem.y;
                }

                snake[i] = PreviousItem;
                snake[i - 1] = NextItem;
            }

            switch(newDirection)
            {
                case direction.right:
                    {
                        snake[0] = new ElementSnake(snake[0].x + 1, snake[0].y);
                        break;
                    }
                case direction.left:
                    {
                        snake[0] = new ElementSnake(snake[0].x - 1, snake[0].y);
                        break;
                    }
                case direction.up:
                    {
                        snake[0] = new ElementSnake(snake[0].x, snake[0].y - 1);
                        break;
                    }
                case direction.down:
                    {
                        snake[0] = new ElementSnake(snake[0].x, snake[0].y + 1);
                        break;
                    }
            }
            preDirection = newDirection;
        }

        public void setDirection(direction direction)
        {
            switch(direction)
            {
                case direction.right:
                    {
                        if(preDirection != direction.left)
                        {
                            newDirection = direction;
                        }
                        break;
                    }
                case direction.left:
                    {
                        if (preDirection != direction.right)
                        {
                            newDirection = direction;
                        }
                        break;
                    }
                case direction.up:
                    {
                        if (preDirection != direction.down)
                        {
                            newDirection = direction;
                        }
                        break;
                    }
                case direction.down:
                    {
                        if (preDirection != direction.up)
                        {
                            newDirection = direction;
                        }
                        break;
                    }

            }
        }







    }
}
