using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Data
{
    public class Orb : INotifyPropertyChanged
    {
        private readonly double radius;

        private double posX;
        private double posY;

        private double velX;
        private double velY;

        public Orb(double radius, double posX, double posY, double velX, double velY)
        {
            this.radius = radius;
            this.posX = posX;
            this.posY = posY;
            this.velX = velX;
            this.velY = velY;
        }

        public double Radius { get { return radius; } }

        public double PositionX
        {
            get { return posX; }
            set
            {
                posX = value;
                OnPropertyChanged(nameof(PositionX));
            }
        }

        public double PositionY
        {
            get { return posY; }
            set
            {
                posY = value;
                OnPropertyChanged(nameof(PositionY));
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

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
