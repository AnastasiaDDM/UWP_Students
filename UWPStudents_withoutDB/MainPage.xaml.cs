using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace UWPStudents_withoutDB
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var t = (ListBoxItem)e.AddedItems[0];
            if (t.Name == "menu_main")
            {
                frx.Navigate(typeof(MainPage));
            }
            if (t.Name == "menu_students")
            {

                frx.Navigate(typeof(Students));
            }

            if (t.Name == "menu_groups")
            {

                frx.Navigate(typeof(Groups));
            }

            if (t.Name == "menu_rating")
            {

                frx.Navigate(typeof(Rating));
            }

        }

        private void menu_Click(object sender, RoutedEventArgs e)
        {
            menu_list.IsPaneOpen = !menu_list.IsPaneOpen;
        }
    }
}
