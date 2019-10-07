using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace Samples
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Password1
        {
            get => m_Password1;
            set { m_Password1 = value; OnPropertyChanged(nameof(Password1)); }
        }
        private string m_Password1 = null;

        public string Password2
        {
            get => m_Password2;
            set { m_Password2 = value; OnPropertyChanged(nameof(Password2)); }
        }
        private string m_Password2 = null;

        public bool ShowText
        {
            get => m_ShowText;
            set { m_ShowText = value; OnPropertyChanged(nameof(ShowText)); }
        }
        private bool m_ShowText = false;

        public bool ShowPassword2
        {
            get => m_ShowPassword2;
            set { m_ShowPassword2 = value; OnPropertyChanged(nameof(ShowPassword2)); }
        }
        private bool m_ShowPassword2 = false;

        public RelayCommand ShowTextCommand { private set; get; }
        public RelayCommand ShowPassword2Command { private set; get; }
        public RelayCommand LoginCommand { private set; get; }


        public MainWindowViewModel()
        {
            ShowTextCommand = new RelayCommand(ShowTextCommandProc);
            ShowPassword2Command = new RelayCommand(ShowPassword2CommandProc);
            LoginCommand = new RelayCommand(LoginCommandProc);
        }

        private void ShowTextCommandProc()
        {
            ShowText = !ShowText;
        }

        private void ShowPassword2CommandProc()
        {
            ShowPassword2 = !ShowPassword2;
        }

        private void LoginCommandProc()
        {
            MessageBox.Show($"your login password is {Password2}");
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return;
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
