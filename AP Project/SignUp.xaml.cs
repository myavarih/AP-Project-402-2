using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AP_Project
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            string Email = EmailTxtBx.Text;
            string FirstName = FirstNameTxtBx.Text;
            string LastName = LastNameTxtBx.Text;
            string PhoneNumber = PhoneNumberTxtBx.Text;
            string Username = UsernameTxtBx.Text;
            try
            {
                MailMessage mail = new MailMessage();


                mail.From = new MailAddress("myavarih@gmail.com");
                mail.To.Add("myavarih@gmail.com");
                mail.Subject = "Vertification Code";
                mail.Body = "Your Vertification Code 618779";


                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";
                smtp.UseDefaultCredentials = false;
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("myavarih@gmail.com", "gxey vnsz vbvt damr");
                smtp.EnableSsl = true;

                smtp.Send(mail);
            }
            catch
            {
                Console.WriteLine("didn't work");
            }
            PasswordWindow passwordWindow = new PasswordWindow();
            passwordWindow.Show();
            this.Close();
        }
    }
}
