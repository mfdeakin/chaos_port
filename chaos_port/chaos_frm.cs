/* Chaos Simulation Program
 * Copyright 2012, Michael Deakin
 * This program and all code included is liscenced under LGPL v3
 * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace chaos_port
{
    public partial class chaos_frm : Form
    {
        int MAXPOINTS = 1000;
        Dictionary<string, simulator> choices = new Dictionary<string,simulator>();
        Dictionary<string, TextBox> values = new Dictionary<string,TextBox>();
        string xval = "", yval = "";
        simulator sim = null;
        double[,] points = null;
        ZedGraph.PointPairList xypoints = new ZedGraph.PointPairList();
        ZedGraph.GraphPane gpane;
        delegate void d_updatetexts();
        d_updatetexts simupdate;

        public chaos_frm()
        {
            InitializeComponent();
            simupdate = new d_updatetexts(simupdater);
            gpane = graph.GraphPane;
        }

        public void simupdater()
        {
            if (this.Handle != null)
            {
                time_txt.Text = "" + sim.time;
                foreach (string var in values.Keys)
                {
                    values[var].Text = "" + sim[var];
                }
                //Don't update the graph too frequently
                if (sim.time % 100 == 0)
                {
                    graph.AxisChange();
                    graph.Refresh();
                }
            }
        }

        public void addchoice(simulator s)
        {
            if (s != null)
            {
                choices[s.name] = s;
                prog.Items.Add(s.name);
                if (prog.Text == "")
                {
                    prog.SelectedItem = s.name;
                }
            }
        }

        private void spc1_resized(object sender, EventArgs e)
        {
            graph.Size = new System.Drawing.Size(spc.Panel2.Width, spc.Size.Height);
        }

        private void spc_SplitterMoved(object sender, SplitterEventArgs e)
        {
            graph.Size = new System.Drawing.Size(spc.Panel2.Width, spc.Size.Height);
        }

        private void prog_SelectedIndexChanged(object sender, EventArgs e)
        {
            sim = choices[(string)prog.SelectedItem];
            settings.Controls.Clear();
            time_txt.Text = "" + 0;
            xvar.Items.Clear();
            xvar.Items.Add("Time");
            xvar.SelectedItem = xvar.Items[0];
            yvar.Items.Clear();
            yvar.Items.Add("Time");
            yvar.SelectedItem = yvar.Items[0];
            xval = "Time";
            yval = "Time";
            values.Clear();
            if (sim != null)
            {
                points = new double[MAXPOINTS, sim.Keys.Count];
                foreach (string vars in sim.Keys)
                {
                    System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
                    lbl.Text = vars;
                    settings.Controls.Add(lbl);
                    xvar.Items.Add(vars);
                    yvar.Items.Add(vars);
                    TextBox txt = new TextBox();
                    txt.Text = "" + sim[vars];
                    values.Add(vars, txt);
                    settings.Controls.Add(txt);
                    txt.Tag = vars;
                    txt.TextChanged += new EventHandler(var_textchange);
                }
                gpane.Title.Text = sim.name;
                graph.Refresh();
            }
        }

        private void xvar_SelectedIndexChanged(object sender, EventArgs e)
        {
            xval = (string)xvar.SelectedItem;
            gpane.XAxis.Title.Text = xval;
        }

        private void yvar_SelectedIndexChanged(object sender, EventArgs e)
        {
            yval = (string)yvar.SelectedItem;
            gpane.YAxis.Title.Text = yval;
        }

        private void run_btn_Click(object sender, EventArgs e)
        {
            if (simthread.IsBusy)
            {
                simthread.CancelAsync();
            }
            else
            {
                run_btn.Text = "Pause";
                prog.Enabled = false;
                point_txt.Enabled = false;
                simthread.RunWorkerAsync();
            }
        }

        private void simthread_DoWork(object sender, DoWorkEventArgs e)
        {
            gpane.CurveList.Clear();
            gpane.AddCurve(yval, xypoints, Color.Red, ZedGraph.SymbolType.None);
            while (!simthread.CancellationPending)
            {
                sim.step();
                for (int i = 0; i < sim.Values.Count; i++)
                    points[(sim.time - 1) % MAXPOINTS, i] = sim.Values.ElementAt(i);
                double x, y;
                if (xval != "" && yval != "")
                {
                    if (xval == "Time")
                        x = sim.time;
                    else
                        x = sim[xval];
                    if (yval == "Time")
                        y = sim.time;
                    else
                        y = sim[yval];
                    xypoints.Add(new ZedGraph.PointPair(x, y));
                    if (xypoints.Count > MAXPOINTS)
                        xypoints.Remove(xypoints[0]);
                }
                Invoke(simupdate);
            }
        }

        private void simthread_Finished(object sender, RunWorkerCompletedEventArgs e)
        {
            run_btn.Text = "Run";
            point_txt.Enabled = true;
            prog.Enabled = true;
        }

        private void var_textchange(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string var = (string)txt.Tag;
            if (var != "")
            {
                double val;
                if(double.TryParse(txt.Text, out val))
                    sim[var] = val;
            }
        }

        private void point_txt_TextChanged(object sender, EventArgs e)
        {
            int tmp = 0;
            if (int.TryParse(point_txt.Text, out tmp))
            {
                double[,] buf = points;
                points = new double[tmp, sim.Keys.Count];
                for (int i = 0; i < sim.time && i < MAXPOINTS && i < tmp; i++)
                    for (int j = 0; j < sim.Keys.Count; j++)
                        points[i, j] = buf[i, j];
                MAXPOINTS = tmp;
                while (xypoints.Count > MAXPOINTS)
                    xypoints.Remove(xypoints[0]);
            }
        }

        private void chaos_frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (simthread.IsBusy)
            {
                simthread.CancelAsync();
            }
        }
    }
}
