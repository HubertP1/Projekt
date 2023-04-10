namespace Data
{
    public class Data : IData
    {
        private int sceneHeight;
        private int sceneWidth;

        private bool Enabled;

        private List<Orb> orbs;

        public Data()
        {
            orbs = new List<Orb>();
        }

        public void AddOrb(Orb orb)
        {
            orbs.Add(orb);
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
