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
    public partial class GRAFICA : Form
    {
        private String connectionString;
        private SQLiteConnection connection;
        private String SQLpareto = "select maquina,sum(horas_detenidas)  horas from sistema  group by maquina order by  horas desc";

        public GRAFICA()
        {
            InitializeComponent();
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            connection = new SQLiteConnection(connectionString);
            graficar();

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        public void graficar()
        {

            string fecha1, fecha2;

            fecha1 = dtp1.Value.Date.ToString("yyyyMMdd");
            fecha2 = dtp2.Value.Date.ToString("yyyyMMdd");
            // Abrimos la conexión
            if (connection.State != ConnectionState.Open)
                connection.Open();

            // Creamos un SQLiteCommand y le asignamos la cadena de consulta
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLpareto;
      
        
            
            DataSet ds = new DataSet();

            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(ds);

            DataView source = new DataView(ds.Tables[0]);

            chart1.DataSource = source;

            chart1.Series[0].XValueMember = "maquina";
            chart1.Series[0].YValueMembers = "Horas";
            chart1.DataBind();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGried D3 = new DataGried();

            D3.Show();
            this.Hide();
        }

        private void GRAFICA_Load(object sender, EventArgs e)
        {
            graficar();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
