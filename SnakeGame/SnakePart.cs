using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SnakeGame_Assignment
{
    // ElementOnGameBoard subclass represents a single snake part.
    public class SnakePart : ElementOnGameBoard
    { 
        // Paint UIElement on Canvas method.
        public override void Paint(Canvas gameBoard)
        {
            Ellipse part = new Ellipse();
            part.Width = ElementSize;
            part.Height = ElementSize;
            part.Fill = Brushes.DarkGreen;
            Canvas.SetLeft(part, CurrentPosition.X);
            Canvas.SetTop(part, CurrentPosition.Y);
            ElementRepresentation = part;
            gameBoard.Children.Add(ElementRepresentation);
        }

        // SnakePart constructor. 
        public SnakePart(Point currentPosition, int snakeSize)
        {
            this.CurrentPosition = currentPosition;
            this.ElementSize = snakeSize;
        }
    }
}
