using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CoreWpfFramework.Commands;
using CoreWpfFramework.ViewModels;
#pragma warning disable CS1591
#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1601 // PartialElementsMustBeDocumented

namespace CoreWpfApp.ViewModels
{
    public partial class Page1ViewModel : ViewModelBase
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
    
    
        partial void OnCommandChanging(ref IDelegateCommand newValue);

        partial void OnCommandChanged();

        private IDelegateCommand command = new DelegateCommand();

        public IDelegateCommand Command
        {
            get { return command; }
            set
            {
                var newValue = value;
                OnCommandChanging(ref newValue);
                if (SetProperty<IDelegateCommand>(ref command, newValue))
                {
                    OnCommandChanged();
                }
            }
        }
    }
}

#pragma warning restore SA1601 // PartialElementsMustBeDocumented
#pragma warning restore SA1600 // ElementsMustBeDocumented
#pragma warning restore CS1591
