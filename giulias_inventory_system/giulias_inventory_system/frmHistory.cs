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

        int clientID;
        bool checker;

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

            dTable = new DataTable(); //initializing datatable
            sc.OpenConnection(); // accessing the OpenConnection method from the Connection class
            get_clients(dTable);
            dgvClients.DataSource = dTable; // assigning values to the datagridview
            dTable.Dispose();

            dgvClients.Columns["clientID"].Visible = false;
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

        private void get_clients(DataTable dt)
        {
            /**
                04-29-18 12:26 am Added by Abe Isidro 

                User active inactive details.
            */

            try
            {
                sc.OpenConnection();
                sc.command = sc.SQLCommand("Select clientID,name FROM clients");
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dTable = new DataTable(); //initializing datatable
            sc.OpenConnection(); // accessing the OpenConnection method from the Connection class
            get_search_item(dTable);
            dgvHistory.DataSource = dTable; // assigning values to the datagridview
            dTable.Dispose();

        }

        private void get_search_item(DataTable dt)
        {

            string date_from = dtpFrom.Value.ToString("yyyy-MM-dd");
            string date_to = dtpTo.Value.ToString("yyyy-MM-dd");
            MessageBox.Show(clientID.ToString());
            MessageBox.Show(checker.ToString());
            /**
                04-29-18 12:26 am Added by Abe Isidro 

                User active inactive details.
            */

            try
            {
                sc.OpenConnection();
                if (checker == true){
                    sc.command = sc.SQLCommand("Select * FROM history WHERE clientID = "+clientID+" AND date_modified BETWEEN '" + date_from + "' AND '" + date_to + "'");
                }
                else
                {
                    sc.command = sc.SQLCommand("Select * FROM history WHERE date_modified BETWEEN '" + date_from + "' AND '" + date_to + "'");
                }
                sc.sqlReader = sc.command.ExecuteReader();
                dt.Load(sc.sqlReader); 
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

        private void dgvClients_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // manipulating the selected datagridview
            if (e.RowIndex >= 0)
            {
                checker = true;
                DataGridViewRow row = this.dgvClients.Rows[e.RowIndex];
                int rowindex = dgvClients.CurrentCell.RowIndex;
                int columnindex = dgvClients.CurrentCell.ColumnIndex;

                try
                {
                    // getting the values of dgvresult;
                    clientID = Convert.ToInt32(dgvClients.Rows[rowindex].Cells[0].Value.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                checker = false;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string search_client = txtSearch.Text;
            // for clients
            dTable = new DataTable();
            search_clients(dTable, search_client);
            dgvClients.DataSource = dTable;
            dgvClients.Columns["clientID"].Visible = false;
            dgvClients.ColumnHeadersVisible = false;
            dTable.Dispose();
        }

        private void search_clients(DataTable dt, string search)
        {
            /**
               04-19-18 11:26 am Added by Kwen Isidro 

               Search Clients 
           */

            try
            {
                sc.OpenConnection();
                sc.command = sc.SQLCommand("SELECT clientID, name FROM clients WHERE active = 1 AND name LIKE @search");
                sc.command.Parameters.Add("@search", MySqlDbType.String).Value = '%' + search + '%';
                sc.sqlReader = sc.command.ExecuteReader();
                dt.Load(sc.sqlReader);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                sc.command.Parameters.Clear();
                sc.CloseConnection();
            }
        }
    }
}
