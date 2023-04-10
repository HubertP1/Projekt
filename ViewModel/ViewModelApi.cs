﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace ViewModel
{
    public class ViewModelApi : INotifyPropertyChanged
    {
        private int orbRadius = 20; // Na sztywno narazie

        private double windowHeight;
        private double windowWidth;
        private ResizeMode resizeMode;
        private int orbQuantity;
        private bool isEnabled = false;

        public ViewModelApi()
        {
            StartButton = new Signal(Enable);
            StopButton = new Signal(Disable);
            resizeMode = ResizeMode.CanResize;
        }

        public double WindowHeight
        {
            get { return windowHeight; }
            set
            {
                windowHeight = value;
                OnPropertyChanged("WindowHeight");
            }
        }

        public double WindowWidth
        {
            get { return windowWidth; }
            set
            {
                windowWidth = value;
                OnPropertyChanged("WindowWidth");
            }
        }

        public ICommand StartButton
        {
            get;
            set;
        }

        public ICommand StopButton
        {
            get;
            set;
        }

        public string OrbQuantity
        {
            get
            {
                return Convert.ToString(orbQuantity);
            }
            set
            {
                try
                {
                    orbQuantity = Convert.ToInt32(value);
                }
                catch { }

                OnPropertyChanged("OrbQuantity");
            }
        }

        public ResizeMode ResizeMode
        {
            get { return resizeMode; }
            set
            {
                resizeMode = value;
                OnPropertyChanged("ResizeMode");
            }
        }

        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
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
        }

        private void Disable()
        {
            ResizeMode = ResizeMode.CanResize;
            IsEnabled = false;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}