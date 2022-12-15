using System;
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
using System.Text.RegularExpressions;

namespace Лиза
{
    /// <summary>
    /// Логика взаимодействия для Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        private SqlConnection sqlConnection = null;
        public Update()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
            sqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From Base", sqlConnection);
            DataTable dt = new DataTable("Base");
            adapter.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
        }
        private void cleaning()
        {
           txtFio_up.Clear(); txtDate_up.Text=null; txtMake_up.Clear(); txtModel_up.Clear(); txtYear_up.Clear(); txtWorks_up.Clear(); txtSumma_up.Clear();

        }
        private void show()
        {
            txtFio_up.Visibility = Visibility.Visible;
            txtMake_up.Visibility = Visibility.Visible;
            txtModel_up.Visibility = Visibility.Visible;
            txtYear_up.Visibility = Visibility.Visible;
            txtWorks_up.Visibility = Visibility.Visible;
            txtSumma_up.Visibility = Visibility.Visible;
            txtDate_up.Visibility = Visibility.Visible;
            btn_Update_save.Visibility = Visibility.Visible;
            l1.Visibility = Visibility.Visible;
            l2.Visibility = Visibility.Visible;
            l3.Visibility = Visibility.Visible;
            l4.Visibility = Visibility.Visible;
            l5.Visibility = Visibility.Visible;
            l6.Visibility = Visibility.Visible;
            l7.Visibility = Visibility.Visible;
            dataGrid.Visibility = Visibility.Hidden;
            btn_Update.Visibility = Visibility.Hidden;

        }
        private void no_show()
        {
            txtFio_up.Visibility = Visibility.Hidden;
            txtMake_up.Visibility = Visibility.Hidden;
            txtModel_up.Visibility = Visibility.Hidden;
            txtYear_up.Visibility = Visibility.Hidden;
            txtWorks_up.Visibility = Visibility.Hidden;
            txtSumma_up.Visibility = Visibility.Hidden;
            txtDate_up.Visibility = Visibility.Hidden;
            btn_Update_save.Visibility = Visibility.Hidden;
            l1.Visibility = Visibility.Hidden;
            l2.Visibility = Visibility.Hidden;
            l3.Visibility = Visibility.Hidden;
            l4.Visibility = Visibility.Hidden;
            l5.Visibility = Visibility.Hidden;
            l6.Visibility = Visibility.Hidden;
            l7.Visibility = Visibility.Hidden;
            dataGrid.Visibility = Visibility.Visible;
            btn_Update.Visibility = Visibility.Visible;

        }
        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            show();
            txtFio_up.Text = ((DataRowView)dataGrid.SelectedItem).Row[1].ToString();
            txtMake_up.Text = ((DataRowView)dataGrid.SelectedItem).Row[2].ToString();
            txtModel_up.Text = ((DataRowView)dataGrid.SelectedItem).Row[3].ToString();
            txtYear_up.Text = ((DataRowView)dataGrid.SelectedItem).Row[4].ToString();
            txtWorks_up.Text = ((DataRowView)dataGrid.SelectedItem).Row[5].ToString();
            txtSumma_up.Text = ((DataRowView)dataGrid.SelectedItem).Row[6].ToString();
            txtDate_up.Text = ((DataRowView)dataGrid.SelectedItem).Row[7].ToString();
        }


        private void Update_save_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Zа-яА-Я ]+$");
            Regex regex_1 = new Regex("^[0-9.]+$");
            if (!regex.IsMatch(txtFio_up.Text)  || !regex.IsMatch(txtMake_up.Text)  || !regex_1.IsMatch(txtYear_up.Text) || !regex_1.IsMatch(txtDate_up.Text) || !regex_1.IsMatch(txtSumma_up.Text))
            {

                MessageBox.Show("Введите корректные данные");
            }
            else
            {
                if (((string.IsNullOrEmpty(txtFio_up.Text))) || ((string.IsNullOrEmpty(txtDate_up.Text))) || ((string.IsNullOrEmpty(txtMake_up.Text))) || ((string.IsNullOrEmpty(txtModel_up.Text))) || ((string.IsNullOrEmpty(txtYear_up.Text))) || ((string.IsNullOrEmpty(txtWorks_up.Text))) || ((string.IsNullOrEmpty(txtSumma_up.Text)))) MessageBox.Show("Данные не введены");
                else
                {
                    sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand("UPDATE [Base] set [ФИО] = @Fio,  [Марка] =@Make, [Модель] =@Model, [Год] = @Year, [Работы] =@Works, [Стоимость] =@Summa,[Дата заказа]=@Date where [Id] = '" + ((DataRowView)dataGrid.SelectedItem).Row[0].ToString() + "'", sqlConnection);
                    command.Parameters.AddWithValue("@Fio", txtFio_up.Text);
                    command.Parameters.AddWithValue("@Make", txtMake_up.Text);
                    command.Parameters.AddWithValue("@Model", txtModel_up.Text);
                    command.Parameters.AddWithValue("@Year", txtYear_up.Text);
                    command.Parameters.AddWithValue("@Works", txtWorks_up.Text);
                    command.Parameters.AddWithValue("@Summa", txtSumma_up.Text);
                    command.Parameters.AddWithValue("@Date", txtDate_up.Text);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                    sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
                    sqlConnection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * From Base", sqlConnection);
                    DataTable dt = new DataTable("Base");
                    adapter.Fill(dt);
                    dataGrid.ItemsSource = dt.DefaultView;
                    MessageBox.Show("Данные изменены");
                    cleaning();
                    no_show();
                }
            }
        }

       

        private void txtFio_up_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

                Regex re = new Regex("[a-zA-Zа-яА-Я]+");
                if (!re.IsMatch(e.Text))
                {
                    txtFio_up.BorderBrush = Brushes.Red;
                }
            
        }

        private void txtYear_up_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[a-zA-Zа-яА-Я]+");
            if (re.IsMatch(e.Text))
            {
                txtYear_up.BorderBrush = Brushes.Red;
            }
        }

        private void txtSumma_up_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[a-zA-Zа-яА-Я]+");
            if (re.IsMatch(e.Text))
            {
                txtSumma_up.BorderBrush = Brushes.Red;
            }
        }
    }


}
