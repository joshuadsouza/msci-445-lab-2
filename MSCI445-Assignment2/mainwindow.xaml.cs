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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Mail;

namespace MSCI445_Assignment2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		// Initialize Variable Fields to Store Information
		string to = null;
		string from = null;
		string subject = null;
		string body = null;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void To_Field_TextChanged(object sender, TextChangedEventArgs e)
		{
			TextBox to = (TextBox)sender;
			this.to = to.Text;
		}

		private void From_Field_TextChanged(object sender, TextChangedEventArgs e)
		{
			TextBox from = (TextBox)sender;
			this.from = from.Text;
		}

		private void Subject_Field_TextChanged(object sender, TextChangedEventArgs e)
		{
			TextBox subject = (TextBox)sender;
			this.subject = subject.Text;
		}

		private void Body_Field_TextChanged(object sender, TextChangedEventArgs e)
		{
			TextBox body = (TextBox)sender;
			this.body = body.Text;
		}

		// For the Send Button Click
		private void Button_Click(object sender, RoutedEventArgs e)
		{

			// Check the fields and show a message if a field is wrong
			// This if statement is to check if the user has entered any details in the fields at all 
			if (this.to == null || this.from == null || this.subject == null || this.body == null) {
				MessageBox.Show("Please make sure you fill out all the fields!");
				return;
			}

			//This if statement checks if the subject and body fields have more than one character
			if (this.subject.Length == 0 || this.body.Length == 0)
			{
				MessageBox.Show("Please enter in some text for your email.");
				return;
			}

			// Check the Email formats and show a message if the email format is wrong
			bool toEmailCheck = this.CheckEmail(this.to, false);
			bool fromEmailCheck = this.CheckEmail(this.from, true);
			
			if (toEmailCheck == false || fromEmailCheck == false)
			{
				MessageBox.Show("Please ensure you entered in the correct e-mails.");
				return;
			}

			// Show the new Form Window
			Window1 passwordForm = new Window1(this.to, this.from, this.subject, this.body);
			passwordForm.Show();

		}

		private bool CheckEmail(string email, bool fromEmail)
		{
			try
			{
				var addr = new System.Net.Mail.MailAddress(email);

				if (fromEmail == true)
				{
					if (!email.Contains("gmail.com"))
					{
						MessageBox.Show("'From:' email can only be a Gmail account :(");
						return false;
					}
				}

				if (!email.Contains("."))
				{
					return false;
				}

				return addr.Address == email;
			}
			catch
			{
				return false;
			}
		}


	}
		

}
