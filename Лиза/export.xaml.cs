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
using Word = Microsoft.Office.Interop.Word;
namespace Лиза
{
    /// <summary>
    /// Логика взаимодействия для export.xaml
    /// </summary>
    public partial class export : Window
    {
        Word._Application oWord = new Word.Application();
        object oMissing = System.Reflection.Missing.Value;
        public export()
        { 
            InitializeComponent();
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
            sqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From Base", sqlConnection);
            DataTable dt = new DataTable("Base");
            adapter.Fill(dt);
            dataGrid1.ItemsSource = dt.DefaultView;
        }
        private SqlConnection sqlConnection = null;
        private void btn_Show_Click(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
            sqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From Base", sqlConnection);
            DataTable dt = new DataTable("Base");
            adapter.Fill(dt);
            dataGrid1.ItemsSource = dt.DefaultView;
        }


        private void Window1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            oWord.Quit();
        }

        private void SetTemplate(Word._Document oDoc)
        {
            TextBox textBox1 = new TextBox();
            TextBox textBox2 = new TextBox();
            TextBox textBox3 = new TextBox();
            TextBox textBox4 = new TextBox();
            TextBox textBox5 = new TextBox();
            TextBox textBox6 = new TextBox();
            TextBox textBox7 = new TextBox();
            TextBox textBox8 = new TextBox();
            TextBox textBox9 = new TextBox();
            TextBox textBox10 = new TextBox();
            TextBox textBox11 = new TextBox();
            textBox1.Text = ((DataRowView)dataGrid1.SelectedItem).Row[0].ToString();
            textBox2.Text = ((DataRowView)dataGrid1.SelectedItem).Row[1].ToString();
            textBox3.Text = ((DataRowView)dataGrid1.SelectedItem).Row[2].ToString();
            textBox4.Text = ((DataRowView)dataGrid1.SelectedItem).Row[3].ToString();
            textBox5.Text = ((DataRowView)dataGrid1.SelectedItem).Row[4].ToString();
            textBox6.Text = ((DataRowView)dataGrid1.SelectedItem).Row[5].ToString();
            textBox7.Text = ((DataRowView)dataGrid1.SelectedItem).Row[6].ToString();
            textBox8.Text = ((DataRowView)dataGrid1.SelectedItem).Row[7].ToString();
            textBox9.Text = DateTime.Now.ToString();
            textBox10.Text = ((DataRowView)dataGrid1.SelectedItem).Row[7].ToString();
            textBox11.Text = DateTime.Now.ToString("dd/MM/yyyy");
            object oBookMark = "Номер";
            oDoc.Bookmarks.get_Item(ref oBookMark).Range.Text = textBox1.Text;
            object oBookMark1 = "ФИО";
            oDoc.Bookmarks.get_Item(ref oBookMark1).Range.Text = textBox2.Text;
            object oBookMark3 = "Марка";
            oDoc.Bookmarks.get_Item(ref oBookMark3).Range.Text = textBox3.Text;
            object oBookMark4 = "Модель";
            oDoc.Bookmarks.get_Item(ref oBookMark4).Range.Text = textBox4.Text;
            object oBookMark5 = "Год";
            oDoc.Bookmarks.get_Item(ref oBookMark5).Range.Text = textBox5.Text;
            object oBookMark6 = "Работы";
            oDoc.Bookmarks.get_Item(ref oBookMark6).Range.Text = textBox6.Text;
            object oBookMark7 = "Сумма";
            oDoc.Bookmarks.get_Item(ref oBookMark7).Range.Text = textBox7.Text;
            object oBookMark8 = "Дата";
            oDoc.Bookmarks.get_Item(ref oBookMark8).Range.Text = textBox8.Text;
            object oBookMark9 = "Число";
            oDoc.Bookmarks.get_Item(ref oBookMark9).Range.Text = textBox11.Text;
            object oBookMark2 = "Сумма1";
            oDoc.Bookmarks.get_Item(ref oBookMark2).Range.Text = textBox7.Text;
        }

        private Word._Document GetDoc(string path)
        {
            Microsoft.Office.Interop.Word._Document oDoc = oWord.Documents.Add(path);
            SetTemplate(oDoc);
            return oDoc;
        }

        private void bntExport_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog print = new PrintDialog();
            if (print.ShowDialog() == true)
            {
                Word._Document oDoc = GetDoc(Environment.CurrentDirectory + "\\1.dotx");
                oDoc.SaveAs(FileName: Environment.CurrentDirectory + "\\Отчет.docx");
                oDoc.Close();
            }
            MessageBox.Show("Квитанция готова");
            oWord.Quit();
            Close();
        }
    }
}