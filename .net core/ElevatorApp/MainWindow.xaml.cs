using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElevatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly int Stories, ElevatorHeight;
        private int currFloor = 1;
        public MainWindow()
        {
            InitializeComponent();

            Width = 500;
            
            Stories = 10;
            ElevatorHeight = (int)(Height / Stories);

            SetElevatorHeight(ElevatorHeight);
            SetElevatorPosition(currFloor);
        }

        private void SetElevatorHeight(int h)
        {
            ElevatorObject.Height = h;
            InteractiveMenu.Height = ElevatorObject.Height;
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Up)
            {
                SetElevatorPosition(++currFloor);
            }
            else if(e.Key == Key.Down)
            {
                SetElevatorPosition(--currFloor);
            }

            if (e.Key == Key.Escape)
                this.Close();

            Debug.WriteLine($"CurrFloor {currFloor}");
        }

        private void SetElevatorPosition(int floor)
        {
            ElevatorObject.Margin = new Thickness(0, Height - (floor * ElevatorHeight),0,0);
            InteractiveMenu.Margin = ElevatorObject.Margin;
        }
    }
}
