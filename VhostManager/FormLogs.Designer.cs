namespace VhostManager
{
    partial class FormLogs
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
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.groupBoxVhostAccess = new System.Windows.Forms.GroupBox();
            this.textBoxAcces = new System.Windows.Forms.TextBox();
            this.groupBoxGlobalError = new System.Windows.Forms.GroupBox();
            this.textBoxErrorGlobal = new System.Windows.Forms.TextBox();
            this.groupBoxVhostError = new System.Windows.Forms.GroupBox();
            this.textBoxError = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelGlobal = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxRewriteLogs = new System.Windows.Forms.TextBox();
            this.groupBoxVhostAccess.SuspendLayout();
            this.groupBoxGlobalError.SuspendLayout();
            this.groupBoxVhostError.SuspendLayout();
            this.tableLayoutPanelGlobal.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 1000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // groupBoxVhostAccess
            // 
            this.groupBoxVhostAccess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxVhostAccess.AutoSize = true;
            this.groupBoxVhostAccess.Controls.Add(this.textBoxAcces);
            this.groupBoxVhostAccess.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxVhostAccess.Location = new System.Drawing.Point(3, 203);
            this.groupBoxVhostAccess.Name = "groupBoxVhostAccess";
            this.groupBoxVhostAccess.Size = new System.Drawing.Size(1357, 194);
            this.groupBoxVhostAccess.TabIndex = 6;
            this.groupBoxVhostAccess.TabStop = false;
            this.groupBoxVhostAccess.Text = "Vhost access logs";
            // 
            // textBoxAcces
            // 
            this.textBoxAcces.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxAcces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxAcces.Font = new System.Drawing.Font("Calibri Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAcces.Location = new System.Drawing.Point(3, 22);
            this.textBoxAcces.Multiline = true;
            this.textBoxAcces.Name = "textBoxAcces";
            this.textBoxAcces.ReadOnly = true;
            this.textBoxAcces.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxAcces.Size = new System.Drawing.Size(1351, 169);
            this.textBoxAcces.TabIndex = 2;
            // 
            // groupBoxGlobalError
            // 
            this.groupBoxGlobalError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxGlobalError.AutoSize = true;
            this.groupBoxGlobalError.Controls.Add(this.textBoxErrorGlobal);
            this.groupBoxGlobalError.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxGlobalError.Location = new System.Drawing.Point(3, 603);
            this.groupBoxGlobalError.Name = "groupBoxGlobalError";
            this.groupBoxGlobalError.Size = new System.Drawing.Size(1357, 194);
            this.groupBoxGlobalError.TabIndex = 7;
            this.groupBoxGlobalError.TabStop = false;
            this.groupBoxGlobalError.Text = "Error logs globaux";
            // 
            // textBoxErrorGlobal
            // 
            this.textBoxErrorGlobal.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxErrorGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxErrorGlobal.Font = new System.Drawing.Font("Calibri Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxErrorGlobal.Location = new System.Drawing.Point(3, 22);
            this.textBoxErrorGlobal.Multiline = true;
            this.textBoxErrorGlobal.Name = "textBoxErrorGlobal";
            this.textBoxErrorGlobal.ReadOnly = true;
            this.textBoxErrorGlobal.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxErrorGlobal.Size = new System.Drawing.Size(1351, 169);
            this.textBoxErrorGlobal.TabIndex = 4;
            // 
            // groupBoxVhostError
            // 
            this.groupBoxVhostError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxVhostError.AutoSize = true;
            this.groupBoxVhostError.Controls.Add(this.textBoxError);
            this.groupBoxVhostError.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxVhostError.Location = new System.Drawing.Point(3, 3);
            this.groupBoxVhostError.Name = "groupBoxVhostError";
            this.groupBoxVhostError.Size = new System.Drawing.Size(1357, 194);
            this.groupBoxVhostError.TabIndex = 5;
            this.groupBoxVhostError.TabStop = false;
            this.groupBoxVhostError.Text = "Vhost error logs";
            // 
            // textBoxError
            // 
            this.textBoxError.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxError.Font = new System.Drawing.Font("Calibri Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxError.Location = new System.Drawing.Point(3, 22);
            this.textBoxError.Multiline = true;
            this.textBoxError.Name = "textBoxError";
            this.textBoxError.ReadOnly = true;
            this.textBoxError.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxError.Size = new System.Drawing.Size(1351, 169);
            this.textBoxError.TabIndex = 0;
            // 
            // tableLayoutPanelGlobal
            // 
            this.tableLayoutPanelGlobal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelGlobal.ColumnCount = 1;
            this.tableLayoutPanelGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelGlobal.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanelGlobal.Controls.Add(this.groupBoxVhostError, 0, 0);
            this.tableLayoutPanelGlobal.Controls.Add(this.groupBoxVhostAccess, 0, 1);
            this.tableLayoutPanelGlobal.Controls.Add(this.groupBoxGlobalError, 0, 3);
            this.tableLayoutPanelGlobal.Location = new System.Drawing.Point(2, 0);
            this.tableLayoutPanelGlobal.Name = "tableLayoutPanelGlobal";
            this.tableLayoutPanelGlobal.RowCount = 4;
            this.tableLayoutPanelGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelGlobal.Size = new System.Drawing.Size(1363, 800);
            this.tableLayoutPanelGlobal.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.textBoxRewriteLogs);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 403);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1357, 194);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vhost rewrite logs";
            // 
            // textBoxRewriteLogs
            // 
            this.textBoxRewriteLogs.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxRewriteLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxRewriteLogs.Font = new System.Drawing.Font("Calibri Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRewriteLogs.Location = new System.Drawing.Point(3, 22);
            this.textBoxRewriteLogs.Multiline = true;
            this.textBoxRewriteLogs.Name = "textBoxRewriteLogs";
            this.textBoxRewriteLogs.ReadOnly = true;
            this.textBoxRewriteLogs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxRewriteLogs.Size = new System.Drawing.Size(1351, 169);
            this.textBoxRewriteLogs.TabIndex = 4;
            // 
            // FormLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 802);
            this.Controls.Add(this.tableLayoutPanelGlobal);
            this.Name = "FormLogs";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Monitoring des logs de ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLogs_FormClosing);
            this.groupBoxVhostAccess.ResumeLayout(false);
            this.groupBoxVhostAccess.PerformLayout();
            this.groupBoxGlobalError.ResumeLayout(false);
            this.groupBoxGlobalError.PerformLayout();
            this.groupBoxVhostError.ResumeLayout(false);
            this.groupBoxVhostError.PerformLayout();
            this.tableLayoutPanelGlobal.ResumeLayout(false);
            this.tableLayoutPanelGlobal.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.GroupBox groupBoxVhostAccess;
        private System.Windows.Forms.TextBox textBoxAcces;
        private System.Windows.Forms.GroupBox groupBoxGlobalError;
        private System.Windows.Forms.TextBox textBoxErrorGlobal;
        private System.Windows.Forms.GroupBox groupBoxVhostError;
        private System.Windows.Forms.TextBox textBoxError;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGlobal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxRewriteLogs;
    }
}