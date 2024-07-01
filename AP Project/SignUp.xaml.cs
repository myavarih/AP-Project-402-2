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
    public partial class SignUp : Page
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            
            Data.CurrentUser.Email = EmailTxtBx.Text;
            Data.CurrentUser.FirstName = FirstNameTxtBx.Text;
            Data.CurrentUser.LastName = LastNameTxtBx.Text;
            Data.CurrentUser.PhoneNumber = PhoneNumberTxtBx.Text;
            Data.CurrentUser.Username = UsernameTxtBx.Text;
            Validation.verificationCode = new Random().Next(1000, 9999);
            try
            {
                Validation.UserSignUpFieldsCheck(Data.CurrentUser.FirstName, Data.CurrentUser.LastName, Data.CurrentUser.PhoneNumber, Data.CurrentUser.Username, Data.CurrentUser.Email);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
                return;
            }

            try // send Email
            {
                MailMessage mail = new MailMessage();


                mail.From = new MailAddress("myavarih@gmail.com");
                mail.To.Add(Data.CurrentUser.Email);
                mail.Subject = "Verification Code";
                mail.Body = "Your Verification Code " + Validation.verificationCode;


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
                MessageBox.Show("Failed To Send Email!");
                return;
            }

            PasswordWindow passwordWindow = new PasswordWindow();
            passwordWindow.Show();
            // this.Close();
        }
    }
}
