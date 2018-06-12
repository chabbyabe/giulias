using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace giulias_inventory_system
{
    public partial class frmTransactionsUpdate : Form
    {
        public frmTransactionsUpdate()
        {
            InitializeComponent();
        }

        #region "Forms and Connections"
        // 04-17-18 11:49 am Added by Abegail Isidro 
        clsConnection sc = new clsConnection(); // Calling the Connection class    
        MySqlConnection vDBConn = new MySqlConnection(); // Calling the Sql Connection method
        DataTable dTable; //Initializing Datatable
        MySqlDataReader read;

        #endregion 

        #region "variables"
        int transaction_no = 0;
        string date_today = DateTime.Now.ToString("yyyy-MM-dd");
        string client_name = "";
        string product_name = "";
        int quantity_from = 0;
        int product_id = 0;
        int client_id = 0;
        int quantity_to = 0;
        decimal commission = 0;
        int quantity_in_stock = 0;
        decimal price = 0;
        decimal total = 0;
        #endregion

        #region "get-set properties"
        public int TransactionNO { set { transaction_no = value; } }
        #endregion

        #region "methods"

        private void update_products()
        {
            try
            {
                // getting the values
                // check to see the changes of numQty
                quantity_to = Convert.ToInt32(numQty.Value);
                int quantity_to_be_changed = 0;

                if (quantity_to != quantity_from)
                {
                    if (quantity_to > quantity_from)
                    {
                        quantity_to_be_changed = (quantity_in_stock - (quantity_to - quantity_from));
                    }
                    else if (quantity_to < quantity_from)
                    {
                        quantity_to_be_changed = (quantity_in_stock + (quantity_from - quantity_to));
                    }
                }

                sc.OpenConnection();
                // query to save to database
                sc.command = sc.SQLCommand("UPDATE products SET qty = @qty WHERE productID = @product_id");
                sc.command.Parameters.Add("@product_id", MySqlDbType.Int32).Value = product_id;
                sc.command.Parameters.Add("@qty", MySqlDbType.Int32).Value = quantity_to_be_changed;
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
                decimal transaction_total_change = quantity_to * price;
                decimal transaction_commission_change = quantity_to * commission;

                sc.OpenConnection();
                // query to save to database
                sc.command = sc.SQLCommand("UPDATE transactions SET quantity = @quantity, total = @total, commission = @commission WHERE transactionNO = @transaction_no");
                sc.command.Parameters.Add("@transaction_no", MySqlDbType.Int32).Value = transaction_no;
                sc.command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity_to;
                sc.command.Parameters.Add("@total", MySqlDbType.Decimal).Value = transaction_total_change;
                sc.command.Parameters.Add("@commission", MySqlDbType.Decimal).Value = transaction_commission_change;
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

                sc.OpenConnection();
                // query to save to database
                sc.command = sc.SQLCommand("INSERT INTO history (transactionNO, date_modified, clientID, productID, userID, quantity_from, quantity_to, note) VALUES (@transaction_no, @date_modified, @client_id, @product_id, @user_id, @quantity_from, @quantity_to, @note) ");
                sc.command.Parameters.Add("@user_id", MySqlDbType.Int32).Value = 1; // change if naa na userid
                sc.command.Parameters.Add("@client_id", MySqlDbType.Int32).Value = client_id;
                sc.command.Parameters.Add("@product_id", MySqlDbType.Int32).Value = product_id;
                sc.command.Parameters.Add("@date_modified", MySqlDbType.String).Value = date_today;
                sc.command.Parameters.Add("@quantity_from", MySqlDbType.Int32).Value = quantity_from;
                sc.command.Parameters.Add("@quantity_to", MySqlDbType.Int32).Value = quantity_to;
                sc.command.Parameters.Add("@transaction_no", MySqlDbType.Int32).Value = transaction_no;
                sc.command.Parameters.Add("@note", MySqlDbType.Text).Value = "UPDATED TRANSACTION";
                sc.command.ExecuteNonQuery();
                sc.CloseConnection();
                sc.command.Parameters.Clear();
                MessageBox.Show("Successfully updated transaction.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        #endregion

        #region "events"

        private void frmTransactionsUpdate_Load(object sender, EventArgs e)
        {
            if (transaction_no > 0)
            {
                try
                {
                    sc.OpenConnection();
                    // query to save to database
                    sc.command = sc.SQLCommand("SELECT c.name as clientName, p.name as productName, t.productID, t.clientID, t.quantity, p.price, t.total, p.qty, p.commission FROM transactions as t INNER JOIN clients as c ON c.clientID = t.clientID INNER JOIN products as p on p.productID = t.productID WHERE transactionNO = @trans_no");
                    sc.command.Parameters.Add("@trans_no", MySqlDbType.Int32).Value = transaction_no;
                    read = sc.command.ExecuteReader();

                    while (read.Read())
                    {
                        client_name = Convert.ToString(read["clientName"]);
                        product_name = Convert.ToString(read["productName"]);
                        quantity_from = Convert.ToInt32(read["quantity"]);
                        quantity_in_stock = Convert.ToInt32(read["qty"]);
                        try
                        {
                            commission = Convert.ToDecimal(read["commission"]);
                        }
                        catch (Exception)
                        {

                        }
                        
                        product_id = Convert.ToInt32(read["productID"]);
                        client_id = Convert.ToInt32(read["clientID"]);
                        price = Convert.ToDecimal(read["price"]);
                        total = Convert.ToDecimal(read["total"]);
                    }
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

                txtClientName.Text = client_name;
                txtProductName.Text = product_name;
                numQty.Value = quantity_from;
                lblqty.Text = quantity_in_stock.ToString() + " in stock.";
                numQty.Maximum = quantity_from+quantity_in_stock;
                txtPrice.Text = price.ToString();
                txtTotal.Text = total.ToString();
            }
            else
            {
                MessageBox.Show("Transaction not valid", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void numQty_ValueChanged(object sender, EventArgs e)
        {
            if (numQty.Value == 0)
            {
                MessageBox.Show("Quantity cannot be zero. Do you want to cancel the transaction instead?", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                numQty.Value = 1;
            }
            else
            {
                quantity_to = Convert.ToInt32(numQty.Value);

                txtTotal.Text = (Convert.ToDecimal(quantity_to) * price).ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (quantity_from != quantity_to)
            {
                update_products();
                update_transactions();
                insert_into_history();
                
            }
            Hide();
        }


        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Visible = true;
            txtPassword.Visible = true;
            lblDiv.Visible = true;
            label11.Visible = true;
            label12.Visible = true;

            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please enter username and password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
            {
                // process to see if naa nag match na username and password with encryption


                // if nag match
                update_transactions_for_cancel();
                update_products_for_cancel();
                insert_into_history_for_cancel();
                Hide();
            }

        }

        private void update_products_for_cancel()
        {
            try
            {
                // getting the values
                // check to see the changes of numQty
                quantity_to = Convert.ToInt32(numQty.Value);
                int quantity_to_be_changed = quantity_in_stock+quantity_from;

                sc.OpenConnection();
                // query to save to database
                sc.command = sc.SQLCommand("UPDATE products SET qty = @qty WHERE productID = @product_id");
                sc.command.Parameters.Add("@product_id", MySqlDbType.Int32).Value = product_id;
                sc.command.Parameters.Add("@qty", MySqlDbType.Int32).Value = quantity_to_be_changed;
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

        private void update_transactions_for_cancel()
        {
            try
            {
             
                sc.OpenConnection();
                // query to save to database
                sc.command = sc.SQLCommand("UPDATE transactions SET active = 0 WHERE transactionNO = @transaction_no");
                sc.command.Parameters.Add("@transaction_no", MySqlDbType.Int32).Value = transaction_no;
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

        private void insert_into_history_for_cancel()
        {
            try
            {

                sc.OpenConnection();
                // query to save to database
                sc.command = sc.SQLCommand("INSERT INTO history (transactionNO, date_modified, clientID, productID, userID, quantity_from, quantity_to, note) VALUES (@transaction_no, @date_modified, @client_id, @product_id, @user_id, @quantity_from, @quantity_to, @note) ");
                sc.command.Parameters.Add("@user_id", MySqlDbType.Int32).Value = 1; // change if naa na userid
                sc.command.Parameters.Add("@client_id", MySqlDbType.Int32).Value = client_id;
                sc.command.Parameters.Add("@product_id", MySqlDbType.Int32).Value = product_id;
                sc.command.Parameters.Add("@date_modified", MySqlDbType.String).Value = date_today;
                sc.command.Parameters.Add("@quantity_from", MySqlDbType.Int32).Value = quantity_from;
                sc.command.Parameters.Add("@quantity_to", MySqlDbType.Int32).Value = 0;
                sc.command.Parameters.Add("@transaction_no", MySqlDbType.Int32).Value = transaction_no;
                sc.command.Parameters.Add("@note", MySqlDbType.Text).Value = "CANCELLED TRANSACTION";
                sc.command.ExecuteNonQuery();
                sc.CloseConnection();
                sc.command.Parameters.Clear();
                MessageBox.Show("Successfully CANCELLED the current transaction.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    }
}
