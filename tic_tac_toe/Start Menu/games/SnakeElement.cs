using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;

namespace tic_tac_toe
{
    class SnakeElement
    {
        public SnakeElement(int Size)
        {
            Rectangle rect = new Rectangle();
            rect.Width = Size;
            rect.Height = Size;
            rect.Fill = Brushes.Green;
            UIElement = rect;
        }
        
        public UIElement UIElement { get; set; }
        public bool IsHead { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
