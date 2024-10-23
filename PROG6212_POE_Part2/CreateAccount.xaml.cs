using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace PROG6212_POE_Part2
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        string DBConn = "Data Source=labg9aeb3\\sqlexpress;Initial Catalog=PROG6212_POE;Integrated Security=True;"; 

        private void CancelAccount_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            string UserFirstName = txtUserFirstName.Text;
            string UserLastName = txtUserLastName.Text;
            string UserEmail = txtUserEmail.Text;
            string UserPhoneNumber = Convert.ToString(txtUserPhoneNumber.Text);
            string UserFaculty = txtUserFaculty.Text;
            string Username = txtUsername.Text;
            string UserPassword = txtUserPassword.Text;
            string AccountType = (AccountTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrWhiteSpace(UserFirstName) || string.IsNullOrWhiteSpace(UserLastName) || string.IsNullOrWhiteSpace(UserEmail) ||
                string.IsNullOrWhiteSpace(UserPhoneNumber) || string.IsNullOrWhiteSpace(UserFaculty) || string.IsNullOrWhiteSpace(Username) || 
                string.IsNullOrWhiteSpace(UserPassword) || string.IsNullOrWhiteSpace(AccountType))
            {
                MessageBox.Show("Please fill out all fields.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(DBConn))
            {
                string query = $"INSERT INTO Account values ({UserFirstName},{UserLastName},{UserEmail},{UserPhoneNumber},{UserFaculty},{Username},{UserPassword},{AccountType}) ";

                // Open connection to database
                conn.Open();

                // Create command
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    MessageBox.Show("Welcome " + Username + "Role: Lecturer");
                }
            }
            Close();
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
