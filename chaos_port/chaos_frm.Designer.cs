/* Chaos Simulation Program
 * Copyright 2012, Michael Deakin
 * This program and all code included is liscenced under LGPL v3
 * */
namespace chaos_port
{
    partial class chaos_frm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.spc = new System.Windows.Forms.SplitContainer();
            this.point_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.yvar = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.xvar = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.time_txt = new System.Windows.Forms.TextBox();
            this.settings = new System.Windows.Forms.FlowLayoutPanel();
            this.run_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.prog = new System.Windows.Forms.ComboBox();
            this.graph = new ZedGraph.ZedGraphControl();
            this.simthread = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.spc)).BeginInit();
            this.spc.Panel1.SuspendLayout();
            this.spc.Panel2.SuspendLayout();
            this.spc.SuspendLayout();
            this.SuspendLayout();
            // 
            // spc
            // 
            this.spc.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.spc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spc.Location = new System.Drawing.Point(0, 0);
            this.spc.Name = "spc";
            // 
            // spc.Panel1
            // 
            this.spc.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.spc.Panel1.Controls.Add(this.point_txt);
            this.spc.Panel1.Controls.Add(this.label5);
            this.spc.Panel1.Controls.Add(this.label4);
            this.spc.Panel1.Controls.Add(this.yvar);
            this.spc.Panel1.Controls.Add(this.label3);
            this.spc.Panel1.Controls.Add(this.xvar);
            this.spc.Panel1.Controls.Add(this.label2);
            this.spc.Panel1.Controls.Add(this.time_txt);
            this.spc.Panel1.Controls.Add(this.settings);
            this.spc.Panel1.Controls.Add(this.run_btn);
            this.spc.Panel1.Controls.Add(this.label1);
            this.spc.Panel1.Controls.Add(this.prog);
            // 
            // spc.Panel2
            // 
            this.spc.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.spc.Panel2.Controls.Add(this.graph);
            this.spc.Size = new System.Drawing.Size(727, 357);
            this.spc.SplitterDistance = 241;
            this.spc.TabIndex = 0;
            this.spc.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.spc_SplitterMoved);
            this.spc.SizeChanged += new System.EventHandler(this.spc1_resized);
            // 
            // point_txt
            // 
            this.point_txt.Location = new System.Drawing.Point(83, 37);
            this.point_txt.Name = "point_txt";
            this.point_txt.Size = new System.Drawing.Size(141, 20);
            this.point_txt.TabIndex = 13;
            this.point_txt.Text = "1000";
            this.point_txt.TextChanged += new System.EventHandler(this.point_txt_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Point Count";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Y Variable";
            // 
            // yvar
            // 
            this.yvar.FormattingEnabled = true;
            this.yvar.Location = new System.Drawing.Point(83, 116);
            this.yvar.Name = "yvar";
            this.yvar.Size = new System.Drawing.Size(141, 21);
            this.yvar.TabIndex = 10;
            this.yvar.SelectedIndexChanged += new System.EventHandler(this.yvar_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "X Variable";
            // 
            // xvar
            // 
            this.xvar.FormattingEnabled = true;
            this.xvar.Location = new System.Drawing.Point(83, 89);
            this.xvar.Name = "xvar";
            this.xvar.Size = new System.Drawing.Size(141, 21);
            this.xvar.TabIndex = 8;
            this.xvar.SelectedIndexChanged += new System.EventHandler(this.xvar_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Time (steps)";
            // 
            // time_txt
            // 
            this.time_txt.Location = new System.Drawing.Point(83, 63);
            this.time_txt.Name = "time_txt";
            this.time_txt.Size = new System.Drawing.Size(141, 20);
            this.time_txt.TabIndex = 6;
            this.time_txt.Text = "0";
            // 
            // settings
            // 
            this.settings.Location = new System.Drawing.Point(12, 143);
            this.settings.MinimumSize = new System.Drawing.Size(226, 0);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(226, 182);
            this.settings.TabIndex = 4;
            // 
            // run_btn
            // 
            this.run_btn.Location = new System.Drawing.Point(163, 331);
            this.run_btn.Name = "run_btn";
            this.run_btn.Size = new System.Drawing.Size(75, 23);
            this.run_btn.TabIndex = 3;
            this.run_btn.Text = "Run";
            this.run_btn.UseVisualStyleBackColor = true;
            this.run_btn.Click += new System.EventHandler(this.run_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Program";
            // 
            // prog
            // 
            this.prog.FormattingEnabled = true;
            this.prog.Location = new System.Drawing.Point(83, 9);
            this.prog.Name = "prog";
            this.prog.Size = new System.Drawing.Size(141, 21);
            this.prog.TabIndex = 0;
            this.prog.SelectedIndexChanged += new System.EventHandler(this.prog_SelectedIndexChanged);
            // 
            // graph
            // 
            this.graph.Location = new System.Drawing.Point(3, 3);
            this.graph.Name = "graph";
            this.graph.ScrollGrace = 0D;
            this.graph.ScrollMaxX = 0D;
            this.graph.ScrollMaxY = 0D;
            this.graph.ScrollMaxY2 = 0D;
            this.graph.ScrollMinX = 0D;
            this.graph.ScrollMinY = 0D;
            this.graph.ScrollMinY2 = 0D;
            this.graph.Size = new System.Drawing.Size(476, 351);
            this.graph.TabIndex = 0;
            // 
            // simthread
            // 
            this.simthread.WorkerSupportsCancellation = true;
            this.simthread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.simthread_DoWork);
            this.simthread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.simthread_Finished);
            // 
            // chaos_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 357);
            this.Controls.Add(this.spc);
            this.Name = "chaos_frm";
            this.Text = "Chaos Simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.chaos_frm_FormClosing);
            this.spc.Panel1.ResumeLayout(false);
            this.spc.Panel1.PerformLayout();
            this.spc.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spc)).EndInit();
            this.spc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spc;
        private ZedGraph.ZedGraphControl graph;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox prog;
        private System.Windows.Forms.Button run_btn;
        private System.Windows.Forms.FlowLayoutPanel settings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox yvar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox xvar;
        private System.ComponentModel.BackgroundWorker simthread;
        private System.Windows.Forms.TextBox time_txt;
        private System.Windows.Forms.TextBox point_txt;
        private System.Windows.Forms.Label label5;
    }
}

