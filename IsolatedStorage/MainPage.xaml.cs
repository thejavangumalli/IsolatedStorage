using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using IsolatedStorage.Resources;
using System.IO.IsolatedStorage;
using System.IO;
using System.Runtime.InteropServices;

namespace IsolatedStorage
{
    public partial class MainPage : PhoneApplicationPage
    {
        int i = 1;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Terminate();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            saveBook("book.txt", "Book" + i++ + "\r\n BookName:" + name.Text + "\r\n AuthorName:" + author.Text + "\r\n Description:" + description.Text);
            MessageBox.Show("Book  "+name.Text+ "  Saved Successfully");
            name.Text = "Max 70. Characters";
            author.Text = "Max 70. Characters";
            description.Text = "Max 255. Characters";
        }
        private void saveBook(string filename, string text)
        {
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (isf.FileExists(filename))
                {
                    using (IsolatedStorageFileStream rawStream = new IsolatedStorageFileStream(filename, FileMode.Append, isf))
                    {   
                        StreamWriter writer = new StreamWriter(rawStream); writer.Write(text+"\r\n"); writer.Close();
                    }
                }
                else
                {
                    using (IsolatedStorageFileStream rawStream = new IsolatedStorageFileStream(filename, FileMode.CreateNew, isf))
                    {
                        StreamWriter writer = new StreamWriter(rawStream); writer.Write(text+"\r\n"); writer.Close();
                    }
                }
            }
        }
        
    }
}