namespace wfxmlrpc
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.loginTab = new System.Windows.Forms.TabPage();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.radioRest = new System.Windows.Forms.RadioButton();
            this.radioSoap = new System.Windows.Forms.RadioButton();
            this.radioXMLRPC = new System.Windows.Forms.RadioButton();
            this.loginBtn = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.shopTab = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.shopcartTab = new System.Windows.Forms.TabPage();
            this.buttonBuyAll = new System.Windows.Forms.Button();
            this.labeltotalCost = new System.Windows.Forms.Label();
            this.labelTotalCount = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.column_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.advanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.labelBalance = new System.Windows.Forms.Label();
            this.labelPleaseWait = new System.Windows.Forms.Label();
            this.pictureBoxLoader = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.loginTab.SuspendLayout();
            this.shopTab.SuspendLayout();
            this.shopcartTab.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.loginTab);
            this.tabControl1.Controls.Add(this.shopTab);
            this.tabControl1.Controls.Add(this.shopcartTab);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(995, 433);
            this.tabControl1.TabIndex = 0;
            // 
            // loginTab
            // 
            this.loginTab.Controls.Add(this.logoutBtn);
            this.loginTab.Controls.Add(this.label3);
            this.loginTab.Controls.Add(this.radioRest);
            this.loginTab.Controls.Add(this.radioSoap);
            this.loginTab.Controls.Add(this.radioXMLRPC);
            this.loginTab.Controls.Add(this.loginBtn);
            this.loginTab.Controls.Add(this.textBox2);
            this.loginTab.Controls.Add(this.textBox1);
            this.loginTab.Controls.Add(this.label2);
            this.loginTab.Controls.Add(this.label1);
            this.loginTab.Location = new System.Drawing.Point(4, 22);
            this.loginTab.Name = "loginTab";
            this.loginTab.Padding = new System.Windows.Forms.Padding(3);
            this.loginTab.Size = new System.Drawing.Size(987, 407);
            this.loginTab.TabIndex = 0;
            this.loginTab.Text = "Login";
            this.loginTab.UseVisualStyleBackColor = true;
            // 
            // logoutBtn
            // 
            this.logoutBtn.Location = new System.Drawing.Point(903, 6);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(75, 23);
            this.logoutBtn.TabIndex = 5;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Visible = false;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(309, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(349, 42);
            this.label3.TabIndex = 4;
            this.label3.Text = "Добро пожаловать";
            this.label3.Visible = false;
            // 
            // radioRest
            // 
            this.radioRest.AutoSize = true;
            this.radioRest.Location = new System.Drawing.Point(8, 52);
            this.radioRest.Name = "radioRest";
            this.radioRest.Size = new System.Drawing.Size(54, 17);
            this.radioRest.TabIndex = 3;
            this.radioRest.TabStop = true;
            this.radioRest.Text = "REST";
            this.radioRest.UseVisualStyleBackColor = true;
            // 
            // radioSoap
            // 
            this.radioSoap.AutoSize = true;
            this.radioSoap.Location = new System.Drawing.Point(8, 29);
            this.radioSoap.Name = "radioSoap";
            this.radioSoap.Size = new System.Drawing.Size(54, 17);
            this.radioSoap.TabIndex = 3;
            this.radioSoap.TabStop = true;
            this.radioSoap.Text = "SOAP";
            this.radioSoap.UseVisualStyleBackColor = true;
            // 
            // radioXMLRPC
            // 
            this.radioXMLRPC.AutoSize = true;
            this.radioXMLRPC.Checked = true;
            this.radioXMLRPC.Location = new System.Drawing.Point(8, 6);
            this.radioXMLRPC.Name = "radioXMLRPC";
            this.radioXMLRPC.Size = new System.Drawing.Size(72, 17);
            this.radioXMLRPC.TabIndex = 3;
            this.radioXMLRPC.TabStop = true;
            this.radioXMLRPC.Text = "XML-RPC";
            this.radioXMLRPC.UseVisualStyleBackColor = true;
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(388, 250);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(197, 23);
            this.loginBtn.TabIndex = 3;
            this.loginBtn.Text = "Submit";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(388, 204);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(197, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(388, 154);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(197, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(458, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(467, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // shopTab
            // 
            this.shopTab.Controls.Add(this.listBox1);
            this.shopTab.Location = new System.Drawing.Point(4, 22);
            this.shopTab.Name = "shopTab";
            this.shopTab.Padding = new System.Windows.Forms.Padding(3);
            this.shopTab.Size = new System.Drawing.Size(987, 407);
            this.shopTab.TabIndex = 1;
            this.shopTab.Text = "Catalog";
            this.shopTab.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(8, 6);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(973, 433);
            this.listBox1.TabIndex = 0;
            this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
            // 
            // shopcartTab
            // 
            this.shopcartTab.Controls.Add(this.buttonBuyAll);
            this.shopcartTab.Controls.Add(this.labeltotalCost);
            this.shopcartTab.Controls.Add(this.labelTotalCount);
            this.shopcartTab.Controls.Add(this.listView1);
            this.shopcartTab.Location = new System.Drawing.Point(4, 22);
            this.shopcartTab.Name = "shopcartTab";
            this.shopcartTab.Size = new System.Drawing.Size(987, 407);
            this.shopcartTab.TabIndex = 2;
            this.shopcartTab.Text = "ShopCart";
            this.shopcartTab.UseVisualStyleBackColor = true;
            // 
            // buttonBuyAll
            // 
            this.buttonBuyAll.Location = new System.Drawing.Point(779, 317);
            this.buttonBuyAll.Name = "buttonBuyAll";
            this.buttonBuyAll.Size = new System.Drawing.Size(199, 46);
            this.buttonBuyAll.TabIndex = 3;
            this.buttonBuyAll.Text = "Оплатить";
            this.buttonBuyAll.UseVisualStyleBackColor = true;
            this.buttonBuyAll.Click += new System.EventHandler(this.buttonBuyAll_Click);
            // 
            // labeltotalCost
            // 
            this.labeltotalCost.AutoSize = true;
            this.labeltotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labeltotalCost.Location = new System.Drawing.Point(8, 343);
            this.labeltotalCost.Name = "labeltotalCost";
            this.labeltotalCost.Size = new System.Drawing.Size(51, 20);
            this.labeltotalCost.TabIndex = 2;
            this.labeltotalCost.Text = "label5";
            // 
            // labelTotalCount
            // 
            this.labelTotalCount.AutoSize = true;
            this.labelTotalCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTotalCount.Location = new System.Drawing.Point(8, 314);
            this.labelTotalCount.Name = "labelTotalCount";
            this.labelTotalCount.Size = new System.Drawing.Size(51, 20);
            this.labelTotalCount.TabIndex = 1;
            this.labelTotalCount.Text = "label4";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_name,
            this.column_price});
            this.listView1.Location = new System.Drawing.Point(8, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(970, 308);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // column_name
            // 
            this.column_name.Text = "Name";
            this.column_name.Width = 200;
            // 
            // column_price
            // 
            this.column_price.Text = "Price";
            this.column_price.Width = 200;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.advanceToolStripMenuItem,
            this.buyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 48);
            // 
            // advanceToolStripMenuItem
            // 
            this.advanceToolStripMenuItem.Name = "advanceToolStripMenuItem";
            this.advanceToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.advanceToolStripMenuItem.Text = "Подробнее";
            this.advanceToolStripMenuItem.Click += new System.EventHandler(this.advanceToolStripMenuItem_Click);
            // 
            // buyToolStripMenuItem
            // 
            this.buyToolStripMenuItem.Name = "buyToolStripMenuItem";
            this.buyToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.buyToolStripMenuItem.Text = "Купить";
            this.buyToolStripMenuItem.Click += new System.EventHandler(this.buyToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // labelBalance
            // 
            this.labelBalance.AutoSize = true;
            this.labelBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBalance.Location = new System.Drawing.Point(13, 439);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(51, 20);
            this.labelBalance.TabIndex = 1;
            this.labelBalance.Text = "label4";
            // 
            // labelPleaseWait
            // 
            this.labelPleaseWait.AutoSize = true;
            this.labelPleaseWait.Location = new System.Drawing.Point(839, 439);
            this.labelPleaseWait.Name = "labelPleaseWait";
            this.labelPleaseWait.Size = new System.Drawing.Size(117, 13);
            this.labelPleaseWait.TabIndex = 2;
            this.labelPleaseWait.Text = "Операция в процессе";
            this.labelPleaseWait.Visible = false;
            // 
            // pictureBoxLoader
            // 
            this.pictureBoxLoader.Image = global::wfxmlrpc.Properties.Resources.ajax_loader;
            this.pictureBoxLoader.Location = new System.Drawing.Point(962, 439);
            this.pictureBoxLoader.Name = "pictureBoxLoader";
            this.pictureBoxLoader.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxLoader.TabIndex = 6;
            this.pictureBoxLoader.TabStop = false;
            this.pictureBoxLoader.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 470);
            this.Controls.Add(this.pictureBoxLoader);
            this.Controls.Add(this.labelPleaseWait);
            this.Controls.Add(this.labelBalance);
            this.Controls.Add(this.tabControl1);
            this.MaximumSize = new System.Drawing.Size(1010, 509);
            this.MinimumSize = new System.Drawing.Size(1010, 509);
            this.Name = "Form1";
            this.Text = "internetSHOP";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.loginTab.ResumeLayout(false);
            this.loginTab.PerformLayout();
            this.shopTab.ResumeLayout(false);
            this.shopcartTab.ResumeLayout(false);
            this.shopcartTab.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage loginTab;
        private System.Windows.Forms.TabPage shopTab;
        private System.Windows.Forms.TabPage shopcartTab;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.RadioButton radioRest;
        public System.Windows.Forms.RadioButton radioSoap;
        public System.Windows.Forms.RadioButton radioXMLRPC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem advanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buyToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader column_name;
        private System.Windows.Forms.ColumnHeader column_price;
        private System.Windows.Forms.Label labeltotalCost;
        private System.Windows.Forms.Label labelTotalCount;
        private System.Windows.Forms.Button buttonBuyAll;
        private System.Windows.Forms.Label labelBalance;
        private System.Windows.Forms.Label labelPleaseWait;
        private System.Windows.Forms.PictureBox pictureBoxLoader;
    }
}

