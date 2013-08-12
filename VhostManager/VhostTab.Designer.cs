namespace VhostManager
{
    partial class VhostTab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSuppresion = new System.Windows.Forms.Button();
            this.linkLabelNDD = new System.Windows.Forms.LinkLabel();
            this.radioButtonProd = new System.Windows.Forms.RadioButton();
            this.radioButtonDev = new System.Windows.Forms.RadioButton();
            this.labelSync = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTipSync = new System.Windows.Forms.ToolTip(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabelCheminLocal = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabelMySQL = new System.Windows.Forms.LinkLabel();
            this.labelErreur = new System.Windows.Forms.Label();
            this.pictureBoxHostsWarn = new System.Windows.Forms.PictureBox();
            this.buttonSync = new System.Windows.Forms.Button();
            this.linkLabelUnlockHosts = new System.Windows.Forms.LinkLabel();
            this.panelUnlockHost = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHostsWarn)).BeginInit();
            this.panelUnlockHost.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Domaine :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Etat fichier hosts:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sync :";
            // 
            // buttonSuppresion
            // 
            this.buttonSuppresion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSuppresion.ForeColor = System.Drawing.Color.Red;
            this.buttonSuppresion.Location = new System.Drawing.Point(605, 3);
            this.buttonSuppresion.Name = "buttonSuppresion";
            this.buttonSuppresion.Size = new System.Drawing.Size(163, 26);
            this.buttonSuppresion.TabIndex = 3;
            this.buttonSuppresion.Text = "Supprimer ce Vhost";
            this.buttonSuppresion.UseVisualStyleBackColor = true;
            this.buttonSuppresion.Click += new System.EventHandler(this.buttonSuppresion_Click);
            // 
            // linkLabelNDD
            // 
            this.linkLabelNDD.AutoSize = true;
            this.linkLabelNDD.Location = new System.Drawing.Point(165, 16);
            this.linkLabelNDD.Name = "linkLabelNDD";
            this.linkLabelNDD.Size = new System.Drawing.Size(10, 13);
            this.linkLabelNDD.TabIndex = 4;
            this.linkLabelNDD.TabStop = true;
            this.linkLabelNDD.Text = "-";
            this.linkLabelNDD.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelNDD_LinkClicked);
            // 
            // radioButtonProd
            // 
            this.radioButtonProd.AutoSize = true;
            this.radioButtonProd.Location = new System.Drawing.Point(168, 51);
            this.radioButtonProd.Name = "radioButtonProd";
            this.radioButtonProd.Size = new System.Drawing.Size(76, 17);
            this.radioButtonProd.TabIndex = 5;
            this.radioButtonProd.TabStop = true;
            this.radioButtonProd.Text = "Production";
            this.radioButtonProd.UseVisualStyleBackColor = true;
            this.radioButtonProd.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // radioButtonDev
            // 
            this.radioButtonDev.AutoSize = true;
            this.radioButtonDev.Location = new System.Drawing.Point(275, 50);
            this.radioButtonDev.Name = "radioButtonDev";
            this.radioButtonDev.Size = new System.Drawing.Size(100, 17);
            this.radioButtonDev.TabIndex = 6;
            this.radioButtonDev.TabStop = true;
            this.radioButtonDev.Text = "Développement";
            this.radioButtonDev.UseVisualStyleBackColor = true;
            this.radioButtonDev.Click += new System.EventHandler(this.radioButton_Click);
            // 
            // labelSync
            // 
            this.labelSync.AutoSize = true;
            this.labelSync.Location = new System.Drawing.Point(165, 125);
            this.labelSync.Name = "labelSync";
            this.labelSync.Size = new System.Drawing.Size(92, 13);
            this.labelSync.TabIndex = 7;
            this.labelSync.Text = "Aucune donnée...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Chemin Local :";
            // 
            // toolTipSync
            // 
            this.toolTipSync.ToolTipTitle = "Synchroniser le dossier local avec le vhost...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Netbeans :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(165, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(444, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Vous pouvez créer un projet netbeans avec les fichiers locaux et debugger (xdebug" +
    " est actif)";
            // 
            // linkLabelCheminLocal
            // 
            this.linkLabelCheminLocal.AutoSize = true;
            this.linkLabelCheminLocal.Location = new System.Drawing.Point(165, 88);
            this.linkLabelCheminLocal.Name = "linkLabelCheminLocal";
            this.linkLabelCheminLocal.Size = new System.Drawing.Size(10, 13);
            this.linkLabelCheminLocal.TabIndex = 13;
            this.linkLabelCheminLocal.TabStop = true;
            this.linkLabelCheminLocal.Text = "-";
            this.linkLabelCheminLocal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCheminLocal_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "MySQL :";
            // 
            // linkLabelMySQL
            // 
            this.linkLabelMySQL.AutoSize = true;
            this.linkLabelMySQL.Location = new System.Drawing.Point(165, 203);
            this.linkLabelMySQL.Name = "linkLabelMySQL";
            this.linkLabelMySQL.Size = new System.Drawing.Size(33, 13);
            this.linkLabelMySQL.TabIndex = 15;
            this.linkLabelMySQL.TabStop = true;
            this.linkLabelMySQL.Text = "Gérer";
            this.linkLabelMySQL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelMySQL_LinkClicked);
            // 
            // labelErreur
            // 
            this.labelErreur.AutoSize = true;
            this.labelErreur.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErreur.ForeColor = System.Drawing.Color.Red;
            this.labelErreur.Location = new System.Drawing.Point(13, 225);
            this.labelErreur.Name = "labelErreur";
            this.labelErreur.Size = new System.Drawing.Size(0, 15);
            this.labelErreur.TabIndex = 16;
            // 
            // pictureBoxHostsWarn
            // 
            this.pictureBoxHostsWarn.Image = global::VhostManager.Properties.Resources.warning_error;
            this.pictureBoxHostsWarn.Location = new System.Drawing.Point(4, 2);
            this.pictureBoxHostsWarn.Name = "pictureBoxHostsWarn";
            this.pictureBoxHostsWarn.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxHostsWarn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxHostsWarn.TabIndex = 17;
            this.pictureBoxHostsWarn.TabStop = false;
            // 
            // buttonSync
            // 
            this.buttonSync.BackgroundImage = global::VhostManager.Properties.Resources.sync1;
            this.buttonSync.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonSync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSync.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonSync.Location = new System.Drawing.Point(324, 119);
            this.buttonSync.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSync.Name = "buttonSync";
            this.buttonSync.Size = new System.Drawing.Size(22, 22);
            this.buttonSync.TabIndex = 10;
            this.buttonSync.UseVisualStyleBackColor = true;
            this.buttonSync.Click += new System.EventHandler(this.buttonSync_Click);
            // 
            // linkLabelUnlockHosts
            // 
            this.linkLabelUnlockHosts.AutoSize = true;
            this.linkLabelUnlockHosts.Location = new System.Drawing.Point(27, 4);
            this.linkLabelUnlockHosts.Name = "linkLabelUnlockHosts";
            this.linkLabelUnlockHosts.Size = new System.Drawing.Size(126, 13);
            this.linkLabelUnlockHosts.TabIndex = 18;
            this.linkLabelUnlockHosts.TabStop = true;
            this.linkLabelUnlockHosts.Text = "Débloquer le fichier hosts";
            this.linkLabelUnlockHosts.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelUnlockHosts_LinkClicked);
            // 
            // panelUnlockHost
            // 
            this.panelUnlockHost.Controls.Add(this.linkLabelUnlockHosts);
            this.panelUnlockHost.Controls.Add(this.pictureBoxHostsWarn);
            this.panelUnlockHost.Location = new System.Drawing.Point(396, 46);
            this.panelUnlockHost.Name = "panelUnlockHost";
            this.panelUnlockHost.Size = new System.Drawing.Size(170, 22);
            this.panelUnlockHost.TabIndex = 19;
            this.panelUnlockHost.Visible = false;
            // 
            // VhostTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelUnlockHost);
            this.Controls.Add(this.labelErreur);
            this.Controls.Add(this.linkLabelMySQL);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.linkLabelCheminLocal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonSync);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelSync);
            this.Controls.Add(this.radioButtonDev);
            this.Controls.Add(this.radioButtonProd);
            this.Controls.Add(this.linkLabelNDD);
            this.Controls.Add(this.buttonSuppresion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "VhostTab";
            this.Size = new System.Drawing.Size(771, 240);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHostsWarn)).EndInit();
            this.panelUnlockHost.ResumeLayout(false);
            this.panelUnlockHost.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSuppresion;
        private System.Windows.Forms.LinkLabel linkLabelNDD;
        private System.Windows.Forms.RadioButton radioButtonProd;
        private System.Windows.Forms.RadioButton radioButtonDev;
        private System.Windows.Forms.Label labelSync;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSync;
        private System.Windows.Forms.ToolTip toolTipSync;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabelCheminLocal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel linkLabelMySQL;
        private System.Windows.Forms.Label labelErreur;
        private System.Windows.Forms.PictureBox pictureBoxHostsWarn;
        private System.Windows.Forms.LinkLabel linkLabelUnlockHosts;
        private System.Windows.Forms.Panel panelUnlockHost;
    }
}
