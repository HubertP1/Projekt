using Data;

namespace Logic
{
    internal class LogicApi : ILogic
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

        public void CreateScene(int height, int width, int orbCount)
        {
            dataApi.SceneYDimension = height;
            dataApi.SceneXDimension = width;

            int radius = 20; // Na razie na sztywno

            // Generowanie orbów
            dataApi.ClearOrbs();
            Random rand = new Random();
            for (int i = 0; i < orbCount; i++)
            {
                int x = rand.Next(radius, width - radius);
                int y = rand.Next(radius, height - radius);
                dataApi.AddOrb(radius, x, y);
            }

            // Tworzenie wątków orbów
            foreach (var o in dataApi.GetOrbs())
            {
                Thread thread = new Thread(() =>
                {
                    while (dataApi.IsEnabled)
                    {

                        o.PositionX += o.VelocityX;
                        if (o.PositionX < 0 + o.Radius)
                        {
                            o.PositionX = 0 + o.Radius;
                            o.VelocityX *= -1;
                        } 
                        else if (o.PositionX > width - radius)
                        {
                            o.PositionX = width - o.Radius;
                            o.VelocityX *= -1;
                        }

                        o.PositionY += o.VelocityY;
                        if (o.PositionY < 0 + o.Radius)
                        {
                            o.PositionY = 0 + o.Radius;
                            o.VelocityY *= -1;
                        }
                        else if (o.PositionY > height - radius)
                        {
                            o.PositionY = height - o.Radius;
                            o.VelocityY *= -1;
                        }

                        Thread.Sleep(10);
                    }
                });
                thread.Start();
            }

        }
    }
}
