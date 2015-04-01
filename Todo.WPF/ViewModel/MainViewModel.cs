using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;
using System.Windows.Input;

namespace Todo.WPF.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            _firstName = "Aldo Martinez";

            this.Message = new RelayCommand(() => MessageBox.Show(FirstName), ()=> !string.IsNullOrWhiteSpace(FirstName));
        }

        private string _firstName = string.Empty;
        public string FirstName 
        { 
            get 
            { 
                return _firstName; 
            } 
            set 
            { 
                _firstName = value; 
                RaisePropertyChanged("FirstName"); 
            } 
        }

        public ICommand Message { get; private set; }

        private void ShowPopUpExecute()
        {
            MessageBox.Show("Hello!");
        }

    }
}