using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace SnakeGame_Assignment
{
    // Class consist of method responsible for checking if a snake's head
    // collides with one of the snake's parts or walls.
    static class CollisionChecker
    {
        // Check method. Return true if a snake's head collides with something,
        // false if not.
        public static bool Check(List<SnakePart> snakeParts, Canvas gameBoard)
        {
            SnakePart snakeHead = snakeParts[0];
            int snakeSize = snakeHead.ElementSize;

            // Check if snake's head collides with one of the snake's parts.
            foreach (SnakePart snakePart in snakeParts.Skip(1))
            {
                if (snakeHead.CurrentPosition == snakePart.CurrentPosition)
                    return true;
            }

            // Check if snake's head collides with one of the walls.
            if (snakeHead.CurrentPosition.X < 0 || snakeHead.CurrentPosition.X > gameBoard.Width - snakeSize
                || snakeHead.CurrentPosition.Y < 0 || snakeHead.CurrentPosition.Y > gameBoard.Height - snakeSize)
                return true;
            return false;
        }
    }
}
