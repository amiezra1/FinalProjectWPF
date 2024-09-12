using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Ink;

namespace FinalProjectWPF.Painter
{
    /// <summary>
    /// Interaction logic for PainterWindow.xaml
    /// </summary>
    public partial class PainterWindow : Window
    {
        private readonly DrawingAttributes PenAttributes = new()
        {
            Color = Colors.Black,
            Height = 2,
            Width = 2
        };

        private readonly DrawingAttributes HighlighterAttributes = new()
        {
            Color = Colors.Yellow,
            Height = 10,
            Width = 2,
            IgnorePressure = true,
            IsHighlighter = true,
            StylusTip = StylusTip.Rectangle
        };
        public PainterWindow()
        {
            InitializeComponent();
            Canvas.DefaultDrawingAttributes = PenAttributes;
        }

        private void SelectBtn_Click(object sender, RoutedEventArgs e)
        {
            SetEditingMode(EditingMode.Select);
        }

        private void PenBtn_Click(object sender, RoutedEventArgs e)
        {
            SetEditingMode(EditingMode.Pen);
        }

        private void HighlighterBtn_Click(object sender, RoutedEventArgs e)
        {
            SetEditingMode(EditingMode.Highlighter);
        }

        private void EraserBtn_Click(object sender, RoutedEventArgs e)
        {
            SetEditingMode(EditingMode.Eraser);
        }


        private void SetEditingMode(EditingMode mode)
        {
            SelectBtn.IsChecked = false;
            PenBtn.IsChecked = false;
            HighlighterBtn.IsChecked = false;
            EraserBtn.IsChecked = false;

            switch (mode)
            {
                case EditingMode.Select:
                    SelectBtn.IsChecked = true;
                    Canvas.EditingMode = InkCanvasEditingMode.Select;
                    break;

                case EditingMode.Pen:
                    PenBtn.IsChecked = true;
                    Canvas.EditingMode = InkCanvasEditingMode.Ink;
                    Canvas.DefaultDrawingAttributes = PenAttributes;
                    break;

                case EditingMode.Highlighter:
                    HighlighterBtn.IsChecked = true;
                    Canvas.EditingMode = InkCanvasEditingMode.Ink;
                    Canvas.DefaultDrawingAttributes = HighlighterAttributes;
                    break;

                case EditingMode.Eraser:
                    EraserBtn.IsChecked = true;
                    if (PartialStrokeRadio.IsChecked == true)
                        Canvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    else
                        Canvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;

                default:
                    break;
            }
        }

        private void PenColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (IsLoaded)
                PenAttributes.Color = PenColorPicker.SelectedColor ?? Colors.Black;
        }

        private void ThicknessSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (IsLoaded)
            {
                PenAttributes.Width = ThicknessSlider.Value;
                PenAttributes.Height = ThicknessSlider.Value;
            }
        }

        private void YellowRadio_Click(object sender, RoutedEventArgs e)
        {
            HighlighterAttributes.Color = Colors.Yellow;
        }

        private void CyanRadio_Click(object sender, RoutedEventArgs e)
        {
            HighlighterAttributes.Color = Colors.Cyan;
        }

        private void MagentaRadio_Click(object sender, RoutedEventArgs e)
        {
            HighlighterAttributes.Color = Colors.Magenta;
        }

        private void PartialStrokeRadio_Click(object sender, RoutedEventArgs e)
        {
            if (EraserBtn.IsChecked == true)
                Canvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }

        private void FullStrokeRadio_Click(object sender, RoutedEventArgs e)
        {
            if (EraserBtn.IsChecked == true)
                Canvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
        }
        public enum EditingMode
        {
            Select, Pen, Highlighter, Eraser
        }
    }
}
