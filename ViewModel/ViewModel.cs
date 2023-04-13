using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;


namespace ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {       
        private readonly Model.Model model = new();

        
        public ViewModel()
        {
            StartButton = new Signal(Enable);
            StopButton = new Signal(Disable);
            model.resizeMode = ResizeMode.CanResize;
            model.isEnabled = false;
        }

        public string OrbQuantity
        {
            get
            {
                //return Convert.ToString(orbQuantity);
                return Convert.ToString(model.orbQuantity);
            }
            set
            {
                try
                {
                    //orbQuantity = Convert.ToInt32(value);
                    model.orbQuantity = Convert.ToInt32(value);
                }
                catch { }

                OnPropertyChanged(nameof(OrbQuantity));
            }
        }

        public ResizeMode ResizeMode
        {
            get { return model.resizeMode; }
            set
            {
                model.resizeMode = value;
                OnPropertyChanged(nameof(ResizeMode));
            }
        }

        public double WindowHeight
        {
            get { return model.windowHeight; }
            set
            {
                model.windowHeight = value;
                OnPropertyChanged(nameof(WindowHeight));
            }
        }

        public double WindowWidth
        {
            get { return model.windowWidth; }
            set
            {
                model.windowWidth = value;
                OnPropertyChanged(nameof(WindowWidth));
            }
        }

        public ICommand StartButton { get; set; }

        public ICommand StopButton { get; set; }

        public bool IsEnabled
        {
            get { return model.isEnabled; }
            set
            {
                model.isEnabled = value;
                OnPropertyChanged("IsEnabled");
                OnPropertyChanged("IsDisabled");
            }
        }

        public bool IsDisabled
        {
            get { return !IsEnabled; }
        }

        private void Enable()
        {
            ResizeMode = ResizeMode.NoResize;
            IsEnabled = true;
            model.Enable(); //
        }

        private void Disable()
        {
            ResizeMode = ResizeMode.CanResize;
            IsEnabled = false;
            model.Disable(); //
        }



        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
