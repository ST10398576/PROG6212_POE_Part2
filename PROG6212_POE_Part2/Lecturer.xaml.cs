﻿using System;
using System.Collections;
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
using static System.Net.Mime.MediaTypeNames;

namespace PROG6212_POE_Part2
{
    /// <summary>
    /// Interaction logic for Lecturer.xaml
    /// </summary>
    public partial class Lecturer : Window
    {
        public Lecturer()
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
            string Username = txtUsername.Text;
            string Password = txtPassword.Text;

            if (Username != null || Password != null)
            {
                using (SqlConnection conn = new SqlConnection(DBConn))
                {
                    string query = $"SELECT * FROM Account where Username={Username} && UserPassword={Password} && AccountType='Lecturer'";

                    // Open connection to database
                    conn.Open();

                    // Create command
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        LecturerDashboard lecturerDashboard = new LecturerDashboard(Username);
                    }
                }
            }
            else 
            {
                UseAndPassBlock.Text = "Both The Username and Password and Must be filled in!";
            }
        }
    }
}
            
            
      