//using DoodleJump;
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

namespace Лиза
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            DeliteUpdateInsert taskWindow = new DeliteUpdateInsert();
            taskWindow.Show();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Show taskWindow = new Show();
            taskWindow.Show();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            export taskWindow = new export();
            taskWindow.Show();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    Window_StartGame taskWindow = new Window_StartGame();
        //    taskWindow.Show();
        //}
        ///Коммит 1
        ///Commit2
      

        
    }
}
