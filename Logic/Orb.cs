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

        public Orb(Data.Orb o)
        {
            Radius = o.Radius;
            PositionX = o.PositionX;
            PositionY = o.PositionY;
            o.PropertyChanged += Update;
        }

        private void Update(object source, PropertyChangedEventArgs e)
        {
            Data.Orb changedOrb = (Data.Orb)source;
            if (e.PropertyName == "PositionX")
            {
                PositionX = changedOrb.PositionX;
            }
            if (e.PropertyName == "PositionY")
            {
                PositionY = changedOrb.PositionY;
            }
        }

        public double Radius
        {
            get {return radius*2; }
            set
            {
                radius = value;
                OnPropertyChanged(nameof(Radius));
            }
        }

        public double PositionX
        {
            get { return posX - radius; }
            set
            {
                posX = value;
                OnPropertyChanged(nameof(PositionX));
            }
        }

        public double PositionY
        {
            get { return posY - radius; }
            set
            {
                posY = value;
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
