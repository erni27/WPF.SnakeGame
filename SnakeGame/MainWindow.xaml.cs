using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace SnakeGame_Assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // The field stores a snake size.
        private const int _snakeSize = 20;

        // Current score. 
        private int _score = 0;

        // List of all snake parts.
        private List<SnakePart> _snakeParts = new List<SnakePart>();

        // Timer responsible for moving snake.
        private DispatcherTimer _timer = new DispatcherTimer();

        // List of all snake foods.
        private List<SnakeFood> _snakeFoods = new List<SnakeFood>();

        // List of snake images urls.
        private List<String> _snakeImagesURL = new List<string>();

        // List of food images path.
        private List<String> _foodImagesPath = new List<string>();

        // Snake directions.
        private enum SnakeDirection {Left, Right, Up, Down};

        // Current snake direction.
        private SnakeDirection _snakeDirection;

        // Max snake speed.
        private int _maxSnakeSpeed = 500000;


        private void Window_ContentRendered(object sender, EventArgs e)
        {
            PromptDisplayer.Display(GameBoard, "Press spacebar to start");

            // Initiate list of snake images urls.
            for (int i = 1; i <= 5; i++)
            {
                string imageURL = ConfigurationManager.AppSettings.Get("snakeImageURL" + i.ToString());
                _snakeImagesURL.Add(imageURL);
            }
            // Initiate list of food images path.
            for (int i=1; i<=5; i++)
            {
                string imagePath = ConfigurationManager.AppSettings.Get("foodImagePath" + i.ToString());
                _foodImagesPath.Add(imagePath);
            }
        }

        // Start game method.
        private void StartGame()
        {
            _snakeDirection = SnakeDirection.Right;

            // Initiate a snake's head.
            Point startPoint = new Point((GameBoard.Width - _snakeSize) / 2, (GameBoard.Height - _snakeSize) / 2);
            SnakePart snakePart = new SnakePart(startPoint, _snakeSize);
            _snakeParts.Add(snakePart);
            snakePart.Paint(GameBoard);

            // Initiate snake's food.
            for (int i=0; i<3; i++)
            {
                SnakeFood snakeFood = new SnakeFood(_snakeParts, _snakeFoods);
                _snakeFoods.Add(snakeFood);
                snakeFood.Paint(GameBoard, RandomString.Draw(_foodImagesPath));
            }

            _timer.Tick += _timer_Tick;
            _timer.Interval = new TimeSpan(10000000); // 10000000 * 0.0000001s
            _timer.Start();
        }

        // End game method.
        private void EndGame()
        {
            _timer.Stop();
            GameBoard.Children.Clear();
            GameBoard.Background = Brushes.White;
            PromptDisplayer.Display(GameBoard, "Your score: " + _score.ToString() + ". \n Please press space bar if you want to try again.");
            _score = 0;
        }
        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += MainWindow_KeyDown;
        }

        // Event handler when right key is pushed.
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Down:
                    if (_snakeDirection != SnakeDirection.Down)
                        _snakeDirection = SnakeDirection.Down;
                    break;
                case Key.Up:
                    if (_snakeDirection != SnakeDirection.Up)
                        _snakeDirection = SnakeDirection.Up;
                    break;
                case Key.Left:
                    if (_snakeDirection != SnakeDirection.Left)
                        _snakeDirection = SnakeDirection.Left;
                    break;
                case Key.Right:
                    if (_snakeDirection != SnakeDirection.Right)
                        _snakeDirection = SnakeDirection.Right;
                    break;

                // Start or restart a game.
                case Key.Space:
                    GameBoard.Children.Clear();
                    _snakeParts.Clear();
                    _timer.Stop();
                    _timer.Tick -= _timer_Tick;
                    GameBoardCreator.Create(GameBoard, _snakeSize);
                    StartGame();
                    break;
            }
        }

        // Move snake method.
        private void MoveSnake()
        {
            // Initiate coordinates for snake's next step.
            double newX = _snakeParts[0].CurrentPosition.X;
            double newY = _snakeParts[0].CurrentPosition.Y;

            // Depends on direction, appropriate change the coordinates.
            switch(_snakeDirection)
            {
                case SnakeDirection.Down:
                    newY += _snakeSize;
                    break;
                case SnakeDirection.Up:
                    newY -= _snakeSize;
                    break;
                case SnakeDirection.Left:
                    newX -= _snakeSize;
                    break;
                case SnakeDirection.Right:
                    newX += _snakeSize;
                    break;
            }

            // Initiate a new point for snake's next step.
            Point newPoint = new Point(newX, newY);

            // Create a moved snake head.
            SnakePart snakePart = new SnakePart(newPoint, _snakeSize);
            _snakeParts.Insert(0, snakePart);

            // Check if created snake head collide with something.
            if (CollisionChecker.Check(_snakeParts, GameBoard))
            {
                EndGame();
                return;
            }
            
            // Initiate an EatenFood object.
            EatenFood eatenFood = new EatenFood(_snakeParts, ref _snakeFoods);

            // Check if new created snake head ate food.
            if (eatenFood.Check())
            {
                // Increase score, snake's speed, remove eaten food and add the new one.
                eatenFood.Eaten(GameBoard, _maxSnakeSpeed,ref _score, ref _timer, RandomString.Draw(_foodImagesPath));

                // Draw an URL Address.
                string imageURL = RandomString.Draw(_snakeImagesURL);

                // Download an image and change the board game background.
                try
                {
                    BackgroundChanger.Change(GameBoard, imageURL);
                }
                catch (WebException exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            // Remove the old snake part
            // cause snake did not eat food.
            else
            {
                GameBoard.Children.Remove(_snakeParts[_snakeParts.Count - 1].ElementRepresentation);
                _snakeParts.RemoveAt(_snakeParts.Count - 1);
            }

            // Paint new created head.
            snakePart.Paint(GameBoard);
        }
        private void _timer_Tick(object sender, EventArgs e)
        {
            MoveSnake();
        }
    }
}
