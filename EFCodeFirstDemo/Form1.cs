using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFCodeFirstDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var db = new EFDbContext();
            var standard = new Standard()
            {
                StandardName = textBox1.Text,
                Description = textBox2.Text
            };
            db.Standards.Add(standard);
            db.SaveChanges();
            MessageBox.Show("Saved");
        }
    }
}
