using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terminus
{
    abstract class Agent
    {
        protected Random r = new Random();
        public State state { get; set; }

        private Map location;
        private List<List<Terrain>> map;

        public int Health { get; set; }
        public int Gold { get; set; }
        public int MaxAge { get; set; } // max age in ticks.

        public int m { get; set; }
        public int n { get; set; }

        public Weapon Equipped { get; set; }
        public List<Weapon> Weapons { get; set; }

        public bool IsDead()
        {
            return (Health <= 0) ? true : false;
        }

        // public abstract void moveTo(int m, int n);

            /*
        public void simpleMoveTo(int m, int n) // no pathfinding, just straight-line movement
        {
            // make random decision where to move when both distances are the same
            double choice = r.NextDouble();

            // only need to know the directions--+x,-x,+y,-y--to take the next step
            int new_m;
            int new_n;

            int unit_m;
            int unit_n;

            new_m = (m - this.m);
            new_n = (n - this.n);

            try { unit_m = (m - this.m) / Math.Abs(m - this.m); }
            catch (DivideByZeroException) { unit_m = 0; }
            try { unit_n = (n - this.n) / Math.Abs(n - this.n); }
            catch (DivideByZeroException) { unit_n = 0; }

            if (new_m == new_n)
            {
                if (choice > 0.5) { this.m += unit_m; }
                else { this.n += unit_n; }
            }
            else
            {
                if (Math.Abs(this.m) > Math.Abs(this.n)) { this.m += unit_m; }
                if (Math.Abs(this.n) > Math.Abs(this.m)) { this.n += unit_n; }
            }

            // double hyp = Math.Sqrt(Math.Pow(dist_m, dist_m) + Math.Pow(dist_n, dist_n));

        }

    */
    }
}
