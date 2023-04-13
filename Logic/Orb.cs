using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Orb : INotifyPropertyChanged
    {
        private double radius;
        private double posX;
        private double posY;

        public Orb(double radius, double posX, double posY)
        {
            this.radius = radius;
            this.posX = posX;
            this.posY = posY;
        }

        public double Radius
        {
            get => radius;
            set
            {
                this.radius = value;
                OnPropertyChanged(nameof(Radius));
            }
        }

        public double PositionX
        {
            get { return posX; }
            set
            {
                this.posX = value;
                OnPropertyChanged(nameof(PositionX));
            }
        }

        public double PositionY
        {
            get { return posY; }
            set
            {
                this.posY = value;
                OnPropertyChanged(nameof(PositionY));
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
