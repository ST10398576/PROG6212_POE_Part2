using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG6212_POE_Part2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string DBConn = "Data Source=labg9aeb3\\sqlexpress;Initial Catalog = PROG6212_POE; Integrated Security = True;";

        private void LecturerSignIn_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Lecturer lecturer = new Lecturer();
            lecturer.Show();
        }

        private void PCoordinatorAManagerSignIn_Click(object sender, RoutedEventArgs e)
        {
            Close();
            ProgramCoOrdinator_AcademicManager programCoOrdinator_AcademicManager = new ProgramCoOrdinator_AcademicManager();
            programCoOrdinator_AcademicManager.Show();
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            Close();
            CreateAccount createAccount = new CreateAccount();
            createAccount.Show();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}