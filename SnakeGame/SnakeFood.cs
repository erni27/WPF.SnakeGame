using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SnakeGame_Assignment
{
    // ElementOnGameBoard subclass represents a snake's food.
    public class SnakeFood : ElementOnGameBoard
    {
        // Paint default UIElement on Canvas method.
        public override void Paint(Canvas gameBoard)
        {
            Rectangle part = new Rectangle();
            part.Width = ElementSize;
            part.Height = ElementSize;
            part.Fill = Brushes.Red;
            Canvas.SetLeft(part, CurrentPosition.X);
            Canvas.SetTop(part, CurrentPosition.Y);
            ElementRepresentation = part;
            gameBoard.Children.Add(ElementRepresentation);
        }

        // Overloaded Paint method. Lets define an image as a UIElement.
        public void Paint(Canvas gameBoard, string imagePath)
        {
            // Load an image.
            Image imageFood = ImageLoader.Load(imagePath, new System.Drawing.Size(ElementSize, ElementSize));
            Canvas.SetLeft(imageFood, CurrentPosition.X);
            Canvas.SetTop(imageFood, CurrentPosition.Y);
            ElementRepresentation = imageFood;
            gameBoard.Children.Add(ElementRepresentation);
        }
        // Check if the point is different than any point from points list method.
        private static bool CheckPointAvailability(List<Point> points, Point checkedPoint)
        {
            foreach (Point point in points)
            {
                if (checkedPoint == point)
                    return false;
            }
            return true;
        }

        // SnakeFood constructor.
        public SnakeFood(List<SnakePart> snakeParts, List<SnakeFood> snakeFoods)
        {
            
            int foodSize = snakeParts[0].ElementSize;
            bool isAvailable = false;
            List<Point> occupiedPoints = new List<Point>();
            foreach (SnakePart snakePart in snakeParts)
            {
                occupiedPoints.Add(snakePart.CurrentPosition);
            }
            foreach (SnakeFood snakeFood in snakeFoods)
            {
                occupiedPoints.Add(snakeFood.CurrentPosition);
            }
            // Draw coordinates of a snake food point.
            this.ElementSize = foodSize;
            Random random = new Random();
            int randomX, randomY;

            // Check if the snake food point is the same as one of the snake parts points.
            // or one of other snake foods points. If yes, draw again
            do
            {
                randomX = random.Next(0, 24) * 20;
                randomY = random.Next(0, 24) * 20;
                this.CurrentPosition = new Point(randomX, randomY);
                isAvailable = SnakeFood.CheckPointAvailability(occupiedPoints, this.CurrentPosition);
            }
            while (!isAvailable);
            
        }
    }
}
