using System;
using System.Windows;
using System.Windows.Controls;
using DemoProjectWPF.Properties;
using DemoProjectWPF.ViewModels;

namespace DemoProjectWPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public LanguageViewModel LanguageViewModel { get; set; } = new LanguageViewModel();

        public MainWindow()
        {
            InitializeComponent();
            LanguageComboBox.SelectedIndex = Settings.Default.defaultIndexCombobox;
        }

        private void LanguageComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LanguageViewModel.SelectLanguage(LanguageComboBox.SelectedIndex);
        }
    }
}