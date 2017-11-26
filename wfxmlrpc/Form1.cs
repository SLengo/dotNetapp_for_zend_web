using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

using System.Web.Script.Serialization;

using Newtonsoft.Json;


namespace wfxmlrpc
{
    public partial class Form1 : Form
    {
        
        public String token = "";
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        String _selectedMenuItem = "";
        double balance = 0;

        public wfxmlrpc.Protocols.XmlRpcWebShop xmlRpcObj = null;
        public wfxmlrpc.Protocols.SoapWebShop soapObj = null;
        public wfxmlrpc.Protocols.RestWebShop restObj = null;
        public wfxmlrpc.Ini ini = null;

        public Form1()
        {
            InitializeComponent();

            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            labelBalance.Text = "";
            labeltotalCost.Text = "";
            labelTotalCount.Text = "";

            ini = new wfxmlrpc.Ini(AppDomain.CurrentDomain.BaseDirectory + "\\Ini.ini");



            xmlRpcObj = new Protocols.XmlRpcWebShop(ini.IniReadValue("Info", "Url") + ini.IniReadValue("Info", "UriXmlRpc"), "greeter");
            soapObj = new Protocols.SoapWebShop(ini.IniReadValue("Info", "Url") + ini.IniReadValue("Info", "UriSoap"));
            restObj = new Protocols.RestWebShop(ini.IniReadValue("Info", "Url") + ini.IniReadValue("Info", "UriRest"));

        }


        public void showLoader()
        {
            pictureBoxLoader.Visible = true;
            labelPleaseWait.Visible = true;
        }

        public void hideLoader()
        {
            pictureBoxLoader.Visible = false;
            labelPleaseWait.Visible = false;
        }

        public string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }


        public async void showShopCart()
        {
            listView1.Items.Clear();

            String responseStr = "";
            string action = "getShopCart";
            KeyValuePair<String, object> param1 = new KeyValuePair<String, object>("token", token);
            KeyValuePair<String, object>[] arr = new KeyValuePair<string, object>[] { param1 };
            if (radioXMLRPC.Checked)
            {
                showLoader();
                await Task.Run(() => responseStr = xmlRpcObj.getResponse(action, arr));
                hideLoader();
            }
            else if (radioSoap.Checked) {
                responseStr = soapObj.soapClientRequest(arr, action);
            }
            else if (radioRest.Checked) {

                responseStr = restObj.restRequest(action, arr);

            }
            if (radioXMLRPC.Checked || radioRest.Checked || radioSoap.Checked)
            {
                double allGoodsCount = 0;
                double allGoodsCost = 0;
                dynamic stuff = JsonConvert.DeserializeObject(responseStr);
                foreach (var item in stuff)
                {
                    
                            foreach (var item1 in item)
                        {
                            string good_id = item1.good;
                            responseStr = "";
                            string action_1 = "getGood";
                            KeyValuePair<String, object> param1_1 = new KeyValuePair<String, object>("token", token);
                        KeyValuePair<String, object> param2_1 = new KeyValuePair<String, object>("good", good_id);
                        KeyValuePair<String, object>[] arr_1 = new KeyValuePair<string, object>[] { param1_1, param2_1 };
                        if (radioXMLRPC.Checked)
                        {
                            await Task.Run(() => responseStr = xmlRpcObj.getResponse(action_1, arr_1));
                        }
                        else if (radioSoap.Checked)
                        {
                            responseStr = soapObj.soapClientRequest(arr_1, action_1);
                        }
                        else if (radioRest.Checked)
                        {
                            responseStr = restObj.restRequest(action_1, arr_1);
                        }
                        dynamic stuff_good = JsonConvert.DeserializeObject(responseStr);
                        if (stuff_good.state != null && stuff_good.state == "FAIL")
                        {
                            String m = stuff_good.message;
                                MessageBox.Show(m, "InternetSHOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                String name = stuff_good.name;
                                String price = stuff_good.price;
                                allGoodsCost += Double.Parse(price);
                                allGoodsCount++;
                                string[] row = { name, price };
                                var listViewItem = new ListViewItem(row);
                                listView1.Items.Add(listViewItem);
                            }
                        }
                    }
                
                labeltotalCost.Text = "Общая стоимость: " + Convert.ToString(allGoodsCost);
                labelTotalCount.Text = "Всего товаров: " + Convert.ToString(allGoodsCount);
            }
        }

        public async void getShopList()
        {
            String responseStr = "";
            string action = "getAllGoods";
            KeyValuePair<String, object> param1 = new KeyValuePair<String, object>("token", token);
            KeyValuePair<String, object>[] arr = new KeyValuePair<string, object>[] { param1 };
            if (radioXMLRPC.Checked)
            {
                showLoader();
                await Task.Run(() => responseStr = xmlRpcObj.getResponse(action, arr));
                hideLoader();
            }
            else if (radioSoap.Checked)
            {
                responseStr = soapObj.soapClientRequest(arr, action);
            }
            else if (radioRest.Checked)
            {

                responseStr = restObj.restRequest(action, arr);

            }
            if (radioXMLRPC.Checked || radioRest.Checked || radioSoap.Checked)
            {
                dynamic stuff = JsonConvert.DeserializeObject(responseStr);
                foreach (var item in stuff)
                {
                    foreach (var item1 in item)
                    {
                        listBox1.Items.Add(item1.id+"@"+item1.name);
                    }
                }
            }
        }


        private async void loginBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {

                String responseStr = "";
                MD5 md5_hash = MD5.Create();

                KeyValuePair<String, object> param1 = new KeyValuePair<String, object>("login", textBox1.Text);
                KeyValuePair<String, object> param2 = new KeyValuePair<String, object>("password_md5", GetMd5Hash(md5_hash, textBox2.Text));
                KeyValuePair<String, object>[] arr = new KeyValuePair<string, object>[] { param1, param2 };

                String action = "getToken";

                if (radioXMLRPC.Checked)
                {
                    showLoader();
                    await Task.Run(() => responseStr = xmlRpcObj.getResponse(action, arr));
                    hideLoader();
                }
                else if (radioSoap.Checked) {
                    responseStr = soapObj.soapClientRequest(arr, action);
                }
                else if (radioRest.Checked) {

                    responseStr = restObj.restRequest(action, arr);

                }

                if (radioXMLRPC.Checked || radioRest.Checked || radioSoap.Checked)
                {
                    dynamic stuff = JsonConvert.DeserializeObject(responseStr);

                    if (stuff.state == "OK")
                    {
                        token = stuff.token;
                        labelBalance.Text = "Ваш баланс: " + stuff.balance + " rub";
                        String balanceStr = stuff.balance;
                        balance = Double.Parse(balanceStr);
                        textBox1.Visible = false;
                        textBox2.Visible = false;
                        label1.Visible = false;
                        label2.Visible = false;
                        loginBtn.Visible = false;

                        logoutBtn.Visible = true;
                        label3.Visible = true;

                        getShopList();
                    }
                    else if (stuff.state == "FAIL")
                    {
                        String m = stuff.message;
                        MessageBox.Show(m, "InternetSHOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else {
                    MessageBox.Show("Выбери протокол", "InternetSHOP", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else {
                MessageBox.Show("Введите логин и пароль", "InternetSHOP",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            logout();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            logout();
            labeltotalCost.Text = "";
            labelTotalCount.Text = "";
            labelBalance.Text = "";
            listView1.Items.Clear();
        }

        public async void logout()
        {
            if (token != "")
            {
                String responseStr = "";
                string action = "destroyToken";
                KeyValuePair<String, object> param1 = new KeyValuePair<String, object>("token", token);
                KeyValuePair<String, object>[] arr = new KeyValuePair<string, object>[] { param1 };
                if (radioXMLRPC.Checked)
                {
                    showLoader();
                    await Task.Run(() => responseStr = xmlRpcObj.getResponse(action, arr));
                    hideLoader();
                }
                else if (radioSoap.Checked) {
                    responseStr = soapObj.soapClientRequest(arr, action);
                }
                else if (radioRest.Checked) {
                    responseStr = restObj.restRequest(action, arr);
                }
                if (radioXMLRPC.Checked || radioRest.Checked || radioSoap.Checked)
                {
                    dynamic stuff = JsonConvert.DeserializeObject(responseStr);
                    if (stuff.state == "OK")
                    {
                        token = stuff.token;
                        textBox1.Visible = true;
                        textBox2.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        loginBtn.Visible = true;

                        logoutBtn.Visible = false;
                        label3.Visible = false;

                        listBox1.Items.Clear();

                        token = "";
                    }
                    else if (stuff.state == "FAIL")
                    {
                        MessageBox.Show(stuff.message, "InternetSHOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var index = listBox1.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                _selectedMenuItem = listBox1.Items[index].ToString();
                contextMenuStrip1.Show(Cursor.Position);
                contextMenuStrip1.Visible = true;
            }
            else
            {
                contextMenuStrip1.Visible = false;
            }
        }

        private async void buyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String responseStr = "";
            string action = "addToShopCart";
            string good = _selectedMenuItem.Split('@')[0];
            KeyValuePair<String, object> param1 = new KeyValuePair<String, object>("token", token);
            KeyValuePair<String, object> param2 = new KeyValuePair<String, object>("good_id", good);
            KeyValuePair<String, object>[] arr = new KeyValuePair<string, object>[] { param1, param2 };
            if (radioXMLRPC.Checked)
            {
                showLoader();
                await Task.Run(() => responseStr = xmlRpcObj.getResponse(action, arr));
                hideLoader();
            }
            else if (radioSoap.Checked) {
                responseStr = soapObj.soapClientRequest(arr, action);
            }
            else if (radioRest.Checked) {
                responseStr = restObj.restRequest(action, arr);
            }
            if (radioXMLRPC.Checked || radioRest.Checked || radioSoap.Checked)
            {
                dynamic stuff = JsonConvert.DeserializeObject(responseStr);
                if (stuff.state == "OK")
                {
                    notifyIcon1.Icon = SystemIcons.Exclamation;
                    notifyIcon1.BalloonTipTitle = "internetSHOP";
                    notifyIcon1.BalloonTipText = stuff.message;
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon1.Visible = true;
                    notifyIcon1.ShowBalloonTip(2000);
                    showShopCart();
                }
                else if (stuff.state == "FAIL")
                {
                    MessageBox.Show(stuff.message, "InternetSHOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void advanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String responseStr = "";
            string action = "getGood";
            string good = _selectedMenuItem.Split('@')[0];

            KeyValuePair<String, object> param1 = new KeyValuePair<String, object>("token", token);
            KeyValuePair<String, object> param2 = new KeyValuePair<String, object>("good", good);
            KeyValuePair<String, object>[] arr = new KeyValuePair<string, object>[] { param1, param2 };
            if (radioXMLRPC.Checked)
            {
                showLoader();
                await Task.Run(() => responseStr = xmlRpcObj.getResponse(action, arr));
                hideLoader();
            }
            else if (radioSoap.Checked) {
                responseStr = soapObj.soapClientRequest(arr, action);
            }
            else if (radioRest.Checked) {
                responseStr = restObj.restRequest(action, arr);
            }
            if (radioXMLRPC.Checked || radioRest.Checked || radioSoap.Checked)
            {
                dynamic stuff = JsonConvert.DeserializeObject(responseStr);
                if (stuff.state != null && stuff.state == "FAIL")
                {
                    String m = stuff.message;
                    MessageBox.Show(m, "InternetSHOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    String name = stuff.name;
                    String description = stuff.description;
                    String price = stuff.price;
                    String id = stuff.id;
                    String img_source = stuff.img_source;
                    Form2 form2 = new Form2(name,id, description, price, img_source, ini.IniReadValue("Info", "Url"));
                    form2.Show();
                }
            }
            
        }

        private async void buttonBuyAll_Click(object sender, EventArgs e)
        {
            if(listView1.Items.Count == 0) {
                MessageBox.Show("Корзина пуста", "internetSHOP", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            String responseStr = "";
            string action = "buyShopCart";
            KeyValuePair<String, object> param1 = new KeyValuePair<String, object>("token", token);
            KeyValuePair<String, object>[] arr = new KeyValuePair<string, object>[] { param1 };
            if (radioXMLRPC.Checked)
            {
                showLoader();
                await Task.Run(() => responseStr = xmlRpcObj.getResponse(action, arr));
                hideLoader();
            }
            else if (radioSoap.Checked) {
                responseStr = soapObj.soapClientRequest(arr, action);
            }
            else if (radioRest.Checked) {
                responseStr = restObj.restRequest(action, arr);
            }
            if (radioXMLRPC.Checked || radioRest.Checked || radioSoap.Checked)
            {
                dynamic stuff = JsonConvert.DeserializeObject(responseStr);
                if (stuff.state != null && stuff.state == "FAIL")
                {
                    String m = stuff.message;
                    MessageBox.Show(m, "InternetSHOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    String m = stuff.message;
                    String totalCost = stuff.total_cost;
                    balance -= Double.Parse(totalCost);
                    labelBalance.Text = "Ваш баланс: " + stuff.balance + " rub";
                    listView1.Items.Clear();
                    labeltotalCost.Text = "";
                    labelTotalCount.Text = "";
                    MessageBox.Show(m, "InternetSHOP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                loginBtn_Click(sender,e);
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginBtn_Click(sender, e);
            }
        }
    }
}
