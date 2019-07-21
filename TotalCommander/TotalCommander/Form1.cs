﻿using System;
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
        private isFocus focusOn;
        DirectoryInfo curDirLeft;
        DirectoryInfo curDirRight;
        DirectoryInfo rootLeft;
        DirectoryInfo rootRight;
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
            listViewLeft.Items.Clear();
            DirectoryInfo ourDir = new DirectoryInfo(ComboBox1.SelectedItem.ToString());
            listViewLeft.LargeImageList = largeIcon;
            listViewLeft.SmallImageList = smallIcon;
            TextBox1.Text = ourDir.FullName;
            curDirLeft = ourDir;
            rootLeft = ourDir;
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
                        item.Tag = file;
                        item.SubItems.Add(file.Extension);
                        item.SubItems.Add(file.Length.ToString());
                        item.SubItems.Add(file.LastAccessTime.ToString());
                        item.SubItems.Add(file.Attributes.ToString());
                        listViewLeft.Items.Add(item);
                    }
                }

                foreach (DirectoryInfo dir in ourDir.GetDirectories())
                {
                    if ((dir.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                    {
                        ListViewItem item = new ListViewItem(dir.Name, 0);
                        item.Tag = dir;
                        item.SubItems.Add("");
                        item.SubItems.Add("<DIR>");
                        item.SubItems.Add(dir.LastAccessTime.ToString());
                        item.SubItems.Add(dir.Attributes.ToString());
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
            listViewRight.Items.Clear();
            DirectoryInfo ourDir = new DirectoryInfo(ComboBox2.SelectedItem.ToString());
            listViewRight.LargeImageList = largeIcon;
            listViewRight.SmallImageList = smallIcon;
            //largeIcon.Images.Add("folder", Image.FromFile(Application.StartupPath + "\\Image\folder.png"));
            TextBox2.Text = ourDir.FullName;
            curDirRight = ourDir;
            rootRight = ourDir;
            try
            {
                foreach (FileInfo file in ourDir.GetFiles())
                {
                    if ((file.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                    {
                        if (!largeIcon.Images.Keys.Contains(file.Extension))
                        {
                            largeIcon.Images.Add(file.Extension, Icon.ExtractAssociatedIcon(file.FullName));
                            smallIcon.Images.Add(file.Extension, Icon.ExtractAssociatedIcon(file.FullName));
                        }
                        int find = largeIcon.Images.Keys.IndexOf(file.Extension);
                        ListViewItem item = new ListViewItem(file.Name, find);
                        item.Tag = file;
                        item.SubItems.Add(file.Extension);
                        item.SubItems.Add(file.Length.ToString());
                        item.SubItems.Add(file.LastAccessTime.ToString());
                        item.SubItems.Add(file.Attributes.ToString());
                        listViewRight.Items.Add(item);
                    }
                }

                foreach (DirectoryInfo dir in ourDir.GetDirectories())
                {
                    if ((dir.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                    {
                        ListViewItem item = new ListViewItem(dir.Name, 0);
                        item.Tag = dir;
                        item.SubItems.Add("");
                        item.SubItems.Add("<DIR>");
                        item.SubItems.Add(dir.LastAccessTime.ToString());
                        item.SubItems.Add(dir.Attributes.ToString());
                        listViewRight.Items.Add(item);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Can't open Directory!");
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            createComboBox();
            createListView1();
            createListView2();
            focusOn = isFocus.Left;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            focusOn = isFocus.Left;
            DriveInfo drive = new DriveInfo(ComboBox1.SelectedItem.ToString());
            try
            {
                Label1.Text = String.Format("{0} GB of {1} GB free", drive.AvailableFreeSpace / (1024 * 1024 * 1024), drive.TotalSize / (1024 * 1024 * 1024));
                createListView1();
            }
            catch {
                MessageBox.Show("Drive is not found");
                ComboBox1.SelectedItem = 0;
                return;
            };
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            focusOn = isFocus.Right;
            DriveInfo drive = new DriveInfo(ComboBox2.SelectedItem.ToString());
            try
            {
                Label2.Text = String.Format("{0} GB of {1} GB free", drive.AvailableFreeSpace / (1024 * 1024 * 1024), drive.TotalSize / (1024 * 1024 * 1024));
                createListView2();
            }
            catch
            {
                MessageBox.Show("Drive is not found");
                ComboBox2.SelectedItem = 0;
                return;
            };
        }

        private void openDirectoryLeft()
        {
            listViewLeft.Items.Clear();
            foreach (FileInfo file in curDirLeft.GetFiles())
            {
                if ((file.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    if (!largeIcon.Images.Keys.Contains(file.Extension))
                    {
                        largeIcon.Images.Add(file.Extension, Icon.ExtractAssociatedIcon(file.FullName));
                        smallIcon.Images.Add(file.Extension, Icon.ExtractAssociatedIcon(file.FullName));
                    }
                    int find = largeIcon.Images.Keys.IndexOf(file.Extension);
                    ListViewItem item = new ListViewItem(file.Name, find);
                    item.Tag = file;
                    item.SubItems.Add(file.Extension);
                    item.SubItems.Add(file.Length.ToString());
                    item.SubItems.Add(file.LastAccessTime.ToString());
                    item.SubItems.Add(file.Attributes.ToString());
                    listViewLeft.Items.Add(item);
                }
            }

            foreach (DirectoryInfo subDir in curDirLeft.GetDirectories())
            {
                if ((subDir.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    ListViewItem item = new ListViewItem(subDir.Name, 0);
                    item.Tag = subDir;
                    item.SubItems.Add("");
                    item.SubItems.Add("<DIR>");
                    item.SubItems.Add(subDir.LastAccessTime.ToString());
                    item.SubItems.Add(subDir.Attributes.ToString());
                    listViewLeft.Items.Add(item);
                }
            }
            TextBox1.Text = curDirLeft.FullName;
        }

        private void openDirectoryRight()
        {
            listViewRight.Items.Clear();
            foreach (FileInfo file in curDirRight.GetFiles())
            {
                if ((file.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    if (!largeIcon.Images.Keys.Contains(file.Extension))
                    {
                        largeIcon.Images.Add(file.Extension, Icon.ExtractAssociatedIcon(file.FullName));
                        smallIcon.Images.Add(file.Extension, Icon.ExtractAssociatedIcon(file.FullName));
                    }
                    int find = largeIcon.Images.Keys.IndexOf(file.Extension);
                    ListViewItem item = new ListViewItem(file.Name, find);
                    item.Tag = file;
                    item.SubItems.Add(file.Extension);
                    item.SubItems.Add(file.Length.ToString());
                    item.SubItems.Add(file.LastAccessTime.ToString());
                    item.SubItems.Add(file.Attributes.ToString());
                    listViewRight.Items.Add(item);
                }
            }

            foreach (DirectoryInfo subDir in curDirRight.GetDirectories())
            {
                if ((subDir.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    ListViewItem item = new ListViewItem(subDir.Name, 0);
                    item.Tag = subDir;
                    item.SubItems.Add("");
                    item.SubItems.Add("<DIR>");
                    item.SubItems.Add(subDir.LastAccessTime.ToString());
                    item.SubItems.Add(subDir.Attributes.ToString());
                    listViewRight.Items.Add(item);
                }
            }

            TextBox2.Text = curDirRight.FullName;
        }

        private void ListViewLeft_ItemActivate(object sender, EventArgs e)
        {
            focusOn = isFocus.Left;
            try
            {
                if (listViewLeft.SelectedItems[0].Tag.GetType() == typeof(DirectoryInfo))
                {
                    curDirLeft = (DirectoryInfo)listViewLeft.SelectedItems[0].Tag;
                    openDirectoryLeft();
                }
                else
                {
                    FileInfo file = (FileInfo)listViewLeft.SelectedItems[0].Tag;
                    System.Diagnostics.Process.Start(file.FullName);
                }

            }
            catch
            {
                MessageBox.Show("Can't Open Directory");
            }
        }

        private void ListViewRight_ItemActivate(object sender, EventArgs e)
        {
            focusOn = isFocus.Right;
            try
            {
                if (listViewRight.SelectedItems[0].Tag.GetType() == typeof(DirectoryInfo))
                {
                    curDirRight = (DirectoryInfo)listViewRight.SelectedItems[0].Tag;
                    openDirectoryRight();
                }
                else
                {
                    FileInfo file = (FileInfo)listViewRight.SelectedItems[0].Tag;
                    System.Diagnostics.Process.Start(file.FullName);
                }

            }
            catch
            {
                MessageBox.Show("Can't Open Directory");
            }
        }

        private void HelpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Application.StartupPath);
            FileInfo file = new FileInfo(Application.StartupPath + "\\HelpMenu.pdf");
            System.Diagnostics.Process.Start(file.FullName);
        }

        private void ListButton_Click(object sender, EventArgs e)
        {
            if (focusOn == isFocus.Left)
                listViewLeft.View = View.List;
            else listViewRight.View = View.List;
        }

        private void DetailButton_Click(object sender, EventArgs e)
        {
            if (focusOn == isFocus.Left)
                listViewLeft.View = View.Details;
            else listViewRight.View = View.Details;
        }

        private void IconButton_Click(object sender, EventArgs e)
        {
            if (focusOn == isFocus.Left)
                listViewLeft.View = View.LargeIcon;
            else listViewRight.View = View.LargeIcon;
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DirectoryInfo dir = new DirectoryInfo(TextBox1.Text.ToString());
                if (dir.Exists)
                {
                    curDirLeft = dir;
                    openDirectoryLeft();
                }
                else TextBox1.Text = curDirLeft.FullName;
            }
          
        }

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DirectoryInfo dir = new DirectoryInfo(TextBox1.Text.ToString());
                if (dir.Exists)
                {
                    curDirRight = dir;
                    openDirectoryRight();
                }
                else TextBox2.Text = curDirRight.FullName;
            }
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            if (focusOn == isFocus.Left)
                openDirectoryLeft();
            else openDirectoryRight();
        }

        private void GoRoot1_Click(object sender, EventArgs e)
        {
            curDirLeft = rootLeft;
            openDirectoryLeft();
        }

        private void GoRoot2_Click(object sender, EventArgs e)
        {
            curDirRight = rootRight;
            openDirectoryRight();
        }
        private void ViewButton_Click(object sender, EventArgs e)
        {
            if(focusOn == isFocus.Left)
            {
                if (listViewLeft.SelectedItems.Count > 0)
                {
                    if (listViewLeft.SelectedItems[0].Tag.GetType() == typeof(DirectoryInfo))
                    {
                        MessageBox.Show("This's a folder");
                    }
                    else
                    {
                        FileInfo file = (FileInfo)listViewLeft.SelectedItems[0].Tag;
                        ViewForm f = new ViewForm(file.FullName);
                        f.ShowDialog();
                    }
                }
            }
            else
            {
                if (listViewRight.SelectedItems.Count > 0)
                {
                    if (listViewRight.SelectedItems[0].Tag.GetType() == typeof(DirectoryInfo))
                    {
                        MessageBox.Show("This's a folder");
                    }
                    else
                    {
                        FileInfo file = (FileInfo)listViewRight.SelectedItems[0].Tag;
                        ViewForm f = new ViewForm(file.FullName);
                        f.ShowDialog();
                    }
                }
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {

        }

        private void MoveButton_Click(object sender, EventArgs e)
        {

        }

        private void FolderButton_Click(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void ListViewRight_Click(object sender, EventArgs e)
        {
            focusOn = isFocus.Right;
        }

        private void ListViewLeft_Click(object sender, EventArgs e)
        {
            focusOn = isFocus.Left;
        }
    }
}
