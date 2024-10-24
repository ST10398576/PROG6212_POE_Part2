﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
    /// Link to GitHub Repository: https://github.com/ST10398576/PROG6212_POE_Part2.git
    /// </summary>
    public partial class SubmitClaim : Window
    {
        public SubmitClaim()
        {
            InitializeComponent();
        }

        string DBConn = "Data Source=labg9aeb3\\sqlexpress;Initial Catalog=PROG6212_POE;Integrated Security=True;";

        private List<string> uploadedFileNames = new List<string>();


        private void btnSupDoc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Multiselect = true,
                    Title = "Select Documents",
                    Filter = "PDF Files (*.pdf)|*.pdf|Word Documents (*.docx;*.doc)|*.docx;*.doc|Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    txtSupDoc.Text = string.Join(", ", uploadedFileNames);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            decimal TotalAmount = Convert.ToInt32(txtLessonNum.Text) * Convert.ToDecimal(txtHourlyRate.Text);
            txtTotalClaimAmount.Text = $"R{TotalAmount}"; 
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string ClaimClassTaught = txtClassTaughtNum.Text;
            string ClaimLessonNum = txtLessonNum.Text;
            string ClaimHourlyRate = txtHourlyRate.Text;
            string ClaimTotalAmount = txtTotalClaimAmount.Text;
            string ClaimSupDocs = txtSupDoc.Text;
            string ClaimStatus = "Pending";

            // Validate inputs
            if (string.IsNullOrEmpty(ClaimHourlyRate) || string.IsNullOrEmpty(ClaimHourlyRate))
            {
                MessageBox.Show("Please fill in hours worked and hourly rate.");
                return;
            }

            if (!int.TryParse(ClaimHourlyRate, out int HoursWorked) || !int.TryParse(ClaimHourlyRate, out int HourlyRate))
            {
                MessageBox.Show("Please enter valid numeric values for hours worked and hourly rate.");
                return;
            }

            SubmitClaimToDatabase(ClaimClassTaught, HoursWorked, HourlyRate, ClaimTotalAmount, ClaimSupDocs, ClaimStatus);

        }

        private void SubmitClaimToDatabase(string ClaimClassTaught, int ClaimLessonNum, int ClaimHourlyRate, string ClaimTotalAmount, string ClaimSupDocs, string ClaimStatus)
        {
            if (!VerifyDatabaseConnection())
            {
                MessageBox.Show("Unable to connect to the database. Please check your connection settings.");
                return;
            }

            string query = "INSERT INTO Claims (ClaimClassTaught, ClaimLessonNum, ClaimHourlyRate, ClaimTotalAmount, ClaimSupDocs, ClaimStatus) VALUES (@ClaimClassTaught, @ClaimLessonNum, @ClaimHourlyRate, @ClaimTotalAmount, @ClaimSupDocs, @ClaimStatus)";

            using (SqlConnection conn = new SqlConnection(DBConn))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClaimClassTaught", ClaimClassTaught);
                cmd.Parameters.AddWithValue("@ClaimLessonNum", ClaimLessonNum);
                cmd.Parameters.AddWithValue("@ClaimHourlyRate", ClaimHourlyRate);
                cmd.Parameters.AddWithValue("@ClaimTotalAmount", ClaimTotalAmount);
                cmd.Parameters.AddWithValue("@ClaimSupDocs", ClaimSupDocs);
                cmd.Parameters.AddWithValue("@ClaimStatus", ClaimStatus);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Claim submitted successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while submitting the claim: {ex.Message}\n{ex.StackTrace}");
                }
            }
        }

        private bool VerifyDatabaseConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBConn))
                {
                    conn.Open(); // Try to open the connection
                    return true; // Connection is successful
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Connection error: {sqlEx.Message}");
                return false; // Connection failed
            }
        }

    }
}
