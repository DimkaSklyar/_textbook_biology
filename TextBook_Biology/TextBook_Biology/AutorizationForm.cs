using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;
using System.Security.Cryptography;


namespace TextBook_Biology
{
    public partial class AutorizationForm : Telerik.WinControls.UI.RadForm
    {
        string path = Application.StartupPath;
        string[] autorization = new string[2] { "1", "1" };
        internal bool sigInON = false;
        MainForm mainForm;
        public AutorizationForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            FileStream file = new FileStream(path + "\\settings.ini", FileMode.Open, FileAccess.ReadWrite);
            StreamReader streamReader = new StreamReader(file);
            autorization[0] = Crypto.DecryptStringAES(streamReader.ReadLine(), "key_1");
            autorization[1] = Crypto.DecryptStringAES(streamReader.ReadLine(), "key_1");
            if (autorization[0] == radTextBox1.Text && autorization[1] == radTextBox2.Text)
            {
                sigInON = true;
                MessageBox.Show("Добро пожаловать, Администратор!");
                mainForm.addButton.Enabled = true;
                mainForm.removeBotton.Enabled = true;
                mainForm.SingInOn = true;
                mainForm.exitButton.Visible = true;
                streamReader.Close();
                Close();
            }
            else
            {
                sigInON = false;
                MessageBox.Show("Неверное имя пользователя или пароль!");
                file.Close();
                streamReader.Close();

            }
        }

        private void AutorizationForm_Shown(object sender, EventArgs e)
        {
            try
            {
                FileStream file = new FileStream(path + "\\settings.ini", FileMode.CreateNew, FileAccess.ReadWrite);
                StreamWriter streamWriter = new StreamWriter(file);
                var encryptedStringAES = Crypto.EncryptStringAES(autorization[0], "key_1");
                streamWriter.WriteLine(encryptedStringAES);
                streamWriter.WriteLine(encryptedStringAES);
                streamWriter.Close();
                MessageBox.Show("Файл настроек был удалён! Если идёт первоначальная настройка программы, игнорируйте это сообщение, иначе, обратитесь к системному администратору!");
            }
            catch (Exception)
            {
                
       
            }
        }
    }
}
