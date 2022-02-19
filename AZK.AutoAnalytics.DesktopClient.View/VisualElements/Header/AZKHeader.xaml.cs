using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AZK.AutoAnalytics.DesktopClient.View.VisualElements.Header
{
    /// <summary>
    /// Interaction logic for AZKHeader.xaml
    /// </summary>
    public partial class AZKHeader : UserControl
    {
        public AZKHeader()
        {
            InitializeComponent();
        }

        
        private void HeaderDblClickHandler(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                Window.GetWindow(this).DragMove();
            }
            else if (e.ClickCount == 2)
            {
                ResizeWind_Click(null, null);
            }
        }
        private void HideBtn_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this);
            parentWindow.WindowState = WindowState.Minimized;
        }

        private void ResizeWind_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this);

            var currentState = parentWindow.WindowState;

            switch (currentState)
            {
                case WindowState.Maximized:
                    {
                        parentWindow.WindowState = WindowState.Normal;
                        break;
                    }
                case WindowState.Normal:
                    {
                        parentWindow.WindowState = WindowState.Maximized;
                        break;
                    }
                default:
                    {
                        //when WindowState.Ninimized -> do nothing
                        break;
                    }
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }
    }
}
