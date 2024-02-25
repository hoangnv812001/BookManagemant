using BusinessObject;
using DTO.Models;
using Microsoft.VisualBasic.ApplicationServices;
using Repository;
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
using MessageBox = System.Windows.MessageBox;

namespace BookManagemant
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Window
    {
        private readonly AccountRepository _accountRepository ;
        public AdminPage()
        {
            _accountRepository = new AccountRepository();
            InitializeComponent();
            LoadAccounts();
        }
        
        private void gvt_View_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            
        }
        public void LoadAccounts()
        {
            List<Account> accounts = _accountRepository.GetAll();
            gvt_View.ItemsSource = accounts ?? new List<Account>();

        }

        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Windows[0].Show();
            for (int i = 1; i < System.Windows.Application.Current.Windows.Count; i++)
            {
                System.Windows.Application.Current.Windows[i].Close();
            }
            Close();
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
          
            Account UpdateAccount = (Account)gvt_View.SelectedItem;
            if (UpdateAccount != null)
            {
                _accountRepository.Update(UpdateAccount);
                LoadAccounts();
            }
            else
            {
                MessageBox.Show("Update Error");
            }

        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            Account SelectAccount = (Account)gvt_View.SelectedItem;
            if(SelectAccount != null)
            {
                _accountRepository.Delete(SelectAccount);
                LoadAccounts();
            }
            else
            {
                MessageBox.Show("error");
            }
           
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            AddUser addNewUser = new AddUser();
            addNewUser.Closed += (_, _) => LoadAccounts();
            addNewUser.ShowDialog();
        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               Account searchAccount = (Account)gvt_View.SelectedItem;
                if (searchAccount != null)
                {

                }
            }catch (Exception ex)
            {
                MessageBox.Show("the Name is not exit!");
            }
        }

        private void btn_Book_Click(object sender, RoutedEventArgs e)
        {
            BookPage bookPage = new BookPage();
            Hide();
            bookPage.ShowDialog();
        }
    }
}
