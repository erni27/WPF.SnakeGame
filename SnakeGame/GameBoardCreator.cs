using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SnakeGame_Assignment
{
    // Game Board creator. Class consist of methods responsible for creating a game board. 
    static class GameBoardCreator
    {
        // Draw a single line on Canvas based on two given points method.
        private static void CreateSingleLine(Point firstPoint, Point secondPoint, Canvas mainWindow)
        {
            Line line = new Line();
            line.Stroke = System.Windows.Media.Brushes.Blue;
            line.StrokeThickness = 1;
            line.X1 = firstPoint.X;
            line.X2 = secondPoint.X;
            line.Y1 = firstPoint.Y;
            line.Y2 = secondPoint.Y;
            mainWindow.Children.Add(line);
        }

        // Create a board game method. 
        public static void Create(Canvas mainWindow, int snakeSize) 
        {
            // Draw vertical lines.
            for (int i = 0; i<mainWindow.Width; i+=snakeSize) {
                Point firstPoint = new Point(i, 0);
                Point secondPoint = new Point(i, mainWindow.Height);
                GameBoardCreator.CreateSingleLine(firstPoint, secondPoint, mainWindow);
            }

            // Draw horizontal lines.
            for (int i = 0; i<mainWindow.Height; i+=snakeSize)
            {
                Point firstPoint = new Point(0, i);
                Point secondPoint = new Point(mainWindow.Width, i);
                GameBoardCreator.CreateSingleLine(firstPoint, secondPoint, mainWindow);
            }
        }

    }
}
