namespace Data
{
    public interface IData
    {
        public void AddOrb(Orb orb);

        public List<Orb> GetOrbs();

        public void ClearOrbs();

        public int SceneXDimension { get; set; }

        public int SceneYDimension { get; set; }

        public bool IsEnabled { get; set; }
    }
}
