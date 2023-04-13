using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface ILogic
    {
        void CreateScene(int height, int width, int orbCount);

        void Enable();
        
        void Disable();

        List<Orb> GetOrbs();
    }
}
