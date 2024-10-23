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

        string dbConnection = @"Server=labg9aeb3\sqlexpress;Database=PROG6212_POE; Trusted_Connection=True";

        private void CancelAccount_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            string UserFirstName = txtUserFirstName.Text;
            string UserLastName = txtUserLastName.Text;
            string UserEmail = txtUserEmail.Text;
            int UserPhoneNumber = Convert.ToInt32(txtUserPhoneNumber.Text);
            string UserFaculty = txtUserFaculty.Text;
            string Username = txtUsername.Text;
            string UserPassword = txtUserPassword.Text;
            string AccountType = (AccountTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();  

        }
    }
}
