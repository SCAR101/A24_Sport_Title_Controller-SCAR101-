using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace A24_Sport_Title_Controller
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GridUp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (WindowState == WindowState.Maximized)
                {
                    WindowState = WindowState.Normal;
                    btnWinMax.Content = "Развернуть";
                }
                else
                {
                    WindowState = WindowState.Maximized;
                    btnWinMax.Content = "Восстановить";
                }
            }
            else
            {
                this.DragMove();
            }
        }

        private void btnMaximaze_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                btnWinMax.Content = "Развернуть";
            }
            else
            {
                WindowState = WindowState.Maximized;
                btnWinMax.Content = "Восстановить";
            }
        }

        private void btnMinimize_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation anim;
            anim = new DoubleAnimation(1.0, 0.0, new Duration(TimeSpan.FromSeconds(0.3)));
            anim.Completed += (s, a) => System.Windows.Application.Current.Shutdown();
            this.BeginAnimation(A24_Sport_Title_Controller.MainWindow.OpacityProperty, anim);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
            btnWinMax.Content = "Восстановить";
        }
    }
}
