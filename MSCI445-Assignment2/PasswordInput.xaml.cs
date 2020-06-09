using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Net.Mail;


namespace MSCI445_Assignment2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
		string to = null;
		string from = null;
		string subject = null;
		string body = null;

		public Window1(string to, string from, string subject, string body)
		{
			InitializeComponent();
			this.to = to;
			this.from = from;
			this.subject = subject;
			this.body = body;
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void SubmitButton_Click(object sender, RoutedEventArgs e)
		{
			var password = PasswordField.Password;

			if (password.Length == 0)
			{
				MessageBox.Show("Please enter a password");
				return;
			}

			// add from,to mailaddresses
			MailAddress from = new MailAddress(this.from);
			MailAddress to = new MailAddress(this.to);
			MailMessage mail = new System.Net.Mail.MailMessage(from, to);
			mail.Subject = this.subject;
			mail.SubjectEncoding = System.Text.Encoding.UTF8;
			mail.Body = this.body;
			mail.BodyEncoding = System.Text.Encoding.UTF8;

			SmtpClient smtp = new SmtpClient
			{
				Host = "smtp.gmail.com",
				Port = 587,
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new System.Net.NetworkCredential(this.from, password),
			};

			try
			{
				smtp.Send(mail);
				MessageBox.Show("E-mail has been sent!");
			}
			catch
			{
				MessageBox.Show("Failed to send the e-mail");
			}

		}
	}
}
