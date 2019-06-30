using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Agregar : Form


    {
        private String connectionString;
        private SQLiteConnection connection;
        private String SQLInsert = "INSERT INTO SISTEMA(SISTEMA,MAQUINA,COMPONENTE,ACTIVIDAD_MANTENIMIENTO,FRECUENCIA,HORAS_DETENIDAS,FECHA,PROBLEMA,CAUSA_GENERAL,CASUA_DETALLADO,SOLUCION) VALUES(?,?, ?, ?,?, ?, ?, ?, ?,?,?)";
        private String SQLUpdate = "UPDATE SISTEMA SET FRECUENCIA = FRECUENCIA+1 where PROBLEMA=? AND SISTEMA=? AND MAQUINA=? AND COMPONENTE=?";
        private String SQLSISTEMA = "SELECT DISTINCT SISTEMA SISTEMA FROM SISTEMA";
        private String SQLMAQUINA = "SELECT DISTINCT MAQUINA FROM SISTEMA WHERE SISTEMA=?";
        private String SQLCOMPONENTE = "SELECT DISTINCT COMPONENTE FROM SISTEMA WHERE MAQUINA=?";
        private String SQLACTIVIDAD = "SELECT DISTINCT ACTIVIDAD_MANTENIMIENTO	 FROM SISTEMA WHERE COMPONENTE=?";
        private String SQLPROBLEMA = "select DISTINCT problema from sistema where maquina=?";
        private String SQLCAUSAGENERAL = "select DISTINCT CAUSA_GENERAL from sistema where PROBLEMA=?";
        private String SQLCAUSADETALLADA = "select DISTINCT CASUA_DETALLADO from sistema where CAUSA_GENERAL=?";
        private String SQLCAUSASOLUCION = "select DISTINCT SOLUCION from sistema where PROBLEMA=?";


        public Agregar()
        {
            InitializeComponent();
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            connection = new SQLiteConnection(connectionString);
            llenarcombo();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SISTEMA_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Agregar_Load(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGried D2 = new DataGried();

            D2.Show();
            this.Hide();
        }

        private void llenarcombo()
        {
            // Abrimos la conexión
            if (connection.State != ConnectionState.Open)
                connection.Open();

            // Creamos un SQLiteCommand y le asignamos la cadena de consulta

            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLSISTEMA;
            DataTable dt1 = new DataTable();
            SQLiteDataAdapter da1 = new SQLiteDataAdapter(command);
            da1.Fill(dt1);
            connection.Close();

            DataRow fila = dt1.NewRow();
            fila["sistema"] = "SELECCIONA UN SISTEMA";
            dt1.Rows.InsertAt(fila, 0);
            comboBox1.ValueMember = "Sistema";
            comboBox1.DisplayMember = "sistema";
            comboBox1.DataSource = dt1;

        }

        private void llenarcomobo2(String sistema)
        {
            // Abrimos la conexión
            if (connection.State != ConnectionState.Open)
                connection.Open();

            // Creamos un SQLiteCommand y le asignamos la cadena de consulta

            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLMAQUINA;
            command.Parameters.AddWithValue("sistema", sistema);
            DataTable dt1 = new DataTable();
            SQLiteDataAdapter da2 = new SQLiteDataAdapter(command);
            da2.Fill(dt1);
            connection.Close();

            DataRow fila = dt1.NewRow();
            fila["MAQUINA"] = "SELECCIONA UNA MAQUINA";
            dt1.Rows.InsertAt(fila, 0);
            comboBox2.ValueMember = "MAQUINA";
            comboBox2.DisplayMember = "MAQUINA";
            comboBox2.DataSource = dt1;

        }
        private void llenarcombo3(String maquina)
        {
            // Abrimos la conexión
            if (connection.State != ConnectionState.Open)
                connection.Open();

            // Creamos un SQLiteCommand y le asignamos la cadena de consulta

            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLCOMPONENTE;
            command.Parameters.AddWithValue("maquina", maquina);
            DataTable dt1 = new DataTable();
            SQLiteDataAdapter da3 = new SQLiteDataAdapter(command);
            da3.Fill(dt1);
            connection.Close();

            DataRow fila = dt1.NewRow();
            fila["COMPONENTE"] = "SELECCIONA UN COMPONENTE";
            dt1.Rows.InsertAt(fila, 0);
            comboBox3.ValueMember = "COMPONENTE";
            comboBox3.DisplayMember = "COMPONENTE";
            comboBox3.DataSource = dt1;

        }
        private void llenarcombo4(String componente)
        {
            // Abrimos la conexión
            if (connection.State != ConnectionState.Open)
                connection.Open();

            // Creamos un SQLiteCommand y le asignamos la cadena de consulta

            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLACTIVIDAD;
            command.Parameters.AddWithValue("COMPONENTE", componente);
            DataTable dt1 = new DataTable();
            SQLiteDataAdapter da3 = new SQLiteDataAdapter(command);
            da3.Fill(dt1);
            connection.Close();

            DataRow fila = dt1.NewRow();
            fila["ACTIVIDAD_MANTENIMIENTO"] = "SELECCIONA UNA ACTIVAD";
            dt1.Rows.InsertAt(fila, 0);
            comboBox4.ValueMember = "ACTIVIDAD_MANTENIMIENTO";
            comboBox4.DisplayMember = "ACTIVIDAD_MANTENIMIENTO";
            comboBox4.DataSource = dt1;

        }
        private void llenarcombo5(String MAQUINA)
        {
            // Abrimos la conexión
            if (connection.State != ConnectionState.Open)
                connection.Open();

            // Creamos un SQLiteCommand y le asignamos la cadena de consulta

            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLPROBLEMA;
            command.Parameters.AddWithValue("MAQUINA", MAQUINA);
            DataTable dt1 = new DataTable();
            SQLiteDataAdapter da3 = new SQLiteDataAdapter(command);
            da3.Fill(dt1);
            connection.Close();

            DataRow fila = dt1.NewRow();
            fila["PROBLEMA"] = "SELECCIONA UN PROBLEMA";
            dt1.Rows.InsertAt(fila, 0);
            comboBox5.ValueMember = "PROBLEMA";
            comboBox5.DisplayMember = "PROBLEMA";
            comboBox5.DataSource = dt1;

        }
        private void llenarcombo6(String PROBLEMA)
        {
            // Abrimos la conexión
            if (connection.State != ConnectionState.Open)
                connection.Open();

            // Creamos un SQLiteCommand y le asignamos la cadena de consulta

            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLCAUSAGENERAL;
            command.Parameters.AddWithValue("CAUSA_GENERAL", PROBLEMA);
            DataTable dt1 = new DataTable();
            SQLiteDataAdapter da3 = new SQLiteDataAdapter(command);
            da3.Fill(dt1);
            connection.Close();

            DataRow fila = dt1.NewRow();
            fila["CAUSA_GENERAL"] = "SELECCIONA UN CAUSA_GENERAL";
            dt1.Rows.InsertAt(fila, 0);
            textBox2.ValueMember = "CAUSA_GENERAL";
            textBox2.DisplayMember = "CAUSA_GENERAL";
            textBox2.DataSource = dt1;

        }
        private void llenarcombo7(String CAUSA_GENERAL)
        {
            // Abrimos la conexión
            if (connection.State != ConnectionState.Open)
                connection.Open();

            // Creamos un SQLiteCommand y le asignamos la cadena de consulta

            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLCAUSADETALLADA;
            command.Parameters.AddWithValue("CAUSA_GENERAL", CAUSA_GENERAL);
            DataTable dt1 = new DataTable();
            SQLiteDataAdapter da3 = new SQLiteDataAdapter(command);
            da3.Fill(dt1);
            connection.Close();

            DataRow fila = dt1.NewRow();
            fila["CASUA_DETALLADO"] = "SELECCIONA UN CASUA_DETALLADO";
            dt1.Rows.InsertAt(fila, 0);
            textBox3.ValueMember = "CASUA_DETALLADO";
            textBox3.DisplayMember = "CASUA_DETALLADO";
            textBox3.DataSource = dt1;

        }
        private void llenarcombo8(String PROBLEMA)
        {
            // Abrimos la conexión
            if (connection.State != ConnectionState.Open)
                connection.Open();

            // Creamos un SQLiteCommand y le asignamos la cadena de consulta

            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLCAUSASOLUCION;
            command.Parameters.AddWithValue("PROBLEMA", PROBLEMA);
            DataTable dt1 = new DataTable();
            SQLiteDataAdapter da3 = new SQLiteDataAdapter(command);
            da3.Fill(dt1);
            connection.Close();

            DataRow fila = dt1.NewRow();
            fila["SOLUCION"] = "SELECCIONA UN SOLUCION";
            dt1.Rows.InsertAt(fila, 0);
            textBox4.ValueMember = "SOLUCION";
            textBox4.DisplayMember = "SOLUCION";
            textBox4.DataSource = dt1;

        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (connection.State != ConnectionState.Open)
                connection.Open();

            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLInsert;

            String fecha2 = dtp3.Value.Date.ToString("dd-MM-yyyy");

            command.Parameters.AddWithValue("sistema", comboBox1.Text);
            command.Parameters.AddWithValue("MAQUINA", comboBox2.Text);
            command.Parameters.AddWithValue("COMPONENTE", comboBox3.Text);
            command.Parameters.AddWithValue("ACTIVIDAD_MANTENIMIENTO", comboBox4.Text);
            command.Parameters.AddWithValue("frecuencia", 1);
            command.Parameters.AddWithValue("HORAS_DETENIDAS", textBox5.Text);
            command.Parameters.AddWithValue("FECHA", fecha2);
            command.Parameters.AddWithValue("PROBLEMA", comboBox5.Text);
            command.Parameters.AddWithValue("CAUSA", textBox2.Text);
            command.Parameters.AddWithValue("CASUA_DETALLADO", textBox3.Text);
            command.Parameters.AddWithValue("SOLUCION", textBox4.Text);


            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("se agrego nuevo registro");



        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue.ToString() != null)
            {
                string maquina = comboBox2.SelectedValue.ToString();
                llenarcombo3(maquina);
                llenarcombo5(maquina);
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue.ToString() != null)
            {
                string sistema = comboBox1.SelectedValue.ToString();
                llenarcomobo2(sistema);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedValue.ToString() != null)
            {
                string problema = comboBox5.SelectedValue.ToString();
                llenarcombo6(problema);
            
                llenarcombo8(problema);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedValue.ToString() != null)
            {
                string componente = comboBox3.SelectedValue.ToString();
                llenarcombo4(componente);
            }
        }

        private void textBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox2.SelectedValue.ToString() != null)
            {
                string CAUSAGENERAL = textBox2.SelectedValue.ToString();
                llenarcombo7(CAUSAGENERAL);
            }
        }
    }
}
