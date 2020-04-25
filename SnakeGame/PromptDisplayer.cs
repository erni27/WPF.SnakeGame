using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SnakeGame_Assignment
{
    // Class consist of method responsible for displaying text on Canvas.
    public static class PromptDisplayer
    {
        // Display method.
        public static void Display(Canvas gameBoard, string prompt)
        {
            TextBlock promptBlock = new TextBlock();
            promptBlock.Text = prompt;
            promptBlock.Width = gameBoard.Width;
            promptBlock.TextAlignment = TextAlignment.Center;
            promptBlock.FontSize = 40;
            promptBlock.Foreground = Brushes.Black;
            promptBlock.TextWrapping = TextWrapping.Wrap;
            gameBoard.Children.Add(promptBlock);
        }
    }
}
