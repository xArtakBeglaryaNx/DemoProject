using System;
using System.Windows;
using System.Windows.Controls;
using DemoProjectWPF.Properties;
using DemoProjectWPF.ViewModels;
using MaterialDesignThemes.Wpf;

namespace DemoProjectWPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public LanguageViewModel LanguageViewModel { get; set; } = new LanguageViewModel();
        private AddEmployeeView AddEmployeeView { get; set; } = new AddEmployeeView();

        public MainWindow()
        {
            InitializeComponent();
            LanguageComboBox.SelectedIndex = Settings.Default.defaultIndexCombobox;
        }

        private void LanguageComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LanguageViewModel.SelectLanguage(LanguageComboBox.SelectedIndex);
        }

        private void AddEmployeeButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddEmployeeView.AddEmployeeTabItem.Header = LangResources.Language.menuAdd;
            EmployeesTabControl.Items.Add(AddEmployeeView);
            EmployeesTabControl.SelectedItem = AddEmployeeView;
        }
    }
}