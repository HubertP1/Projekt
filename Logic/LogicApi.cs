using Data;

namespace Logic
{
    public class LogicApi : ILogic
    {
        private IData dataApi;

        public LogicApi(IData dataApi = null)
        {
            if (dataApi == null) dataApi = new DataApi();
            this.dataApi = dataApi;
        }

        public void Disable()
        {
            dataApi.IsEnabled = false;
        }

        public void Enable()
        {
            dataApi.IsEnabled = true;
        }

        public void CreateScene(double height, double width, int orbCount, int radius)
        {
            dataApi.SceneYDimension = height;
            dataApi.SceneXDimension = width;

            // Generowanie orbów
            dataApi.ClearOrbs();

            Random rand = new();
            for (int i = 0; i < orbCount; i++)
            {
                int x = rand.Next(radius, (int)(width - radius));
                int y = rand.Next(radius, (int)(height - radius));
                double vx = rand.Next(-500, 500) / 200.0;
                double vy = rand.Next(-500, 500) / 200.0;
                int randomRadius = rand.Next(5, 15);
                dataApi.AddOrb(randomRadius, x, y, vx, vy);
                // dataApi.AddOrb(radius, x, y, vx, vy);
            }

            double gravity = 0.1;

            // Tworzenie wątków orbów
            foreach (var o in dataApi.GetOrbs())
            {
                Task.Run(async () =>
                {
                    double minX = 2 + o.Radius;
                    double minY = 2 + o.Radius;
                    double maxX = dataApi.SceneXDimension - o.Radius - 2;
                    double maxY = dataApi.SceneYDimension - o.Radius - 2;

                    double lastPosX;
                    double lastPosY;
                    double newPosX;
                    double newPosY;

                    double collisionTime = 1.0;

                    while (dataApi.IsEnabled)
                    {

                        // wyznaczyć pkt pocz i końc
                        lastPosX = o.PositionX;
                        lastPosY = o.PositionY;
                        newPosX = lastPosX + o.VelocityX;
                        newPosY = lastPosY + o.VelocityY;

                        // znaleźć czas kolizji
                        if (newPosX < minX)
                        {
                            collisionTime = CCD(lastPosX, lastPosY, newPosX, newPosY, minX);
                            double tempPos = lastPosX;
                            tempPos += o.VelocityX * collisionTime;
                            tempPos -= o.VelocityX * (1 - collisionTime);
                            newPosX = tempPos;
                            o.VelocityX *= -1;
                        }

                        if (newPosX > maxX)
                        {
                            collisionTime = CCD(lastPosX, lastPosY, newPosX, newPosY, maxX);
                            double tempPos = lastPosX;
                            tempPos += o.VelocityX * collisionTime;
                            tempPos -= o.VelocityX * (1 - collisionTime);
                            newPosX = tempPos;
                            o.VelocityX *= -1;
                        }

                        if (newPosY < minY)
                        {
                            collisionTime = CCD(lastPosY, lastPosX, newPosY, newPosX, minY);
                            double tempPos = lastPosY;
                            tempPos += o.VelocityY * collisionTime;
                            tempPos -= o.VelocityY * (1 - collisionTime);
                            newPosY = tempPos;
                            o.VelocityY *= -1;
                        }

                        if (newPosY > maxY)
                        {
                            collisionTime = CCD(lastPosY, lastPosX, newPosY, newPosX, maxY);
                            double tempPos = lastPosY;
                            tempPos += o.VelocityY * collisionTime;
                            tempPos -= o.VelocityY * (1 - collisionTime);
                            newPosY = tempPos;
                            o.VelocityY *= -1;
                        }

                        o.VelocityY += gravity;
                        o.PositionX = newPosX;
                        o.PositionY = newPosY;


                        await Task.Delay(10);
                    }
                });
            }
        }

        private double CCD(double x0, double y0, double x1, double y1, double wall)
        {
            if ((x0 < wall && x1 < wall) || (x0 > wall && x1 > wall))
            {
                return 1.0;
            }
            double slope = (y1 - y0) / (x1 - x0);
            double yIntercept = y0 - slope * x0;
            double wallY = slope * wall + yIntercept;
            double collisionTime = (wall - x0) / (x1 - x0);
            if (collisionTime < 0 || collisionTime > 1)
            {
                return 1.0;
            }
            if (wallY < Math.Min(y0, y1) || wallY > Math.Max(y0, y1))
            {
                return 1.0;
            }
            return collisionTime;
        }

        public List<Orb> GetOrbs()
        {
            List<Orb> temp = new();
            foreach (var o in dataApi.GetOrbs())
            {
                temp.Add(new Orb(o));
            }
            return temp;
        }
    }
}
