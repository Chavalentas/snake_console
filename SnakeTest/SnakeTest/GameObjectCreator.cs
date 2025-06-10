using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class GameObjectCreator
    {
        private Random random;

        private Playfield playfield;

        private Snake snake;

        private List<GameObject> gameObjects;

        public GameObjectCreator(Random random, Playfield playfield, Snake snake, List<GameObject> gameObjects)
        {
            this.random = random ?? throw new ArgumentNullException("The value of the random generator cannot be null!");
            this.playfield = playfield ?? throw new ArgumentNullException("The value of the playfield cannot be null!");
            this.snake = snake ?? throw new ArgumentNullException("The value of the snake cannot be null!");
            this.gameObjects = gameObjects ?? throw new ArgumentNullException("The value of the game objects cannot be null!");
        }

        public GameObject Create()
        {
            int indicator = this.random.Next(0, 5);

            switch (indicator)
            {
                case 0:
                    return this.CreateApple();
                case 1:
                    return this.CreateSegmentDestructor();
                case 2:
                    return this.CreateRainbow();
                case 3:
                    return this.CreateMushroom();
                case 4:
                    return this.CreateFly();
                default:
                    throw new ArgumentException("Invalid indicator detected!");
            }
        }

        private Apple CreateApple()
        {
            int[] snakeSegmentsX = this.snake.Segments.Select(s => s.X).ToArray();
            int[] snakeSegmentsY = this.snake.Segments.Select(s => s.X).ToArray();
            int[] gameObjectsX = this.gameObjects.Select(g => g.X).ToArray();
            int[] gameObjectsY = this.gameObjects.Select(g => g.Y).ToArray();
            int x = 0;
            int y = 0;

            do
            {
                x = this.random.Next(this.playfield.PlayfieldArgs.MinX + 1, this.playfield.PlayfieldArgs.MaxX);
                y = this.random.Next(this.playfield.PlayfieldArgs.MinY + 1, this.playfield.PlayfieldArgs.MaxY);
            }
            while ((snakeSegmentsX.Contains(x) && snakeSegmentsY.Contains(y)) || (gameObjectsX.Contains(x) && gameObjectsY.Contains(y)));

            return new Apple(x, y);
        }

        private SegmentDestructor CreateSegmentDestructor()
        {
            int[] snakeSegmentsX = this.snake.Segments.Select(s => s.X).ToArray();
            int[] snakeSegmentsY = this.snake.Segments.Select(s => s.X).ToArray();
            int[] gameObjectsX = this.gameObjects.Select(g => g.X).ToArray();
            int[] gameObjectsY = this.gameObjects.Select(g => g.Y).ToArray();
            int x = 0;
            int y = 0;

            do
            {
                x = this.random.Next(this.playfield.PlayfieldArgs.MinX + 1, this.playfield.PlayfieldArgs.MaxX);
                y = this.random.Next(this.playfield.PlayfieldArgs.MinY + 1, this.playfield.PlayfieldArgs.MaxY);
            }
            while ((snakeSegmentsX.Contains(x) && snakeSegmentsY.Contains(y)) || (gameObjectsX.Contains(x) && gameObjectsY.Contains(y)));

            return new SegmentDestructor(x, y);
        }

        private Rainbow CreateRainbow()
        {
            int[] snakeSegmentsX = this.snake.Segments.Select(s => s.X).ToArray();
            int[] snakeSegmentsY = this.snake.Segments.Select(s => s.X).ToArray();
            int[] gameObjectsX = this.gameObjects.Select(g => g.X).ToArray();
            int[] gameObjectsY = this.gameObjects.Select(g => g.Y).ToArray();
            int x = 0;
            int y = 0;

            do
            {
                x = this.random.Next(this.playfield.PlayfieldArgs.MinX + 1, this.playfield.PlayfieldArgs.MaxX);
                y = this.random.Next(this.playfield.PlayfieldArgs.MinY + 1, this.playfield.PlayfieldArgs.MaxY);
            }
            while ((snakeSegmentsX.Contains(x) && snakeSegmentsY.Contains(y)) || (gameObjectsX.Contains(x) && gameObjectsY.Contains(y)));

            return new Rainbow(x, y);
        }

        private Mushroom CreateMushroom()
        {
            int[] snakeSegmentsX = this.snake.Segments.Select(s => s.X).ToArray();
            int[] snakeSegmentsY = this.snake.Segments.Select(s => s.X).ToArray();
            int[] gameObjectsX = this.gameObjects.Select(g => g.X).ToArray();
            int[] gameObjectsY = this.gameObjects.Select(g => g.Y).ToArray();
            int x = 0;
            int y = 0;

            do
            {
                x = this.random.Next(this.playfield.PlayfieldArgs.MinX + 1, this.playfield.PlayfieldArgs.MaxX);
                y = this.random.Next(this.playfield.PlayfieldArgs.MinY + 1, this.playfield.PlayfieldArgs.MaxY);
            }
            while ((snakeSegmentsX.Contains(x) && snakeSegmentsY.Contains(y)) || (gameObjectsX.Contains(x) && gameObjectsY.Contains(y)));

            return new Mushroom(x, y);
        }

        private Fly CreateFly()
        {
            int[] snakeSegmentsX = this.snake.Segments.Select(s => s.X).ToArray();
            int[] snakeSegmentsY = this.snake.Segments.Select(s => s.X).ToArray();
            int[] gameObjectsX = this.gameObjects.Select(g => g.X).ToArray();
            int[] gameObjectsY = this.gameObjects.Select(g => g.Y).ToArray();
            int x = 0;
            int y = 0;

            do
            {
                x = this.random.Next(this.playfield.PlayfieldArgs.MinX + 1, this.playfield.PlayfieldArgs.MaxX);
                y = this.random.Next(this.playfield.PlayfieldArgs.MinY + 1, this.playfield.PlayfieldArgs.MaxY);
            }
            while ((snakeSegmentsX.Contains(x) && snakeSegmentsY.Contains(y)) || (gameObjectsX.Contains(x) && gameObjectsY.Contains(y)));

            return new Fly(x, y);
        }
    }
}
