using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace tic_tac_toe
{
    class Food : GameEntity
    {
        public Food(int Size) : base(Size)
        {
            Rectangle rect = new Rectangle();
            rect.Width = Size;
            rect.Height = Size;
            rect.Fill = Brushes.Green;
            UIElement = rect;
        }
    }
}
