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
        public ManageCustomers()
        {
            InitializeComponent();
            CustomerGV.CellClick += CustomerGV_CellClick;
        }

        private void CustomerGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = CustomerGV.SelectedCells[0].RowIndex;
            CustomerIDTextbox.Text = CustomerGV.Rows[rowIndex].Cells[0].Value.ToString();
            CustomerNameTextbox.Text = CustomerGV.Rows[rowIndex].Cells[1].Value.ToString();
            CustomerNumberTextbox.Text = CustomerGV.Rows[rowIndex].Cells[2].Value.ToString();
            MessageBox.Show("Customer selected");
        }

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maher\OneDrive\Documents\InventoryDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        //populate GV with Customers
        void PopulateGraph()
        {
            try
            {
                connection.Open();
                string myQuery = "select *  from CustomerTable";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myQuery, connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                CustomerGV.DataSource = dataSet.Tables[0];
                connection.Close();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO CustomerTable values('" + CustomerIDTextbox.Text + "','" + CustomerNameTextbox.Text + "','" 
                + CustomerNumberTextbox.Text + "')", connection);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer successfully added");
                connection.Close();
                PopulateGraph();
            }
            catch
            {

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
            if (CustomerIDTextbox.Text == String.Empty)
            {
                MessageBox.Show("Enter Customer ID number");
            }
            else
            {
                connection.Open();
                string myQuery = "DELETE from CustomerTable where Customer_ID='" + CustomerIDTextbox.Text + "';";
                SqlCommand cmd = new SqlCommand(myQuery, connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer successfully deleted");
                connection.Close();
                PopulateGraph();
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE CustomerTable SET Customer_Name = @CustomerName, Customer_telephone = @Customertelephone WHERE Customer_ID = @CustomerId";

            using (connection) // Assuming connectionString is defined
            {
                using (var cmd = new SqlCommand(query, connection))
                {
                    // Add parameters to secure the query against SQL injection
                    cmd.Parameters.AddWithValue("@CustomerName", CustomerNameTextbox.Text);
                    cmd.Parameters.AddWithValue("@Customertelephone", CustomerNumberTextbox.Text);
                    cmd.Parameters.AddWithValue("@CustomerId", CustomerIDTextbox.Text);

                    try
                    {
                        await connection.OpenAsync();
                        int affectedRows = await cmd.ExecuteNonQueryAsync();
                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Customer successfully updated");
                        }
                        else
                        {
                            MessageBox.Show("No customer was updated. Please check the customer ID.");
                        }
                        connection.Close();
                        PopulateGraph();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }
            }
        }

    }
}
