using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DemoProjectWPF.Models;

namespace DemoProjectWPF.ViewModels;

public class LanguageViewModel : INotifyPropertyChanged
{
    private ObservableCollection<LanguageModel> _supportedLanguages;
    public ObservableCollection<LanguageModel> SupportedLanguages
    {
        get => _supportedLanguages;
        set
        {
            value = _supportedLanguages;
            OnPropertyChanged(nameof(_supportedLanguages));
        }
    }

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
            new LanguageModel() { Name = "en", CultureInfo = "en-US" },
            new LanguageModel() { Name = "zh", CultureInfo = "zh-HANS" },
            new LanguageModel() { Name = "es", CultureInfo = "es-ES" }
        };
    }
    
    


    #region NotifyPropertyChanged

    public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

    #endregion
}