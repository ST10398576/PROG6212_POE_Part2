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
    /// Interaction logic for ProgramCoOrdinator_AcademicManager.xaml
    /// </summary>
    public partial class ProgramCoOrdinator_AcademicManager : Window
    {
        public ProgramCoOrdinator_AcademicManager()
        {
            InitializeComponent();
        }
        string DBConn = "Data Source=labg9aeb3\\sqlexpress;Initial Catalog=PROG6212_POE;Integrated Security=True;";

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            CreateAccount createAccount = new CreateAccount();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
