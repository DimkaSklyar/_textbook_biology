using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;

namespace TextBook_Biology
{
    public partial class ResetPassword : Telerik.WinControls.UI.RadForm
    {
        string path = Application.StartupPath;
        string[] autorization = new string[2];
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (radTextBox1.Text != "" && radTextBox2.Text != "" && radTextBox3.Text != "" && radTextBox4.Text != "")
            {
                FileStream file = new FileStream(path + "\\settings.ini", FileMode.Open, FileAccess.ReadWrite);
                StreamReader streamReader = new StreamReader(file);
                autorization[0] = Crypto.DecryptStringAES(streamReader.ReadLine(), "key_1");
                autorization[1] = Crypto.DecryptStringAES(streamReader.ReadLine(), "key_1");
                streamReader.Close();
                file.Close();
                if (autorization[0] == radTextBox1.Text && autorization[1] == radTextBox3.Text)
                {
                    FileStream filestream = new FileStream(path + "\\settings.ini", FileMode.Truncate, FileAccess.ReadWrite);
                    StreamWriter streamWriter = new StreamWriter(filestream);
                    var new_login = Crypto.EncryptStringAES(radTextBox2.Text, "key_1");
                    var new_password = Crypto.EncryptStringAES(radTextBox2.Text, "key_1");
                    streamWriter.WriteLine(new_login);
                    streamWriter.WriteLine(new_password);
                    streamWriter.Close();
                    filestream.Close();
                    DialogResult res = MessageBox.Show("Логин и пароль изменён!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (res == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                else
                {
                    DialogResult res = MessageBox.Show("Неверное имя пользователя или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                }
            }
            else
            {
                MessageBox.Show("Поля не должны быть пусты!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
