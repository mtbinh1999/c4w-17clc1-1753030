using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TotalCommander
{
    public partial class Form1 : Form
    {
        private enum isFocus {Left, Right};
        private isFocus focusOn = isFocus.Left;
        DirectoryInfo curDir;
        int imageCount1 = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void createComboBox()
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                ComboBox1.Items.Add(drive.Name);
                ComboBox2.Items.Add(drive.Name);
                ComboBox1.SelectedIndex = 0;
                ComboBox2.SelectedIndex = 0;
            }
        }

        private void createListView1()
        {
            DirectoryInfo ourDir = new DirectoryInfo(ComboBox1.SelectedItem.ToString());
            string filename;
            try
            {
                foreach(FileInfo file in ourDir.GetFiles())
                {
                    if((file.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                    { 
                        if(!largeIcon.Images.Keys.Contains(file.Extension))
                        {
                            largeIcon.Images.Add(file.Extension, Icon.ExtractAssociatedIcon(file.FullName));
                            smallIcon.Images.Add(file.Extension, Icon.ExtractAssociatedIcon(file.FullName));
                        }
                        int find = largeIcon.Images.Keys.IndexOf(file.Extension);
                        ListViewItem item = new ListViewItem(file.Name, find);
                        item.Tag = file.FullName;
                        item.SubItems.Add(file.Extension);
                        item.SubItems.Add(file.Length.ToString());
                        item.SubItems.Add(file.LastAccessTime.ToString());
                        item.SubItems.Add(file.Attributes.ToString());
                        listViewLeft.Items.Add(item);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Can't open Directory!");
                return;
            }
        }

        private void createListView2()
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            createComboBox();
            createListView1();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DriveInfo drive = new DriveInfo(ComboBox1.SelectedItem.ToString());
            try
            {
                Label1.Text = String.Format("{0} GB of {1} GB free", drive.AvailableFreeSpace / (1024 * 1024 * 1024), drive.TotalSize / (1024 * 1024 * 1024));
            }
            catch {
                MessageBox.Show("Drive is not found");
                ComboBox1.SelectedItem = 0;
                return;
            };
            
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DriveInfo drive = new DriveInfo(ComboBox2.SelectedItem.ToString());
            try
            {
                Label2.Text = String.Format("{0} GB of {1} GB free", drive.AvailableFreeSpace / (1024 * 1024 * 1024), drive.TotalSize / (1024 * 1024 * 1024));
            }
            catch
            {
                MessageBox.Show("Drive is not found");
                ComboBox2.SelectedItem = 0;
                return;
            };
        }

        
    }
}
