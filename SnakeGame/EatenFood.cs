using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace SnakeGame_Assignment
{
    // Class consist of methods responsible for checking if snake ate food
    // and behavior if yes. 
    public class EatenFood
    {
        // The field stores current list of the snake foods.
        private List<SnakeFood> _snakeFoods = new List<SnakeFood>();

        // Current list of the snake parts.
        private List<SnakePart> _snakeParts = new List<SnakePart>();

        // The eaten snake food.
        private SnakeFood _eatenSnakeFood;

        // EatenFood constructor. 
        public EatenFood(List<SnakePart> snakeParts, ref List<SnakeFood> snakeFoods)
        {
            _snakeFoods = snakeFoods;
            _snakeParts = snakeParts;
        }

        // Check if the snake ate food method.
        public bool Check()
        {
            // Assign the first element of the snake parts list 
            // which is always the snake's head.
            SnakePart snakeHead = _snakeParts[0];
            foreach (SnakeFood snakeFood in _snakeFoods)
            {
                if (snakeHead.CurrentPosition == snakeFood.CurrentPosition)
                {
                    _eatenSnakeFood = snakeFood;
                    return true;
                }
            }
            return false;
        }

        // Behavior if snake ate food.
        public void Eaten(Canvas gameBoard, int maxSnakeSpeed, ref int score, ref DispatcherTimer timer, string foodImagePath)
        {
            // Increment score.
            score++;

            // Increase a snake speed.
            int timeInterval = Math.Max((10000000 - score * 500000), maxSnakeSpeed);
            timer.Interval = new TimeSpan(timeInterval);


            // Delete the eaten food element.
            gameBoard.Children.Remove(_eatenSnakeFood.ElementRepresentation);
            _snakeFoods.Remove(_eatenSnakeFood);

            // Create a new food element.
            SnakeFood newSnakeFood = new SnakeFood(_snakeParts, _snakeFoods);
            _snakeFoods.Add(newSnakeFood);
            newSnakeFood.Paint(gameBoard, foodImagePath);
        }
    }
}
