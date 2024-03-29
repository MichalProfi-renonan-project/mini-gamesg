﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;

namespace tic_tac_toe
{
    class SnakeElement : GameEntity
    {
   
       public SnakeElement(int size)
        {
            Rectangle rect = new Rectangle();
            rect.Width = size;
            rect.Height = size;
            rect.Fill = Brushes.Chartreuse;
            rect.RadiusX = size / 2;
            rect.RadiusY = size / 2;
            UIElement = rect;
        }
        
        public bool IsHead { get; set; }

    }
}
