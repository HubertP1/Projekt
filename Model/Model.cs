using Logic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Model
{
    public class Model
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
            isEnabled = true;
        }

        public void Disable()
        {
            logic.Disable();
            isEnabled = false;
        }


    }
}
