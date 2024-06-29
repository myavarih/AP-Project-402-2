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
            
            Data.CUEmail = EmailTxtBx.Text;
            Data.CUFirstName = FirstNameTxtBx.Text;
            Data.CULastName = LastNameTxtBx.Text;
            Data.CUPhoneNumber = PhoneNumberTxtBx.Text;
            Data.CUUsername = UsernameTxtBx.Text;
            Validation.verificationCode = new Random().Next(1000, 9999);
            try
            {
                Validation.UserSignUpFieldsCheck(Data.CUFirstName, Data.CULastName, Data.CUPhoneNumber, Data.CUUsername, Data.CUEmail);
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
                mail.To.Add(Data.CUEmail);
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
            this.Close();
        }
    }
}
