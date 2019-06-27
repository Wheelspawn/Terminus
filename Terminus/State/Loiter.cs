using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terminus
{
    class Loiter : State, IState
    {
        Random r = new Random();

        public void Enter(Agent n)
        {
            this.Do(n);
        }

        public void Do(Agent n)
        {
            if (-50 == n.Gold)
                this.Exit(n);
            /*
            if (r.NextDouble() > 0.5)
                n.moveTo(r.Next(-1, 1), r.Next(-1, 1)); */
        }

        public void Exit(Agent n)
        {
            n.state = new Evade();
        }
    }
}
