namespace giulias_inventory_system
{
    partial class frmClients
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radActive = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.radInactive = new System.Windows.Forms.RadioButton();
            this.panel12 = new System.Windows.Forms.Panel();
            this.radActiveProducts = new System.Windows.Forms.RadioButton();
            this.radInactiveProducts = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.btnEditClient = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.lblBookTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.coverpanel = new System.Windows.Forms.Panel();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblMatches = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvClientClassification = new System.Windows.Forms.DataGridView();
            this.txtClientDescription = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.pbClientImage = new System.Windows.Forms.PictureBox();
            this.btnPaid = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.coverpanel.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientClassification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClientImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::giulias_inventory_system.Properties.Resources.giulia;
            this.pictureBox1.Location = new System.Drawing.Point(-9, -178);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(315, 565);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 65;
            this.pictureBox1.TabStop = false;
            // 
            // radActive
            // 
            this.radActive.AutoSize = true;
            this.radActive.Checked = true;
            this.radActive.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radActive.ForeColor = System.Drawing.Color.White;
            this.radActive.Location = new System.Drawing.Point(136, 3);
            this.radActive.Name = "radActive";
            this.radActive.Size = new System.Drawing.Size(72, 20);
            this.radActive.TabIndex = 31;
            this.radActive.TabStop = true;
            this.radActive.Text = "ACTIVE";
            this.radActive.UseVisualStyleBackColor = true;
            this.radActive.CheckedChanged += new System.EventHandler(this.radActive_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Search";
            // 
            // radInactive
            // 
            this.radInactive.AutoSize = true;
            this.radInactive.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radInactive.ForeColor = System.Drawing.Color.White;
            this.radInactive.Location = new System.Drawing.Point(212, 3);
            this.radInactive.Name = "radInactive";
            this.radInactive.Size = new System.Drawing.Size(86, 20);
            this.radInactive.TabIndex = 32;
            this.radInactive.Text = "INACTIVE";
            this.radInactive.UseVisualStyleBackColor = true;
            this.radInactive.CheckedChanged += new System.EventHandler(this.radInactive_CheckedChanged);
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Crimson;
            this.panel12.Controls.Add(this.radActive);
            this.panel12.Controls.Add(this.label1);
            this.panel12.Controls.Add(this.radInactive);
            this.panel12.Location = new System.Drawing.Point(2, 225);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(304, 26);
            this.panel12.TabIndex = 61;
            // 
            // radActiveProducts
            // 
            this.radActiveProducts.AutoSize = true;
            this.radActiveProducts.Checked = true;
            this.radActiveProducts.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radActiveProducts.ForeColor = System.Drawing.Color.White;
            this.radActiveProducts.Location = new System.Drawing.Point(423, 2);
            this.radActiveProducts.Name = "radActiveProducts";
            this.radActiveProducts.Size = new System.Drawing.Size(72, 20);
            this.radActiveProducts.TabIndex = 33;
            this.radActiveProducts.TabStop = true;
            this.radActiveProducts.Text = "ACTIVE";
            this.radActiveProducts.UseVisualStyleBackColor = true;
            this.radActiveProducts.CheckedChanged += new System.EventHandler(this.radActiveProducts_CheckedChanged);
            // 
            // radInactiveProducts
            // 
            this.radInactiveProducts.AutoSize = true;
            this.radInactiveProducts.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radInactiveProducts.ForeColor = System.Drawing.Color.White;
            this.radInactiveProducts.Location = new System.Drawing.Point(501, 2);
            this.radInactiveProducts.Name = "radInactiveProducts";
            this.radInactiveProducts.Size = new System.Drawing.Size(86, 20);
            this.radInactiveProducts.TabIndex = 34;
            this.radInactiveProducts.Text = "INACTIVE";
            this.radInactiveProducts.UseVisualStyleBackColor = true;
            this.radInactiveProducts.CheckedChanged += new System.EventHandler(this.radInactiveProducts_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(6, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Products";
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AllowUserToResizeColumns = false;
            this.dgvResults.AllowUserToResizeRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.BackgroundColor = System.Drawing.Color.White;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.LightPink;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Pink;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResults.DefaultCellStyle = dataGridViewCellStyle19;
            this.dgvResults.GridColor = System.Drawing.Color.LightPink;
            this.dgvResults.Location = new System.Drawing.Point(3, 318);
            this.dgvResults.MultiSelect = false;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersVisible = false;
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.Crimson;
            this.dgvResults.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(303, 278);
            this.dgvResults.TabIndex = 60;
            this.dgvResults.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvResults_CellMouseClick);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Crimson;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(18, 557);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(185, 36);
            this.button3.TabIndex = 73;
            this.button3.Text = "SET CLIENT AS INACTIVE";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnEditClient
            // 
            this.btnEditClient.BackColor = System.Drawing.Color.Crimson;
            this.btnEditClient.Enabled = false;
            this.btnEditClient.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditClient.ForeColor = System.Drawing.Color.White;
            this.btnEditClient.Location = new System.Drawing.Point(451, 212);
            this.btnEditClient.Name = "btnEditClient";
            this.btnEditClient.Size = new System.Drawing.Size(164, 36);
            this.btnEditClient.TabIndex = 72;
            this.btnEditClient.Text = "UPDATE CLIENT";
            this.btnEditClient.UseVisualStyleBackColor = false;
            this.btnEditClient.Click += new System.EventHandler(this.btnEditClient_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Crimson;
            this.btnClear.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(428, 557);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(185, 36);
            this.btnClear.TabIndex = 71;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Crimson;
            this.panel3.Controls.Add(this.btnUpdateProduct);
            this.panel3.Controls.Add(this.btnAddProduct);
            this.panel3.Controls.Add(this.radActiveProducts);
            this.panel3.Controls.Add(this.radInactiveProducts);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(18, 265);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(595, 26);
            this.panel3.TabIndex = 70;
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.BackColor = System.Drawing.Color.Crimson;
            this.btnUpdateProduct.Enabled = false;
            this.btnUpdateProduct.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateProduct.ForeColor = System.Drawing.Color.White;
            this.btnUpdateProduct.Location = new System.Drawing.Point(169, -4);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(71, 36);
            this.btnUpdateProduct.TabIndex = 110;
            this.btnUpdateProduct.Text = "UPDATE";
            this.btnUpdateProduct.UseVisualStyleBackColor = false;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackColor = System.Drawing.Color.Crimson;
            this.btnAddProduct.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProduct.ForeColor = System.Drawing.Color.White;
            this.btnAddProduct.Location = new System.Drawing.Point(112, -4);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(62, 36);
            this.btnAddProduct.TabIndex = 109;
            this.btnAddProduct.Text = "ADD";
            this.btnAddProduct.UseVisualStyleBackColor = false;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.Crimson;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.lblStatus);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.btnPaid);
            this.panel6.Controls.Add(this.label26);
            this.panel6.Controls.Add(this.lblBookTitle);
            this.panel6.Location = new System.Drawing.Point(305, 1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(626, 38);
            this.panel6.TabIndex = 51;
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.YellowGreen;
            this.label26.Location = new System.Drawing.Point(3, 5);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(0, 25);
            this.label26.TabIndex = 94;
            this.label26.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblBookTitle
            // 
            this.lblBookTitle.AutoSize = true;
            this.lblBookTitle.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookTitle.ForeColor = System.Drawing.Color.White;
            this.lblBookTitle.Location = new System.Drawing.Point(-11, 6);
            this.lblBookTitle.Name = "lblBookTitle";
            this.lblBookTitle.Size = new System.Drawing.Size(0, 23);
            this.lblBookTitle.TabIndex = 35;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepPink;
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.coverpanel);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Controls.Add(this.dgvResults);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-5, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(937, 596);
            this.panel1.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.LimeGreen;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(188, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(115, 40);
            this.btnBack.TabIndex = 74;
            this.btnBack.Text = "go back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // coverpanel
            // 
            this.coverpanel.BackColor = System.Drawing.Color.Crimson;
            this.coverpanel.Controls.Add(this.lblResult);
            this.coverpanel.Controls.Add(this.lblMatches);
            this.coverpanel.Controls.Add(this.label16);
            this.coverpanel.Location = new System.Drawing.Point(2, 298);
            this.coverpanel.Name = "coverpanel";
            this.coverpanel.Size = new System.Drawing.Size(304, 20);
            this.coverpanel.TabIndex = 56;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.Transparent;
            this.lblResult.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.White;
            this.lblResult.Location = new System.Drawing.Point(74, 2);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(142, 17);
            this.lblResult.TabIndex = 33;
            this.lblResult.Text = "No match(es) found.";
            // 
            // lblMatches
            // 
            this.lblMatches.AutoSize = true;
            this.lblMatches.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatches.ForeColor = System.Drawing.Color.White;
            this.lblMatches.Location = new System.Drawing.Point(107, 1);
            this.lblMatches.Name = "lblMatches";
            this.lblMatches.Size = new System.Drawing.Size(0, 16);
            this.lblMatches.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(9, 1);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 16);
            this.label16.TabIndex = 0;
            this.label16.Text = "RESULTS:";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.LightCoral;
            this.panel8.Controls.Add(this.txtSearch);
            this.panel8.Controls.Add(this.btnSearch);
            this.panel8.Location = new System.Drawing.Point(0, 251);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(306, 49);
            this.panel8.TabIndex = 52;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.DeepPink;
            this.txtSearch.Location = new System.Drawing.Point(4, 13);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(242, 23);
            this.txtSearch.TabIndex = 25;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Crimson;
            this.btnSearch.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(252, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(49, 35);
            this.btnSearch.TabIndex = 24;
            this.btnSearch.Text = "GO";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.dgvClientClassification);
            this.panel2.Controls.Add(this.txtClientDescription);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.btnEditClient);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dgvProducts);
            this.panel2.Controls.Add(this.btnAddClient);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtClient);
            this.panel2.Controls.Add(this.btnUpload);
            this.panel2.Controls.Add(this.pbClientImage);
            this.panel2.Location = new System.Drawing.Point(305, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(629, 617);
            this.panel2.TabIndex = 62;
            // 
            // dgvClientClassification
            // 
            this.dgvClientClassification.AllowUserToAddRows = false;
            this.dgvClientClassification.AllowUserToDeleteRows = false;
            this.dgvClientClassification.AllowUserToResizeColumns = false;
            this.dgvClientClassification.AllowUserToResizeRows = false;
            this.dgvClientClassification.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientClassification.BackgroundColor = System.Drawing.Color.White;
            this.dgvClientClassification.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.LightPink;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Pink;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClientClassification.DefaultCellStyle = dataGridViewCellStyle21;
            this.dgvClientClassification.GridColor = System.Drawing.Color.LightPink;
            this.dgvClientClassification.Location = new System.Drawing.Point(301, 81);
            this.dgvClientClassification.MultiSelect = false;
            this.dgvClientClassification.Name = "dgvClientClassification";
            this.dgvClientClassification.ReadOnly = true;
            this.dgvClientClassification.RowHeadersVisible = false;
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.Crimson;
            this.dgvClientClassification.RowsDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvClientClassification.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientClassification.Size = new System.Drawing.Size(312, 51);
            this.dgvClientClassification.TabIndex = 108;
            this.dgvClientClassification.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvClientClassification_CellMouseClick);
            // 
            // txtClientDescription
            // 
            this.txtClientDescription.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientDescription.ForeColor = System.Drawing.Color.DeepPink;
            this.txtClientDescription.Location = new System.Drawing.Point(189, 157);
            this.txtClientDescription.Name = "txtClientDescription";
            this.txtClientDescription.ReadOnly = true;
            this.txtClientDescription.Size = new System.Drawing.Size(235, 87);
            this.txtClientDescription.TabIndex = 107;
            this.txtClientDescription.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Crimson;
            this.label5.Location = new System.Drawing.Point(185, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 19);
            this.label5.TabIndex = 75;
            this.label5.Text = "Client Description:";
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AllowUserToResizeRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.LightPink;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.Pink;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProducts.DefaultCellStyle = dataGridViewCellStyle23;
            this.dgvProducts.GridColor = System.Drawing.Color.LightPink;
            this.dgvProducts.Location = new System.Drawing.Point(18, 293);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.Crimson;
            this.dgvProducts.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.dgvProducts.RowTemplate.Height = 50;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(595, 262);
            this.dgvProducts.TabIndex = 69;
            this.dgvProducts.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProducts_CellMouseClick);
            // 
            // btnAddClient
            // 
            this.btnAddClient.BackColor = System.Drawing.Color.Crimson;
            this.btnAddClient.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddClient.ForeColor = System.Drawing.Color.White;
            this.btnAddClient.Location = new System.Drawing.Point(451, 169);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(164, 36);
            this.btnAddClient.TabIndex = 68;
            this.btnAddClient.Text = "ADD CLIENT";
            this.btnAddClient.UseVisualStyleBackColor = false;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(184, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 19);
            this.label3.TabIndex = 36;
            this.label3.Text = "Client Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(185, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 19);
            this.label2.TabIndex = 33;
            this.label2.Text = "Client Name:";
            // 
            // txtClient
            // 
            this.txtClient.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClient.ForeColor = System.Drawing.Color.DeepPink;
            this.txtClient.Location = new System.Drawing.Point(301, 50);
            this.txtClient.Name = "txtClient";
            this.txtClient.Size = new System.Drawing.Size(312, 27);
            this.txtClient.TabIndex = 35;
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.Crimson;
            this.btnUpload.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.ForeColor = System.Drawing.Color.White;
            this.btnUpload.Location = new System.Drawing.Point(18, 211);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(150, 33);
            this.btnUpload.TabIndex = 34;
            this.btnUpload.Text = "Upload Photo";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // pbClientImage
            // 
            this.pbClientImage.Image = global::giulias_inventory_system.Properties.Resources.original_clients;
            this.pbClientImage.Location = new System.Drawing.Point(18, 55);
            this.pbClientImage.Name = "pbClientImage";
            this.pbClientImage.Size = new System.Drawing.Size(150, 150);
            this.pbClientImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbClientImage.TabIndex = 0;
            this.pbClientImage.TabStop = false;
            // 
            // btnPaid
            // 
            this.btnPaid.BackColor = System.Drawing.Color.LimeGreen;
            this.btnPaid.Enabled = false;
            this.btnPaid.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaid.ForeColor = System.Drawing.Color.White;
            this.btnPaid.Location = new System.Drawing.Point(357, -3);
            this.btnPaid.Name = "btnPaid";
            this.btnPaid.Size = new System.Drawing.Size(156, 40);
            this.btnPaid.TabIndex = 109;
            this.btnPaid.Text = "SET CLIENT AS PAID";
            this.btnPaid.UseVisualStyleBackColor = false;
            this.btnPaid.Click += new System.EventHandler(this.btnPaid_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(23, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 19);
            this.label6.TabIndex = 110;
            this.label6.Text = "CLIENT STATUS:  ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Goudy Stout", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(150, 6);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 28);
            this.lblStatus.TabIndex = 111;
            // 
            // frmClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 597);
            this.Controls.Add(this.panel1);
            this.Name = "frmClients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmClients";
            this.Activated += new System.EventHandler(this.frmClients_Activated);
            this.Load += new System.EventHandler(this.frmClients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.coverpanel.ResumeLayout(false);
            this.coverpanel.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientClassification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClientImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton radActive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radInactive;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.RadioButton radActiveProducts;
        private System.Windows.Forms.RadioButton radInactiveProducts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnEditClient;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblBookTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel coverpanel;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblMatches;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.PictureBox pbClientImage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtClientDescription;
        private System.Windows.Forms.DataGridView dgvClientClassification;
        private System.Windows.Forms.Button btnUpdateProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPaid;
        private System.Windows.Forms.Label lblStatus;
    }
}