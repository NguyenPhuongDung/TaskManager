namespace Server
{
    partial class frm_Server
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
            this.colMemory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dgvlistProcess = new System.Windows.Forms.ListView();
            this.colCPU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tstripTotalProcess = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPUName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.remoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutdownToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.processToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.btnLoadProcess = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.endTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colMemory
            // 
            this.colMemory.Text = "Memory";
            this.colMemory.Width = 150;
            // 
            // colPID
            // 
            this.colPID.Text = "PID";
            this.colPID.Width = 70;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 180;
            // 
            // dgvlistProcess
            // 
            this.dgvlistProcess.AllowColumnReorder = true;
            this.dgvlistProcess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colPID,
            this.colCPU,
            this.colMemory});
            this.dgvlistProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvlistProcess.FullRowSelect = true;
            this.dgvlistProcess.Location = new System.Drawing.Point(3, 16);
            this.dgvlistProcess.Name = "dgvlistProcess";
            this.dgvlistProcess.Size = new System.Drawing.Size(627, 324);
            this.dgvlistProcess.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.dgvlistProcess.TabIndex = 1;
            this.dgvlistProcess.UseCompatibleStateImageBehavior = false;
            this.dgvlistProcess.View = System.Windows.Forms.View.Details;
            // 
            // colCPU
            // 
            this.colCPU.Text = "CPU";
            this.colCPU.Width = 150;
            // 
            // tstripTotalProcess
            // 
            this.tstripTotalProcess.Name = "tstripTotalProcess";
            this.tstripTotalProcess.Size = new System.Drawing.Size(77, 17);
            this.tstripTotalProcess.Text = "Total process";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstripTotalProcess});
            this.statusStrip1.Location = new System.Drawing.Point(3, 318);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(627, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.statusStrip1);
            this.groupBox2.Controls.Add(this.dgvlistProcess);
            this.groupBox2.Location = new System.Drawing.Point(309, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(633, 343);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Process";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView);
            this.groupBox1.Location = new System.Drawing.Point(11, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 395);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.CPUName,
            this.IP,
            this.Status});
            this.dataGridView.ContextMenuStrip = this.contextMenuStrip;
            this.dataGridView.Location = new System.Drawing.Point(6, 19);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(267, 370);
            this.dataGridView.TabIndex = 8;
            // 
            // ID
            // 
            this.ID.HeaderText = "#";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 40;
            // 
            // CPUName
            // 
            this.CPUName.HeaderText = "Tên máy";
            this.CPUName.Name = "CPUName";
            this.CPUName.ReadOnly = true;
            this.CPUName.Width = 70;
            // 
            // IP
            // 
            this.IP.HeaderText = "IP";
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            this.IP.Width = 50;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.HeaderText = "Trạng thái";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remoteToolStripMenuItem,
            this.chatToolStripMenuItem,
            this.mouseToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.shutdownToolStripMenuItem1,
            this.processToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(182, 136);
            // 
            // remoteToolStripMenuItem
            // 
            this.remoteToolStripMenuItem.Name = "remoteToolStripMenuItem";
            this.remoteToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.remoteToolStripMenuItem.Text = "Điều khiển";
            // 
            // chatToolStripMenuItem
            // 
            this.chatToolStripMenuItem.Name = "chatToolStripMenuItem";
            this.chatToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.chatToolStripMenuItem.Text = "Trò chuyện";
            // 
            // mouseToolStripMenuItem
            // 
            this.mouseToolStripMenuItem.Name = "mouseToolStripMenuItem";
            this.mouseToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.mouseToolStripMenuItem.Text = "Khóa chuột và phím";
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.restartToolStripMenuItem.Text = "Khởi động lại";
            // 
            // shutdownToolStripMenuItem1
            // 
            this.shutdownToolStripMenuItem1.Name = "shutdownToolStripMenuItem1";
            this.shutdownToolStripMenuItem1.Size = new System.Drawing.Size(181, 22);
            this.shutdownToolStripMenuItem1.Text = "Tắt máy";
            // 
            // processToolStripMenuItem
            // 
            this.processToolStripMenuItem.Name = "processToolStripMenuItem";
            this.processToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.processToolStripMenuItem.Text = "Process";
            this.processToolStripMenuItem.Click += new System.EventHandler(this.processToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.exitToolStripMenuItem.Text = "Thoát";
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.resetToolStripMenuItem.Text = "Khởi động lại";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.settingToolStripMenuItem.Text = "Cấu hình";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // sendAllToolStripMenuItem
            // 
            this.sendAllToolStripMenuItem.Name = "sendAllToolStripMenuItem";
            this.sendAllToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.sendAllToolStripMenuItem.Text = "Gởi tin nhắn tất cả";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendAllToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // lbl_Info
            // 
            this.lbl_Info.ForeColor = System.Drawing.Color.Red;
            this.lbl_Info.Location = new System.Drawing.Point(2, 30);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(952, 26);
            this.lbl_Info.TabIndex = 12;
            this.lbl_Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(964, 24);
            this.menuStrip.TabIndex = 11;
            this.menuStrip.Text = "menuStrip1";
            // 
            // btnLoadProcess
            // 
            this.btnLoadProcess.Location = new System.Drawing.Point(312, 69);
            this.btnLoadProcess.Name = "btnLoadProcess";
            this.btnLoadProcess.Size = new System.Drawing.Size(75, 23);
            this.btnLoadProcess.TabIndex = 15;
            this.btnLoadProcess.Text = "Load";
            this.btnLoadProcess.UseVisualStyleBackColor = true;
            this.btnLoadProcess.Click += new System.EventHandler(this.btnLoadProcess_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.endTaskToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // endTaskToolStripMenuItem
            // 
            this.endTaskToolStripMenuItem.Name = "endTaskToolStripMenuItem";
            this.endTaskToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.endTaskToolStripMenuItem.Text = "End Task";
            this.endTaskToolStripMenuItem.Click += new System.EventHandler(this.endTaskToolStripMenuItem_Click);
            // 
            // frm_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 473);
            this.Controls.Add(this.btnLoadProcess);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_Info);
            this.Controls.Add(this.menuStrip);
            this.Name = "frm_Server";
            this.Text = "frm_Server";
            this.Load += new System.EventHandler(this.frm_Server_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colMemory;
        private System.Windows.Forms.ColumnHeader colPID;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ListView dgvlistProcess;
        private System.Windows.Forms.ColumnHeader colCPU;
        private System.Windows.Forms.ToolStripStatusLabel tstripTotalProcess;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPUName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem remoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem processToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.Button btnLoadProcess;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem endTaskToolStripMenuItem;
    }
}