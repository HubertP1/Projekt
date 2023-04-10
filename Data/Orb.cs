using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Data
{
    public class Orb
    {
        private readonly double radius;

        private double posX;
        private double posY;

        private double velX;
        private double velY;

        public Orb(double radius, double posX, double posY)
        {
            this.radius = radius;
            this.posX = posX;
            this.posY = posY;
        }

        public double Radius { get { return radius; } }

        public double PositionX
        {
            get { return posX; }
            set
            {
                posX = value;
            }
        }

        public double PositionY
        {
            get { return posY; }
            set
            {
                posY = value;
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
    }
}
