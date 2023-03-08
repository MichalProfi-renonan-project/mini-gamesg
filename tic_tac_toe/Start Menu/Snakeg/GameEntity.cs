using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace tic_tac_toe
{
    class GameEntity
    {

        public GameEntity(int Size)
        {
            Rectangle rect = new Rectangle
            {
                Width = Size,
                Height = Size,
                Fill = Brushes.Green
            };
            UIElement = rect;
        }

        public UIElement UIElement { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
