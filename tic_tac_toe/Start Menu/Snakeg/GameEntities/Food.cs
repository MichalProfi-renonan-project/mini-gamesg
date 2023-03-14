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
        public Food(int size)
        {
            Rectangle rect = new Rectangle()
            {
                Width = size - 4,
                Height = size - 4,
                Fill = Brushes.Red,
                RadiusX =  15,
                RadiusY = 15
            };
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
