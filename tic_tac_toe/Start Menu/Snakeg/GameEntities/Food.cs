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
        public Food(int Size)
        {
            Rectangle rect = new Rectangle();
            rect.Width = Size;
            rect.Height = Size;
            rect.Fill = Brushes.Red;
            UIElement = rect;
        }

        public override bool Equals(object obj)
        {
            Food food = obj as Food;
            if(food != null)
            {
                return X == food.X && Y == food.Y;
            }
            else
            {
                return false;
            }

        }
    }
}
