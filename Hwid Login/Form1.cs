using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hwid_Login
{
    public partial class Form1 : Form
    {
        string hwid;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hwid = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
            guna2TextBox1.Text = hwid;
            guna2TextBox1.ReadOnly = true;
        }

        bool form = false;
        Point baslangic = new Point(0, 0);
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            form = true;
            baslangic = new Point(e.X, e.Y);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            form = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (form)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.baslangic.X, p.Y - this.baslangic.Y);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            WebClient wb = new WebClient();
            string Hwıd = wb.DownloadString("https://raw.githubusercontent.com/Selyk35/Hwid-Check/main/Hwid.txt"); 
            if (Hwıd.Contains(guna2TextBox1.Text))
            {
                MessageBox.Show("Hwid'iniz listede :)");
            }
            else
            {
                MessageBox.Show("hwid bulunamadı!");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(hwid);
            guna2Button2.Enabled = false;
            guna2Button2.Text = "Copied";
        }

        
    }
}
