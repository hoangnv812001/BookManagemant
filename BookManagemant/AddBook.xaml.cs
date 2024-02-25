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

namespace BookManagemant
{
    /// <summary>
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        private readonly IBookRepository _bookRepository;
        private Book NewBook { get; set; } = new Book();
        public AddBook()
        {
            _bookRepository = new BookRepository();
            InitializeComponent();

        }
        public AddBook(Book book) : this()
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateForm()) return;
            _bookRepository.SaveBook(NewBook!);
            this.Close();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(tbxName.Text) || string.IsNullOrEmpty(tbxISBN.Text) || string.IsNullOrEmpty(tbxAuthorName.Text))
            {
                return false;
            }
            var books  = _bookRepository.GetByName(tbxName.Text);
            if(books != null)
            {
                return false;
            }
            return true;
        }
    }
}
