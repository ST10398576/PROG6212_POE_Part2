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
    /// Interaction logic for ClaimStatus.xaml
    /// </summary>
    public partial class ClaimStatus : Window
    {
        string DBConn = "Data Source=labg9aeb3\\sqlexpress;Initial Catalog=PROG6212_POE;Integrated Security=True;";

        public ClaimStatus()
        {
            InitializeComponent();
            txtClaimStatusHeading.Content = $"Claim Status For Lecturer";
        }

    }
}
