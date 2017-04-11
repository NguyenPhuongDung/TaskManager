namespace TaskManager
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.Task = new System.Windows.Forms.TabControl();
            this.tabProcess = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.listProcess = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.endTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erformance = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.colCPU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMemory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDisk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.Task.SuspendLayout();
            this.tabProcess.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Task
            // 
            this.Task.Controls.Add(this.tabProcess);
            this.Task.Controls.Add(this.erformance);
            this.Task.Location = new System.Drawing.Point(-3, -4);
            this.Task.Name = "Task";
            this.Task.SelectedIndex = 0;
            this.Task.Size = new System.Drawing.Size(804, 455);
            this.Task.TabIndex = 1;
            // 
            // tabProcess
            // 
            this.tabProcess.Controls.Add(this.label2);
            this.tabProcess.Controls.Add(this.label1);
            this.tabProcess.Controls.Add(this.listProcess);
            this.tabProcess.Location = new System.Drawing.Point(4, 22);
            this.tabProcess.Name = "tabProcess";
            this.tabProcess.Padding = new System.Windows.Forms.Padding(3);
            this.tabProcess.Size = new System.Drawing.Size(796, 429);
            this.tabProcess.TabIndex = 0;
            this.tabProcess.Text = "Process";
            this.tabProcess.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(668, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // listProcess
            // 
            this.listProcess.AllowColumnReorder = true;
            this.listProcess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colPID,
            this.colCPU,
            this.colMemory,
            this.colDisk});
            this.listProcess.ContextMenuStrip = this.contextMenuStrip1;
            this.listProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listProcess.FullRowSelect = true;
            this.listProcess.Location = new System.Drawing.Point(3, 3);
            this.listProcess.Name = "listProcess";
            this.listProcess.Size = new System.Drawing.Size(790, 423);
            this.listProcess.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listProcess.TabIndex = 0;
            this.listProcess.UseCompatibleStateImageBehavior = false;
            this.listProcess.View = System.Windows.Forms.View.Details;
            this.listProcess.SelectedIndexChanged += new System.EventHandler(this.listProcess_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 180;
            // 
            // colPID
            // 
            this.colPID.Text = "PID";
            this.colPID.Width = 70;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.endTaskToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 26);
            // 
            // endTaskToolStripMenuItem
            // 
            this.endTaskToolStripMenuItem.Name = "endTaskToolStripMenuItem";
            this.endTaskToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.endTaskToolStripMenuItem.Text = "End Task";
            this.endTaskToolStripMenuItem.Click += new System.EventHandler(this.endTaskToolStripMenuItem_Click);
            // 
            // erformance
            // 
            this.erformance.Location = new System.Drawing.Point(4, 22);
            this.erformance.Name = "erformance";
            this.erformance.Padding = new System.Windows.Forms.Padding(3);
            this.erformance.Size = new System.Drawing.Size(796, 429);
            this.erformance.TabIndex = 1;
            this.erformance.Text = "Performance";
            this.erformance.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // colCPU
            // 
            this.colCPU.Text = "CPU";
            // 
            // colMemory
            // 
            this.colMemory.Text = "Memory";
            // 
            // colDisk
            // 
            this.colDisk.Text = "Disk";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(671, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "%";
            // 
            // Form1
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 444);
            this.Controls.Add(this.Task);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Task.ResumeLayout(false);
            this.tabProcess.ResumeLayout(false);
            this.tabProcess.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Task;
        private System.Windows.Forms.TabPage tabProcess;
        private System.Windows.Forms.ListView listProcess;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.TabPage erformance;
        private System.Windows.Forms.ColumnHeader colPID;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem endTaskToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader colCPU;
        private System.Windows.Forms.ColumnHeader colMemory;
        private System.Windows.Forms.ColumnHeader colDisk;
        private System.Windows.Forms.Label label2;
    }
}

