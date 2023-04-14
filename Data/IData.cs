namespace Data
{
    public interface IData
    {
        void AddOrb(double radius, double posX, double posY, double velX, double velY);

        List<Orb> GetOrbs();

        void ClearOrbs();

        double SceneXDimension { get; set; }

        double SceneYDimension { get; set; }

        bool IsEnabled { get; set; }
    }
}
