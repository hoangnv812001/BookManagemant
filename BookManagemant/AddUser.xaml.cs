using BusinessObject;
using DTO.Models;
using Repository;
using System.Windows;
using System.Windows.Controls;


namespace BookManagemant
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        private readonly IAccountRepository _accountRepository;
        private Account? Account { get; set; } = new()
        {
            Email = "",
            Password = "",
            Role = -1
        };
        public AddUser()
        {
            _accountRepository = new AccountRepository();
            InitializeComponent();
            LoadComboBox();
            formGrid.DataContext = Account;
        }

        public AddUser(Account? account) : this()
        {
            Account = account;
            cbxRole.SelectedIndex = Account?.Role - 1 ?? -1;
            formGrid.DataContext = Account;
        }
        private void LoadComboBox()
        {
           cbxRole.ItemsSource = Enum.GetValues(typeof(ERole));
           cbxRole.SelectionChanged += CbxRole_SelectionChanged;
        }

        private void CbxRole_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Account!.Role = (int)cbxRole.SelectedValue;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateForm()) return;
            _accountRepository.SaveAccount(Account!);
            this.Close();
        }
        private bool ValidateForm()
        {
            if(string.IsNullOrEmpty(tbxEmail.Text) || string.IsNullOrEmpty(tbxPassword.Text) || cbxRole.SelectedItem == null)
            {
                return false;
            }

            if (cbxRole.SelectedItem == null) { return false; }

            // if email is existed
            var account = _accountRepository.GetByEmail(tbxEmail.Text);
            if (account != null) { return false; }

            return true;
        }

        private void tbxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Account != null)
            {
                Account.Password = ((System.Windows.Controls.TextBox)sender).Text;
            }
        }

        private void cbxRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Account!.Role = ((System.Windows.Controls.ComboBox)sender).SelectedIndex + 1;
        }
    }
}
