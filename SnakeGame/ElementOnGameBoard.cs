using System.Windows;
using System.Windows.Controls;

namespace SnakeGame_Assignment
{
    // Abstract Class for an element on a game board.
    public abstract class ElementOnGameBoard
    {
        // The field stores the current position (point (x,y)) on the game board.
        public Point CurrentPosition { set; get; }

        // Size of the element placed on the game board.
        public int ElementSize { set; get; }

        // Representation of the element placed on the game board.
        public UIElement ElementRepresentation { set; get; }

        // Paint UIElement on Canvas method.
        public abstract void Paint(Canvas gameBoard);
    }
}
