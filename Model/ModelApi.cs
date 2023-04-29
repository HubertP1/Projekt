using System.Collections.ObjectModel;
using System.Windows;
using Logic;

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
        private readonly ILogic logic;

        public ModelApi(ILogic logicApi = null)
        {
            if (logicApi == null) logicApi = new LogicApi();
            this.logic = logicApi;
        }

        public ObservableCollection<Orb> orbs = new();

        public void Enable()
        {
            logic.Enable();
            logic.CreateScene(windowHeight - 43.6, windowWidth - 170.4, orbQuantity, orbRadius);
            GenerateOrbCollection();
        }

        public void Disable()
        {
            orbs.Clear();
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
