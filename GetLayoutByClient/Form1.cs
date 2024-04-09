using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Resolvers;
using DAL;
using Telerik.WinControls.UI;

namespace GetLayoutByClient
{
    public partial class Form1 : Form
    {
        private IDataLayer dal;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private bool debug = false;
        private void Init()
        {
            if (debug)
            {
                dal = new MockDataLayer();

            }
            else
            {
                dal = new DataLayer();

            }
            dal.Connect();
            var clients = dal.GetClients();
            var labs = dal.GetLabs();

            ddlClients.DataSource = clients;
            ddlLabs.DataSource = labs;
            string name = "Name";
            ddlLabs.DisplayMember = name;

            ddlClients.DisplayMember = name;

        }


        private void ClearGridView()
        {
            label1.Text = "";

            radGridView1.BeginEdit();
            radGridView1.Columns.Clear();
            radGridView1.Rows.Clear();
            radGridView1.DataSource = null;
            radGridView1.EndEdit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ClearGridView();
            var Client = (Client)ddlClients.SelectedItem.DataBoundItem;
            var lab = (LabInfo)ddlLabs.SelectedItem.DataBoundItem;
            var xml = dal.GetXmlStorage("CLIENT_SAMPLE_DETAILS", Client.ClientId, lab.LabInfoId);
            if (xml != null)
            {

                LoadLayout(xml.XmlData);
                var str = System.Text.Encoding.Default.GetString(xml.XmlData);
                richTextBox1.Text = str;
                label1.Text = "מספר תווים " + richTextBox1.Text.Length;

            }
            else
            {
                MessageBox.Show("Xml is null");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearGridView();

            var Client = (Client)ddlClients.SelectedItem.DataBoundItem;
            var lab = (LabInfo)ddlLabs.SelectedItem.DataBoundItem;
            var xml = dal.GetXmlStorage("CLIENT_ASSOCIATION_TESTS", Client.ClientId, lab.LabInfoId);
            if (xml != null)
            {
                LoadLayout(xml.XmlData);
                var str = System.Text.Encoding.Default.GetString(xml.XmlData);
                richTextBox1.Text = str;
                label1.Text = "מספר תווים " + richTextBox1.Text.Length;

            }
            else
            {
                MessageBox.Show("Xml is null");
            }
        }

        private void LoadLayout(byte[] abBytes)
        {

            Stream stream = new MemoryStream(abBytes);
              radGridView1.LoadLayout(stream);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }



}

