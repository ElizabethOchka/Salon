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

namespace Лиза
{
    /// <summary>
    /// Логика взаимодействия для DeliteUpdateInsert.xaml
    /// </summary>
    public partial class DeliteUpdateInsert : Window
    {
        private SqlConnection sqlConnection = null;
        public DeliteUpdateInsert()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
            sqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From Base", sqlConnection);
            DataTable dt = new DataTable("Base");
            adapter.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Insert taskWindow = new Insert();
            taskWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM  [Base] where [Id]= '" + ((DataRowView)dataGrid.SelectedItem).Row[0].ToString() + "'", sqlConnection);
                command.ExecuteNonQuery();
                sqlConnection.Close();
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("Select * From Base", sqlConnection);
                DataTable dt = new DataTable("Base");
                adapter.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                MessageBox.Show("Данные удалены");
                SqlDataAdapter adapter1 = new SqlDataAdapter("Select * From Base", sqlConnection);
                DataTable dt1 = new DataTable("Base");
                adapter.Fill(dt1);
                dataGrid.ItemsSource = dt.DefaultView;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Update taskWindow = new Update();
            taskWindow.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
            sqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From Base", sqlConnection);
            DataTable dt = new DataTable("Base");
            adapter.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
        }
    }
}
