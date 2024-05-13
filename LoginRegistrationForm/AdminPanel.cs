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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LoginRegistrationForm
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Badd_Click(object sender, EventArgs e)
        {
            SqlConnection connnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\loginData1.mdf;Integrated Security=True;Connect Timeout=30");
            connnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO admin1 (email, username, passowrd, accountType, date_created) " +
                                             "VALUES(@email, @username, @password, @accountType, @date)", connnection);
            cmd.Parameters.AddWithValue("@email", TBemail.Text.Trim());
            cmd.Parameters.AddWithValue("@username", TBusername.Text.Trim());
            cmd.Parameters.AddWithValue("@password", TBpassword.Text.Trim());
            cmd.Parameters.AddWithValue("@accountType", TBaccountype.Text.Trim());
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.ExecuteNonQuery();
            connnection.Close();

            MessageBox.Show("Successfully Added");
        }

        private void Bremove_Click(object sender, EventArgs e)
        {
            // Check if username is provided
            if (!string.IsNullOrWhiteSpace(TBusername.Text))
            {
                // Open connection to the database
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\loginData1.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    connection.Open();

                    // Define the SQL command to delete the row based on username
                    string sql = "DELETE FROM admin1 WHERE username = @username";

                    // Create a command object
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        // Add username parameter to the command
                        cmd.Parameters.AddWithValue("@username", TBusername.Text.Trim());

                        // Execute the command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if any rows were affected (i.e., if a row with the provided username was found and deleted)
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Successfully Removed");
                        }
                        else
                        {
                            MessageBox.Show("No user found with the provided username.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please provide a username.");
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Bsearch_Click(object sender, EventArgs e)
        {
            // Check if username is provided
            if (!string.IsNullOrWhiteSpace(TBusername.Text))
            {
                // Open connection to the database
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\loginData1.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    connection.Open();

                    // Define the SQL command to select the row based on username
                    string sql = "SELECT * FROM admin1 WHERE username = @username";

                    // Create a command object
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        // Add username parameter to the command
                        cmd.Parameters.AddWithValue("@username", TBusername.Text.Trim());

                        // Execute the command and retrieve the data
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Create a DataTable to store the retrieved data
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        // Bind the DataTable to the dataGridView1
                        dataGridView1.DataSource = dataTable;

                        // Close the reader
                        reader.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please provide a username.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Brefresh_Click(object sender, EventArgs e)
        {

            // Open connection to the database
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\loginData1.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();

                // Define the SQL command to select all rows
                string sql = "SELECT * FROM admin1";

                // Create a command object
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    // Execute the command and retrieve the data
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Create a DataTable to store the retrieved data
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    // Bind the DataTable to the dataGridView1
                    dataGridView1.DataSource = dataTable;

                    // Close the reader
                    reader.Close();
                }
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 lForm = new Form1();
            lForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GoldUserForm gForm = new GoldUserForm();
            gForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FreeUserForm fForm = new FreeUserForm();
            fForm.Show();
            this.Hide();

        }
    }
}
