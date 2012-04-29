using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;

namespace chaos_port
{
    static class chaos
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            chaos_frm frm = new chaos_frm();
            frm.addchoice(new petersim());
            frm.addchoice(new kepler());
            Application.Run(frm);
        }
    }

    public abstract class simulator : Dictionary<string, double>
    {
        public simulator()
        {
            name = "Simulator";
            time = 0;
        }

        public abstract void step();
        public int time;
        public string name;
    }

    public class kepler : simulator
    {
        public kepler()
        {
            name = "Kepler";
            mean = 2.36;
            f = 0;
            //Eccentricity
            e = 0.595;
            //Previous Eccentricity
            ep = 0.595;
            //?
            fp = 0;
            //??
            fpp = 0;
        }

        public override void step()
        {
            ep = e;
            f = e - mean - Math.E / 5 * Math.Sin(e);
            fp = 1 - Math.E / 5 * Math.Cos(e);
            fpp = Math.E / 5 * Math.Sin(e);
            e -= f / fp * (1 + 0.5 * (f / fp) * (fpp / fp));
            time++;
        }

        public double mean
        {
            get
            {
                return this["Mean Anomaly"];
            }
            set
            {
                this["Mean Anomaly"] = value;
            }
        }

        public double f
        {
            get
            {
                return this["f"];
            }
            set
            {
                this["f"] = value;
            }
        }

        public double fp
        {
            get
            {
                return this["fp"];
            }
            set
            {
                this["fp"] = value;
            }
        }

        public double fpp
        {
            get
            {
                return this["fpp"];
            }
            set
            {
                this["fpp"] = value;
            }
        }

        public double e
        {
            get
            {
                return this["e"];
            }
            set
            {
                this["e"] = value;
            }
        }

        public double ep
        {
            get
            {
                return this["ep"];
            }
            set
            {
                this["ep"] = value;
            }
        }

    }

    public class petersim : simulator
    {
        public petersim()
        {
            name = "Peter Map";
            p = 0;
            q  = Math.PI / 4;
            c = 1.8;
        }

        public override void step()
        {
            p += -q + c * Math.Sin(q);
            q += p;
            time++;
        }

        public double p
        {
            get
            {
                return this["p"];
            }
            set
            {
                this["p"] = value;
            }

        }

        public double q
        {
            get
            {
                return this["q"];
            }
            set
            {
                this["q"] = value;
            }

        }

        public double c
        {
            get
            {
                return this["c"];
            }
            set
            {
                this["c"] = value;
            }

        }
    }
}
