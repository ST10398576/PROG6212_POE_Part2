using System;
using System.Collections;
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
    /// Interaction logic for LecturerDashboard.xaml
    /// </summary>
    public partial class LecturerDashboard : Window
    {
        public LecturerDashboard(string Username)
        {
            InitializeComponent();
            
            txtClaimStatus.Content = $" Claim Status of {Username}";
        }

        string DBConn = "Data Source=labg9aeb3\\sqlexpress;Initial Catalog=PROG6212_POE;Integrated Security=True;";

        private void btnSubmitClaim_Click(object sender, RoutedEventArgs e)
        {
            SubmitClaim submitClaim = new SubmitClaim();
            submitClaim.Show();
        }

        private void btnSupportingDocs_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnViewClaims_Click(object sender, RoutedEventArgs e)
        {
            ClaimStatus claimStatus = new ClaimStatus();
        }
    }
}
