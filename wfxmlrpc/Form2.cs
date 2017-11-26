using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XmlRpc;
using System.Xml;
using System.Security.Cryptography;

using System.Web.Script.Serialization;
using System.Collections.ObjectModel;
using System.Dynamic;

using Newtonsoft.Json;

namespace wfxmlrpc
{
    public partial class Form2 : Form
    {
        string name = "";
        string discription = "";
        string cost = "";
        string img = "";
        string url = "";
        string id = "";


        public Form2()
        {
            InitializeComponent();
        }
        public Form2(string good_name, string good_id, string discr, string price, string imgSource, string url_site)
        {
            InitializeComponent();

            name = good_name;
            discription = discr;
            cost = price;
            img = imgSource;
            url = url_site;
            id = good_id;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            labelPrice.Text = cost + " rub";
            labelSign.Text = name;
            textBoxDescription.Text = discription;
            pictureBox1.Load(url +  img);
            this.Text = name;
        }

        private async void buttonInSCform2_Click(object sender, EventArgs e)
        {
            String responseStr = "";
            string good = id;
            string action = "addToShopCart";
            KeyValuePair<String, object> param1 = new KeyValuePair<String, object>("token", Program.myform.token);
            KeyValuePair<String, object> param2 = new KeyValuePair<String, object>("good_id", good);
            KeyValuePair<String, object>[] arr = new KeyValuePair<string, object>[] { param1, param2 };
            if (Program.myform.radioXMLRPC.Checked)
            {
                await Task.Run(() => responseStr = Program.myform.xmlRpcObj.getResponse(action, arr));
            }
            else if (Program.myform.radioSoap.Checked) {
                responseStr = Program.myform.soapObj.soapClientRequest(arr, action);
            }
            else if (Program.myform.radioRest.Checked) {
                responseStr = Program.myform.restObj.restRequest(action, arr);
            }
            if (Program.myform.radioXMLRPC.Checked || Program.myform.radioRest.Checked || Program.myform.radioSoap.Checked)
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
                    Program.myform.showShopCart();
                }
                else if (stuff.state == "FAIL")
                {
                    MessageBox.Show(stuff.message, "InternetSHOP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
