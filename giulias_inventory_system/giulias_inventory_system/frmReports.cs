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
    public partial class frmReposrts : Form
    {
        string name;
        int user_id;
        int user_priviledge;
        public frmReposrts()
        {
            InitializeComponent();
        }
        #region "Forms and Connections"
        // 04-17-18 11:49 am Added by Abegail Isidro 
        clsConnection sc = new clsConnection(); // Calling the Connection class    
        MySqlConnection vDBConn = new MySqlConnection(); // Calling the Sql Connection method
        DataTable dTable; //Initializing Datatable
        frmHome home = new frmHome();
        #endregion

        #region "variables"
        string date_today = DateTime.Now.ToString("MMMMMMMMMMMMMM-dd-yyyy"); // date today
        int month = DateTime.Now.Month; // getting the current month
        int year = DateTime.Now.Year; // getting the current year
        int clientID = 0; // getting the clientID
        int clientClassificationID = 0; // getting the client classification id
        string client_name = "";
        string subtitle = "";
        // variables used for the get-set property

        string client_type;
        string client_desc;
        byte[] client_pic;
        #endregion

        #region "GetSet Properties"
        public string ClientName { set { client_name = value; } }
        public string ClientType { set { client_type = value; } }
        public string ClientDesc { set { client_desc = value; } }
        public byte[] ClientPicture { set { client_pic = value; } }
        #endregion


        #region "methods"
        private void get_client_name(DataTable dt)
        {

            /**
              04-19-18 4:31 pm Added by Kwen Isidro 

              Setting Client Type
           */

            try
            {
                sc.OpenConnection();
                sc.command = sc.SQLCommand("SELECT clientID, name, clientclassificationID FROM clients WHERE active = 1 LIMIT 50");
                sc.sqlReader = sc.command.ExecuteReader();
                dt.Load(sc.sqlReader);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                sc.CloseConnection();

            }

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
                sc.command = sc.SQLCommand("SELECT clientID, name, clientclassificationID FROM clients WHERE active = 1 AND name LIKE @search");
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

        private void fill_dgvs()
        {
            dTable = new DataTable();
            if (radThis.Checked == true)
            {
                string[] split = date_today.Split('-');
                subtitle = "for the month of "+split[0]+' '+split[2]+'.';
                int max_date = DateTime.DaysInMonth(year, month);
                string date_from = year.ToString()+'-'+month.ToString()+"-01";
                string date_to = year.ToString() + '-' + month.ToString() + "-"+max_date.ToString();
                populate_dgv_reports(dTable,date_from,date_to);
                dgvReports.DataSource = dTable;
                dTable.Dispose();
            }
            else
             {
                //subtitle kay from date_from to date_to year
                //subtitle = "for the month of " + split[0] + ' ' + split[2] + '.';
            }

            decimal total_sum = 0;
            decimal commission_sum = 0;
            for (int i = 0; i < dgvReports.Rows.Count; ++i)
            {
                total_sum += Convert.ToDecimal(dgvReports.Rows[i].Cells[4].Value);
                commission_sum += Convert.ToDecimal(dgvReports.Rows[i].Cells[5].Value);
            }

            //simple way create object for rowvalues here i have given only 2 add as per your requirement
            object[] RowValuesForSpacing = { null, "__________________________",null, null, null };
            object[] RowValuesForTotal = { null, "",null,null,null };
            object[] RowValuesForCommission = { null, "", null, null, null };

            //assign values into row object
            RowValuesForTotal[1] = "TOTAL REVENUE:      "+total_sum;
            RowValuesForCommission[1] = "TOTAL COMMISSION:  " + commission_sum;

            //create new data row
            DataRow dRow;
            dRow = dTable.Rows.Add(RowValuesForSpacing);
            dTable.AcceptChanges();

            //create new data row
            DataRow dRowForTotal;
            dRowForTotal = dTable.Rows.Add(RowValuesForTotal);
            dTable.AcceptChanges();

            if (clientClassificationID == 2)
            {
                //create new data row
                DataRow dRowForCommission;
                dRowForCommission = dTable.Rows.Add(RowValuesForCommission);
                dTable.AcceptChanges();
 

            }
            

            if (clientClassificationID != 2)
            {
                dgvReports.Columns["commission"].Visible = false;
            }
            else
            {
                dgvReports.Columns["commission"].Visible = true;
            }

            foreach (DataGridViewColumn column in dgvReports.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                // para ma pagamyan ang size sa quantity
                DataGridViewColumn quantity_size = dgvReports.Columns[3];
                quantity_size.Width = 100;
                // para ma pagamyan ang size sa total
                DataGridViewColumn total_size = dgvReports.Columns[4];
                total_size.Width = 150;
                // para ma pagamyan ang size sa commission
                DataGridViewColumn commission_size = dgvReports.Columns[5];
                commission_size.Width = 100;
                // para ma pagamyan ang size sa price
                DataGridViewColumn price_size = dgvReports.Columns[2];
                price_size.Width = 150;
                // para ma pagamyan ang size sa date
                DataGridViewColumn date_size = dgvReports.Columns[0];
                date_size.Width = 150;
            }
            

        }

       

        private void populate_dgv_reports(DataTable dt, string datefrom, string dateto)
        {
            /**
               04-19-18 11:26 am Added by Kwen Isidro 

               Populating datagridview for printing
           */

            try
            {
                sc.OpenConnection();
                sc.command = sc.SQLCommand("SELECT t.transaction_date, p.name as product_name, p.price, t.quantity, t.total, t.commission FROM transactions as t INNER JOIN products as p ON p.productID = t.productID INNER JOIN clients as c ON c.clientId = t.clientID WHERE (t.transaction_date BETWEEN @date_from AND @date_to) AND c.clientID = @client_id ORDER BY p.name, t.transaction_date");
                sc.command.Parameters.Add("@client_id", MySqlDbType.Int32).Value = clientID;
                sc.command.Parameters.Add("@date_from", MySqlDbType.String).Value = datefrom;
                sc.command.Parameters.Add("@date_to", MySqlDbType.String).Value = dateto;
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

        #endregion

        #region "events" 
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            home.Show();
        }

        private void frmReposrts_Load(object sender, EventArgs e)
        {
            label1.Text = date_today;
            // for clients
            dTable = new DataTable();
            get_client_name(dTable);
            dgvClients.DataSource = dTable;
            dgvClients.Columns["clientID"].Visible = false;
            dgvClients.Columns["clientclassificationID"].Visible = false;
            dgvClients.ColumnHeadersVisible = false;
            dTable.Dispose();

            try
            {
                DataGridViewRow rows = dgvClients.Rows[0];
                clientID = Convert.ToInt32(rows.Cells[0].Value.ToString());
                client_name = rows.Cells[1].Value.ToString();
                clientClassificationID = Convert.ToInt32(rows.Cells[2].Value.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            fill_dgvs();

        }

        private void radSpecified_CheckedChanged(object sender, EventArgs e)
        {
            if (radSpecified.Checked==true)
            {
                groupBox1.Visible = true;
            }
        }

        private void radThis_CheckedChanged(object sender, EventArgs e)
        {
            if (radThis.Checked == true)
            {
                groupBox1.Visible = false;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string search_client = txtSearchClient.Text;
            txtSearchClient.Text = "";
            // for clients
            dTable = new DataTable();
            search_clients(dTable, search_client);
            dgvClients.DataSource = dTable;
            dgvClients.Columns["clientID"].Visible = false;
            dgvClients.Columns["clientclassificationID"].Visible = false;
            dgvClients.ColumnHeadersVisible = false;
            dTable.Dispose();
        }


        #endregion

        private void dgvClients_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // manipulating the selected datagridview
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvClients.Rows[e.RowIndex];
                int rowindex = dgvClients.CurrentCell.RowIndex;
                int columnindex = dgvClients.CurrentCell.ColumnIndex;

                try
                {
                    // getting the values of dgvresult;
                    clientID = Convert.ToInt32(dgvClients.Rows[rowindex].Cells[0].Value.ToString());
                    client_name = dgvClients.Rows[rowindex].Cells[1].Value.ToString();
                    clientClassificationID = Convert.ToInt32(dgvClients.Rows[rowindex].Cells[2].Value.ToString());
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                // calling the fill_dgvs method
                fill_dgvs();

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            DGVPrinter printer = new DGVPrinter();
            printer.Title = client_name;
            printer.SubTitle =  subtitle;
            printer.Footer = "AGTech 0938-245-9457 / 0907-319-5457";
            printer.FooterSpacing = 15;
            printer.TitleAlignment = StringAlignment.Center;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = false;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(dgvReports);

        }
        public void get_details(string user, int id, int priviledge)    //passes value from one class to another
        {
            name = user;
            user_id = id;
            user_priviledge = priviledge;
        }
    }
}
