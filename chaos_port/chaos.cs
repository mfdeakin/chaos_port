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

    public class petersim : simulator
    {
        public petersim()
        {
            name = "Peter Map";
            this["p"] = 0;
            this["q"] = Math.PI / 4;
            this["c"] = 1.8;
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

        public override void step()
        {
            p += -q + c * Math.Sin(q);
            q += p;
            time++;
        }
    }
}
