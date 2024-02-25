using DTO.Models;
using Repository;
using System.Text;
using System.Windows;
using MessageBox = System.Windows.MessageBox;


namespace BookManagemant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IAccountRepository _accountRepository;

        public MainWindow()
        {
            _accountRepository = new AccountRepository();
            InitializeComponent();
        }

        private void tbn_Login_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            if(string.IsNullOrEmpty(email) )
            {
                MessageBox.Show("Email is required");
                return;
            }
            if(string.IsNullOrEmpty(password) )
            {
                MessageBox.Show("Password is required");
                return;
            }

            bool result = _accountRepository.Login(email, password);

            if(result)
            {
                Account account;
                bool value = int.TryParse(txtEmail.Text, out int uid);
                if(value)
                {
                    account = _accountRepository.GetByID(uid)!;
                }else
                {
                    account = _accountRepository.GetByEmail(txtEmail.Text)!;
                }
                AdminPage homePage = new AdminPage();

                Hide();
                txtPassword.Clear();
                
                homePage.ShowDialog();
            }
            else
            {
                MessageBox.Show("Password incorrect or userId/Email not found");
            }
        }

        private void tbn_Close_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}