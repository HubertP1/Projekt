namespace Data
{
    public class DataApi : IData
    {
        private double sceneHeight;
        private double sceneWidth;

        private bool Enabled;

        private List<Orb> orbs;

        public DataApi()
        {
            orbs = new List<Orb>();
        }

        public void AddOrb(double radius, double posX, double posY, double velX, double velY)
        {
            orbs.Add(new Orb(radius, posX, posY, velX, velY));
        }

        public List<Orb> GetOrbs()
        {
            return orbs;
        }

        public void ClearOrbs()
        {
            orbs.Clear();
        }

        public double SceneXDimension
        {
            get { return sceneWidth; }
            set { sceneWidth = value; }
        }

        public double SceneYDimension
        {
            get { return sceneHeight; }
            set { sceneHeight = value; }
        }

        public bool IsEnabled
        {
            get { return Enabled; }
            set { Enabled = value; }
        }
    }
}
