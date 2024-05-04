using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Inventory_Management_Application
{
    public partial class ManageUsers : Form
    {
        const string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maher\OneDrive\Documents\InventoryDB.mdf;Integrated Security=True;Connect Timeout=30");
        public ManageUsers()
        {
            InitializeComponent();
            UserGV.CellClick += UserGV_CellClick;

        }
        //select user by click on the GV cells
        private void UserGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if the clicked row index is valid
            {
                try
                {
                    // Directly use e.RowIndex to ensure you're working with the row that was clicked
                    DataGridViewRow row = UserGV.Rows[e.RowIndex];

                    // Safely convert cell values to string, assuming cells are not null
                    UsernameTextbox.Text = row.Cells[0].Value?.ToString() ?? "";
                    FullnameTextbox.Text = row.Cells[1].Value?.ToString() ?? "";
                    PasswordTextbox.Text = row.Cells[2].Value?.ToString() ?? "";
                    TelephoneTextbox.Text = row.Cells[3].Value?.ToString() ?? "";

                    // Optional: Remove MessageBox if it's too intrusive for frequent actions
                    MessageBox.Show("User selected");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error selecting user: {ex.Message}");
                }
            }
        }

        //populate GV with users
        void PopulateGraph()
        {
            DataSet dataSet = new DataSet();
            try
            {
                string myQuery = "SELECT * FROM UserTable";
                using (SqlConnection connection = new SqlConnection(connectionString)) // Ensure to define or pass connectionString
                {
                    connection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(myQuery, connection))
                    {
                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                        dataAdapter.Fill(dataSet);
                    } // SqlDataAdapter is disposed here, which also closes the connection
                } // SqlConnection is disposed here, if not already closed
                UserGV.DataSource = dataSet.Tables[0];
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"An error occurred: {sqlEx.Message}");
                // Log sqlEx here; you could use Debug.WriteLine(sqlEx) for simplicity or any logging framework you prefer
                throw; // Consider rethrowing or handling the exception based on your application's error handling policy
            }
            catch (Exception ex)
            {
                // Log or handle general exceptions
                MessageBox.Show($"An error occurred: {ex.Message}");
                throw;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //add user after filling infos
        private void button1_Click(object sender, EventArgs e)
        {
            // Use parameterized SQL to prevent SQL injection
            string query = "INSERT INTO UserTable (User_name, User_fullname, User_password, User_telephone) VALUES (@Username, @Fullname, @Password, @Telephone)";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@Username", UsernameTextbox.Text);
                        cmd.Parameters.AddWithValue("@Fullname", FullnameTextbox.Text);
                        cmd.Parameters.AddWithValue("@Password", PasswordTextbox.Text);
                        cmd.Parameters.AddWithValue("@Telephone", TelephoneTextbox.Text);

                        connection.Open();
                        int result = cmd.ExecuteNonQuery();

                        // Check if the insert was successful
                        if (result > 0)
                        {
                            MessageBox.Show("User successfully added");
                            PopulateGraph(); // Refresh the graph to show the new user
                        }
                        else
                        {
                            MessageBox.Show("User not added. Please try again.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        //OnLoad?
        private void ManageUsers_Load(object sender, EventArgs e)
        {
            PopulateGraph();
        }
        //Deleted users after matching phone number
        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TelephoneTextbox.Text))
            {
                MessageBox.Show("Enter user phone number");
                return; // Exit the method early to avoid further processing.
            }
            string query = "DELETE FROM UserTable WHERE User_telephone = @Telephone";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Use parameters to prevent SQL injection.
                        cmd.Parameters.AddWithValue("@Telephone", TelephoneTextbox.Text);

                        connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if any rows were actually deleted.
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User successfully deleted");
                            PopulateGraph(); // Refresh the UI to reflect the change.
                        }
                        else
                        {
                            MessageBox.Show("No user found with the provided telephone number.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TelephoneTextbox.Text) || string.IsNullOrWhiteSpace(UsernameTextbox.Text) ||
                string.IsNullOrWhiteSpace(FullnameTextbox.Text) || string.IsNullOrWhiteSpace(PasswordTextbox.Text))
            {
                MessageBox.Show("Please ensure all fields are filled out.");
                return; // Exit the method early to avoid further processing.
            }
            string query = "UPDATE UserTable SET User_name = @Username, User_fullname = @Fullname, User_password = @Password WHERE User_telephone = @Telephone";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Use parameters to prevent SQL injection.
                        cmd.Parameters.AddWithValue("@Username", UsernameTextbox.Text);
                        cmd.Parameters.AddWithValue("@Fullname", FullnameTextbox.Text);
                        cmd.Parameters.AddWithValue("@Password", PasswordTextbox.Text);
                        cmd.Parameters.AddWithValue("@Telephone", TelephoneTextbox.Text);

                        connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Provide feedback based on the operation success.
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User successfully updated");
                            PopulateGraph(); // Refresh the UI to show the updated data
                        }
                        else
                        {
                            MessageBox.Show("No user found with the provided telephone number, or no data was changed.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        //exit button TODO: change to icon
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
