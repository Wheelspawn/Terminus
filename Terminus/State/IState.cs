using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terminus
{
    interface IState
    {
        void Enter(Agent n);
        void Do(Agent n);
        void Exit(Agent n);
    }
}
