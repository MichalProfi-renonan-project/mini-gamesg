using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace tic_tac_toe
{
    /// <summary>
    /// Interaction logic for SnakeGame.xaml
    /// </summary>
    public partial class SnakeGame : Window
    {
        int _elementSize = 40;
        int _numberOfColumns;
        int _numberOfRows;
        int score = 0;
        double _gameWidth;
        double _gameHeight;
        
        

        Food _food;
        DispatcherTimer _gameLoopTimer;
        List<SnakeElement> _snakeElements;
        Random _randoTron;
        Direction _currentDirection;        
        SnakeElement _tailBackup;
        SoundPlayer game_over_player = new SoundPlayer(Properties.Resources.game_over);
        SoundPlayer eatsnake = new SoundPlayer(Properties.Resources.eatingsfxwav_14588);


        public SnakeGame()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
       
        }

        protected override void OnContentRendered(EventArgs e)
        {
            InitializeGame();
            base.OnContentRendered(e);
        }
        void InitializeGame()
        {
            _randoTron = new Random(DateTime.Now.Millisecond / DateTime.Now.Second);
            InitializeTimer();
            DrawGameWorld();
            InitializeSnake();
            DrawSnake();
            this.KeyDown += KeyRealised;
        }

        void ResetGame()
        {
            if (_gameLoopTimer != null)
            {
                _gameLoopTimer.Stop();
                _gameLoopTimer.Tick -= MainGameLoop;
                _gameLoopTimer = null;

            }

            if(GameWorld != null)
            {
                GameWorld.Children.Clear();
            }
            _food = null;
            if(_snakeElements != null)
            {
                _snakeElements.Clear();
                _snakeElements = null;
            }
            _tailBackup = null;

            score = 0;
            LblFoodCounter.Content = "Score: " + score;
            
        }

        private void DrawSnake()
        {
            foreach (var snakeElement in _snakeElements)
            {
                if (!GameWorld.Children.Contains(snakeElement.UIElement))
                    GameWorld.Children.Add(snakeElement.UIElement);

                Canvas.SetLeft(snakeElement.UIElement, snakeElement.X);
                Canvas.SetTop(snakeElement.UIElement, snakeElement.Y);
            }
        }

        private void InitializeSnake()
        {
            _snakeElements = new List<SnakeElement>();
            _snakeElements.Add(new SnakeElement(_elementSize)
            {
                X = (_numberOfColumns / 2) * _elementSize,
                Y = (_numberOfRows / 2) * _elementSize,
                IsHead = true
            });
            
            _snakeElements.Add(new SnakeElement(_elementSize)
            {
                X = (_numberOfColumns / 2) * _elementSize - _elementSize,
                Y = (_numberOfRows / 2) * _elementSize,
                IsHead = true
            });
            
            _snakeElements.Add(new SnakeElement(_elementSize)
            {
                X = (_numberOfColumns / 2) * _elementSize - (_elementSize * 2),
                Y = (_numberOfRows / 2) * _elementSize,
                IsHead = true
            });
            _currentDirection = Direction.Right;
        }

        private void DrawGameWorld()
        {
            _gameWidth = GameWorld.ActualWidth;
            _gameHeight = GameWorld.ActualHeight;
            _numberOfColumns = (int)_gameWidth / _elementSize;
            _numberOfRows = (int)_gameHeight / _elementSize;

            for (int i = 0; i < _numberOfRows; i++)
            {
                Line line = new Line();
                line.Stroke = Brushes.Black;
                line.X1 = 0;
                line.Y1 = i * _elementSize;
                line.X2 = _gameWidth;
                line.Y2 = i * _elementSize;
                GameWorld.Children.Add(line);
            }
            for (int i = 0; i < _numberOfColumns; i++)
            {
                Line line = new Line();
                line.Stroke = Brushes.Black;
                line.X1 = i * _elementSize;
                line.Y1 = 0;
                line.X2 = i * _elementSize;
                line.Y2 = _gameHeight;
                GameWorld.Children.Add(line);
            }
        }

        public void InitializeTimer()
        {
            _gameLoopTimer = new DispatcherTimer();
            _gameLoopTimer.Interval = TimeSpan.FromSeconds(0.2);
            _gameLoopTimer.Tick += MainGameLoop;
            _gameLoopTimer.Start();
        }

        private void MakeGameFaster()
        {
            _gameLoopTimer.Interval = _gameLoopTimer.Interval = TimeSpan.FromSeconds(0.1);
        }
        private void MainGameLoop(object sender, EventArgs e)
        {
            MoveSnake();
            CheckCollision();
            DrawSnake();
            CreateFood();
            DrawFoods();
        }

        private void MoveSnake()
        {
            SnakeElement head = _snakeElements[0];
            SnakeElement tail = _snakeElements[_snakeElements.Count - 1];

            _tailBackup = new SnakeElement(_elementSize)
            {
                X = tail.X,
                Y = tail.Y
            };

            head.IsHead = false;
            tail.IsHead = true;
            tail.X = head.X;
            tail.Y = head.Y;

            switch (_currentDirection)
            {
                case Direction.Right:
                    tail.X += _elementSize;
                    break;
                case Direction.Left:
                    tail.X -= _elementSize;
                    break;
                case Direction.Up:
                    tail.Y -= _elementSize;
                    break;
                case Direction.Down:
                    tail.Y += _elementSize;
                    break;

            }
            _snakeElements.RemoveAt(_snakeElements.Count - 1);
            _snakeElements.Insert(0, tail);

        }

        private void DrawFoods()
        {
            if (_food == null)
                return;
            if (!GameWorld.Children.Contains(_food.UIElement))
                GameWorld.Children.Add(_food.UIElement);
            Canvas.SetLeft(_food.UIElement, _food.X);
            Canvas.SetTop(_food.UIElement, _food.Y);
        }

        private void CreateFood()
        {
            if (_food != null)
                return;
            _food = new Food(_elementSize)
            {
                X = _randoTron.Next(0, _numberOfColumns) * _elementSize,
                Y = _randoTron.Next(0, _numberOfRows) * _elementSize
            };
        }
        

        private void CheckCollision()
        {
            CheckCollisionWithWorldBounds();
            CheckCollisionWithSelf();
            CheckCollisionWithWorldItems();
        }

        private void CheckCollisionWithWorldItems()
        {
            if (_food == null)
                return;
            SnakeElement head = _snakeElements[0];
            if (head.X == _food.X && head.Y == _food.Y)
            {
                GameWorld.Children.Remove(_food.UIElement);
                GrowSnake();
                MakeGameFaster();
                _food = null;
                eatsnake.Play();
                score++;
                LblFoodCounter.Content = "Score: " + score;
                
            }
            
        }

        private void GrowSnake()
        {
            _snakeElements.Add(new SnakeElement(_elementSize) { X = _tailBackup.X, Y = _tailBackup.Y });
            
        }

        private void CheckCollisionWithSelf()
        {
            SnakeElement snakeHead = GetSnakeHead();
            bool hadCollision = false;
            if (snakeHead != null)
            {
                foreach (var snakeElement in _snakeElements)
                {
                    if (!snakeElement.IsHead)
                    {
                        if (snakeElement.X == snakeHead.X && snakeElement.Y == snakeHead.Y)
                        {
                            hadCollision = true;
                            break;
                        }
                    }
                }
            }
            if (hadCollision)
            {
                
                game_over_player.Play();
                MessageBox.Show("Game Over collided with your own tail YOU STUPID!");
                ResetGame();
                InitializeGame();                
            }
        }

        private void CheckCollisionWithWorldBounds()
        {
            SnakeElement snakeHead = GetSnakeHead();
            if (snakeHead.X > _gameWidth - _elementSize || snakeHead.X < 0 || snakeHead.Y < 0 || snakeHead.Y > _gameHeight - _elementSize)
            {
                               
                game_over_player.Play();                
                MessageBox.Show("Game Over collided with bounds! Restart?");
                ResetGame();
                InitializeGame();
                
            }
        }
        private SnakeElement GetSnakeHead()
        {
            SnakeElement snakeHead = null;
            foreach (var snakeElement in _snakeElements)
            {
                if (snakeElement.IsHead)
                {
                    snakeHead = snakeElement;
                    break;
                }
            }
            return snakeHead;
        }


        

        private void KeyRealised(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                    if (_currentDirection != Direction.Down)
                        _currentDirection = Direction.Up;
                    break;
                case Key.A:
                    if (_currentDirection != Direction.Right)
                        _currentDirection = Direction.Left;
                    break;
                case Key.S:
                    if (_currentDirection != Direction.Up)
                        _currentDirection = Direction.Down;
                    break;
                case Key.D:
                    if (_currentDirection != Direction.Left)
                        _currentDirection = Direction.Right;
                    break;
            }
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ChoosingGame back = new ChoosingGame();
            back.Show();
            _gameLoopTimer.Stop();
        }

        private void Button_pause_Click(object sender, RoutedEventArgs e)
        {
            _gameLoopTimer.Stop();
            string caption = "Do you want resume the game?";
            MessageBoxResult result = MessageBox.Show(caption);
            _gameLoopTimer.Start();

        }
    }
    enum Direction
    {
        Right,
        Left,
        Up,
        Down
    }
}
