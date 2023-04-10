namespace Data
{
    public class DataApi : IData
    {
        private int sceneHeight;
        private int sceneWidth;

        private bool Enabled;

        private List<Orb> orbs;

        public DataApi()
        {
            orbs = new List<Orb>();
        }

        public void AddOrb(double radius, double posX, double posY)
        {
            orbs.Add(new Orb(radius, posX, posY));
        }

        public List<Orb> GetOrbs()
        {
            return orbs;
        }

        public void ClearOrbs()
        {
            orbs.Clear();
        }

        public int SceneXDimension
        {
            get { return sceneWidth; }
            set { sceneWidth = value; }
        }

        public int SceneYDimension
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
