using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface ILogic
    {
        void Initialize(double height, double width, int orbCount, int radius);

        void Enable();
        
        void Disable();

        List<Orb> GetOrbs();
    }
}
