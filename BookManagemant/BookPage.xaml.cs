using DTO.Models;
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
    /// Interaction logic for BookPage.xaml
    /// </summary>
    public partial class BookPage : Window
    {
        private readonly BookRepository _bookRepository;
        public BookPage()
        {
             _bookRepository = new BookRepository();
            InitializeComponent();
            LoadBooks();
        }

        public void LoadBooks()
        {
            List<Book> books = _bookRepository.GetAll();
            gvt_ViewBook.ItemsSource = books ?? new List<Book>();

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


        private void btn_User_Click(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            Hide();
            adminPage.Show();
        }

        private void gvt_ViewBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            AddBook addBook = new AddBook();
            addBook.ShowDialog();

        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            Book deleteBook = (Book)gvt_ViewBook.SelectedItem;
            if (deleteBook != null)
            {
                _bookRepository.Delete(deleteBook);
                LoadBooks();
            }
            else
            {
                MessageBox.Show("Update Book Error");
            }
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            Book updateBook = (Book)gvt_ViewBook.SelectedItem;
            if (updateBook != null)
            {
                _bookRepository.Update(updateBook);
                LoadBooks();
            }else
            {
                MessageBox.Show("Update Book Error");
            }
        }
    }
}
