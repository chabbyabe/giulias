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
    public partial class frmTransaction : Form
    {
        public frmTransaction()
        {
            InitializeComponent();
        }
        // 04-17-18 3:00 pm Added by Abegail Isidro 
        clsConnection sc = new clsConnection(); // Calling the Connection class    
        MySqlConnection vDBConn = new MySqlConnection(); // Calling the Sql Connection method
        DataTable dTable; //Initializing Datatable
        frmClientConfiguration cc = new frmClientConfiguration();   //Calls the client configuration form to add or update costumers
        frmHome home = new frmHome();


        string date_today = DateTime.Now.ToString("yyyy-MM-dd");
        int clientID = 0;
        decimal price = 0;
        int qty = 0;
        int productID = 0;
        decimal commission = 0;
        int transactionNO = 0;


        string name;
        int user_id;
        int user_priviledge;
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            home.Show();
        }

        private void frmTransaction_Activated(object sender, EventArgs e)
        {
            button1.Enabled = false;
            commission = 0;
            // for clients
            dTable = new DataTable();
            get_client_name(dTable);
            dgvClients.DataSource = dTable;
            dgvClients.Columns["clientID"].Visible = false;
            dgvClients.ColumnHeadersVisible = false;
            dTable.Dispose();

            try
            {
                DataGridViewRow rows = dgvClients.Rows[0];
                clientID = Convert.ToInt32(rows.Cells[0].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            fill_dgvs();

            // for transactions
            dTable = new DataTable();
            get_current_transactions(dTable);
            dgvTransaction.DataSource = dTable;
            dTable.Dispose();
            dgvTransaction.Columns["transactionNO"].Visible = false;
            dgvTransaction.Columns["name"].HeaderText = "Client Name";
            dgvTransaction.Columns["name1"].HeaderText = "Product Name";

            foreach (DataGridViewColumn column in dgvTransaction.Columns)
            {
                // para ma pagamyan ang size sa quantity
                DataGridViewColumn quantity_size = dgvTransaction.Columns["quantity"];
                quantity_size.Width = 80;
                // para ma pagamyan ang size sa total
                DataGridViewColumn total_size = dgvTransaction.Columns["total"];
                total_size.Width = 150;
                // para ma pagamyan ang size sa commission
                DataGridViewColumn commission_size = dgvTransaction.Columns["commission"];
                commission_size.Width = 100;
                // para ma pagamyan ang size sa price
                DataGridViewColumn price_size = dgvTransaction.Columns["price"];
                price_size.Width = 150;
            }

        }

        private void fill_dgvs()
        {
            bool checker = false;
            numQty.Value = 0;

            try
            {
                // for products
                dTable = new DataTable();
                get_product_name(dTable, clientID, productID);
                dgvProducts.DataSource = dTable;
                dgvProducts.Columns["productID"].Visible = false;
                dgvProducts.Columns["qty"].Visible = false;
                dgvProducts.Columns["price"].Visible = false;
                dgvProducts.Columns["commission"].Visible = false;
                dgvProducts.ColumnHeadersVisible = false;
                dTable.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            try
            {
                DataGridViewRow rows = dgvProducts.Rows[0];
                productID = Convert.ToInt32(rows.Cells[0].Value.ToString());
                qty = Convert.ToInt32(rows.Cells[2].Value.ToString());
                price = Convert.ToDecimal(rows.Cells[3].Value.ToString());
                try
                {
                    commission = Convert.ToDecimal(rows.Cells[4].Value.ToString());
                }
                catch (Exception) { }
            }
            catch (Exception)
            {
                checker = true;
            }


            if (checker == false)
            {
                // assigning of values to price and qty textboxes
                txtPrice.Text = price.ToString();
                lblqty.Text = qty + " in stock.";

                // setting the max value of numericUPDown qty
                numQty.Maximum = qty;

            } else
            {
                // assigning of values to price and qty textboxes
                txtPrice.Text = "";
                lblqty.Text = "0 in stock.";
                numQty.Maximum = 0;
            }

        }

        private void get_current_transactions(DataTable dt)
        {

            /**
              04-19-18 4:31 pm Added by Kwen Isidro 

              GETTING CURRENT TRANSACTIONS
           */
            string date_today = DateTime.Now.ToString("yyyy-MM-dd");
            try
            {
                sc.OpenConnection();
                sc.command = sc.SQLCommand("SELECT t.transactionNO, c.name, p.name, p.price, t.quantity, t.total, t.commission FROM transactions as t INNER JOIN products as p ON t.productID = p.productID INNER JOIN clients as c ON c.clientID = t.clientID WHERE transaction_date = @date_today AND t.active =1");
                sc.command.Parameters.Add("@date_today", MySqlDbType.String).Value = date_today;
                sc.sqlReader = sc.command.ExecuteReader();
                dt.Load(sc.sqlReader);
                sc.command.Parameters.Clear();
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

        private void get_client_name(DataTable dt)
        {

            /**
              04-19-18 4:31 pm Added by Kwen Isidro 

              Setting Client Type
           */

            try
            {
                sc.OpenConnection();
                sc.command = sc.SQLCommand("SELECT clientID, name FROM clients WHERE active = 1 LIMIT 50");
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

        private void get_product_name(DataTable dt, int clientID, int productID)
        {

            /**
              04-19-18 4:31 pm Added by Kwen Isidro 

              Setting Product Type
           */
            try
            {
                sc.OpenConnection();
                sc.command = sc.SQLCommand("SELECT productID, name,qty,price,commission FROM products WHERE active = 1 AND clientID = @client_id");
                sc.command.Parameters.Add("@product_id", MySqlDbType.Int32).Value = productID;
                sc.command.Parameters.Add("@client_id", MySqlDbType.Int32).Value = clientID;
                sc.sqlReader = sc.command.ExecuteReader();
                dt.Load(sc.sqlReader);
                sc.command.Parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sc.CloseConnection();
            }

        }

        private void dgvClients_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtSearchClient.Text = "";


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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                // calling the fill_dgvs method
                fill_dgvs();

            }
        }

        private void dgvProducts_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
            numQty.Value = 0;

            // manipulating the selected datagridview
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvProducts.Rows[e.RowIndex];
                int rowindex = dgvProducts.CurrentCell.RowIndex;
                int columnindex = dgvProducts.CurrentCell.ColumnIndex;

                try
                {
                    // getting the values of dgvresult;
                    productID = Convert.ToInt32(dgvProducts.Rows[rowindex].Cells[0].Value.ToString());
                    qty = Convert.ToInt32(dgvProducts.Rows[rowindex].Cells[2].Value.ToString());
                    price = Convert.ToDecimal(dgvProducts.Rows[rowindex].Cells[3].Value.ToString());
                    try
                    {
                        commission = Convert.ToDecimal(dgvProducts.Rows[rowindex].Cells[4].Value.ToString());
                    }
                    catch (Exception) { }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                // assigning the values
                txtPrice.Text = price.ToString();
                lblqty.Text = qty + " in stock.";
                // setting the max value of numericUPDown qty
                numQty.Maximum = qty;
            }
        }



        private void numQty_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal price = Convert.ToDecimal(txtPrice.Text.ToString());
                decimal qty = numQty.Value;

                decimal total = price * qty;
                txtTotal.Text = total.ToString();
            }
            catch (Exception)
            {

            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (clientID == 0 || productID == 0 || txtPrice.Text.ToString() == "" || numQty.Value.ToString() == "0" || txtTotal.Text.ToString() =="0.00" || txtTotal.Text.ToString() == "")
            {
                MessageBox.Show("Please Fill out the necessary fields.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else
            {
                insert_into_transactions();
                update_transactions();
                insert_into_history();
            }
        }

        private void insert_into_transactions()
        {
            try
            {
                // getting the values
                string date_today = DateTime.Now.ToString("yyyy-MM-dd");
                int quantity = Convert.ToInt32(numQty.Value);
                decimal total = Convert.ToDecimal(txtTotal.Text.ToString());
                decimal total_commission = commission*quantity;
                sc.OpenConnection();
                // query to save to database
                sc.command = sc.SQLCommand("INSERT INTO  transactions (userID,clientID,productID,transaction_date,quantity,total,commission,active) VALUES(@user_id,@client_id,@product_id,@transaction_date,@quantity,@total,@total_commission,1)");
                sc.command.Parameters.Add("@user_id", MySqlDbType.Int32).Value = user_id; // change if naa na userid
                sc.command.Parameters.Add("@client_id", MySqlDbType.Int32).Value = clientID;
                sc.command.Parameters.Add("@product_id", MySqlDbType.Int32).Value = productID;
                sc.command.Parameters.Add("@transaction_date", MySqlDbType.String).Value = date_today;
                sc.command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity;
                sc.command.Parameters.Add("@total", MySqlDbType.Decimal).Value = total;
                sc.command.Parameters.Add("@total_commission", MySqlDbType.Decimal).Value = total_commission;
                sc.command.ExecuteNonQuery();
                sc.CloseConnection();
                sc.command.Parameters.Clear();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sc.CloseConnection();
            }
        }

        private void update_transactions()
        {
            try
            {
                // getting the values
                int quantity = Convert.ToInt32(numQty.Value);
                int final_quantity = qty - quantity;

                sc.OpenConnection();
                // query to save to database
                sc.command = sc.SQLCommand("UPDATE products SET qty = @quantity WHERE productID = @product_id");
                sc.command.Parameters.Add("@product_id", MySqlDbType.Int32).Value = productID;
                sc.command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = final_quantity;
                sc.command.ExecuteNonQuery();
                sc.CloseConnection();
                sc.command.Parameters.Clear();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sc.CloseConnection();
            }
        }

        private void insert_into_history()
        {
            try
            {
                // getting the values
                int quantity = Convert.ToInt32(numQty.Value);
                int quentity_to = qty - quantity;
                sc.OpenConnection();
                // query to save to database
                sc.command = sc.SQLCommand("INSERT INTO history (date_modified, clientID, productID, userID, quantity_from, quantity_to, note) VALUES (@date_modified, @client_id, @product_id, @user_id, @quantity_from, @quantity_to, @note) ");
                sc.command.Parameters.Add("@user_id", MySqlDbType.Int32).Value = user_id; // change if naa na userid
                sc.command.Parameters.Add("@client_id", MySqlDbType.Int32).Value = clientID;
                sc.command.Parameters.Add("@product_id", MySqlDbType.Int32).Value = productID;
                sc.command.Parameters.Add("@date_modified", MySqlDbType.String).Value = date_today;
                sc.command.Parameters.Add("@quantity_from", MySqlDbType.Int32).Value = qty;
                sc.command.Parameters.Add("@quantity_to", MySqlDbType.Int32).Value = quentity_to;
                sc.command.Parameters.Add("@note", MySqlDbType.Text).Value = "Bought by Customer";
                sc.command.ExecuteNonQuery();
                sc.CloseConnection();
                sc.command.Parameters.Clear();
                MessageBox.Show("A new transaction has been successfully saved.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sc.CloseConnection();
            }
        }

        private void btnSearchClient_Click(object sender, EventArgs e)
        {
            string search_client = txtSearchClient.Text;
            // for clients
            dTable = new DataTable();
            search_clients(dTable,search_client);
            dgvClients.DataSource = dTable;
            dgvClients.Columns["clientID"].Visible = false;
            dgvClients.ColumnHeadersVisible = false;
            dTable.Dispose();

            try
            {
                DataGridViewRow rows = dgvClients.Rows[0];
                clientID = Convert.ToInt32(rows.Cells[0].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            fill_dgvs();

            // for transactions
            dTable = new DataTable();
            get_current_transactions(dTable);
            dgvTransaction.DataSource = dTable;
            dTable.Dispose();
            dgvTransaction.Columns["transactionNO"].Visible = false;
            dgvTransaction.Columns["name"].HeaderText = "Client Name";
            dgvTransaction.Columns["name1"].HeaderText = "Product Name";
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
                sc.command.Parameters.Add("@search", MySqlDbType.String).Value = '%'+search+'%';
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (transactionNO > 0)
            {
                frmTransactionsUpdate trans = new frmTransactionsUpdate();
                trans.TransactionNO = transactionNO;
                trans.Show();
            }else
            {
                MessageBox.Show("Please select a transaction first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
     
        }

        private void dgvTransaction_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            button1.Enabled = true;
            // manipulating the selected datagridview
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvTransaction.Rows[e.RowIndex];
                int rowindex = dgvTransaction.CurrentCell.RowIndex;
                int columnindex = dgvTransaction.CurrentCell.ColumnIndex;

                try
                {
                    // getting the values of dgvresult;
                    transactionNO = Convert.ToInt32(dgvTransaction.Rows[rowindex].Cells[0].Value.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                // calling the fill_dgvs method
                fill_dgvs();

            }
        }

        public void get_details(string user, int id, int priviledge)    //passes value from one class to another
        {
            name = user;
            user_id = id;
            user_priviledge = priviledge;
        }

        private void frmTransaction_Load(object sender, EventArgs e)
        {

        }

     
    }
}
