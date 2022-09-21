using System.Text;

namespace Rijndael_Encryption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var AES = new System.Security.Cryptography.RijndaelManaged();
            var Hash_AES = new System.Security.Cryptography.MD5CryptoServiceProvider();
            string encrypted = "";
            try
            {
                var hash = new byte[32];
                var temp = Hash_AES.ComputeHash(Encoding.ASCII.GetBytes("PASSWORD"));
                Array.Copy(temp, 0, hash, 0, 16);
                Array.Copy(temp, 0, hash, 15, 16);
                AES.Key = hash;
                AES.Mode = System.Security.Cryptography.CipherMode.ECB;
                var DESEncrypter = AES.CreateEncryptor();
                var Buffer = Encoding.ASCII.GetBytes(textBox1.Text);
                encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length));
                textBox2.Text = encrypted;
            }
            catch (Exception)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var AES = new System.Security.Cryptography.RijndaelManaged();
            var Hash_AES = new System.Security.Cryptography.MD5CryptoServiceProvider();
            string decrypted = "";
            try
            {
                var hash = new byte[32];
                var temp = Hash_AES.ComputeHash(Encoding.ASCII.GetBytes("PASSWORD"));
                Array.Copy(temp, 0, hash, 0, 16);
                Array.Copy(temp, 0, hash, 15, 16);
                AES.Key = hash;
                AES.Mode = System.Security.Cryptography.CipherMode.ECB;
                var DESDecrypter = AES.CreateDecryptor();
                var Buffer = Convert.FromBase64String(textBox2.Text);
                decrypted = Encoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length));
                textBox3.Text = decrypted;
            }
            catch (Exception ex)
            {
            }
        }
    }
}