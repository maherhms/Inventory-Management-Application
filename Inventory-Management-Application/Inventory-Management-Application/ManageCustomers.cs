using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management_Application
{
    public partial class ManageCustomers : Form
    {
        const string connectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maher\OneDrive\Documents\InventoryDB.mdf;Integrated Security=True;Connect Timeout=30");
        public ManageCustomers()
        {
            InitializeComponent();
            CustomerGV.CellClick += CustomerGV_CellClick;
        }

        private void CustomerGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if the clicked row index is valid
            {
                try
                {
                    // Directly use e.RowIndex to ensure you're working with the row that was clicked
                    DataGridViewRow row = CustomerGV.Rows[e.RowIndex];

                    // Safely convert cell values to string, assuming cells are not null
                    CustomerIDTextbox.Text = row.Cells[0].Value?.ToString() ?? "";
                    CustomerNameTextbox.Text = row.Cells[1].Value?.ToString() ?? "";
                    CustomerNumberTextbox.Text = row.Cells[2].Value?.ToString() ?? "";

                    // Optional: Remove MessageBox if it's too intrusive for frequent actions
                    MessageBox.Show("Customer selected");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error selecting Customer: {ex.Message}");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //populate GV with Customers
        void PopulateGraph()
        {
            DataSet dataSet = new DataSet();
            try
            {
                string myQuery = "SELECT * FROM CustomerTable";
                using (SqlConnection connection = new SqlConnection(connectionString)) // Ensure to define or pass connectionString
                {
                    connection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(myQuery, connection))
                    {
                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                        dataAdapter.Fill(dataSet);
                    } // SqlDataAdapter is disposed here, which also closes the connection
                } // SqlConnection is disposed here, if not already closed
                CustomerGV.DataSource = dataSet.Tables[0];
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CustomerIDTextbox.Text) || string.IsNullOrEmpty(CustomerNameTextbox.Text) || string.IsNullOrEmpty(CustomerNumberTextbox.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;  // Exit the method if any fields are empty.
            }

            string query = "INSERT INTO CustomerTable (Customer_ID, Customer_Name, Customer_Telephone) VALUES (@CustomerID, @CustomerName, @CustomerTelephone)";

            try
            {
                // Use a local connection object within a using statement for automatic disposal.
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Add parameters to secure the query against SQL injection.
                        cmd.Parameters.AddWithValue("@CustomerID", CustomerIDTextbox.Text);
                        cmd.Parameters.AddWithValue("@CustomerName", CustomerNameTextbox.Text);
                        cmd.Parameters.AddWithValue("@CustomerTelephone", CustomerNumberTextbox.Text);

                        connection.Open();
                        int result = cmd.ExecuteNonQuery();

                        // Check if the insert was successful.
                        if (result > 0)
                        {
                            MessageBox.Show("Customer successfully added");
                            PopulateGraph(); // Refresh the graph to show the new customer.
                        }
                        else
                        {
                            MessageBox.Show("Customer not added. Please try again.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Properly handle the exception by informing the user.
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void ManageCustomers_Load(object sender, EventArgs e)
        {
            PopulateGraph();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CustomerIDTextbox.Text))
            {
                MessageBox.Show("Enter Customer ID number");
                return; // Early exit if input validation fails
            }

            string query = "DELETE FROM CustomerTable WHERE Customer_ID = @CustomerID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Use parameters to prevent SQL injection.
                        cmd.Parameters.AddWithValue("@CustomerID", CustomerIDTextbox.Text);

                        connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if the deletion was successful
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer successfully deleted");
                            PopulateGraph(); // Refresh the graph to reflect the change
                        }
                        else
                        {
                            MessageBox.Show("No customer found with the provided ID.");
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"A database error occurred: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE CustomerTable SET Customer_Name = @CustomerName, Customer_telephone = @Customertelephone WHERE Customer_ID = @CustomerId";

            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand(query, connection))
                {
                    // Explicitly specify parameter types
                    cmd.Parameters.AddWithValue("@CustomerName", CustomerNameTextbox.Text);
                    cmd.Parameters.AddWithValue("@Customertelephone", CustomerNumberTextbox.Text);
                    cmd.Parameters.AddWithValue("@CustomerId", CustomerIDTextbox.Text);

                    try
                    {
                        await connection.OpenAsync();
                        int affectedRows = await cmd.ExecuteNonQueryAsync();

                        // Use Invoke to update the UI safely on the UI thread
                        this.Invoke(new Action(() => {
                            if (affectedRows > 0)
                            {
                                MessageBox.Show("Customer successfully updated");
                            }
                            else
                            {
                                MessageBox.Show("No customer was updated. Please check the customer ID.");
                            }
                            PopulateGraph(); // Assuming this method is thread-safe or updates UI correctly
                        }));
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show($"A database error occurred: {sqlEx.Message}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
