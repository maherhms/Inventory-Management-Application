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
    public partial class ManageCategories : Form
    {
        public ManageCategories()
        {
            InitializeComponent();
            CategoriesGV.CellClick += CategoriesGV_CellClick;
        }

        private void CategoriesGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = CategoriesGV.SelectedCells[0].RowIndex;
            CategoryIDTextbox.Text = CategoriesGV.Rows[rowIndex].Cells[0].Value.ToString();
            CategoryNameTextbox.Text = CategoriesGV.Rows[rowIndex].Cells[1].Value.ToString();
            MessageBox.Show("Category selected");
        }


        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maher\OneDrive\Documents\InventoryDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO CategoriesTable values('" + CategoryIDTextbox.Text + "','" + CategoryNameTextbox.Text + "')", connection);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category successfully added");
                connection.Close();
                PopulateGraph();
            }
            catch
            {

            }
        }

        void PopulateGraph()
        {
            try
            {
                connection.Open();
                string myQuery = "SELECT *  from CategoriesTable";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myQuery, connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                CategoriesGV.DataSource = dataSet.Tables[0];
                connection.Close();
            }
            catch
            {

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CategoryIDTextbox.Text == String.Empty)
            {
                MessageBox.Show("Enter Customer ID number");
            }
            else
            {
                connection.Open();
                string myQuery = "DELETE from CategoriesTable WHERE Category_Id='" + CategoryIDTextbox.Text + "';";
                SqlCommand cmd = new SqlCommand(myQuery, connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category successfully deleted");
                connection.Close();
                PopulateGraph();
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE CategoriesTable SET Category_Name = @CategoryName WHERE Category_Id = @CategoryId";

            using (connection) // Assuming connectionString is defined
            {
                using (var cmd = new SqlCommand(query, connection))
                {
                    // Add parameters to secure the query against SQL injection
                    cmd.Parameters.AddWithValue("@CategoryName", CategoryNameTextbox.Text);
                    cmd.Parameters.AddWithValue("@CategoryId", CategoryIDTextbox.Text);

                    try
                    {
                        await connection.OpenAsync();
                        int affectedRows = await cmd.ExecuteNonQueryAsync();
                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Category successfully updated");
                        }
                        else
                        {
                            MessageBox.Show("No Category was updated. Please check the Category ID.");
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

        private void ManageCategories_Load(object sender, EventArgs e)
        {
            PopulateGraph();
        }
    }
}
