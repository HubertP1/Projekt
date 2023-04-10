namespace Data
{
    public interface IData
    {
        void AddOrb(double radius, double posX, double posY);

        List<Orb> GetOrbs();

        void ClearOrbs();

        int SceneXDimension { get; set; }

        int SceneYDimension { get; set; }

        bool IsEnabled { get; set; }
    }
}
