using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls;

namespace StreamingDienst.StandardFenster
{
    /// <summary>
    /// Interaktionslogik für StandardWindow.xaml
    /// </summary>
    public partial class StandardWindow : Window
    {

        #region Constructor
        public StandardWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Dependencies Properties
        public static readonly DependencyProperty ShowTitleBarPropperty =
            DependencyProperty.Register(nameof(ShowTitleBar), typeof(bool), typeof(StandardWindow), new PropertyMetadata(true));

        public static readonly DependencyProperty TitleTextProperty =
        DependencyProperty.Register(nameof(TitleText), typeof(string), typeof(StandardWindow), new PropertyMetadata("Titel"));

        public static readonly DependencyProperty WindowIconProperty =
            DependencyProperty.Register(nameof(WindowIcon), typeof(ImageSource), typeof(StandardWindow));

        #endregion

        #region Properties

        public bool ShowTitleBar
        {
            get => (bool)GetValue(ShowTitleBarPropperty);
            set => SetValue(ShowTitleBarPropperty, value);
        }

        public string TitleText
        {
            get => (string)GetValue(TitleTextProperty);
            set => SetValue(TitleTextProperty, value);
        }

        public Image WindowIcon
        {
            get => (Image)GetValue(WindowIconProperty);
            set => SetValue(WindowIconProperty, value);
        }
        #endregion
    }
}
