namespace Logic
{

    internal static class Collision
    {
        private static void ResolveCollision(Data.Orb orb1, Data.Orb orb2)
        {
            Data.Orb o1;
            Data.Orb o2;
            if (orb1.Id < orb2.Id)
            {
                o1 = orb1;
                o2 = orb2;
            }
            else
            {
                o1 = orb2;
                o2 = orb1;
            }

            lock (o1.LockingVar)
            {
                lock (o2.LockingVar)
                {
                    // Obliczanie odległości między kulami
                    double dx = o2.PositionX - o1.PositionX;
                    double dy = o2.PositionY - o1.PositionY;
                    double distance = Math.Sqrt(dx * dx + dy * dy);

                    if (distance >= o1.Radius + o2.Radius) return;

                    // Obliczanie mas kul
                    double mass1 = Math.Pow(o1.Radius, 2) * Math.PI * o1.MassMultiplier;
                    double mass2 = Math.Pow(o2.Radius, 2) * Math.PI * o2.MassMultiplier;

                    // Obliczanie wektora normalnego
                    double nx = dx / distance;
                    double ny = dy / distance;

                    // Obliczanie wektora stycznego
                    double tx = -ny;
                    double ty = nx;

                    // Obliczanie iloczynu skalarnego wektora prędkości i wektora normalnego
                    double dotProduct1 = o1.VelocityX * nx + o1.VelocityY * ny;
                    double dotProduct2 = o2.VelocityX * nx + o2.VelocityY * ny;

                    // Obliczanie iloczynu skalarnego wektora prędkości i wektora stycznego
                    double tangent1 = o1.VelocityX * tx + o1.VelocityY * ty;
                    double tangent2 = o2.VelocityX * tx + o2.VelocityY * ty;

                    // Obliczanie nowych prędkości po zderzeniu
                    double newVelocity1 = (dotProduct1 * (mass1 - mass2) + 2 * mass2 * dotProduct2) / (mass1 + mass2);
                    double newVelocity2 = (dotProduct2 * (mass2 - mass1) + 2 * mass1 * dotProduct1) / (mass1 + mass2);

                    double newTangent1 = tangent1;
                    double newTangent2 = tangent2;

                    // Aktualizacja prędkości kulek
                    o1.VelocityX = newVelocity1 * nx + newTangent1 * tx;
                    o1.VelocityY = newVelocity1 * ny + newTangent1 * ty;
                    o2.VelocityX = newVelocity2 * nx + newTangent2 * tx;
                    o2.VelocityY = newVelocity2 * ny + newTangent2 * ty;

                    // Przesunięcie kul do punktu w którym się stykają
                    double overlap = o1.Radius + o2.Radius - distance;
                    o1.PositionX += overlap * (o1.PositionX - o2.PositionX) / distance;
                    o1.PositionY += overlap * (o1.PositionY - o2.PositionY) / distance;
                    o2.PositionX -= overlap * (o1.PositionX - o2.PositionX) / distance;
                    o2.PositionY -= overlap * (o1.PositionY - o2.PositionY) / distance;
                }
            }
        }

        public static void CollisionCheck(List<Data.Orb> orbs, Data.Orb orb)
        {
            for (int i = 0; i < orbs.Count; i++)
            {
                if (orb == orbs[i]) continue;

                double distanceX = Math.Abs(orbs[i].PositionX - orb.PositionX);
                if (distanceX >= orbs[i].Radius + orb.Radius) continue;

                double distanceY = Math.Abs(orbs[i].PositionY - orb.PositionY);
                if (distanceY >= orbs[i].Radius + orb.Radius) continue;

                ResolveCollision(orbs[i], orb);
                return;
            }
        }

        public static double CCD(double x0, double y0, double x1, double y1, double wall)
        {

            double collisionTime = (wall - x0) / (x1 - x0);

            return collisionTime;
        }
    }
}
