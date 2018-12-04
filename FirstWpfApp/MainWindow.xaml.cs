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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Drawing;

namespace FirstWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            KeepReportMousePos();
        }

        public void KeepReportMousePos()
        {
            //Endless Report Mouse position
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.SystemIdle,
                        new Action(() =>
                        {
                            DisplayMousePosition();
                        }));
                }
            });
        }
        public void DisplayMousePosition()
        {
            //get the mouse position and show on the TextBlock
            System.Drawing.Point p = GetMousePosition();
            TBK.Text = "X: " + p.X + " " + "Y: " + p.Y;
        }

        private void MainWindow_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            //invoke mouse position detect when wheel the mouse
            KeepReportMousePos();
        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Drawing.Point p = GetMousePosition();
            System.Windows.Clipboard.SetText(p.X + " " + p.Y);
        }

        private System.Drawing.Point GetMousePosition()
        {
            System.Drawing.Point p = System.Windows.Forms.Cursor.Position;
            return p;
        }
    }
}
