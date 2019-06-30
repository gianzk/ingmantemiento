using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;

namespace CapaPresentacion
{
    public partial class REGISTER : Form
    {
        private String connectionString;
        private SQLiteConnection connection;
        private String SQLUSER = "SELECT count(*) FROM USUARIOS WHERE USER=?";
        private String SQLADD = "INSERT INTO USUARIOS(USER,PASSWORD) VALUES(?,?)";
        

        public REGISTER()
        {
            InitializeComponent();
           
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            connection = new SQLiteConnection(connectionString);

        }

        private void REGISTER_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login L1 = new Login();

            this.Hide();

            L1.Show();
        }
        private void registrar()
        {

            String user;
            String pass;
     
            user = textBox1.Text;
            pass = textBox2.Text;

            if(textBox4.Text=="RAM")
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = SQLADD;
                command.Parameters.AddWithValue("user", user);
                command.Parameters.AddWithValue("password", pass);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("se agrego nuevo usario");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            else
            {
                MessageBox.Show("verifique la informacion");

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }





        }
        private void limpiar()
        {

            

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            registrar();

         
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
