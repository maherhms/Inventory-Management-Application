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
        public ManageUsers()
        {
            InitializeComponent();
            UserGV.CellClick += UserGV_CellClick;

        }
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\maher\OneDrive\Documents\InventoryDB.mdf;Integrated Security=True;Connect Timeout=30");
        //select user by click on the GV cells
        private void UserGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = UserGV.SelectedCells[0].RowIndex;
            UsernameTextbox.Text = UserGV.Rows[rowIndex].Cells[0].Value.ToString();
            FullnameTextbox.Text = UserGV.Rows[rowIndex].Cells[1].Value.ToString();
            PasswordTextbox.Text = UserGV.Rows[rowIndex].Cells[2].Value.ToString();
            TelephoneTextbox.Text = UserGV.Rows[rowIndex].Cells[3].Value.ToString();
            MessageBox.Show("user selected");
        }

        //populate GV with users
        void PopulateGraph()
        {
            try
            {
                connection.Open();
                string myQuery = "select *  from UserTable";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(myQuery,connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                UserGV.DataSource = dataSet.Tables[0];
                connection.Close();
            }
            catch
            {

            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        //add user after filling infos
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO UserTable values('"+UsernameTextbox.Text+ "','" + FullnameTextbox.Text + "','" 
                + PasswordTextbox.Text + "','" + TelephoneTextbox.Text + "')",connection);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("User successfully added");
                connection.Close();
                PopulateGraph();
            }
            catch
            {

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
            if (TelephoneTextbox.Text == String.Empty)
            {
                MessageBox.Show("Enter user phone number");
            }
            else
            {
                connection.Open();
                string myQuery = "DELETE from UserTable where User_telephone='" + TelephoneTextbox.Text + "';";
                SqlCommand cmd = new SqlCommand(myQuery,connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User successfully deleted");
                connection.Close();
                PopulateGraph();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE UserTable set User_name='" + UsernameTextbox.Text + "',User_fullname='" + FullnameTextbox.Text + "',User_password='"
                + FullnameTextbox.Text + "' where User_telephone='" + TelephoneTextbox.Text + "'", connection);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("User successfully updated");
                connection.Close();
                PopulateGraph();
            }
            catch
            {

            }
        }
        //exit button TODO: change to icon
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
