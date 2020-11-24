using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using AislevatorSystem;

namespace ElevatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly int Stories, ElevatorHeight;
        private int currFloor = 1;

        private Elevator elevator;

        public MainWindow()
        {
            InitializeComponent();
            Stories = 10;
            currFloor = Stories; //top

            elevator = new Elevator(currFloor);
            
            ElevatorHeight = (int)(Height / Stories);

            SetElevatorHeight(ElevatorHeight);

            for (int i = 1; i <= Stories; i++)
            {
                var callBtn = new Button()
                {
                    Name = i == 1 ? "ElevatorBottom" : "",
                    Tag = i,
                    Content = $"{i}",
                    Height = ElevatorHeight,
                    Width = CallButtonMenu.Width,
                    Margin = new Thickness(0, this.Height - i * ElevatorHeight, 0, 0),
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };

                callBtn.Click += CallBtn_Click;

                CallButtonMenu.Children.Add(callBtn);
            }
        }

        private async void CallBtn_Click(object sender, RoutedEventArgs e)
        {
            var f = (int)((Button)sender).Tag;
            Debug.WriteLine($"Elevator Called at {f}");
            await Task.Run(new Action(() =>
            {
                foreach (int f in elevator.GetMoveList(f))
                {
                    Thread.Sleep(100);
                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        SetElevatorPosition(f);
                    }));
                }
            }));
        }

        private void SetElevatorHeight(int h)
        {
            ElevatorObject.Height = h;
            InteractiveMenu.Height = ElevatorObject.Height;
        }
        private void SetElevatorPosition(int floor)
        {
            Debug.WriteLine($"{floor} floor ... ");
            ElevatorObject.Margin = new Thickness(0, Height - (floor * ElevatorHeight) - 14, 0, 0);
            InteractiveMenu.Margin = ElevatorObject.Margin;
        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }



    }
}
