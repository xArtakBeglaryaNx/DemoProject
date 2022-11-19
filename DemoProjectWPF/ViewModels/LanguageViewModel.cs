using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DemoProjectWPF.Models;
using DemoProjectWPF.Properties;

namespace DemoProjectWPF.ViewModels;

public sealed class LanguageViewModel : INotifyPropertyChanged
{
    public ObservableCollection<LanguageModel> SupportedLanguages { get; set; }

    private LanguageModel _selectedLanguage;
    public LanguageModel SelectedLanguage
    {
        get => _selectedLanguage;
        set
        {
            value = _selectedLanguage;
            OnPropertyChanged();
        }
    }

    public LanguageViewModel()
    {
        SupportedLanguages = new ObservableCollection<LanguageModel>()
        {
            new LanguageModel() { LanguageName = "English", CultureInfo = "en-US" },
            new LanguageModel() { LanguageName = "简体中文", CultureInfo = "zh-HANS" },
            new LanguageModel() { LanguageName = "Español", CultureInfo = "es-ES" }
        };
    }

    public void SelectLanguage(int index)
    {
        switch (index)
        {
            case 0:
                Settings.Default.langCode = "en-US";
                App.ChangeCulture(Settings.Default.langCode);
                Settings.Default.defaultIndexCombobox = index;
                break;
            case 1:
                Settings.Default.langCode = "zh-HANS";
                App.ChangeCulture(Settings.Default.langCode);
                Settings.Default.defaultIndexCombobox = index;
                break;
            case 2:
                Settings.Default.langCode = "es-ES";
                App.ChangeCulture(Settings.Default.langCode);
                Settings.Default.defaultIndexCombobox = index;
                break;
        }
        Settings.Default.Save();
    }

    #region NotifyPropertyChanged

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

    #endregion
}