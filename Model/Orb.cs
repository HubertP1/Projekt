using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Orb
    {
        private readonly double radius;
        private double posX;
        private double posY;

        public Orb(double radius, double posX, double posY)
        {
            this.radius = radius;
            this.posX = posX;
            this.posY = posY;
        }
    }
}
