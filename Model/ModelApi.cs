using Logic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Model
{
    public class ModelApi
    {
        public int orbRadius = 20; // Na sztywno narazie
        public int orbQuantity;
        public ResizeMode resizeMode;
        public double windowHeight;
        public double windowWidth;
        public bool isEnabled;

        public ObservableCollection<Orb> orbs = new();

        private readonly LogicApi logic = new();

        public void Enable()
        {
            logic.Enable();
            logic.CreateScene(windowHeight - 43.6, windowWidth - 170.4, orbQuantity, orbRadius);
            GenerateOrbCollection();
        }

        public void Disable()
        {
            orbs.Clear(); // temp
            logic.Disable();
        }

        private void GenerateOrbCollection()
        {
            foreach (var o in logic.GetOrbs())
            {
                orbs.Add(new Orb(o));
            }
        }

    }
}
