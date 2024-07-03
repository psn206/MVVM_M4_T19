using MVVM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        double input;
        double output;
        public double Input
        {
            get => input;
            set
            {
                input = value;
                OnPropertyChenged();
            }
        }

        public double Output
        {
            get => output;
            set
            {
                output = value;
                OnPropertyChenged();
            }
        }

        public MainWindowViewModel()
        {
            GetСircumference = new RelayCommand(OnСircumferenceCommandExecut, CanСircumferenceCommandExecut);
        }

        void OnPropertyChenged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public ICommand GetСircumference { get; }
        private void OnСircumferenceCommandExecut(Object p)
        {
            Output = CalcGeometry.Сircumference(Input);
        }
        private bool CanСircumferenceCommandExecut(Object p)
        {
            if (Input != 0)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }
      
    }
}
