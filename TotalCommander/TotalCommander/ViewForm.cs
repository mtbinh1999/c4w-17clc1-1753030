using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TotalCommander
{
    public partial class ViewForm : Form
    {
        private string filename;
        public ViewForm(string file)
        {
            InitializeComponent();
            filename = file;
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {
            System.IO.StreamReader streamReader = new System.IO.StreamReader(filename);
            string line = "";
            while ((line = streamReader.ReadLine()) != null)
            {
                ContextFile.Text += line + Environment.NewLine;
            }
        }
    }
}
