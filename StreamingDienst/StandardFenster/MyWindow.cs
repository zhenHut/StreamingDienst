using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows;

namespace StreamingDienst.StandardFenster
{
    public class MyWindow : Window
    {
        private Grid _layoutGrid;
        private ContentPresenter _contentPresenter;

        public MyWindow()
        {
            AllowsTransparency = true;
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
            Background = Brushes.Transparent;

            BuildWindowStructure();
        }

        private void BuildWindowStructure()
        {
            // Border mit abgerundeten Ecken
            var border = new Border
            {
                CornerRadius = new CornerRadius(15),
                BorderBrush = Brushes.Gray,
                BorderThickness = new Thickness(1),
                Background = Brushes.White,
            };

            _layoutGrid = new Grid();
            _layoutGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // TitleBar
            _layoutGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }); // Content

            // TitleBar als UserControl
            var titleBar = new WindowTitleBar();
         
            
            titleBar.SetBinding(WindowTitleBar.TitleBarStyleProperty, new Binding(nameof(TitlebarStyle)) { Source = this });
            titleBar.SetBinding(WindowTitleBar.ShowMinimizeButtonProperty, new Binding(nameof(ShowMinimizeButton)) { Source = this });
            titleBar.SetBinding(WindowTitleBar.ShowMaximizeButtonProperty, new Binding(nameof(ShowMaximizeButton)) { Source = this });
            

            // Optional: Sichtbarkeit der Titlebar
            var titleBarContainer = new ContentControl { Content = titleBar };
            var visibilityBinding = new Binding(nameof(ShowTitleBar)) { Source = this, Converter = new BooleanToVisibilityConverter() };
            titleBarContainer.SetBinding(ContentControl.VisibilityProperty, visibilityBinding);

            _layoutGrid.Children.Add(titleBarContainer);
            Grid.SetRow(titleBarContainer, 0);

            // ContentPresenter für Nutz-Inhalt
            _contentPresenter = new ContentPresenter();
            _layoutGrid.Children.Add(_contentPresenter);
            Grid.SetRow(_contentPresenter, 1);

            border.Child = _layoutGrid;
            Content = border;
        }

        // DependencyProperties
        public static readonly DependencyProperty TitleTextProperty =
            DependencyProperty.Register(nameof(TitleText), typeof(string), typeof(StandardWindow), new PropertyMetadata("Titel"));

        public string TitleText
        {
            get => (string)GetValue(TitleTextProperty);
            set => SetValue(TitleTextProperty, value);
        }

        public static readonly DependencyProperty ShowTitleBarProperty =
            DependencyProperty.Register(nameof(ShowTitleBar), typeof(bool), typeof(StandardWindow), new PropertyMetadata(true));

        public bool ShowTitleBar
        {
            get => (bool)GetValue(ShowTitleBarProperty);
            set => SetValue(ShowTitleBarProperty, value);
        }

        public static readonly DependencyProperty WindowIconProperty =
            DependencyProperty.Register(nameof(WindowIcon), typeof(ImageSource), typeof(StandardWindow), new PropertyMetadata(null));

        public ImageSource WindowIcon
        {
            get => (ImageSource)GetValue(WindowIconProperty);
            set => SetValue(WindowIconProperty, value);
        }

        public static readonly DependencyProperty TitlebarStyleProperty =
            DependencyProperty.Register(nameof(TitlebarStyle), typeof(Style), typeof(StandardWindow), new PropertyMetadata(null));

        public Style TitlebarStyle
        {
            get => (Style)GetValue(TitlebarStyleProperty);
            set => SetValue(TitlebarStyleProperty, value);
        }

        public static readonly DependencyProperty ShowMinimizeButtonProperty =
            DependencyProperty.Register(nameof(ShowMinimizeButton), typeof(bool), typeof(StandardWindow), new PropertyMetadata(true));

        public bool ShowMinimizeButton
        {
            get => (bool)GetValue(ShowMinimizeButtonProperty);
            set => SetValue(ShowMinimizeButtonProperty, value);
        }

        public static readonly DependencyProperty ShowMaximizeButtonProperty =
            DependencyProperty.Register(nameof(ShowMaximizeButton), typeof(bool), typeof(StandardWindow), new PropertyMetadata(false));

        public bool ShowMaximizeButton
        {
            get => (bool)GetValue(ShowMaximizeButtonProperty);
            set => SetValue(ShowMaximizeButtonProperty, value);
        }

        public static readonly DependencyProperty ShowCloseButtonProperty =
            DependencyProperty.Register(nameof(ShowCloseButton), typeof(bool), typeof(StandardWindow), new PropertyMetadata(true));

        public bool ShowCloseButton
        {
            get => (bool)GetValue(ShowCloseButtonProperty);
            set => SetValue(ShowCloseButtonProperty, value);
        }
    }
}

