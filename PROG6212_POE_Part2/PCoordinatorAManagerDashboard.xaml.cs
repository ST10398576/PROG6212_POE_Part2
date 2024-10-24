using System;
using System.Collections.Generic;
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
    /// Interaction logic for PCoordinatorAManagerDashboard.xaml
    /// </summary>
    public partial class PCoordinatorAManagerDashboard : Window
    {
        string DBConn = "Data Source=labg9aeb3\\sqlexpress;Initial Catalog=PROG6212_POE;Integrated Security=True;";

        public PCoordinatorAManagerDashboard()
        {
            InitializeComponent();
            LoadPendingClaims();
        }

        private void LoadPendingClaims()
        {
            List<Claim> pendingClaims = new List<Claim>();

            // Load All pending claims
            string query = "SELECT ClaimId, LecturerName, AdditionalNotes, Status FROM Claims";

            using (SqlConnection connection = new SqlConnection(DBConn))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Claim claim = new Claim
                        {
                            ClaimId = reader.GetInt32(0),
                            LecturerName = reader.GetString(1),
                            AdditionalNotes = reader.GetString(2),
                            Status = reader.GetString(3)

                        };
                        pendingClaims.Add(claim);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading claims: {ex.Message}");
                }
            }

            // Binding the list of claims to the ListView
            ClaimListView.ItemsSource = pendingClaims;
        }

        private void Approve_Click(object sender, RoutedEventArgs e)
        {
            // Logic for approving the claim
            if (ClaimListView.SelectedItem is Claim selectedClaim)
            {
                UpdateClaimStatus(selectedClaim.ClaimId, "Approved");
            }
        }

        private void Reject_Click(object sender, RoutedEventArgs e)
        {
            // Logic for rejecting the claim
            if (ClaimListView.SelectedItem is Claim selectedClaim)
            {
                UpdateClaimStatus(selectedClaim.ClaimId, "Rejected");
            }
        }

        private void UpdateClaimStatus(int claimId, string status)
        {
            string query = "UPDATE Claims SET Status = @Status WHERE ClaimId = @ClaimId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@ClaimId", claimId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show($"Claim {status} successfully.");
                    LoadPendingClaims();  // Refresh the claim list
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private void ClaimListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ClaimListView.SelectedItem is Claim selectedClaim)
            {
                ClaimDetailsTextBox.Text = $"Lecturer: {selectedClaim.LecturerName}\n" +
                                           $"Notes: {selectedClaim.AdditionalNotes}";
            }
        }
    }
}
