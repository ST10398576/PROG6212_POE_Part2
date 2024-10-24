using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for SubmitClaim.xaml
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
                    foreach (string file in openFileDialog.FileNames)
                    {
                        StoreFileSecurely(file);
                    }

                    UploadedFilesTextBlock.Text = string.Join(", ", uploadedFileNames);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void StoreFileSecurely(string filePath)
        {
            // Define the directory to store the uploaded files
            string directoryPath = "C:\\SecureUploads"; // Change this to your secure directory

            // Ensure the directory exists
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Generate a unique file name to avoid conflicts
            string fileName = Path.GetFileName(filePath);
            string newFilePath = Path.Combine(directoryPath, Guid.NewGuid().ToString() + "_" + fileName);

            // Copy the file to the secure directory
            File.Copy(filePath, newFilePath, true); // true to overwrite if the file already exists

            // Add the uploaded file name to the list
            uploadedFileNames.Add(fileName);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            int ClassesTaught = Convert.ToInt32(txtLessonNum.Text) * Convert.ToInt32(txtHourlyRate.Text);
            txtTotalClaimAmount.Text = $"R{ClassesTaught}"; 
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string ClaimClassTaught = txtClassTaughtNum.Text;
            string ClaimLessonNum = txtLessonNum.Text;
            string ClaimHourlyRate = txtHourlyRate.Text;

        }

        
    }
}
