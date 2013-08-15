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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogs));
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.groupBoxVhostAccess = new System.Windows.Forms.GroupBox();
            this.textBoxAcces = new System.Windows.Forms.TextBox();
            this.groupBoxGlobalError = new System.Windows.Forms.GroupBox();
            this.textBoxErrorGlobal = new System.Windows.Forms.TextBox();
            this.groupBoxVhostError = new System.Windows.Forms.GroupBox();
            this.textBoxError = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelGlobal = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxRewrite = new System.Windows.Forms.GroupBox();
            this.textBoxRewriteLogs = new System.Windows.Forms.TextBox();
            this.groupBoxStat = new System.Windows.Forms.GroupBox();
            this.labelLoad3 = new System.Windows.Forms.Label();
            this.labelLoad2 = new System.Windows.Forms.Label();
            this.labelUpdateError = new System.Windows.Forms.Label();
            this.labelLoad1 = new System.Windows.Forms.Label();
            this.colorProgressBarMysql = new VhostManager.ColorProgressBar();
            this.colorProgressBarApache = new VhostManager.ColorProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelApachePourcent = new System.Windows.Forms.Label();
            this.labelMysqlPourcent = new System.Windows.Forms.Label();
            this.groupBoxVhostAccess.SuspendLayout();
            this.groupBoxGlobalError.SuspendLayout();
            this.groupBoxVhostError.SuspendLayout();
            this.tableLayoutPanelGlobal.SuspendLayout();
            this.groupBoxRewrite.SuspendLayout();
            this.groupBoxStat.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 2000;
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
            this.groupBoxVhostAccess.Location = new System.Drawing.Point(3, 263);
            this.groupBoxVhostAccess.Name = "groupBoxVhostAccess";
            this.groupBoxVhostAccess.Size = new System.Drawing.Size(1357, 174);
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
            this.textBoxAcces.Size = new System.Drawing.Size(1351, 149);
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
            this.groupBoxGlobalError.Location = new System.Drawing.Point(3, 623);
            this.groupBoxGlobalError.Name = "groupBoxGlobalError";
            this.groupBoxGlobalError.Size = new System.Drawing.Size(1357, 174);
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
            this.textBoxErrorGlobal.Size = new System.Drawing.Size(1351, 149);
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
            this.groupBoxVhostError.Location = new System.Drawing.Point(3, 83);
            this.groupBoxVhostError.Name = "groupBoxVhostError";
            this.groupBoxVhostError.Size = new System.Drawing.Size(1357, 174);
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
            this.textBoxError.Size = new System.Drawing.Size(1351, 149);
            this.textBoxError.TabIndex = 0;
            // 
            // tableLayoutPanelGlobal
            // 
            this.tableLayoutPanelGlobal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelGlobal.ColumnCount = 1;
            this.tableLayoutPanelGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelGlobal.Controls.Add(this.groupBoxVhostError, 0, 1);
            this.tableLayoutPanelGlobal.Controls.Add(this.groupBoxVhostAccess, 0, 2);
            this.tableLayoutPanelGlobal.Controls.Add(this.groupBoxRewrite, 0, 3);
            this.tableLayoutPanelGlobal.Controls.Add(this.groupBoxGlobalError, 0, 4);
            this.tableLayoutPanelGlobal.Controls.Add(this.groupBoxStat, 0, 0);
            this.tableLayoutPanelGlobal.Location = new System.Drawing.Point(2, 0);
            this.tableLayoutPanelGlobal.Name = "tableLayoutPanelGlobal";
            this.tableLayoutPanelGlobal.RowCount = 5;
            this.tableLayoutPanelGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelGlobal.Size = new System.Drawing.Size(1363, 800);
            this.tableLayoutPanelGlobal.TabIndex = 1;
            // 
            // groupBoxRewrite
            // 
            this.groupBoxRewrite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxRewrite.AutoSize = true;
            this.groupBoxRewrite.Controls.Add(this.textBoxRewriteLogs);
            this.groupBoxRewrite.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxRewrite.Location = new System.Drawing.Point(3, 443);
            this.groupBoxRewrite.Name = "groupBoxRewrite";
            this.groupBoxRewrite.Size = new System.Drawing.Size(1357, 174);
            this.groupBoxRewrite.TabIndex = 8;
            this.groupBoxRewrite.TabStop = false;
            this.groupBoxRewrite.Text = "Vhost rewrite logs";
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
            this.textBoxRewriteLogs.Size = new System.Drawing.Size(1351, 149);
            this.textBoxRewriteLogs.TabIndex = 4;
            // 
            // groupBoxStat
            // 
            this.groupBoxStat.Controls.Add(this.labelMysqlPourcent);
            this.groupBoxStat.Controls.Add(this.labelApachePourcent);
            this.groupBoxStat.Controls.Add(this.labelLoad3);
            this.groupBoxStat.Controls.Add(this.labelLoad2);
            this.groupBoxStat.Controls.Add(this.labelUpdateError);
            this.groupBoxStat.Controls.Add(this.labelLoad1);
            this.groupBoxStat.Controls.Add(this.colorProgressBarMysql);
            this.groupBoxStat.Controls.Add(this.colorProgressBarApache);
            this.groupBoxStat.Controls.Add(this.label3);
            this.groupBoxStat.Controls.Add(this.label2);
            this.groupBoxStat.Controls.Add(this.label1);
            this.groupBoxStat.Location = new System.Drawing.Point(3, 3);
            this.groupBoxStat.Name = "groupBoxStat";
            this.groupBoxStat.Size = new System.Drawing.Size(1357, 74);
            this.groupBoxStat.TabIndex = 9;
            this.groupBoxStat.TabStop = false;
            this.groupBoxStat.Text = "Stats Serveur";
            // 
            // labelLoad3
            // 
            this.labelLoad3.AutoSize = true;
            this.labelLoad3.ForeColor = System.Drawing.Color.Gray;
            this.labelLoad3.Location = new System.Drawing.Point(186, 26);
            this.labelLoad3.Name = "labelLoad3";
            this.labelLoad3.Size = new System.Drawing.Size(22, 13);
            this.labelLoad3.TabIndex = 8;
            this.labelLoad3.Text = "0.0";
            this.labelLoad3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelLoad2
            // 
            this.labelLoad2.AutoSize = true;
            this.labelLoad2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoad2.ForeColor = System.Drawing.Color.DimGray;
            this.labelLoad2.Location = new System.Drawing.Point(149, 26);
            this.labelLoad2.Name = "labelLoad2";
            this.labelLoad2.Size = new System.Drawing.Size(22, 13);
            this.labelLoad2.TabIndex = 7;
            this.labelLoad2.Text = "0.0";
            this.labelLoad2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelUpdateError
            // 
            this.labelUpdateError.AutoSize = true;
            this.labelUpdateError.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUpdateError.ForeColor = System.Drawing.Color.Red;
            this.labelUpdateError.Location = new System.Drawing.Point(20, 55);
            this.labelUpdateError.Name = "labelUpdateError";
            this.labelUpdateError.Size = new System.Drawing.Size(108, 13);
            this.labelUpdateError.TabIndex = 6;
            this.labelUpdateError.Text = "Connexion en cours...";
            // 
            // labelLoad1
            // 
            this.labelLoad1.AutoSize = true;
            this.labelLoad1.Location = new System.Drawing.Point(112, 26);
            this.labelLoad1.Name = "labelLoad1";
            this.labelLoad1.Size = new System.Drawing.Size(22, 13);
            this.labelLoad1.TabIndex = 5;
            this.labelLoad1.Text = "0.0";
            this.labelLoad1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // colorProgressBarMysql
            // 
            this.colorProgressBarMysql.Location = new System.Drawing.Point(962, 26);
            this.colorProgressBarMysql.Name = "colorProgressBarMysql";
            this.colorProgressBarMysql.Size = new System.Drawing.Size(213, 13);
            this.colorProgressBarMysql.TabIndex = 4;
            // 
            // colorProgressBarApache
            // 
            this.colorProgressBarApache.Location = new System.Drawing.Point(474, 26);
            this.colorProgressBarApache.Name = "colorProgressBarApache";
            this.colorProgressBarApache.Size = new System.Drawing.Size(213, 13);
            this.colorProgressBarApache.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(823, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Utilisation Cpu MySQL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(331, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Utilisation Cpu Apache";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Load Average";
            // 
            // labelApachePourcent
            // 
            this.labelApachePourcent.AutoSize = true;
            this.labelApachePourcent.Location = new System.Drawing.Point(694, 26);
            this.labelApachePourcent.Name = "labelApachePourcent";
            this.labelApachePourcent.Size = new System.Drawing.Size(21, 13);
            this.labelApachePourcent.TabIndex = 9;
            this.labelApachePourcent.Text = "0%";
            // 
            // labelMysqlPourcent
            // 
            this.labelMysqlPourcent.AutoSize = true;
            this.labelMysqlPourcent.Location = new System.Drawing.Point(1181, 26);
            this.labelMysqlPourcent.Name = "labelMysqlPourcent";
            this.labelMysqlPourcent.Size = new System.Drawing.Size(21, 13);
            this.labelMysqlPourcent.TabIndex = 10;
            this.labelMysqlPourcent.Text = "0%";
            // 
            // FormLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 802);
            this.Controls.Add(this.tableLayoutPanelGlobal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLogs";
            this.Text = " : monitoring des logs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLogs_FormClosing);
            this.groupBoxVhostAccess.ResumeLayout(false);
            this.groupBoxVhostAccess.PerformLayout();
            this.groupBoxGlobalError.ResumeLayout(false);
            this.groupBoxGlobalError.PerformLayout();
            this.groupBoxVhostError.ResumeLayout(false);
            this.groupBoxVhostError.PerformLayout();
            this.tableLayoutPanelGlobal.ResumeLayout(false);
            this.tableLayoutPanelGlobal.PerformLayout();
            this.groupBoxRewrite.ResumeLayout(false);
            this.groupBoxRewrite.PerformLayout();
            this.groupBoxStat.ResumeLayout(false);
            this.groupBoxStat.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBoxRewrite;
        private System.Windows.Forms.TextBox textBoxRewriteLogs;
        private System.Windows.Forms.GroupBox groupBoxStat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelLoad1;
        private ColorProgressBar colorProgressBarMysql;
        private ColorProgressBar colorProgressBarApache;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelUpdateError;
        private System.Windows.Forms.Label labelLoad3;
        private System.Windows.Forms.Label labelLoad2;
        private System.Windows.Forms.Label labelMysqlPourcent;
        private System.Windows.Forms.Label labelApachePourcent;
    }
}