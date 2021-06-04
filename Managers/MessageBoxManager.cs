using System;
using System.Windows;

namespace DogsExhibitionsSystem.Managers
{
    public class MessageBoxManager
    {
        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }

        public void ShowException(Exception ex)
        {
            MessageBox.Show($"{ex}\ninner expetion\n{ex.InnerException}");
        }
    }
}
