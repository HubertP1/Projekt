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

        public void Initialize(double height, double width, int orbCount, int radius)
        {
            dataApi.SceneYDimension = height;
            dataApi.SceneXDimension = width;

            // Generowanie orbów
            dataApi.ClearOrbs();

            Random rand = new();
            for (int i = 0; i < orbCount; i++)
            {
                int randomRadius = rand.Next(10, 20);
                int x = rand.Next(randomRadius + 2, (int)(width - randomRadius - 2));
                int y = rand.Next(randomRadius + 2, (int)(height - randomRadius - 2));
                double vx = rand.Next(-500, 500) / 200.0;
                double vy = rand.Next(-500, 500) / 200.0;
                dataApi.AddOrb(randomRadius, x, y, vx, vy);
            }

            double gravity = 0.0;

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

                    while (dataApi.IsEnabled)
                    {
                        lastPosX = o.PositionX;
                        lastPosY = o.PositionY;
                        newPosX = lastPosX + o.VelocityX;
                        newPosY = lastPosY + o.VelocityY;

                        if (newPosX < minX)
                        {
                            double collisionTime = Collision.CCD(lastPosX, lastPosY, newPosX, newPosY, minX);
                            newPosX = lastPosX;
                            newPosX += o.VelocityX * collisionTime;
                            newPosX -= o.VelocityX * (1 - collisionTime);
                            o.VelocityX *= -1;
                        }

                        if (newPosX > maxX)
                        {
                            double collisionTime = Collision.CCD(lastPosX, lastPosY, newPosX, newPosY, maxX);
                            newPosX = lastPosX;
                            newPosX += o.VelocityX * collisionTime;
                            newPosX -= o.VelocityX * (1 - collisionTime);
                            o.VelocityX *= -1;
                        }

                        if (newPosY < minY)
                        {
                            double collisionTime = Collision.CCD(lastPosY, lastPosX, newPosY, newPosX, minY);
                            newPosY = lastPosY;
                            newPosY += o.VelocityY * collisionTime;
                            newPosY -= o.VelocityY * (1 - collisionTime);
                            o.VelocityY *= -1;
                        }

                        if (newPosY > maxY)
                        {
                            double collisionTime = Collision.CCD(lastPosY, lastPosX, newPosY, newPosX, maxY);
                            newPosY = lastPosY;
                            newPosY += o.VelocityY * collisionTime;
                            newPosY -= o.VelocityY * (1 - collisionTime);
                            o.VelocityY *= -1;
                        }

                        o.PositionX = newPosX;
                        o.PositionY = newPosY;

                        Collision.CollisionCheck(dataApi.GetOrbs());
                        if (o.PositionX < minX) { o.PositionX = minX; }
                        if (o.PositionX > maxX) { o.PositionX = maxX; }
                        if (o.PositionY < minY) { o.PositionY = minY; }
                        if (o.PositionY > maxY) { o.PositionY = maxY; }

                        o.VelocityY += gravity;

                        await Task.Delay(10);
                    }
                });
            }
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
