using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FinalProjectWPF.Snakes
{
    public class GridCell : Grid
    {
        private Rectangle rectangle;

        public GridCell()
        {
            rectangle = new Rectangle
            {
                Fill = Brushes.LightGray,
                Stretch = Stretch.Fill
            };
            Children.Add(rectangle);
        }

        public void SetState(CellState state)
        {
            switch (state)
            {
                case CellState.Empty:
                    rectangle.Fill = Brushes.LightGray;
                    break;
                case CellState.Snake:
                    rectangle.Fill = Brushes.Green;
                    break;
                case CellState.Apple:
                    rectangle.Fill = Brushes.Red;
                    break;
            }
        }
    }
}
