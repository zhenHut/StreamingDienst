using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace StreamingDienst.StandardFenster
{
    /// <summary>
    /// Interaktionslogik für WindowTitleBar.xaml
    /// </summary>
    public partial class WindowTitleBar : UserControl
    {
        #region Constructor
        public WindowTitleBar()
        {
            InitializeComponent();
        }

        #endregion

        #region Dependency Properties
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(BarCornerRadius), typeof(CornerRadius), typeof(WindowTitleBar), new PropertyMetadata(new CornerRadius(0)));

        public static readonly DependencyProperty TitleBarBackgroundProperty =
            DependencyProperty.Register(nameof(TitleBarBackground), typeof(Brush), typeof(WindowTitleBar));

        public static readonly DependencyProperty TitleBarStyleProperty =
            DependencyProperty.Register(nameof(TitlebarStyle), typeof(Style), typeof(WindowTitleBar), new PropertyMetadata(default(Style)));

        public static readonly DependencyProperty TitleTextProperty = 
            DependencyProperty.Register(nameof(TitleText), typeof(string), typeof(WindowTitleBar), new PropertyMetadata("Titel"));
        
        public static readonly DependencyProperty TitleForegroundProperty = 
            DependencyProperty.Register(nameof(TitleForeground), typeof(Brush), typeof(WindowTitleBar));
        
        public static readonly DependencyProperty TitleFontSizeProperty = 
            DependencyProperty.Register(nameof(TitleFontSize), typeof(int), typeof(WindowTitleBar));        

        public static readonly DependencyProperty TitleHorizontalAlignmentProperty = 
            DependencyProperty.Register(nameof(TitleHorizontalAlignment), typeof(string), typeof(WindowTitleBar), new PropertyMetadata("Center"));

        public static readonly DependencyProperty WindowIconProperty =
            DependencyProperty.Register(nameof(WindowIcon), typeof(string), typeof(WindowTitleBar));

        public static readonly DependencyProperty IconStyleProperty =
            DependencyProperty.Register(nameof(IconStyle), typeof(Style), typeof(WindowTitleBar));

        public static readonly DependencyProperty TitleStyleProperty =
            DependencyProperty.Register(nameof(TitleStyle), typeof(Style), typeof(WindowTitleBar));

        public static readonly DependencyProperty ButtonStyleProperty =
            DependencyProperty.Register(nameof(ButtonStyle), typeof(Style), typeof(WindowTitleBar));

        public static readonly DependencyProperty MinimizeCommandProperty =
           DependencyProperty.Register(nameof(MinimizeCommand), typeof(ICommand), typeof(WindowTitleBar));

        public static readonly DependencyProperty ShowMinimizeButtonProperty =
            DependencyProperty.Register(nameof(ShowMinimizeButton), typeof(bool), typeof(WindowTitleBar), new PropertyMetadata(false));

        public static readonly DependencyProperty MaximizeCommandProperty =
            DependencyProperty.Register(nameof(MaximizeCommand), typeof(ICommand), typeof(WindowTitleBar));

        public static readonly DependencyProperty ShowMaximizeButtonProperty =
            DependencyProperty.Register(nameof(ShowMaximizeButton), typeof(bool), typeof(WindowTitleBar), new PropertyMetadata(false));

        public static readonly DependencyProperty CloseCommandProperty =
            DependencyProperty.Register(nameof(CloseCommand), typeof(ICommand), typeof(WindowTitleBar));

        public static readonly DependencyProperty CloseButtonStyleProperty =
            DependencyProperty.Register(nameof(CloseButtonStyle), typeof(Style), typeof(WindowTitleBar));

        #endregion

        #region Properties

        public CornerRadius BarCornerRadius
        {
            get=>(CornerRadius)GetValue(CornerRadiusProperty);
            set=>SetValue(CornerRadiusProperty, value); }

        public Brush TitleBarBackground
        {
            get => (Brush)GetValue(TitleBarBackgroundProperty);
            set => SetValue(TitleBarBackgroundProperty, value);
        }

        public string TitleText
        {
            get=> (string)GetValue(TitleTextProperty);
            set => SetValue(TitleTextProperty, value);
        }

        public Brush TitleForeground
        {
            get => (Brush)GetValue(TitleForegroundProperty);
            set => SetValue(TitleForegroundProperty, value);
        }
         
        public int TitleFontSize
        {
            get =>(int)GetValue(TitleFontSizeProperty);
            set=> SetValue(TitleFontSizeProperty, value);
        }

        public string TitleHorizontalAlignment
        {
            get=>(string)GetValue(TitleHorizontalAlignmentProperty);
            set=> SetValue(TitleHorizontalAlignmentProperty, value);
        }

        public Style TitlebarStyle
        {
            get => (Style)GetValue(TitleBarStyleProperty);
            set => SetValue(TitleBarStyleProperty, value);
        }

        public string WindowIcon
        {
            get => (string)GetValue(WindowIconProperty);
            set => SetValue(WindowIconProperty, value);
        }

        public Style IconStyle
        {
            get => (Style)GetValue(IconStyleProperty);
            set => SetValue(IconStyleProperty, value);
        }

        public Style TitleStyle
        {
            get => (Style)GetValue(TitleStyleProperty);
            set => SetValue(TitleStyleProperty, value);
        }

        public Style ButtonStyle
        {
            get => (Style)GetValue(ButtonStyleProperty);
            set => SetValue(ButtonStyleProperty, value);
        }

        public ICommand MinimizeCommand
        {
            get => (ICommand)GetValue(MinimizeCommandProperty);
            set => SetValue(MinimizeCommandProperty, value);
        }

        public bool ShowMinimizeButton
        {
            get => (bool)GetValue(ShowMinimizeButtonProperty);
            set => SetValue(ShowMinimizeButtonProperty, value);
        }

        public ICommand MaximizeCommand
        {
            get => (ICommand)GetValue(MaximizeCommandProperty);
            set => SetValue(MaximizeCommandProperty, value);
        }

        public bool ShowMaximizeButton
        {
            get => (bool)GetValue(ShowMaximizeButtonProperty);
            set => SetValue(ShowMaximizeButtonProperty, value);
        }

        public ICommand CloseCommand
        {
            get => (ICommand)GetValue(CloseCommandProperty);
            set => SetValue(CloseCommandProperty, value);
        }

        public Style CloseButtonStyle
        {
            get => (Style)GetValue(CloseButtonStyleProperty);
            set => SetValue(CloseButtonStyleProperty, value);
        }
        #endregion

        #region EventMethods
      

        #endregion
    }
}
