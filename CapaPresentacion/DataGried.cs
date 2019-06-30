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
    public partial class DataGried : Form
    {
        private String connectionString;
        private SQLiteConnection connection;

        private String SQLInsert = "INSERT INTO SISTEMA(SISTEMA,MAQUINA,COMPONENTE,ACTIVIDAD_MANTENIMIENTO,PROBLEMA,CAUSA_GENERAL,CAUSA_DETALLADO,SOLUCION) VALUES(?, ?, ?, ?, ?, ?, ?, ?)";
        private String SQLUpdate = "UPDATE User SET Name = ?, Surname = ? where UserId = ?";
        private String SQLSelect = "SELECT SISTEMA,MAQUINA,COMPONENTE,ACTIVIDAD_MANTENIMIENTO,FRECUENCIA,FECHA,HORAS_DETENIDAS,PROBLEMA,CAUSA_GENERAL,CASUA_DETALLADO,SOLUCION FROM sistema where cast(substr(fecha,7,4)||substr(fecha,4,2)||substr(fecha,1,2) as decimal) between ? and ?  AND sistema=?and maquina=? ";
        private String SQLDelete = "DELETE FROM User WHERE UserId = ?";
        private String SQLList= "SELECT SISTEMA,MAQUINA,COMPONENTE,ACTIVIDAD_MANTENIMIENTO,FRECUENCIA,FECHA,HORAS_DETENIDAS,PROBLEMA,CAUSA_GENERAL,CASUA_DETALLADO,SOLUCION FROM sistema";
        private String SQLSISTEMA = "SELECT DISTINCT SISTEMA SISTEMA FROM SISTEMA";
        private String SQLMAQUINA = "SELECT DISTINCT MAQUINA FROM SISTEMA WHERE SISTEMA=?";
        private String SQLCOMPONENTE = "SELECT DISTINCT COMPONENTE FROM SISTEMA WHERE MAQUINA=?";
 
        public DataGried()
        {
            InitializeComponent();
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            connection = new SQLiteConnection(connectionString);
            mostrar();
            llenarcombo();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Agregar a1 = new Agregar();

            a1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            string fecha1, fecha2;

            fecha1 = dtp1.Value.Date.ToString("yyyyMMdd");
            fecha2 = dtp2.Value.Date.ToString("yyyyMMdd");
            // Eliminamos el handler del evento RowEnter para evitar que se dispare al
            // realizar la búsqueda
            dataGridView1.RowEnter -= dataGrid_RowEnter;

            // Abrimos la conexión
            if (connection.State != ConnectionState.Open)
                connection.Open();

            // Creamos un SQLiteCommand y le asignamos la cadena de consulta
            SQLiteCommand command = connection.CreateCommand();

            command.CommandText = SQLSelect;

            command.Parameters.AddWithValue("fecha1", fecha1);
            command.Parameters.AddWithValue("fecha2", fecha2);
            command.Parameters.AddWithValue("sistema", comboBox1.Text);
            command.Parameters.AddWithValue("maquina", comboBox2.Text);


       
            command.ExecuteNonQuery();
            connection.Close();
           

            // Creamos un nuevo DataTable y un DataAdapter a partir de la SELECT.
            // A continuación, rellenamos la tabla con el DataAdapter
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);

            // Asignamos el DataTable al DataGrid y cerramos la conexión
            dataGridView1.DataSource = dt;
            connection.Close();

            // Restauramos el handler del evento
            dataGridView1.RowEnter += dataGrid_RowEnter;
        }

        private void mostrar()
        {
            // Eliminamos el handler del evento RowEnter para evitar que se dispare al
            // realizar la búsqueda
            dataGridView1.RowEnter -= dataGrid_RowEnter;

            // Abrimos la conexión
            if (connection.State != ConnectionState.Open)
                connection.Open();

            // Creamos un SQLiteCommand y le asignamos la cadena de consulta
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLList;

            // Creamos un nuevo DataTable y un DataAdapter a partir de la SELECT.
            // A continuación, rellenamos la tabla con el DataAdapter
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dt);

            // Asignamos el DataTable al DataGrid y cerramos la conexión
            dataGridView1.DataSource = dt;
            connection.Close();

            // Restauramos el handler del evento
            dataGridView1.RowEnter += dataGrid_RowEnter;
        }
        private void fechasobtener()
        {
            string fecha1, fecha2;

            fecha1 = dtp1.Value.Date.ToString("yyyyMMdd");
            fecha2 = dtp2.Value.Date.ToString();

            MessageBox.Show(fecha1,fecha2);
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
            comboBox1.ValueMember = "sistema";
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

        private void dataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Recuperamos ID, nombre y apellido de la fila
            String sistema = (String)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            // String maquina = (String)dataGridView1.Rows[e.RowIndex].Cells[3].Value;
            //String componente = (String)dataGridView1.Rows[e.RowIndex].Cells[4].Value;

            // Asignamos los valores a las cajas de texto
            comboBox1.Text = sistema;
            // comboBox2.Text = maquina;
            // comboBox3.Text = componente;
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            
        }


        private void EXPORTARDATA_Click(object sender, EventArgs e)
        {
            SaveFileDialog browseFile = new SaveFileDialog();
           
            browseFile.InitialDirectory = @"C:\";
            browseFile.Title = "GUARDAR ARCHIVO COMO EXCEL";
            browseFile.FileName = "";
            browseFile.Filter = "Excel|*.xls|Excel 2010|*.xlsx"; 
            browseFile.ShowDialog();

            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported from gridview";
            // storing header part in Excel  
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            // save the application  
           // workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            app.Quit();

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            GRAFICA G1 = new GRAFICA();

            G1.Show();
            this.Hide();
        }

        private void DataGried_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue.ToString() != null)
            {
                string sistema = comboBox1.SelectedValue.ToString();
                llenarcomobo2(sistema);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue.ToString() != null)
            {
                string maquina = comboBox2.SelectedValue.ToString();
                llenarcombo3(maquina);
            }
        }
    }
}
