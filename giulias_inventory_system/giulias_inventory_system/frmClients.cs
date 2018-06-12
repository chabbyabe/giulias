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
using System.Drawing.Imaging;

namespace giulias_inventory_system
{
    public partial class frmClients : Form
    {
        public frmClients()
        {
            InitializeComponent();
        }
        #region "Forms and Connections"
        // 04-17-18 11:49 am Added by Abegail Isidro 
        clsConnection sc = new clsConnection(); // Calling the Connection class    
        MySqlConnection vDBConn = new MySqlConnection(); // Calling the Sql Connection method
        DataTable dTable; //Initializing Datatable
        frmClientConfiguration cc = new frmClientConfiguration();   //Calls the client configuration form to add or update costumers
        frmHome home = new frmHome();
        MySqlDataReader read;

        #endregion 

        #region "variables"

        int clientID;
        string client_name;
        string client_description;
        int active_inactive = 1;
        string search_this;
        int client_classification_id = 0;
        bool add_or_update = true;
        int product_id;
        int currently_added_client_id = 0;
        DateTime date_last_paid;
        string date_today = DateTime.Now.ToString("yyyy-MM-dd");

        string user_name;
        int user_id;
        int user_priviledge;
        #endregion

        #region "methods"
        private void get_product_details(DataTable dt, int active_inactive)
        {
            /**
                04-18-18 11:26 pm Added by Kwen Isidro 

                Client and Product details.
            */

            try
            {
                sc.OpenConnection();
                sc.command = sc.SQLCommand("Select c.clientID, c.name, c.photo, p.name, c.clientclassificationID, c.date_last_paid From clients as c LEFT JOIN products as p ON c.clientID = p.clientID WHERE c.active = @activeinactive ORDER BY c.clientID DESC");
                sc.command.Parameters.Add("@activeinactive", MySqlDbType.Int32).Value = active_inactive;
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

        private void get_list_of_products(DataTable dt, int id, int activeinactive)
        {
            /**
                04-18-18 11:26 pm Added by Kwen Isidro 

                Gets all of the products of the user
                parameters: datatable, id for the client id and activeinactive
            */

            try
            {
                sc.OpenConnection();
                if (client_classification_id == 1)
                {
                    sc.command = sc.SQLCommand("SELECT p.productID, p.photo, p.name, p.descr, p.qty, p.price FROM products as p INNER JOIN clients as c ON c.clientID = p.clientID WHERE p.clientID = " + id + " and p.active =" + activeinactive);
                }
                else
                {
                    sc.command = sc.SQLCommand("SELECT p.productID, p.photo, p.name, p.descr, p.qty, p.price, p.commission FROM products as p INNER JOIN clients as c ON c.clientID = p.clientID WHERE p.clientID = " + id + " and p.active =" + activeinactive);
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

        private void Hide_DGV()
        {
            /**
                04-18-18 11:26 pm Added by Kwen Isidro 

                This method is used to hide the values that appear on the right side of the screen.
                Redundant Column names are also replaced in this method.
            */
            dgvResults.Columns["clientID"].Visible = false;
            dgvResults.Columns["clientclassificationID"].Visible = false;
            dgvResults.Columns["name"].HeaderText = "Client Name";
            dgvResults.Columns["name1"].HeaderText = "Product Name";
            dgvResults.Columns["photo"].Visible = false;
            dgvResults.Columns["date_last_paid"].Visible = false;
            lblResult.Text = dgvResults.RowCount.ToString() + "   match(es) Found.";
        }

        private void get_client_classification_details(DataTable dt, int id, int active_inactive)
        {
            /**
                04-18-18 11:26 pm Added by Kwen Isidro 

                Getting the client's priviledges
            */

            try
            {
                sc.OpenConnection();
                sc.command = sc.SQLCommand("SELECT cc.name, cc.description FROM clientclassifications as cc INNER JOIN clients as c ON c.clientclassificationID = cc.clientclassificationID WHERE c.active = @activeinactive AND cc.active = 1 AND c.clientID = " + id);
                sc.command.Parameters.Add("@activeinactive", MySqlDbType.Int32).Value = active_inactive;
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

        private void ClearAllValues()
        {
            // enabling the AddClient button
            btnAddClient.Enabled = true;

            // disabling the EditClient button
            btnEditClient.Enabled = false;

            // clearing all values of the textboxes
            txtClient.Text = "";
            txtClientDescription.Text = "";

            // change picture box to the default picture
            pbClientImage.Image = giulias_inventory_system.Properties.Resources.original_clients;

            // deleting all the values of the two datagridview
            dgvClientClassification.DataSource = null;
            dgvClientClassification.Rows.Clear();
            dgvProducts.DataSource = null;
            dgvProducts.Rows.Clear();

            // deleting any values inputted in the search button
            txtSearch.Text = "";

            // setting the text Value ReadOnly Propery as FALSE
            txtClient.ReadOnly = false;

            // setting the client type with default choices
            setting_client_type();

            // setting the default product buttons
            btnAddProduct.Enabled = true;
            btnUpdateProduct.Enabled = false;
      
            // setting clientID and ProductID variables to 0
            clientID = 0;
            product_id = 0;

            // setting values of the ACTIVE INACTIVE Buttons
            if (radActive.Checked==true)
            {
                button3.Text = "SET CLIENT AS INACTIVE";
            }else
            {
                button3.Text = "SET CLIENT AS ACTIVE";
            }

            radActiveProducts.Checked = true;
            
        }

        private void setting_client_type()
        {
            dTable = new DataTable();
            get_client_type(dTable);
            dgvClientClassification.DataSource = dTable;
            dTable.Dispose();
            dgvClientClassification.Columns["description"].Visible = false;
            dgvClientClassification.ColumnHeadersVisible = false;
            try{
                DataGridViewRow rows = dgvClientClassification.Rows[0];
                client_description = rows.Cells[1].Value.ToString();
            }
            catch (Exception)
            {}
            
            txtClientDescription.Text = client_description;
        }

        private void get_client_type(DataTable dt)
        {
           
            /**
              04-19-18 4:31 pm Added by Kwen Isidro 

              Setting Client Type
           */

            try
            {
                sc.OpenConnection();
                sc.command = sc.SQLCommand("SELECT DISTINCT cc.name, cc.description FROM clientclassifications as cc INNER JOIN clients as c ON c.clientclassificationID = cc.clientclassificationID WHERE c.active = 1 AND cc.active = 1 ");
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
        private void search_items(DataTable dt, int active_inactive, string search)
        {
            /**
               04-19-18 11:26 am Added by Kwen Isidro 

               Search Clients and Products
           */

            try
            {
                sc.OpenConnection();
                sc.command = sc.SQLCommand("Select c.clientID, c.name, c.photo, p.name, c.clientclassificationID , c.date_last_paid From clients as c LEFT JOIN products as p ON c.clientID = p.clientID WHERE c.active = @activeinactive AND (c.name LIKE '%" + search + "%' OR p.name LIKE '%" + search + "%')");
                sc.command.Parameters.Add("@activeinactive", MySqlDbType.Int32).Value = active_inactive;
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
                sc.command.Parameters.Clear();
            }
        }

        private void convertPictureBox(bool checker_add_or_update)
        {

            //kuhaon ang picture gikan sa picturebox
            Image img = pbClientImage.Image;
            // byte na array
            byte[] arr;
            //memory stream
            var ms = new MemoryStream();



            //check ang file tapos i convert ang Image to memory stream

            if (ImageFormat.Jpeg.Equals(img.RawFormat))
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else if (ImageFormat.Png.Equals(img.RawFormat))
            {

                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            }
            else if (ImageFormat.Gif.Equals(img.RawFormat))
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
                string name = txtClient.Text;
                string desc = txtClientDescription.Text;

                if (client_classification_id == 0)
                {
                    client_classification_id = 1;
                }

                try
                {
                    sc.OpenConnection();
                    // modification of the error messages that will show
                  
                    if (name.Equals(""))
                    {
                        MessageBox.Show("Please enter the name of the client.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (add_or_update==true)
                        {
                            // query to save to database
                            sc.command = sc.SQLCommand("INSERT INTO  clients (name,photo,clientclassificationID,active) VALUES(@name,@Picture," + client_classification_id + ",1)");
                            sc.command.Parameters.Add("@Picture", MySqlDbType.Blob).Value = arr;
                            sc.command.Parameters.Add("@name", MySqlDbType.Blob).Value = name;
                            sc.command.ExecuteNonQuery();
                            sc.CloseConnection();
                            sc.command.Parameters.Clear();
                            get_newly_added_client();
                            insert_into_history(add_or_update);
                            ClearAllValues();
                        }else if (add_or_update == false)
                        {
                            // query to save to database
                            sc.command = sc.SQLCommand("UPDATE clients SET name = @Name, photo = @Picture WHERE clientID = @ClientID");
                            sc.command.Parameters.Add("@Picture", MySqlDbType.Blob).Value = arr;
                            sc.command.Parameters.Add("@Name", MySqlDbType.String).Value = client_name;
                            sc.command.Parameters.Add("@ClientID", MySqlDbType.Int32).Value = clientID;
                            sc.command.ExecuteNonQuery();
                            sc.CloseConnection();
                            sc.command.Parameters.Clear();
                            insert_into_history(add_or_update);
                            ClearAllValues();
                        }
                        
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
                MessageBox.Show("Oopss. The size of the image reached the maximum value. Please upload 65kb or lesser than files.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool Check_IF_Default(byte[] Image)
        {
            Image Default_Image = giulias_inventory_system.Properties.Resources.original_clients;
            byte[] arr;

            var ms = new MemoryStream();

            if (ImageFormat.Jpeg.Equals(Default_Image.RawFormat))
            {
                Default_Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else if (ImageFormat.Png.Equals(Default_Image.RawFormat))
            {

                Default_Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            }
            else if (ImageFormat.Gif.Equals(Default_Image.RawFormat))
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

        private void get_newly_added_client(){
            try
            {
                sc.OpenConnection();
                // query to save to database
                sc.command = sc.SQLCommand("SELECT clientID from clients ORDER BY clientID DESC LIMIT 1");
                read = sc.command.ExecuteReader();

                while (read.Read())
                {
                    currently_added_client_id = Convert.ToInt32(read["clientID"]);
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

        private void insert_into_history(bool add_or_update )
        {
            string note = "";
            try
            {
                if (add_or_update == true)
                {
                    note = "Added a new client.";
                }else
                {
                    note = "Updated Client Information.";
                }
           
                sc.OpenConnection();
                // query to save to database
                sc.command = sc.SQLCommand("INSERT INTO history (date_modified, clientID, userID, note) VALUES (@date_modified, @client_id, @user_id, @note) ");
                sc.command.Parameters.Add("@user_id", MySqlDbType.Int32).Value = user_id; // change if naa na userid
                if (add_or_update == true)
                {
                    sc.command.Parameters.Add("@client_id", MySqlDbType.Int32).Value = currently_added_client_id;
                }else
                {
                    sc.command.Parameters.Add("@client_id", MySqlDbType.Int32).Value = clientID;
                }
                sc.command.Parameters.Add("@date_modified", MySqlDbType.String).Value = date_today;
                sc.command.Parameters.Add("@note", MySqlDbType.Text).Value = note;
                sc.command.ExecuteNonQuery();
                sc.CloseConnection();
                sc.command.Parameters.Clear();
                if (add_or_update == true)
                {
                    MessageBox.Show("Successfully added a new Client.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Successfully modified Client Information.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                note = "Set Client status to ACTIVE";
            }
            else
            {
                note = "Set Client status to INACTIVE";
            }

            try
            {
                sc.OpenConnection();
                sc.command = sc.SQLCommand("INSERT INTO history (date_modified, clientID, userID, note) VALUES (@date_modified, @client_id, @user_id, @note) ");
                sc.command.Parameters.Add("@user_id", MySqlDbType.Int32).Value = user_id; // change if naa na userid
                sc.command.Parameters.Add("@client_id", MySqlDbType.Int32).Value = clientID;
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
                MessageBox.Show("Successfully set Client status to ACTIVE", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Successfully set Client status to INACTIVE", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region "events"

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            add_or_update = false;
            client_name = txtClient.Text;
            convertPictureBox(add_or_update);

        }

        private void dgvClientClassification_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string client_desc = "";

            /**
               04-18-18 11:26 pm Added by Kwen Isidro 

               This method is triggered when the user clicks any cell in the results dgv
           */


            // manipulating the selected datagridview
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvClientClassification.Rows[e.RowIndex];
                int rowindex = dgvClientClassification.CurrentCell.RowIndex;
                int columnindex = dgvClientClassification.CurrentCell.ColumnIndex;

                try
                {
                    // getting the values of dgvresult;
                    client_desc = dgvClientClassification.Rows[rowindex].Cells[1].Value.ToString();
                    string client_name_class = dgvClientClassification.Rows[rowindex].Cells[0].Value.ToString();
                    if (client_name_class == "Renter")
                    {
                        client_classification_id = 1;
                    }
                    else if (client_name_class == "Shareholder")
                    {
                        client_classification_id = 2;
                    }
                }
                catch (Exception)
                {

                }

                // assigning the values to the respective placements

                // textbox
                txtClientDescription.Text = client_desc;
            }

        }

        private void dgvProducts_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnAddProduct.Enabled = false;
            btnUpdateProduct.Enabled = true;

            // manipulating the selected datagridview
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvProducts.Rows[e.RowIndex];
                int rowindex = dgvProducts.CurrentCell.RowIndex;
                int columnindex = dgvProducts.CurrentCell.ColumnIndex;

                try
                {
                    // getting the values of dgvresult;
                    product_id = Convert.ToInt32(dgvProducts.Rows[rowindex].Cells[0].Value.ToString());
                }
                catch (Exception)
                {
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /**
             04-19-18 7:38 pm Added by Kwen Isidro 

                Set Active Inactive
            */
 
            if (clientID>0)
            {
                int active_checker = 0;

                if (button3.Text == "SET CLIENT AS ACTIVE")
                {
                    active_checker = 1;
                }
                else if (button3.Text == "SET CLIENT AS INACTIVE")
                {
                    active_checker = 0;
                }

                try
                {
                    sc.OpenConnection();
                    sc.command = sc.SQLCommand("UPDATE clients SET active = @active_inactive WHERE clientID = @id");
                    sc.command.Parameters.Add("@id", MySqlDbType.Int32).Value = clientID;
                    sc.command.Parameters.Add("@active_inactive", MySqlDbType.Int32).Value = active_checker;
                    sc.command.ExecuteNonQuery();
                    sc.CloseConnection();
                    sc.command.Parameters.Clear();
                    insert_into_history_active_inactive(active_checker);
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
                ClearAllValues();
            }else
            {
                MessageBox.Show("Please Select a Client first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (radActive.Checked == true)
            {
                frmProducts prod = new frmProducts();
                if (clientID == 0)
                {
                    MessageBox.Show("A product must have an owner. Please choose a CLIENT first then try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    prod.ClientID = clientID;
                    prod.ClientClassificationID = client_classification_id;
                    prod.Show();
                }
            }
            else
            {
                MessageBox.Show("You cannot add a product to an INACTIVE Client", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            add_or_update = true;
            convertPictureBox(add_or_update);

        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            home.getUsername(user_name, user_id, user_priviledge);         //to send data from one place to another
            home.Show();
        }

        private void frmClients_Load(object sender, EventArgs e)
        {
            dTable = new DataTable();
            get_product_details(dTable,1);
            dgvResults.DataSource = dTable;
            Hide_DGV(); // calling Hide_DGV function
            dTable.Dispose();
            setting_client_type();

            
            


            

        }

        private void dgvResults_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /**
                04-18-18 11:26 pm Added by Kwen Isidro 

                This method is triggered when the user clicks any cell in the results dgv
            */

            // setting textfield values to READ ONLY
            //txtClient.ReadOnly = true;
            //txtClientDescription.ReadOnly = true;
            radActiveProducts.Checked = true;
            btnAddProduct.Enabled = true;

            // disable the the addClient button
            btnAddClient.Enabled = false; 

            // enable the editClient button
            btnEditClient.Enabled = true;

            if (radActive.Checked==true)
            {
                button3.Text = "SET CLIENT AS INACTIVE";
            }else
            {
                button3.Text = "SET CLIENT AS ACTIVE";
            }
          

            // manipulating the selected datagridview
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvResults.Rows[e.RowIndex];
                int rowindex = dgvResults.CurrentCell.RowIndex;
                int columnindex = dgvResults.CurrentCell.ColumnIndex;

                try
                {
                    // getting the values of dgvresult;
                    clientID = Convert.ToInt32(dgvResults.Rows[rowindex].Cells[0].Value.ToString());
                    client_name = dgvResults.Rows[rowindex].Cells[1].Value.ToString();
                    client_classification_id = Convert.ToInt32(dgvResults.Rows[rowindex].Cells[4].Value.ToString());
                    date_last_paid = Convert.ToDateTime(dgvResults.Rows[rowindex].Cells[5].Value.ToString());
                    
                }
                catch (Exception)
                {

                }

                // assigning the values to the respective placements

                // textbox
                txtClient.Text = client_name;

                // datetime
                string[] split = date_today.Split('-');
                DateTime due_date = new DateTime(Convert.ToInt16(split[0]), Convert.ToInt16(split[1]), 5, 0, 0, 0);

                if (client_classification_id == 0 || client_classification_id ==1)
                {
                    if (date_last_paid >= due_date)
                    {
                        lblStatus.Text = "PAID";
                        btnPaid.Enabled = false;
                    }
                    else
                    {
                        lblStatus.Text = "NOT PAID";
                        btnPaid.Enabled = true;
                    }

                }else
                {
                    lblStatus.Text = "";
                    btnPaid.Enabled = false;
                }


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
                        pbClientImage.Image = giulias_inventory_system.Properties.Resources.original_clients;
                    }
                }
                catch (Exception)
                {
                    pbClientImage.Image = giulias_inventory_system.Properties.Resources.original_clients;
                }

                // getting the client's client identification

                dTable = new DataTable();
                if (radActive.Checked == true)
                {
                    active_inactive = 1;
                }
                else
                {
                    active_inactive = 0;
                }
                get_client_classification_details(dTable, clientID, active_inactive);
                dgvClientClassification.DataSource = dTable;
                dTable.Dispose();
                dgvClientClassification.Columns["description"].Visible = false;
                dgvClientClassification.ColumnHeadersVisible = false;
                try{
                    DataGridViewRow rows = dgvClientClassification.Rows[0];
                    client_description = rows.Cells[1].Value.ToString();
                }catch (Exception) { }

                txtClientDescription.Text = client_description;


                // getting the list of products of the user
                dTable = new DataTable();
                get_list_of_products(dTable, clientID,1);
                dgvProducts.DataSource = dTable;
                dTable.Dispose();
                dgvProducts.Columns["productID"].Visible = false;
                dgvProducts.Columns["photo"].Visible = false;

               
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog();
            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif)|*.jpg; *.jpeg; *.gif";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                pbClientImage.Image = new Bitmap(open.FileName);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllValues();
        }

        private void frmClients_Activated(object sender, EventArgs e)
        {
            dTable = new DataTable();
            if (radActive.Checked == true)
            {
                active_inactive = 1;
            }
            else
            {
                active_inactive = 0;
            }
            get_product_details(dTable, active_inactive);
            dgvResults.DataSource = dTable;
            dTable.Dispose();
            Hide_DGV(); // calling Hide_DGV function
            ClearAllValues();
        }

        private void radInactive_CheckedChanged(object sender, EventArgs e)
        {
            if (radInactive.Checked == true)
            {
                button3.Text = "SET CLIENT AS ACTIVE";
                ClearAllValues();
                dTable = new DataTable();
                if (radActive.Checked == true)
                {
                    active_inactive = 1;
                }
                else
                {
                    active_inactive = 0;
                }
                get_product_details(dTable, active_inactive);
                dgvResults.DataSource = dTable;
                dTable.Dispose();
                Hide_DGV(); // calling Hide_DGV function
            }
        }

        private void radActive_CheckedChanged(object sender, EventArgs e)
        {
            if (radActive.Checked == true)
            {
                button3.Text = "SET CLIENT AS INACTIVE";
                ClearAllValues();
                dTable = new DataTable();
                if (radActive.Checked == true)
                {
                    active_inactive = 1;
                }
                else
                {
                    active_inactive = 0;
                }
                get_product_details(dTable, active_inactive);
                dgvResults.DataSource = dTable;
                dTable.Dispose();
                Hide_DGV(); // calling Hide_DGV function
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            search_this = txtSearch.Text.ToString();

            ClearAllValues();
            dTable = new DataTable();
            if (radActive.Checked == true)
            {
                active_inactive = 1;
            }
            else
            {
                active_inactive = 0;
            }

            search_items(dTable, active_inactive, search_this);
            dgvResults.DataSource = dTable;
            dTable.Dispose();
            Hide_DGV(); // calling Hide_DGV function
          
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (radActive.Checked==true)
            {
                frmProducts prod = new frmProducts();
                if (radActiveProducts.Checked ==true)
                {
                    prod.ActiveInactive = true;
                }
                else if (radInactiveProducts.Checked == true)
                {
                    prod.ActiveInactive = false;
                }
                prod.ClientID = clientID;
                prod.ProductID = product_id;
                prod.ClientClassificationID = client_classification_id;
                prod.Show(); 
            }
            else
            {
                MessageBox.Show("You cannot update a product to an INACTIVE Client", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        private void radActiveProducts_CheckedChanged(object sender, EventArgs e)
        {
            if (radActiveProducts.Checked == true)
            {
                btnAddProduct.Enabled = true;
                bool checker = true;
                dTable = new DataTable();
                get_products(dTable, checker);
                dgvProducts.DataSource = dTable;
                dTable.Dispose();
             
            }
        }

        private void radInactiveProducts_CheckedChanged(object sender, EventArgs e)
        {
            if (radInactiveProducts.Checked == true)
            {
                btnAddProduct.Enabled = false;
                bool checker = false;
                dTable = new DataTable();
                get_products(dTable, checker);
                dgvProducts.DataSource = dTable;
                dTable.Dispose();

            }
        }


        private void get_products(DataTable dt, bool checker)
        {
            /**
                04-18-18 11:26 pm Added by Kwen Isidro 

                Gets all of the products of the user
                parameters: datatable, id for the client id and activeinactive
            */
            int checkers = 0;

            if (checker == true)
            {
                checkers = 1;
            }

            try
            {
                sc.OpenConnection();
                sc.command = sc.SQLCommand("SELECT p.productID, p.photo, p.name, p.descr, p.qty, p.price FROM products as p WHERE clientID = @client_id AND active = @active_inactive");
                sc.command.Parameters.Add("@client_id", MySqlDbType.Int32).Value = clientID;
                sc.command.Parameters.Add("@active_inactive", MySqlDbType.Int32).Value = checkers;
                sc.sqlReader = sc.command.ExecuteReader();
                dt.Load(sc.sqlReader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                sc.CloseConnection();
            }

        }

        private void btnPaid_Click(object sender, EventArgs e)
        {

            try
            {
                sc.OpenConnection();
                sc.command = sc.SQLCommand("UPDATE clients SET date_last_paid = @date_today WHERE clientID = @client_id");
                sc.command.Parameters.Add("@client_id", MySqlDbType.Int32).Value = clientID;
                sc.command.Parameters.Add("@date_today", MySqlDbType.Date).Value = date_today;
                sc.command.ExecuteNonQuery();
                sc.command.Parameters.Clear();
                MessageBox.Show("Successfully set client status to PAID.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                sc.CloseConnection();
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
