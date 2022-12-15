using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
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
using System.Windows.Shapes;
using System;
using System.Text.RegularExpressions;
using System.IO;

namespace Лиза
{
    /// <summary>
    /// Логика взаимодействия для Insert.xaml
    /// </summary>
    public partial class Insert : Window
    {
        private SqlConnection sqlConnection = null;
        public Insert()
        {
            InitializeComponent();
            txtYear.MaxLength = 4;
            txtMake.ItemsSource = File.ReadAllLines(@"1.txt");
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Zа-яА-Я ]+$");
            Regex regex_1 = new Regex("^[0-9.]+$");
            if (!regex.IsMatch(txtFio.Text) || !regex.IsMatch(txtMake.Text) || !regex_1.IsMatch(txtYear.Text) || !regex_1.IsMatch(txtDate.Text) || !regex_1.IsMatch(txtSumma.Text))
            {

                MessageBox.Show("Введите корректные данные");
            }
            else
            {
                if (((string.IsNullOrEmpty(txtFio.Text))) || ((string.IsNullOrEmpty(txtMake.Text))) || ((string.IsNullOrEmpty(txtModel.Text))) || ((string.IsNullOrEmpty(txtYear.Text))) || ((string.IsNullOrEmpty(txtWorks.Text))) || ((string.IsNullOrEmpty(txtSumma.Text))) || ((string.IsNullOrEmpty(txtDate.Text)))) MessageBox.Show("Данные не введены");
                else
                {
                    sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand($"Insert into [Base]([ФИО], [Марка], [Модель], [Год], [Работы], [Стоимость], [Дата заказа]) Values (@Fio,  @Make, @Model, @Year, @Works, @Summa, @Date)", sqlConnection); ;
                    command.Parameters.AddWithValue("Fio", txtFio.Text);
                    command.Parameters.AddWithValue("Make", txtMake.Text);
                    command.Parameters.AddWithValue("Model", txtModel.Text);
                    command.Parameters.AddWithValue("Year", txtYear.Text);
                    command.Parameters.AddWithValue("Works", txtWorks.Text);
                    command.Parameters.AddWithValue("Summa", txtSumma.Text);
                    command.Parameters.AddWithValue("Date", txtDate.Text);
                    int a = command.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Данные записаны");
                    }
                    txtFio.Clear(); txtDate.Text=null; txtMake.Text= null; txtModel.Clear(); txtYear.Clear(); txtWorks.Clear(); txtSumma.Clear();
                }
            }
        }

        private void txtYear_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[a-zA-Zа-яА-Я]+");
            if (re.IsMatch(e.Text))
            {
                txtYear.BorderBrush = Brushes.Red;
            }
        }

        private void txtFio_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[а-яА-Я]+");
            if (!re.IsMatch(e.Text))
            {
                txtFio.BorderBrush = Brushes.Red;
            }
        }

        private void txtSumma_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[a-zA-Zа-яА-Я]+");
            if (re.IsMatch(e.Text))
            {
                txtSumma.BorderBrush = Brushes.Red;
            }
        }
    }
}

