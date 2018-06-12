using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //needed import to connect to the mysql database

namespace giulias_inventory_system
{
    public partial class frmHistory : Form
    {
        public frmHistory()
        {
            InitializeComponent();
        }
        // 04-17-18 11:49 am Added by Abegail Isidro 
        clsConnection sc = new clsConnection(); // Calling the Connection class    
        MySqlConnection vDBConn = new MySqlConnection(); // Calling the Sql Connection method
        DataTable dTable; //Initializing Datatable
        frmClientConfiguration cc = new frmClientConfiguration();   //Calls the client configuration form to add or update costumers
        frmHome home = new frmHome();

        string user_name;
        int user_id;
        int user_priviledge;
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            home.getUsername(user_name, user_id, user_priviledge);         //to send data from one place to another
            home.Show();
        }
        public void get_details(string user, int id, int priviledge)    //passes value from one class to another
        {
            user_name = user;
            user_id = id;
            user_priviledge = priviledge;
        }

        private void frmHistory_Load(object sender, EventArgs e)
        {
            dTable = new DataTable(); //initializing datatable
            sc.OpenConnection(); // accessing the OpenConnection method from the Connection class
            get_history_details(dTable);
            dgvHistory.DataSource = dTable; // assigning values to the datagridview
            dTable.Dispose();
        }

        private void get_history_details(DataTable dt)
        {
            /**
                04-29-18 12:26 am Added by Abe Isidro 

                User active inactive details.
            */

            try
            {
                sc.OpenConnection();
                sc.command = sc.SQLCommand("Select * FROM history");
               // sc.command.Parameters.Add("@activeinactive", MySqlDbType.Int32).Value = active_inactive;
                sc.sqlReader = sc.command.ExecuteReader();
                dt.Load(sc.sqlReader);
                sc.command.Parameters.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {

                sc.CloseConnection();
            }
        }
    }
}
