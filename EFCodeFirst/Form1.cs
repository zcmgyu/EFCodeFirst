using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFCodeFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var db = new CodeFirstDbContext();
            var stand = new Standard
            {
                StandardName = "Nhat - Han - Thai",
                Description = "New Description"
            };
            db.Standards.Add(stand);
            db.SaveChanges();
            MessageBox.Show("Saved");
            // Duy edit 123
        }
    }
}
