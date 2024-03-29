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
using System.Reflection;

namespace TotalCommander
{
    public partial class Form1 : Form
    {
        private enum isFocus {Left, Right};
        private isFocus focusOn;
        public string editor = "notepad.exe";
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
            ListViewItem root = new ListViewItem("..", 1);
            root.Tag = curDirLeft;
            listViewLeft.Items.Add(root);
            TextBox1.Text = ourDir.FullName;
            curDirLeft = ourDir;
            rootLeft = ourDir;
            try
            {
                foreach(FileInfo file in ourDir.GetFiles())
                {
                    if((file.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden || showHidden)
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
                    if ((dir.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden || showHidden)
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
            ListViewItem root = new ListViewItem("..", 1);
            root.Tag = curDirRight;
            listViewRight.Items.Add(root);
            TextBox2.Text = ourDir.FullName;
            curDirRight = ourDir;
            rootRight = ourDir;
            try
            {
                foreach (FileInfo file in ourDir.GetFiles())
                {
                    if ((file.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden || showHidden)
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
                    if ((dir.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden || showHidden)
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
            ListViewItem root = new ListViewItem("..", 1);
            if (curDirLeft.Parent != null)
                root.Tag = curDirLeft.Parent;
            else root.Tag = curDirLeft;
            listViewLeft.Items.Add(root);

            foreach (FileInfo file in curDirLeft.GetFiles())
            {
                if ((file.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden || showHidden)
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
                if ((subDir.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden || showHidden)
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

            ListViewItem root = new ListViewItem("..", 1);
            if (curDirRight.Parent != null)
                root.Tag = curDirRight.Parent;
            else root.Tag = curDirRight;
            listViewRight.Items.Add(root);

            foreach (FileInfo file in curDirRight.GetFiles())
            {
                if ((file.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden || showHidden)
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
                if ((subDir.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden || showHidden)
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
                    try { System.Diagnostics.Process.Start(editor, "\"" + file.FullName + "\""); }
                    catch (IOException er)
                    {
                        MessageBox.Show(er.Message);
                        MessageBox.Show("Notepad sets as default editor");
                        editor = "notepad.exe";
                    }
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
                    FileInfo file = (FileInfo)listViewLeft.SelectedItems[0].Tag;
                    try { System.Diagnostics.Process.Start(editor, "\"" + file.FullName + "\""); }
                    catch (IOException er)
                    {
                        MessageBox.Show(er.Message);
                        MessageBox.Show("Notepad sets as default editor");
                        editor = "notepad.exe";
                    }
                }

            }
            catch
            {
                MessageBox.Show("Can't Open Directory");
            }
        }

        private void saveFileHelp()
        {
            Assembly Assemb = Assembly.GetExecutingAssembly();
            Stream stream = Assemb.GetManifestResourceStream("TotalCommander.Resources.HelpMenu.pdf");
            FileStream fs = new FileStream(Application.StartupPath + "\\HelpMenu.pdf", FileMode.CreateNew);
            BinaryReader br = new BinaryReader(stream);
            byte[] save = new byte[stream.Length];
            br.Read(save, 0, save.Length);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(save, 0, save.Length);
            bw.Flush();
            bw.Close();
        }

        private void HelpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!File.Exists("HelpMenu.pdf"))
                saveFileHelp();
            System.Diagnostics.Process.Start("HelpMenu.pdf");
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
                DirectoryInfo dir = new DirectoryInfo(TextBox2.Text.ToString());
                if (dir.Exists)
                {
                    curDirRight = dir;
                    openDirectoryRight();
                }
                else TextBox2.Text = curDirRight.FullName;
            }
        }

        private void refreshListView()
        {
            openDirectoryLeft();
            openDirectoryRight();
        }
        private void refButton_Click(object sender, EventArgs e)
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
                    for (int i = 0; i < listViewLeft.SelectedItems.Count; i++)
                    {
                        if (listViewLeft.SelectedItems[i].Tag.GetType() == typeof(DirectoryInfo))
                        {
                            MessageBox.Show(listViewLeft.SelectedItems[i].Text + " is a folder");
                        }
                        else
                        {
                            FileInfo file = (FileInfo)listViewLeft.SelectedItems[i].Tag;
                            ViewForm f = new ViewForm(file.FullName);
                            f.ShowDialog();
                        }
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
                        try { System.Diagnostics.Process.Start(editor, "\"" + file.FullName + "\""); }
                        catch (IOException er)
                        {
                            MessageBox.Show(er.Message);
                            MessageBox.Show("Notepad sets as default editor");
                            editor = "notepad.exe";
                        }
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
                        try { System.Diagnostics.Process.Start(editor, "\"" + file.FullName + "\""); }
                        catch (IOException er)
                        {
                            MessageBox.Show(er.Message);
                            MessageBox.Show("Notepad sets as default editor");
                            editor = "notepad.exe";
                        }
                    }
                }
            }
        }

        private void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);

            string[] files = Directory.GetFiles(sourceFolder);

            foreach (string file in files)
            {

                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest);
            }

            string[] folders = Directory.GetDirectories(sourceFolder);

            foreach (string folder in folders)
            {

                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);

            }
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            if(focusOn == isFocus.Left)
            {
                if(listViewLeft.SelectedItems.Count > 0)
                {
                    DialogResult confirm = MessageBox.Show("Confirm Copy!", "Copy Option", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Cancel)
                        return;
                    for (int i = 0; i < listViewLeft.SelectedItems.Count; i++)
                    {
                        if(listViewLeft.SelectedItems[i].Tag.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo dir = (DirectoryInfo)listViewLeft.SelectedItems[i].Tag;
                            string name = dir.Name;
                            string dest = Path.Combine(curDirRight.FullName, name);
                            if(dir.FullName == curDirRight.FullName)
                            {
                                MessageBox.Show("The destination folder is a subfolder the source folder", "Interrupted Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            CopyFolder(dir.FullName, dest);
                        }
                        else
                        {
                            FileInfo file = (FileInfo)listViewLeft.SelectedItems[i].Tag;
                            string name = Path.GetFileName(file.FullName);
                            string dest = Path.Combine(curDirRight.FullName, name);

                            if (File.Exists(dest))
                            {
                                DialogResult dlr = MessageBox.Show(name + " existed! Do you want to overwrite? Yes (Overwrite), No (Skip)", "Replace file", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dlr == DialogResult.Yes)
                                {
                                    try { File.Copy(file.FullName, dest, true); }
                                    catch (IOException er)
                                    {
                                        MessageBox.Show(er.Message);
                                    }
                                }
                                else if (dlr == DialogResult.No)
                                    break;
                            }
                            else
                            {
                                try { File.Copy(file.FullName, dest); }
                                catch (IOException er)
                                {
                                    MessageBox.Show(er.Message);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (listViewRight.SelectedItems.Count > 0)
                {
                    DialogResult confirm = MessageBox.Show("Confirm Copy!", "Copy Option", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Cancel)
                        return;
                    for (int i = 0; i < listViewRight.SelectedItems.Count; i++)
                    {
                        if (listViewRight.SelectedItems[i].Tag.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo dir = (DirectoryInfo)listViewRight.SelectedItems[i].Tag;
                            string name = dir.Name;
                            string dest = Path.Combine(curDirLeft.FullName, name);
                            if (dir.FullName == curDirLeft.FullName)
                            {
                                MessageBox.Show("The destination folder is a subfolder the source folder", "Interrupted Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            CopyFolder(dir.FullName, dest);
                        }
                        else
                        {
                            FileInfo file = (FileInfo)listViewRight.SelectedItems[i].Tag;
                            string name = Path.GetFileName(file.FullName);
                            string dest = Path.Combine(curDirLeft.FullName, name);

                            if (File.Exists(dest))
                            {
                                DialogResult dlr = MessageBox.Show(name + " existed! Do you want to overwrite? Yes (Overwrite), No (Skip)", "Replace file", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dlr == DialogResult.Yes)
                                {
                                    try { File.Copy(file.FullName, dest, true); }
                                    catch (IOException er)
                                    {
                                        MessageBox.Show(er.Message);
                                    }
                                }
                                else if (dlr == DialogResult.No)
                                    break;
                            }
                            else
                            {
                                try { File.Copy(file.FullName, dest); }
                                catch (IOException er)
                                {
                                    MessageBox.Show(er.Message);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void MoveButton_Click(object sender, EventArgs e)
        {
            if(focusOn == isFocus.Left)
            {
                if (listViewLeft.SelectedItems.Count > 0)
                {
                    DialogResult confirm = MessageBox.Show("Confirm Move!", "Move Option", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Cancel)
                        return;
                    for (int i = 0; i < listViewLeft.SelectedItems.Count; i++)
                    {
                        if (listViewLeft.SelectedItems[i].Tag.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo dir = (DirectoryInfo)listViewLeft.SelectedItems[i].Tag;
                            if (dir.FullName == curDirRight.FullName)
                            {
                                MessageBox.Show("The destination folder is a subfolder the source folder", "Interrupted Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            string dest = Path.Combine(curDirRight.FullName, dir.Name);
                            Directory.Move(dir.FullName, dest);
                        }
                        else
                        {
                            FileInfo file = (FileInfo)listViewLeft.SelectedItems[i].Tag;
                            string name = Path.GetFileName(file.FullName);
                            string dest = Path.Combine(curDirRight.FullName, name);

                            if (File.Exists(dest))
                            {
                                DialogResult dlr = MessageBox.Show(name + " existed! Do you want to overwrite? Yes (Overwrite), No (Skip)", "Replace file", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dlr == DialogResult.Yes)
                                {
                                    try {
                                        File.Copy(file.FullName, dest, true);
                                        File.Delete(file.FullName);
                                    }
                                    catch (IOException er)
                                    {
                                        MessageBox.Show(er.Message);
                                    }
                                }
                                else if (dlr == DialogResult.No)
                                    break;
                            }
                            else
                            {
                                try { File.Move(file.FullName, dest); }
                                catch (IOException er)
                                {
                                    MessageBox.Show(er.Message);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (listViewRight.SelectedItems.Count > 0)
                {
                    DialogResult confirm = MessageBox.Show("Confirm Move!", "Move Option", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Cancel)
                        return;
                    for (int i = 0; i < listViewRight.SelectedItems.Count; i++)
                    {
                        if (listViewRight.SelectedItems[i].Tag.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo dir = (DirectoryInfo)listViewRight.SelectedItems[i].Tag;
                            if (dir.FullName == curDirLeft.FullName)
                            {
                                MessageBox.Show("The destination folder is a subfolder the source folder", "Interrupted Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            string dest = Path.Combine(curDirLeft.FullName, dir.Name);
                            Directory.Move(dir.FullName, dest);
                        }
                        else
                        {
                            FileInfo file = (FileInfo)listViewRight.SelectedItems[i].Tag;
                            string name = Path.GetFileName(file.FullName);
                            string dest = Path.Combine(curDirLeft.FullName, name);

                            if (File.Exists(dest))
                            {
                                DialogResult dlr = MessageBox.Show(name + " existed! Do you want to overwrite? Yes (Overwrite), No (Skip)", "Replace file", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dlr == DialogResult.Yes)
                                {
                                    try
                                    {
                                        File.Copy(file.FullName, dest, true);
                                        File.Delete(file.FullName);
                                    }
                                    catch (IOException er)
                                    {
                                        MessageBox.Show(er.Message);
                                    }
                                }
                                else if (dlr == DialogResult.No)
                                    break;
                            }
                            else
                            {
                                try { File.Move(file.FullName, dest); }
                                catch (IOException er)
                                {
                                    MessageBox.Show(er.Message);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void FolderButton_Click(object sender, EventArgs e)
        {
            if(focusOn == isFocus.Left)
            {
                int i = 1;
                if((curDirLeft.Attributes & FileAttributes.ReadOnly) != FileAttributes.ReadOnly)
                {
                    DirectoryInfo dir = new DirectoryInfo(curDirLeft.FullName + "\\New Folder");
                    if(!dir.Exists)
                    {
                        Directory.CreateDirectory(curDirLeft.FullName + "\\New Folder");
                        refreshListView();
                        return;
                    }
                    else
                    {
                        while (true)
                        {
                            DirectoryInfo edir = new DirectoryInfo(curDirLeft.FullName + string.Format("\\New Folder ({0})", i));
                            if(!edir.Exists)
                            {
                                Directory.CreateDirectory(curDirLeft.FullName + string.Format("\\New Folder ({0})", i));
                                refreshListView();
                                return;
                            }
                            i++;
                        }
                    }
                    
                    
                }
                else
                {
                    MessageBox.Show("This folder is ReadOnly");
                    return;
                }
            }
            else
            {
                int i = 1;
                if ((curDirRight.Attributes & FileAttributes.ReadOnly) != FileAttributes.ReadOnly)
                {
                    DirectoryInfo dir = new DirectoryInfo(curDirRight.FullName + "\\New Folder");
                    if (!dir.Exists)
                    {
                        Directory.CreateDirectory(curDirRight.FullName + "\\New Folder");
                        refreshListView();
                        return;
                    }
                    else
                    {
                        while (true)
                        {
                            DirectoryInfo edir = new DirectoryInfo(curDirRight.FullName + string.Format("\\New Folder ({0})", i));
                            if (!edir.Exists)
                            {
                                Directory.CreateDirectory(curDirRight.FullName + string.Format("\\New Folder ({0})", i));
                                refreshListView();
                                return;
                            }
                            i++;
                        }
                    }


                }
                else
                {
                    MessageBox.Show("This folder is ReadOnly");
                    return;
                }
            }
        }

        private bool checkExitsFile(DirectoryInfo dir)
        {
            int i = 0;
            foreach(DirectoryInfo subdir in dir.GetDirectories())
            {
                i++;
            }
            foreach(FileInfo file in dir.GetFiles())
            {
                i++;
            }
            if (i != 0)
                return true;
            return false;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if(focusOn == isFocus.Left)
            {
                if(listViewLeft.SelectedItems.Count > 0)
                {
                    DialogResult dlr = MessageBox.Show("Confirm Delete!", "Delete Option", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Cancel)
                        return;
                    for(int i = 0; i < listViewLeft.SelectedItems.Count; i++)
                    {
                        if(listViewLeft.SelectedItems[i].Tag.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo dir = (DirectoryInfo)listViewLeft.SelectedItems[i].Tag;
                            if (checkExitsFile(dir))
                            {
                                dlr = MessageBox.Show(dir.Name + " contains items! Want to delete?", "Contains item!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                if (dlr == DialogResult.Cancel)
                                    break;
                                try { dir.Delete(true); refreshListView(); }
                                catch (IOException er)
                                {
                                    MessageBox.Show(er.Message);
                                }
                            }
                            else
                            {
                                try { dir.Delete(true); }
                                catch (IOException er)
                                {
                                    MessageBox.Show(er.Message);
                                }
                            }
                        }
                        else
                        {
                            FileInfo file = (FileInfo)listViewLeft.SelectedItems[i].Tag;
                            try { file.Delete();}
                            catch(IOException er)
                            {
                                MessageBox.Show(er.Message);
                            }
                        }
                    }
                }
            }
            else
            {
                if (listViewRight.SelectedItems.Count > 0)
                {
                    DialogResult dlr = MessageBox.Show("Confirm Delete!", "Delete Option", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Cancel)
                        return;
                    for (int i = 0; i < listViewRight.SelectedItems.Count; i++)
                    {
                        if (listViewRight.SelectedItems[i].Tag.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo dir = (DirectoryInfo)listViewRight.SelectedItems[i].Tag;
                            if (checkExitsFile(dir))
                            {
                                dlr = MessageBox.Show(dir.Name + " contains items! Want to delete?", "Contains item!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                if (dlr == DialogResult.Cancel)
                                    break;
                                try { dir.Delete(true); refreshListView(); }
                                catch (IOException er)
                                {
                                    MessageBox.Show(er.Message);
                                }
                            }
                            else
                            {
                                try { dir.Delete(true); refreshListView(); }
                                catch (IOException er)
                                {
                                    MessageBox.Show(er.Message);
                                }
                            }
                        }
                        else
                        {
                            FileInfo file = (FileInfo)listViewRight.SelectedItems[i].Tag;
                            try { file.Delete(); }
                            catch (IOException er)
                            {
                                MessageBox.Show(er.Message);
                            }
                        }
                    }
                }
            }
            refreshListView();
        }

        private void ListViewRight_Click(object sender, EventArgs e)
        {
            focusOn = isFocus.Right;
        }

        private void ListViewLeft_Click(object sender, EventArgs e)
        {
            focusOn = isFocus.Left;
        }

        private void ViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (focusOn == isFocus.Left)
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

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (focusOn == isFocus.Left)
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
                        try { System.Diagnostics.Process.Start(editor, "\"" + file.FullName + "\""); }
                        catch(IOException er)
                        {
                            MessageBox.Show(er.Message);
                            MessageBox.Show("Notepad sets as default editor");
                            editor = "notepad.exe";
                        }
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
                        try { System.Diagnostics.Process.Start(editor, "\"" + file.FullName + "\""); }
                        catch (IOException er)
                        {
                            MessageBox.Show(er.Message);
                            MessageBox.Show("Notepad sets as default editor");
                            editor = "notepad.exe";
                        }
                    }
                }
            }
        }

        private void NewFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (focusOn == isFocus.Left)
            {
                int i = 1;
                if ((curDirLeft.Attributes & FileAttributes.ReadOnly) != FileAttributes.ReadOnly)
                {
                    DirectoryInfo dir = new DirectoryInfo(curDirLeft.FullName + "\\New Folder");
                    if (!dir.Exists)
                    {
                        Directory.CreateDirectory(curDirLeft.FullName + "\\New Folder");
                        refreshListView();
                        return;
                    }
                    else
                    {
                        while (true)
                        {
                            DirectoryInfo edir = new DirectoryInfo(curDirLeft.FullName + string.Format("\\New Folder ({0})", i));
                            if (!edir.Exists)
                            {
                                Directory.CreateDirectory(curDirLeft.FullName + string.Format("\\New Folder ({0})", i));
                                refreshListView();
                                return;
                            }
                            i++;
                        }
                    }


                }
                else
                {
                    MessageBox.Show("This folder is ReadOnly");
                    return;
                }
            }
            else
            {
                int i = 1;
                if ((curDirRight.Attributes & FileAttributes.ReadOnly) != FileAttributes.ReadOnly)
                {
                    DirectoryInfo dir = new DirectoryInfo(curDirRight.FullName + "\\New Folder");
                    if (!dir.Exists)
                    {
                        Directory.CreateDirectory(curDirRight.FullName + "\\New Folder");
                        refreshListView();
                        return;
                    }
                    else
                    {
                        while (true)
                        {
                            DirectoryInfo edir = new DirectoryInfo(curDirRight.FullName + string.Format("\\New Folder ({0})", i));
                            if (!edir.Exists)
                            {
                                Directory.CreateDirectory(curDirRight.FullName + string.Format("\\New Folder ({0})", i));
                                refreshListView();
                                return;
                            }
                            i++;
                        }
                    }


                }
                else
                {
                    MessageBox.Show("This folder is ReadOnly");
                    return;
                }
            }
            refreshListView();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (focusOn == isFocus.Left)
            {
                if (listViewLeft.SelectedItems.Count > 0)
                {
                    DialogResult confirm = MessageBox.Show("Confirm Copy!", "Copy Option", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Cancel)
                        return;
                    for (int i = 0; i < listViewLeft.SelectedItems.Count; i++)
                    {
                        if (listViewLeft.SelectedItems[i].Tag.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo dir = (DirectoryInfo)listViewLeft.SelectedItems[i].Tag;
                            string name = dir.Name;
                            string dest = Path.Combine(curDirRight.FullName, name);
                            if (dir.FullName == curDirRight.FullName)
                            {
                                MessageBox.Show("The destination folder is a subfolder the source folder", "Interrupted Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            CopyFolder(dir.FullName, dest);
                        }
                        else
                        {
                            FileInfo file = (FileInfo)listViewLeft.SelectedItems[i].Tag;
                            string name = Path.GetFileName(file.FullName);
                            string dest = Path.Combine(curDirRight.FullName, name);

                            if (File.Exists(dest))
                            {
                                DialogResult dlr = MessageBox.Show(name + " existed! Do you want to overwrite? Yes (Overwrite), No (Skip)", "Replace file", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dlr == DialogResult.Yes)
                                {
                                    try { File.Copy(file.FullName, dest, true); }
                                    catch (IOException er)
                                    {
                                        MessageBox.Show(er.Message);
                                    }
                                }
                                else if (dlr == DialogResult.No)
                                    break;
                            }
                            else
                            {
                                try { File.Copy(file.FullName, dest); }
                                catch (IOException er)
                                {
                                    MessageBox.Show(er.Message);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (listViewRight.SelectedItems.Count > 0)
                {
                    DialogResult confirm = MessageBox.Show("Confirm Copy!", "Copy Option", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Cancel)
                        return;
                    for (int i = 0; i < listViewRight.SelectedItems.Count; i++)
                    {
                        if (listViewRight.SelectedItems[i].Tag.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo dir = (DirectoryInfo)listViewRight.SelectedItems[i].Tag;
                            string name = dir.Name;
                            string dest = Path.Combine(curDirLeft.FullName, name);
                            if (dir.FullName == curDirLeft.FullName)
                            {
                                MessageBox.Show("The destination folder is a subfolder the source folder", "Interrupted Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            CopyFolder(dir.FullName, dest);
                        }
                        else
                        {
                            FileInfo file = (FileInfo)listViewRight.SelectedItems[i].Tag;
                            string name = Path.GetFileName(file.FullName);
                            string dest = Path.Combine(curDirLeft.FullName, name);

                            if (File.Exists(dest))
                            {
                                DialogResult dlr = MessageBox.Show(name + " existed! Do you want to overwrite? Yes (Overwrite), No (Skip)", "Replace file", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dlr == DialogResult.Yes)
                                {
                                    try { File.Copy(file.FullName, dest, true); }
                                    catch (IOException er)
                                    {
                                        MessageBox.Show(er.Message);
                                    }
                                }
                                else if (dlr == DialogResult.No)
                                    break;
                            }
                            else
                            {
                                try { File.Copy(file.FullName, dest); }
                                catch (IOException er)
                                {
                                    MessageBox.Show(er.Message);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void NotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor = "notepad.exe";
        }

        private bool showHidden = false;
        private void ShowHiddenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showHidden = !showHidden;
        }

        private void WordpadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor = "wordpad.exe";
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (focusOn == isFocus.Left)
            {
                if (listViewLeft.SelectedItems.Count == 1)
                {
                    if (listViewLeft.SelectedItems[0].Tag.GetType() == typeof(FileInfo))
                    {
                        FileInfo file = (FileInfo)listViewLeft.SelectedItems[0].Tag;
                        editor = file.FullName;
                    }
                    else MessageBox.Show("This's not a editor");
                }
                else
                {
                    MessageBox.Show("Please choose ONE item!");
                }
            }
            else
            {
                if (listViewRight.SelectedItems.Count == 1)
                {
                    if (listViewRight.SelectedItems[0].Tag.GetType() == typeof(FileInfo))
                    {
                        FileInfo file = (FileInfo)listViewRight.SelectedItems[0].Tag;
                        editor = file.FullName;
                    }
                    else MessageBox.Show("This's not a editor");
                }
                else
                {
                    MessageBox.Show("Please choose ONE item!");
                }
            }
        }

        private void MoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (focusOn == isFocus.Left)
            {
                if (listViewLeft.SelectedItems.Count > 0)
                {
                    DialogResult confirm = MessageBox.Show("Confirm Move!", "Move Option", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Cancel)
                        return;
                    for (int i = 0; i < listViewLeft.SelectedItems.Count; i++)
                    {
                        if (listViewLeft.SelectedItems[i].Tag.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo dir = (DirectoryInfo)listViewLeft.SelectedItems[i].Tag;
                            if (dir.FullName == curDirRight.FullName)
                            {
                                MessageBox.Show("The destination folder is a subfolder the source folder", "Interrupted Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            string dest = Path.Combine(curDirRight.FullName, dir.Name);
                            Directory.Move(dir.FullName, dest);
                        }
                        else
                        {
                            FileInfo file = (FileInfo)listViewLeft.SelectedItems[i].Tag;
                            string name = Path.GetFileName(file.FullName);
                            string dest = Path.Combine(curDirRight.FullName, name);

                            if (File.Exists(dest))
                            {
                                DialogResult dlr = MessageBox.Show(name + " existed! Do you want to overwrite? Yes (Overwrite), No (Skip)", "Replace file", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dlr == DialogResult.Yes)
                                {
                                    try
                                    {
                                        File.Copy(file.FullName, dest, true);
                                        File.Delete(file.FullName);
                                    }
                                    catch (IOException er)
                                    {
                                        MessageBox.Show(er.Message);
                                    }
                                }
                                else if (dlr == DialogResult.No)
                                    break;
                            }
                            else
                            {
                                try { File.Move(file.FullName, dest); }
                                catch (IOException er)
                                {
                                    MessageBox.Show(er.Message);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (listViewRight.SelectedItems.Count > 0)
                {
                    DialogResult confirm = MessageBox.Show("Confirm Move!", "Move Option", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Cancel)
                        return;
                    for (int i = 0; i < listViewRight.SelectedItems.Count; i++)
                    {
                        if (listViewRight.SelectedItems[i].Tag.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo dir = (DirectoryInfo)listViewRight.SelectedItems[i].Tag;
                            if (dir.FullName == curDirLeft.FullName)
                            {
                                MessageBox.Show("The destination folder is a subfolder the source folder", "Interrupted Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            string dest = Path.Combine(curDirLeft.FullName, dir.Name);
                            Directory.Move(dir.FullName, dest);
                        }
                        else
                        {
                            FileInfo file = (FileInfo)listViewRight.SelectedItems[i].Tag;
                            string name = Path.GetFileName(file.FullName);
                            string dest = Path.Combine(curDirLeft.FullName, name);

                            if (File.Exists(dest))
                            {
                                DialogResult dlr = MessageBox.Show(name + " existed! Do you want to overwrite? Yes (Overwrite), No (Skip)", "Replace file", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dlr == DialogResult.Yes)
                                {
                                    try
                                    {
                                        File.Copy(file.FullName, dest, true);
                                        File.Delete(file.FullName);
                                    }
                                    catch (IOException er)
                                    {
                                        MessageBox.Show(er.Message);
                                    }
                                }
                                else if (dlr == DialogResult.No)
                                    break;
                            }
                            else
                            {
                                try { File.Move(file.FullName, dest); }
                                catch (IOException er)
                                {
                                    MessageBox.Show(er.Message);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (focusOn == isFocus.Left)
            {
                if (listViewLeft.SelectedItems.Count > 0)
                {
                    DialogResult dlr = MessageBox.Show("Confirm Delete!", "Delete Option", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Cancel)
                        return;
                    for (int i = 0; i < listViewLeft.SelectedItems.Count; i++)
                    {
                        if (listViewLeft.SelectedItems[i].Tag.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo dir = (DirectoryInfo)listViewLeft.SelectedItems[i].Tag;
                            if (checkExitsFile(dir))
                            {
                                dlr = MessageBox.Show(dir.Name + " contains items! Want to delete?", "Contains item!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                if (dlr == DialogResult.Cancel)
                                    break;
                                try { dir.Delete(true); refreshListView(); }
                                catch (IOException er)
                                {
                                    MessageBox.Show(er.Message);
                                }
                            }
                            else
                            {
                                try { dir.Delete(true); }
                                catch (IOException er)
                                {
                                    MessageBox.Show(er.Message);
                                }
                            }
                        }
                        else
                        {
                            FileInfo file = (FileInfo)listViewLeft.SelectedItems[i].Tag;
                            try { file.Delete();}
                            catch (IOException er)
                            {
                                MessageBox.Show(er.Message);
                            }
                        }
                    }
                }
            }
            else
            {
                if (listViewRight.SelectedItems.Count > 0)
                {
                    DialogResult dlr = MessageBox.Show("Confirm Delete!", "Delete Option", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Cancel)
                        return;
                    for (int i = 0; i < listViewRight.SelectedItems.Count; i++)
                    {
                        if (listViewRight.SelectedItems[i].Tag.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo dir = (DirectoryInfo)listViewRight.SelectedItems[i].Tag;
                            if (checkExitsFile(dir))
                            {
                                dlr = MessageBox.Show(dir.Name + " contains items! Want to delete?", "Contains item!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                if (dlr == DialogResult.Cancel)
                                    break;
                                try { dir.Delete(true); refreshListView(); }
                                catch (IOException er)
                                {
                                    MessageBox.Show(er.Message);
                                }
                            }
                            else
                            {
                                try { dir.Delete(true); refreshListView(); }
                                catch (IOException er)
                                {
                                    MessageBox.Show(er.Message);
                                }
                            }
                        }
                        else
                        {
                            FileInfo file = (FileInfo)listViewRight.SelectedItems[i].Tag;
                            try { file.Delete(); }
                            catch (IOException er)
                            {
                                MessageBox.Show(er.Message);
                            }
                        }
                    }
                }
            }
            refreshListView();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Application.ExitThread();
            this.Close();
            this.Dispose();
        }

        private void ListViewLeft_MouseUp(object sender, MouseEventArgs e)
        {
            focusOn = isFocus.Left;
            if(e.Button == MouseButtons.Right && listViewLeft.SelectedItems.Count != 0)
            {
                contextMenuStrip1.Show(this, this.PointToClient(MousePosition));
            }
            else if (e.Button == MouseButtons.Right && listViewRight.SelectedItems.Count == 0)
            {
                contextMenuStrip2.Show(this, this.PointToClient(MousePosition));
            }
        }

        private void ListViewRight_MouseUp(object sender, MouseEventArgs e)
        {
            focusOn = isFocus.Right;
            if (e.Button == MouseButtons.Right && listViewRight.SelectedItems.Count != 0)
            {
                contextMenuStrip1.Show(this, this.PointToClient(MousePosition));
            }
            else if(e.Button == MouseButtons.Right && listViewRight.SelectedItems.Count == 0)
            {
                contextMenuStrip2.Show(this, this.PointToClient(MousePosition));
            }
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (focusOn == isFocus.Left)
                openDirectoryLeft();
            else openDirectoryRight();
        }

        private void RefreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (focusOn == isFocus.Left)
                openDirectoryLeft();
            else openDirectoryRight();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TotalCommander - 1753030 - Mai Thanh Binh \n Individual Project \n WindowsForm", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
