using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TextBook_Biology
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        AddTextbookForm addTextbook;
        string path = Application.StartupPath;
        public MainForm()
        {
            InitializeComponent();
        }
        void saveList()
        {

            FileStream file = new FileStream(path + "\\listTextBook.lst", FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(file, Encoding.Default);
            for (int i = 0; i < listTextbook.Items.Count; i++)
            {
                streamWriter.WriteLine(listTextbook.Items[i].ToString());
            }
            streamWriter.Close();
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            if (addTextbook == null)
            {
                addTextbook = new AddTextbookForm(this);
                addTextbook.Show();
            }
            else if (addTextbook.IsDisposed)
            {
                AddTextbookForm addTextbook = new AddTextbookForm(this);
                addTextbook.Show();
            }
        }

        private void removeBotton_Click(object sender, EventArgs e)
        {

            var item = this.listTextbook.SelectedItem;
            if (item != null)
            {
                DialogResult res = MessageBox.Show("Вы уверены что хотете удалить " + item.Text + "? Все страницы учебника будут удалены!", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (res == DialogResult.OK)
                {
                    try
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(path + "\\" + item);
                        directoryInfo.Delete(true);
                        listTextbook.Items.Remove(item);
                    }
                    catch (Exception)
                    {
                        DialogResult res2 = MessageBox.Show("Выбранный учебник " + item.Text + ", был удалён или перенесён. Удалить выделеную строку?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (res2 == DialogResult.OK)
                        {
                            listTextbook.Items.Remove(item);
                        }
                    }
                    saveList();
                }
            }
            
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            listTextbook.Items.Clear();
            StreamReader streamReader = new StreamReader(path + "\\listTextBook.lst", Encoding.Default);
            while (!streamReader.EndOfStream)
            {
                listTextbook.Items.Add(streamReader.ReadLine());
            }
            streamReader.Close();
        }
    }
}
