using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace StreamingDienst.StandardFenster
{
    public class Testwindo : Window
    {
        protected ContentPresenter _viewArea;

        public Testwindo()
        {
            WindowStyle = WindowStyle.None;
            AllowsTransparency = true;
            Background = Brushes.Transparent;

            var border = new Border
            {
                Background = (Brush)Application.Current.FindResource("BackgroundGradient"),
                CornerRadius = new CornerRadius(6),
                BorderBrush = Brushes.Gray,
                BorderThickness = new Thickness(1),
            };

            var layout = new Grid();
            layout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40) });
            layout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            var titleBar = new WindowTitleBar();
            Grid.SetRow(titleBar, 0);
            layout.Children.Add(titleBar);

            _viewArea = new ContentPresenter();
            Grid.SetRow(_viewArea, 1);
            layout.Children.Add(_viewArea);

            border.Child = layout;
            base.Content = border;
        }

        public UIElement ViewContent
        {
            get => _viewArea.Content as UIElement;
            set => _viewArea.Content = value;
        }
    }

}
