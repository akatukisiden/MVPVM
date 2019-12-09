using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using UwpFramework.Commands;
using UwpFramework.ViewModels;
using Windows.UI.Xaml;

#pragma warning disable CS1591
#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented

namespace UwpApp.ViewModels
{
    public partial class Page2ViewModel : ViewModelBase
    {
        partial void OnTextChanging(ref string newValue);

        partial void OnTextChanged();

        private string text = string.Empty;

        public string Text
        {
            get { return text; }
            set
            {
                var newValue = value;
                OnTextChanging(ref newValue);
                if (SetProperty<string>(ref text, newValue))
                {
                    ValidateProperty();
                    OnTextChanged();
                }
            }
        }
    
        partial void OnInputCollectionChanging(ref ObservableCollection<string> newValue);

        partial void OnInputCollectionChanged();
        
        private ObservableCollection<string> inputCollection = new ObservableCollection<string>();

        public ObservableCollection<string> InputCollection
        {
            get { return inputCollection; }
            set
            {
                var newValue = value;
                OnInputCollectionChanging(ref newValue);
                if (SetProperty<ObservableCollection<string>>(ref inputCollection, newValue))
                {
                    ValidateProperty();
                    OnInputCollectionChanged();
                }
            }
        }
    
        partial void OnSampleCommandChanging(ref DelegateCommand newValue);

        partial void OnSampleCommandChanged();

        private DelegateCommand sampleCommand = new DelegateCommand();

        public DelegateCommand SampleCommand
        {
            get { return sampleCommand; }
            set
            {
                var newValue = value;
                OnSampleCommandChanging(ref newValue);
                if (SetProperty<DelegateCommand>(ref sampleCommand, newValue))
                {
                    OnSampleCommandChanged();
                }
            }
        }
        partial void OnClickEventChanging(ref RoutedEventHandler newValue);

        partial void OnClickEventChanged();
        
        private RoutedEventHandler clickEvent;

        
        public RoutedEventHandler ClickEvent
        {
            get { return clickEvent; }
            set
            {
                var newValue = value;
                OnClickEventChanging(ref newValue);
                if(clickEvent != newValue)
                {
                    clickEvent = newValue;
                    OnPropertyChanged("ClickEvent");
                    OnClickEventChanged();
                }
            }
        }
        
    }
}

#pragma warning restore SA1601 // PartialElementsMustBeDocumented
#pragma warning restore SA1600 // ElementsMustBeDocumented
#pragma warning restore CS1591
