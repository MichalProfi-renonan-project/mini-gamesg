﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        int _elementSize = 20;
        private int _numberOfColumns;
        private int _numberOfRows;

        DispatcherTimer _gameLoopTimer;
        List<SnakeElement> _snakeElements;
        List<Food> _foods; 
        private Random _randoTron;

        private Direction _currentDirection;
        private double _gameWidth;
        private double _gameHeight;
        private long _elapsedTicks;
        
        public SnakeGame()
        {
            InitializeComponent();
            _randoTron = new Random(DateTime.Now.Millisecond / DateTime.Now.Second);
            _foods = new List<Food>();
            InitializeTimer();
            DrawGameWorld();
            InitializeSnake();
            DrawSnake();
            this.KeyDown += KeyRealised;
        }

        private void DrawSnake()
        {
            foreach (var food in _foods)
            {
                if (!GameWorld.Children.Contains(food.UIElement))
                    GameWorld.Children.Add(food.UIElement);

                Canvas.SetLeft(food.UIElement, food.X);
                Canvas.SetTop(food.UIElement, food.Y);
            }
        }

        private void InitializeSnake()
        {
            _snakeElements = new List<SnakeElement>();
            _snakeElements.Add(new SnakeElement(_elementSize)
            {
                X = (_numberOfRows / 2) * _elementSize,
                Y = (_numberOfColumns / 2) * _elementSize,
                IsHead = true
            });
            _currentDirection = Direction.Left;
        }

        private void DrawGameWorld()
        {
            _gameWidth = Width;
            _gameHeight = Height;
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

        private void MainGameLoop(object sender, EventArgs e)
        {
            MoveSnake();
            CheckCollision();
            DrawSnake();
            CreateFood();
            DrawFoods();
        }

        private void DrawFoods()
        {
            foreach (var snakeElement in _snakeElements)
            {
                if (!GameWorld.Children.Contains(snakeElement.UIElement))
                    GameWorld.Children.Add(snakeElement.UIElement);

                Canvas.SetLeft(snakeElement.UIElement, snakeElement.X);
                Canvas.SetTop(snakeElement.UIElement, snakeElement.Y);
            }
        }

        private void CreateFood()
        {
            if(_elapsedTicks / 13 == 0)
            {
                _foods.Add(new Food(_elementSize) {
                    X = _randoTron.Next(0, _numberOfColumns) * _elementSize,
                    Y = _randoTron.Next(0, _numberOfRows) * _elementSize
                });
            }
        }

        private void CheckCollision()
        {
            CheckCollisionWithWorldBounds();
            CheckCollisionWithSelf();
            CheckCollisionWithWorldItems();
        }

        private void CheckCollisionWithWorldItems()
        {
            SnakeElement snakeHead = GetSnakeHead();
            if (snakeHead.X > _gameWidth - _elementSize || snakeHead.X < 0 || snakeHead.Y < 0 || snakeHead.Y > _gameHeight - _elementSize)
            {
                MessageBox.Show("Game Over collided with bounds!");
            }  
        }

        private void CheckCollisionWithSelf()
        {
            SnakeElement snakeHead = GetSnakeHead();
            if (snakeHead != null)
            {
                foreach (var snakeElement in _snakeElements)
                {
                    if (!snakeElement.IsHead)
                    {
                        if (snakeElement.X == snakeHead.X && snakeElement.Y == snakeHead.Y)
                        {
                            MessageBox.Show("Game Over collided with bounds!");
                        }
                        break;
                    }
                }
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

        private void CheckCollisionWithWorldBounds()
        {

        }

        private void MoveSnake()
        {
            foreach (var snakeElement in _snakeElements)
            {
                switch (_currentDirection)
                {
                    case Direction.Right:
                        snakeElement.X += _elementSize;
                        break;
                    case Direction.Left:
                        snakeElement.X -= _elementSize;
                        break;
                    case Direction.Up:
                        snakeElement.Y -= _elementSize;
                        break;
                    case Direction.Down:
                        snakeElement.Y += _elementSize;
                        break;

                }


            }

        }

        private void KeyRealised(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                    _currentDirection = Direction.Up;
                    break;
                case Key.A:
                    _currentDirection = Direction.Left;
                    break;
                case Key.S:
                    _currentDirection = Direction.Down;
                    break;
                case Key.D:
                    _currentDirection = Direction.Right;
                    break;
            }
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
