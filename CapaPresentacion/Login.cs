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
    public partial class Login : Form
    {
        private String connectionString;
        private SQLiteConnection connection;

        private String SQLVALIDACION = "SELECT PASSWORD FROM USUARIOS WHERE USER=?";
        private String SQLUSER = "SELECT USER FROM USUARIOs WHERE USER=?";
        private String SQLUSERLIST = "SELECT USER FROM USUARIOs";

        public Login()
        {
            InitializeComponent();
                        connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            connection = new SQLiteConnection(connectionString);
            llenarcombo();

        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
      
        }
        
        private void button1_Click(object sender, EventArgs e)
        {


            if(textBox1.Text=="123456")
             {
                 DataGried D1 = new DataGried();

                 D1.Show();
                 this.Hide();

                


             }
             else {

                 MessageBox.Show("INGRESE CREDENCIALES CORRECTAS");

             }


        }
        private void llenarcombo()
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            // Creamos un SQLiteCommand y le asignamos la cadena de consulta

            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLUSERLIST;
            DataTable dt1 = new DataTable();
            SQLiteDataAdapter da1 = new SQLiteDataAdapter(command);
            da1.Fill(dt1);
            connection.Close();

            DataRow fila = dt1.NewRow();
            fila["user"] = "USUARIOS";
            dt1.Rows.InsertAt(fila, 0);
            comboBox1.ValueMember = "user";
            comboBox1.DisplayMember = "user";
            comboBox1.DataSource = dt1;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            REGISTER D2 = new REGISTER();
            D2.Show();
            this.Hide();
        }
    }
}
