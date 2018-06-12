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
using System.IO;

namespace giulias_inventory_system
{
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }
        clsConnection sc = new clsConnection(); // Calling the Connection class    
        MySqlConnection vDBConn = new MySqlConnection(); // Calling the Sql Connection method
        DataTable dTable; //Initializing Datatable
        MySqlDataReader read;

        string name;
        string desc;
        int qty;
        decimal price;

        int client_id = 0;
        int product_id = 0;
        bool add_or_update = true;
        bool active_inactive = true;
        string date_today = DateTime.Now.ToString("yyyy-MM-dd");
        int currently_added_product_id = 0;
        int quantity_from = 0;
        decimal price_from = 0;
        decimal commission = 0;
        int client_classification_id = 0;
        public int ClientID { set { client_id = value; } }
        public int ClientClassificationID { set { client_classification_id = value; } }
        public int ProductID { set { product_id = value; } }
        public bool ActiveInactive { set { active_inactive = value; } }

        string user_name;
        int user_id;
        int user_priviledge;
        private void convertPictureBox()
        {

            //kuhaon ang picture gikan sa picturebox
            Image img = pbClientImage.Image;
            // byte na array
            byte[] arr;
            //memory stream
            var ms = new MemoryStream();



            //check ang file tapos i convert ang Image to memory stream

            if (System.Drawing.Imaging.ImageFormat.Jpeg.Equals(img.RawFormat))
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else if (System.Drawing.Imaging.ImageFormat.Png.Equals(img.RawFormat))
            {

                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            }
            else if (System.Drawing.Imaging.ImageFormat.Gif.Equals(img.RawFormat))
            {

                img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            }

            //himoun og array ang memory stream
            arr = ms.ToArray();

            //check lang ni if default ang picture
            bool Default = Check_IF_Default(arr);


            if (Default == true)
            {

                byte[] Def = { 0 };
                arr = Def;


            }
            //1048576

            //check if more than 5mb. If more than then di pwede
            if (arr.Length < 65536)
            {
               // diri ka tig query
                try
                {
                    sc.OpenConnection();

                    name = txtProductName.Text;
                    desc = txtDescription.Text;
                    qty = Convert.ToInt32(numQty.Value);
                    price = Convert.ToDecimal(txtPrice.Text);
                    price = Math.Round(price,2);

                    if (txtCommission.Text == "")
                    {
                        commission = 0;
                    }else
                    {
                        commission = Convert.ToDecimal(txtCommission.Text);
                    }

                    if (add_or_update == false)
                    {
                        // updating
                        // query to save to database
                        sc.command = sc.SQLCommand("UPDATE products SET name = @name, descr = @descr, photo = @photo, qty = @qty, price = @price, commission = @commission WHERE productID = @product_id");
                        sc.command.Parameters.Add("@photo", MySqlDbType.Blob).Value = arr;
                        sc.command.Parameters.Add("@name", MySqlDbType.String).Value = name;
                        sc.command.Parameters.Add("@descr", MySqlDbType.Text).Value = desc;
                        sc.command.Parameters.Add("@qty", MySqlDbType.Int32).Value = qty;
                        sc.command.Parameters.Add("@price", MySqlDbType.Decimal).Value = price;
                        sc.command.Parameters.Add("@product_id", MySqlDbType.Int32).Value = product_id;
                        sc.command.Parameters.Add("@commission", MySqlDbType.Decimal).Value = commission;
                        sc.command.ExecuteNonQuery();
                        sc.CloseConnection();
                        sc.command.Parameters.Clear();
                        insert_into_history(add_or_update);
                        Hide();
                    }
                    else if(add_or_update == true)
                    {
                        // adding
                        // query to save to database
                        sc.command = sc.SQLCommand("INSERT INTO  products (clientID,name,descr,photo,qty,price,commission,active) VALUES(@client_id, @name, @descr, @photo, @qty, @price,@commission,1)");
                        sc.command.Parameters.Add("@photo", MySqlDbType.Blob).Value = arr;
                        sc.command.Parameters.Add("@name", MySqlDbType.String).Value = name;
                        sc.command.Parameters.Add("@descr", MySqlDbType.Text).Value = desc;
                        sc.command.Parameters.Add("@qty", MySqlDbType.Int32).Value = qty;
                        sc.command.Parameters.Add("@price", MySqlDbType.Decimal).Value = price;
                        sc.command.Parameters.Add("@client_id", MySqlDbType.Int32).Value = client_id;
                        sc.command.Parameters.Add("@commission", MySqlDbType.Decimal).Value = commission;
                        sc.command.ExecuteNonQuery();
                        sc.CloseConnection();
                        sc.command.Parameters.Clear();
                        get_newly_added_product();
                        insert_into_history(add_or_update);
                        Hide();

                    }
                    

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
            else
            {
                MessageBox.Show("Oopss. The size of the image reached the maximum value. Please upload files that are 65kb or less.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool Check_IF_Default(byte[] Image)
        {
            Image Default_Image = giulias_inventory_system.Properties.Resources.original_clients;
            byte[] arr;

            var ms = new MemoryStream();

            if (System.Drawing.Imaging.ImageFormat.Jpeg.Equals(Default_Image.RawFormat))
            {
                Default_Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else if (System.Drawing.Imaging.ImageFormat.Png.Equals(Default_Image.RawFormat))
            {

                Default_Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            }
            else if (System.Drawing.Imaging.ImageFormat.Gif.Equals(Default_Image.RawFormat))
            {

                Default_Image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            }
            arr = ms.ToArray();

            Boolean Same = true;

            //check every single bit.
            int a = 0;
            try
            {

                while (a < Image.Length)
                {
                    if (arr[a] != Image[a])
                    {

                        Same = false;
                        break;
                    }
                    a += 1;
                }
            }
            catch (Exception)
            {
                Same = false;
            }
            return Same;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            add_or_update = true;
            try
            {
                name = txtProductName.Text;
                desc = txtDescription.Text;
                qty = Convert.ToInt32(numQty.Value);
                price = Convert.ToDecimal(txtPrice.Text);
                convertPictureBox();
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill out the necessary fields before proceeding", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
           

            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            add_or_update = false;
            try
            {
                name = txtProductName.Text;
                desc = txtDescription.Text;
                qty = Convert.ToInt32(numQty.Value);
                price = Convert.ToDecimal(txtPrice.Text);
                convertPictureBox();
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill out the necessary fields before proceeding", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

       
        private void btnUpload_Click(object sender, EventArgs e)
        {
            // Clicking the Upload Button
            // added by Abegail Isidro
            // April 17, 2018

            OpenFileDialog ofdPic = new OpenFileDialog();
            ofdPic.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (ofdPic.ShowDialog() == DialogResult.OK)
            {
                pbClientImage.ImageLocation = ofdPic.FileName;

            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void txtPrice_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal amount = Convert.ToDecimal(txtPrice.Text);
                txtPrice.Text = amount.ToString("##.00");
                
            }
            catch (Exception)
            {
                txtPrice.Text = "";
                MessageBox.Show("Invalid Input! Please enter a valid amount", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            if (client_classification_id == 1)
            {
                txtCommission.Enabled = false;
            }
            else
            {
                txtCommission.Enabled = true;
            }
            if (active_inactive==true)
            {
                btnActiveInactive.Text = "SET AS INACTIVE";
            }
            else
            {
                btnActiveInactive.Text = "SET AS ACTIVE";
            }
            if (product_id > 0)
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;

                DataTable dTable = new DataTable();
                get_product_values(dTable);
                dgvHidden.DataSource = dTable;
                dTable.Dispose();
                DataGridViewRow row = dgvHidden.Rows[0];
                txtProductName.Text = row.Cells[2].Value.ToString();
                quantity_from = Convert.ToInt32(row.Cells[5].Value.ToString());
                price_from= Convert.ToDecimal(row.Cells[6].Value.ToString());
                txtDescription.Text = row.Cells[3].Value.ToString();
                txtCommission.Text = row.Cells[7].Value.ToString();
                // picture
                try
                {
                    if (row.Cells["photo"].Value != System.DBNull.Value) // if there is a picture available
                    {
                        var data = (Byte[])(row.Cells["photo"].Value);
                        var stream = new MemoryStream(data);
                        pbClientImage.Image = Image.FromStream(stream);
                    }
                    else
                    {
                        pbClientImage.Image = giulias_inventory_system.Properties.Resources.original_transaction;
                    }
                }
                catch (Exception)
                {
                    pbClientImage.Image = giulias_inventory_system.Properties.Resources.original_transaction;
                }
                numQty.Value = Convert.ToInt32(row.Cells[5].Value.ToString());
                txtPrice.Text = row.Cells[6].Value.ToString();

            }
            else
            {
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
                btnActiveInactive.Enabled = false;
            }
        }


        private void get_product_values(DataTable dt)
        {
            try
            {
                sc.OpenConnection();
                sc.command = sc.SQLCommand("SELECT * FROM `products` WHERE productID = @productID");
                sc.command.Parameters.Add("@productID", MySqlDbType.Int32).Value = product_id;
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

        private void frmProducts_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnActiveInactive_Click(object sender, EventArgs e)
        {
            int activeinactive = 0;

            if (active_inactive == false)
            {
                activeinactive = 1;
            }

            try
            {
                sc.OpenConnection();
                // query to save to database
                sc.command = sc.SQLCommand("UPDATE products SET active = @active_inactive WHERE productID = @product_id");
                sc.command.Parameters.Add("@active_inactive", MySqlDbType.Int32).Value = activeinactive;
                sc.command.Parameters.Add("@product_id", MySqlDbType.Int32).Value = product_id;
                sc.command.ExecuteNonQuery();
                sc.CloseConnection();
                sc.command.Parameters.Clear();

                insert_into_history_active_inactive(activeinactive);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Hide();
            
        }

        private void get_newly_added_product()
        {
            try
            {
                sc.OpenConnection();
                // query to save to database
                sc.command = sc.SQLCommand("SELECT productID from products ORDER BY productID DESC LIMIT 1");
                read = sc.command.ExecuteReader();

                while (read.Read())
                {
                    currently_added_product_id = Convert.ToInt32(read["productID"]);
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
        }

        private void insert_into_history(bool add_or_update)
        {
            string note = "";
            try
            {
                if (add_or_update == true)
                {
                    note = "Added a new product.";
                }
                else
                {
                    note = "Updated Product Information.";
                }

                sc.OpenConnection();
                // query to save to database
                sc.command = sc.SQLCommand("INSERT INTO history (date_modified, clientID, userID, note,productID,price_from,price_to,quantity_from,quantity_to) VALUES (@date_modified, @client_id, @user_id, @note,@product_id,@price_from,@price_to,@quantity_from,@quantity_to) ");
                sc.command.Parameters.Add("@user_id", MySqlDbType.Int32).Value = 1; // change if naa na userid
                sc.command.Parameters.Add("@client_id", MySqlDbType.Int32).Value = client_id;
                if (add_or_update == true)
                {
                    sc.command.Parameters.Add("@product_id", MySqlDbType.Int32).Value = currently_added_product_id;
                }
                else
                {
                    sc.command.Parameters.Add("@product_id", MySqlDbType.Int32).Value = product_id;
                }
                sc.command.Parameters.Add("@date_modified", MySqlDbType.String).Value = date_today;
                sc.command.Parameters.Add("@note", MySqlDbType.Text).Value = note;
                sc.command.Parameters.Add("@price_from", MySqlDbType.Int32).Value = price_from;
                sc.command.Parameters.Add("@quantity_from", MySqlDbType.Decimal).Value = quantity_from;
                sc.command.Parameters.Add("@price_to", MySqlDbType.Int32).Value = price;
                sc.command.Parameters.Add("@quantity_to", MySqlDbType.Decimal).Value = qty;
                sc.command.ExecuteNonQuery();
                sc.CloseConnection();
                sc.command.Parameters.Clear();
                if (add_or_update == true)
                {
                    MessageBox.Show("Successfully added a new Product.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Successfully modified Product Information.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

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

        private void insert_into_history_active_inactive(int active_checker)
        {
            string note = "";
            if (active_checker == 1)
            {
                note = "Set Product status to ACTIVE";
            }
            else
            {
                note = "Set Product status to INACTIVE";
            }

            try
            {
                sc.OpenConnection();
                sc.command = sc.SQLCommand("INSERT INTO history (date_modified, clientID, userID, note, productID) VALUES (@date_modified, @client_id, @user_id, @note ,@product_id) ");
                sc.command.Parameters.Add("@user_id", MySqlDbType.Int32).Value = 1; // change if naa na userid
                sc.command.Parameters.Add("@client_id", MySqlDbType.Int32).Value = client_id;
                sc.command.Parameters.Add("@product_id", MySqlDbType.Int32).Value = product_id;
                sc.command.Parameters.Add("@date_modified", MySqlDbType.String).Value = date_today;
                sc.command.Parameters.Add("@note", MySqlDbType.Text).Value = note;
                sc.command.ExecuteNonQuery();
                sc.CloseConnection();
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

            if (active_checker == 1)
            {
                MessageBox.Show("Successfully set Product status to ACTIVE", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Successfully set Product status to INACTIVE", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCommission_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal amount = Convert.ToDecimal(txtCommission.Text);
                txtCommission.Text = amount.ToString("##.00");

            }
            catch (Exception)
            {
                txtCommission.Text = "";
                MessageBox.Show("Invalid Input! Please enter a valid amount", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        public void get_details(string user, int id, int priviledge)    //passes value from one class to another
        {
            user_name = user;
            user_id = id;
            user_priviledge = priviledge;
        }
    }
}
