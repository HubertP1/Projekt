using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Data
{
    public class Orb : INotifyPropertyChanged
    {
        private readonly double radius;
        private readonly double weight;

        private double posX;
        private double posY;

        private double velX;
        private double velY;

        public Orb(double radius, double weight, double posX, double posY)
        {
            this.radius = radius;
            this.weight = weight;
            this.posX = posX;
            this.posY = posY;
        }

        public double Radius { get { return radius; } }

        public double Weight { get { return weight; } }

        public double PositionX
        {
            get { return posX; }
            set
            {
                posX = value;
                OnPropertyChanged("PositionX");
            }
        }

        public double PositionY
        {
            get { return posY; }
            set
            {
                posY = value;
                OnPropertyChanged("PositionY");
            }
        }

        public double VelocityX
        {
            get { return velX; }
            set
            {
                velX = value;
            }
        }

        public double VelocityY
        {
            get { return velY; }
            set
            {
                velY = value;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
