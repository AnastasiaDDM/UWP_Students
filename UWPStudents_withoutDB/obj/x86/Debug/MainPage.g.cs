﻿#pragma checksum "C:\Users\79016\Documents\Учеба\4\4-1\Мобильная разработка\LR3\UWPStudents_withoutDB\UWPStudents_withoutDB\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1BCF6782E0FFA82D1588C4364BB36CB62EAAB12D6D4C352ABE009D8384D8DC58"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UWPStudents_withoutDB
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 53
                {
                    this.g1 = (global::Windows.UI.Xaml.Controls.VariableSizedWrapGrid)(target);
                }
                break;
            case 3: // MainPage.xaml line 56
                {
                    this.tbn1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // MainPage.xaml line 58
                {
                    this.btn1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btn1).Click += this.menu_Click;
                }
                break;
            case 5: // MainPage.xaml line 60
                {
                    this.menu_list = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 6: // MainPage.xaml line 63
                {
                    global::Windows.UI.Xaml.Controls.ListBox element6 = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ListBox)element6).SelectionChanged += this.menu_SelectionChanged;
                }
                break;
            case 7: // MainPage.xaml line 64
                {
                    this.menu_students = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 8: // MainPage.xaml line 67
                {
                    this.menu_groups = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 9: // MainPage.xaml line 70
                {
                    this.menu_rating = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 10: // MainPage.xaml line 76
                {
                    this.frx = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
