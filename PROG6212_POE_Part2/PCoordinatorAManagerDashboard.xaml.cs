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
    /// Interaction logic for PCoordinatorAManagerDashboard.xaml
    /// </summary>
    public partial class PCoordinatorAManagerDashboard : Window
    {
        public PCoordinatorAManagerDashboard()
        {
            InitializeComponent();
        }

        string dbConnection = @"Server=labg9aeb3\sqlexpress;Database=PROG6212_POE; Trusted_Connection=True";
    }
}
