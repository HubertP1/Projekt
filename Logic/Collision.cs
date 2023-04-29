namespace Logic
{

    internal static class Collision
    {
        private static object LockingVar = new object();
        private static void ResolveCollision(Data.Orb o1, Data.Orb o2)
        {
            lock (LockingVar)
            {
                // Obliczanie mas kul
                double mass1 = Math.Pow(o1.Radius, 2) * Math.PI * o1.MassMultiplier;
                double mass2 = Math.Pow(o2.Radius, 2) * Math.PI * o2.MassMultiplier;

                // Obliczanie odległości między kulami
                double dx = o2.PositionX - o1.PositionX;
                double dy = o2.PositionY - o1.PositionY;
                double distance = Math.Sqrt(dx * dx + dy * dy);

                if (distance >= o1.Radius + o2.Radius) return;

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
        public static void CollisionCheck(List<Data.Orb> orbs) // to do optymalizacji
        {
            for (int i = 0; i < orbs.Count; i++)
            {
                for (int j = 0; j < orbs.Count; j++)
                {
                    if (i == j) continue;
                    double distance = Math.Pow(orbs[i].PositionX - orbs[j].PositionX, 2)
                        + Math.Pow(orbs[i].PositionY - orbs[j].PositionY, 2);
                    if (Math.Pow(orbs[i].Radius + orbs[j].Radius, 2) >= distance)
                    {
                        ResolveCollision(orbs[i], orbs[j]);
                    }
                }
            }
        }

        public static double CCD(double x0, double y0, double x1, double y1, double wall)
        {
            if ((x0 < wall && x1 < wall) || (x0 > wall && x1 > wall)) return 1.0;

            double slope = (y1 - y0) / (x1 - x0);
            double yIntercept = y0 - slope * x0;
            double wallY = slope * wall + yIntercept;
            double collisionTime = (wall - x0) / (x1 - x0);

            if (collisionTime < 0 || collisionTime > 1) return 1.0;
            if (wallY < Math.Min(y0, y1) || wallY > Math.Max(y0, y1)) return 1.0;

            return collisionTime;
        }
    }
}
