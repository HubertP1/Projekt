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
                int vx = rand.Next(-10,10);
                int vy = rand.Next(-10,10);
                dataApi.AddOrb(radius, x, y, vx, vy);
            }

            // Tworzenie wątków orbów
            foreach (var o in dataApi.GetOrbs())
            {
                Thread thread = new(() =>
                {
                    while (dataApi.IsEnabled)
                    {

                        o.PositionX += o.VelocityX;
                        if (o.PositionX < 0 + o.Radius)
                        {
                            o.PositionX = 0 + o.Radius;
                            o.VelocityX *= -1;
                        } 
                        else if (o.PositionX > dataApi.SceneXDimension - o.Radius)
                        {
                            o.PositionX = dataApi.SceneXDimension - o.Radius;
                            o.VelocityX *= -1;
                        }

                        o.PositionY += o.VelocityY;
                        if (o.PositionY < 0 + o.Radius)
                        {
                            o.PositionY = 0 + o.Radius;
                            o.VelocityY *= -1;
                        }
                        else if (o.PositionY > dataApi.SceneYDimension - o.Radius)
                        {
                            o.PositionY = dataApi.SceneYDimension - o.Radius;
                            o.VelocityY *= -1;
                        }

                        Thread.Sleep(10);
                    }
                });
                thread.Start();
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
