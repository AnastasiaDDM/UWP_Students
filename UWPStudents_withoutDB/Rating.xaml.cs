using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPStudents_withoutDB
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Rating : Page
    {
        public Rating()
        {
            this.InitializeComponent();
        }

        private void MinSalary_TextChanged(object sender, TextChangedEventArgs e)
        { 
            try
            {
                if (MinSalary.Text != string.Empty)
                {
                    var result = Convert.ToInt32(MinSalary.Text);
                    VM.MinSalary = result;
                }
            }
            catch
            {
                var dialog = new MessageDialog("Введите число", "Предупреждение!");
                var result1 = dialog.ShowAsync();
            }
        }

    }
}
