using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CoreWpfFramework.Commands;
using CoreWpfFramework.ViewModels;
#pragma warning disable CS1591
#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented

namespace CoreWpfFramework.ViewModels
{
    public partial class SampleViewModel : ViewModelBase
    {
        partial void OnSamplePropertyChanging(ref string newValue);

        partial void OnSamplePropertyChanged();

        private string sampleProperty = string.Empty;

        public string SampleProperty
        {
            get { return sampleProperty; }
            set
            {
                var newValue = value;
                OnSamplePropertyChanging(ref newValue);
                if (SetProperty<string>(ref sampleProperty, newValue))
                {
                    ValidateProperty();
                    OnSamplePropertyChanged();
                }
            }
        }
    
        partial void OnSampleCollectionChanging(ref ObservableCollection<string> newValue);

        partial void OnSampleCollectionChanged();
        
        private ObservableCollection<string> sampleCollection = new ObservableCollection<string>();

        public ObservableCollection<string> SampleCollection
        {
            get { return sampleCollection; }
            set
            {
                var newValue = value;
                OnSampleCollectionChanging(ref newValue);
                if (SetProperty<ObservableCollection<string>>(ref sampleCollection, newValue))
                {
                    ValidateProperty();
                    OnSampleCollectionChanged();
                }
            }
        }
    
        partial void OnSampleCommandChanging(ref IDelegateCommand newValue);

        partial void OnSampleCommandChanged();

        private IDelegateCommand sampleCommand = new DelegateCommand();

        public IDelegateCommand SampleCommand
        {
            get { return sampleCommand; }
            set
            {
                var newValue = value;
                OnSampleCommandChanging(ref newValue);
                if (SetProperty<IDelegateCommand>(ref sampleCommand, newValue))
                {
                    OnSampleCommandChanged();
                }
            }
        }
    }
}

#pragma warning restore SA1601 // PartialElementsMustBeDocumented
#pragma warning restore SA1600 // ElementsMustBeDocumented
#pragma warning restore CS1591
