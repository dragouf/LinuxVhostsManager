namespace VhostManager
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageOptions = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelTailleVhosts = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBoxParamGlobal = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonSyncNon = new System.Windows.Forms.RadioButton();
            this.radioButtonSyncOui = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonDownload = new System.Windows.Forms.RadioButton();
            this.radioButtonBoth = new System.Windows.Forms.RadioButton();
            this.radioButtonUpload = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBoxSSH = new System.Windows.Forms.GroupBox();
            this.buttonConnexion = new System.Windows.Forms.Button();
            this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxHost = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPageCreateVhost = new System.Windows.Forms.TabPage();
            this.comboBoxSousDomaine = new System.Windows.Forms.ComboBox();
            this.buttonAddSubDomain = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.labelLoading = new System.Windows.Forms.Label();
            this.buttonBrowseLocal = new System.Windows.Forms.Button();
            this.buttonCreerVhost = new System.Windows.Forms.Button();
            this.labelCheminDistant = new System.Windows.Forms.Label();
            this.textBoxCheminLocal = new System.Windows.Forms.TextBox();
            this.textBoxNomDomaine = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialogLocal = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelEtat = new System.Windows.Forms.ToolStripStatusLabel();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.labelMaxHddSize = new System.Windows.Forms.Label();
            this.tabControlMain.SuspendLayout();
            this.tabPageOptions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxParamGlobal.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxSSH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
            this.tabPageCreateVhost.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPageOptions);
            this.tabControlMain.Controls.Add(this.tabPageCreateVhost);
            this.tabControlMain.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.Location = new System.Drawing.Point(0, 1);
            this.tabControlMain.Multiline = true;
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(788, 293);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageOptions
            // 
            this.tabPageOptions.Controls.Add(this.groupBox1);
            this.tabPageOptions.Controls.Add(this.groupBoxParamGlobal);
            this.tabPageOptions.Controls.Add(this.groupBoxSSH);
            this.tabPageOptions.Location = new System.Drawing.Point(4, 23);
            this.tabPageOptions.Name = "tabPageOptions";
            this.tabPageOptions.Size = new System.Drawing.Size(780, 266);
            this.tabPageOptions.TabIndex = 2;
            this.tabPageOptions.Text = "Options";
            this.tabPageOptions.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelMaxHddSize);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.labelTailleVhosts);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(391, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 123);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Infos Linux";
            // 
            // labelTailleVhosts
            // 
            this.labelTailleVhosts.AutoSize = true;
            this.labelTailleVhosts.Location = new System.Drawing.Point(137, 60);
            this.labelTailleVhosts.Name = "labelTailleVhosts";
            this.labelTailleVhosts.Size = new System.Drawing.Size(11, 14);
            this.labelTailleVhosts.TabIndex = 12;
            this.labelTailleVhosts.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(18, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Taille Vhosts ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(18, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Espace occupé";
            // 
            // groupBoxParamGlobal
            // 
            this.groupBoxParamGlobal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxParamGlobal.Controls.Add(this.label13);
            this.groupBoxParamGlobal.Controls.Add(this.panel2);
            this.groupBoxParamGlobal.Controls.Add(this.panel1);
            this.groupBoxParamGlobal.Controls.Add(this.label9);
            this.groupBoxParamGlobal.Controls.Add(this.label8);
            this.groupBoxParamGlobal.Location = new System.Drawing.Point(391, 16);
            this.groupBoxParamGlobal.Name = "groupBoxParamGlobal";
            this.groupBoxParamGlobal.Size = new System.Drawing.Size(381, 103);
            this.groupBoxParamGlobal.TabIndex = 10;
            this.groupBoxParamGlobal.TabStop = false;
            this.groupBoxParamGlobal.Text = "Paramètres Synchronisation";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButtonSyncNon);
            this.panel2.Controls.Add(this.radioButtonSyncOui);
            this.panel2.Location = new System.Drawing.Point(220, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(144, 22);
            this.panel2.TabIndex = 8;
            // 
            // radioButtonSyncNon
            // 
            this.radioButtonSyncNon.AutoSize = true;
            this.radioButtonSyncNon.Location = new System.Drawing.Point(71, 3);
            this.radioButtonSyncNon.Name = "radioButtonSyncNon";
            this.radioButtonSyncNon.Size = new System.Drawing.Size(47, 18);
            this.radioButtonSyncNon.TabIndex = 2;
            this.radioButtonSyncNon.Text = "Non";
            this.radioButtonSyncNon.UseVisualStyleBackColor = true;
            // 
            // radioButtonSyncOui
            // 
            this.radioButtonSyncOui.AutoSize = true;
            this.radioButtonSyncOui.Checked = true;
            this.radioButtonSyncOui.Location = new System.Drawing.Point(4, 3);
            this.radioButtonSyncOui.Name = "radioButtonSyncOui";
            this.radioButtonSyncOui.Size = new System.Drawing.Size(44, 18);
            this.radioButtonSyncOui.TabIndex = 1;
            this.radioButtonSyncOui.TabStop = true;
            this.radioButtonSyncOui.Text = "Oui";
            this.radioButtonSyncOui.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonDownload);
            this.panel1.Controls.Add(this.radioButtonBoth);
            this.panel1.Controls.Add(this.radioButtonUpload);
            this.panel1.Location = new System.Drawing.Point(150, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(214, 24);
            this.panel1.TabIndex = 7;
            this.panel1.Visible = false;
            // 
            // radioButtonDownload
            // 
            this.radioButtonDownload.AutoSize = true;
            this.radioButtonDownload.Location = new System.Drawing.Point(71, 3);
            this.radioButtonDownload.Name = "radioButtonDownload";
            this.radioButtonDownload.Size = new System.Drawing.Size(81, 18);
            this.radioButtonDownload.TabIndex = 5;
            this.radioButtonDownload.Text = "Download";
            this.radioButtonDownload.UseVisualStyleBackColor = true;
            // 
            // radioButtonBoth
            // 
            this.radioButtonBoth.AutoSize = true;
            this.radioButtonBoth.Location = new System.Drawing.Point(150, 3);
            this.radioButtonBoth.Name = "radioButtonBoth";
            this.radioButtonBoth.Size = new System.Drawing.Size(72, 18);
            this.radioButtonBoth.TabIndex = 6;
            this.radioButtonBoth.Text = "Les deux";
            this.radioButtonBoth.UseVisualStyleBackColor = true;
            // 
            // radioButtonUpload
            // 
            this.radioButtonUpload.AutoSize = true;
            this.radioButtonUpload.Checked = true;
            this.radioButtonUpload.Location = new System.Drawing.Point(4, 3);
            this.radioButtonUpload.Name = "radioButtonUpload";
            this.radioButtonUpload.Size = new System.Drawing.Size(65, 18);
            this.radioButtonUpload.TabIndex = 4;
            this.radioButtonUpload.TabStop = true;
            this.radioButtonUpload.Text = "Upload";
            this.radioButtonUpload.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Type de Sync.";
            this.label9.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Réplication instantanée";
            // 
            // groupBoxSSH
            // 
            this.groupBoxSSH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSSH.Controls.Add(this.buttonConnexion);
            this.groupBoxSSH.Controls.Add(this.numericUpDownPort);
            this.groupBoxSSH.Controls.Add(this.label7);
            this.groupBoxSSH.Controls.Add(this.textBoxPassword);
            this.groupBoxSSH.Controls.Add(this.textBoxUser);
            this.groupBoxSSH.Controls.Add(this.textBoxHost);
            this.groupBoxSSH.Controls.Add(this.label6);
            this.groupBoxSSH.Controls.Add(this.label5);
            this.groupBoxSSH.Controls.Add(this.label4);
            this.groupBoxSSH.Location = new System.Drawing.Point(8, 16);
            this.groupBoxSSH.Name = "groupBoxSSH";
            this.groupBoxSSH.Size = new System.Drawing.Size(371, 233);
            this.groupBoxSSH.TabIndex = 0;
            this.groupBoxSSH.TabStop = false;
            this.groupBoxSSH.Text = "Paramètres SSH";
            // 
            // buttonConnexion
            // 
            this.buttonConnexion.Location = new System.Drawing.Point(252, 193);
            this.buttonConnexion.Name = "buttonConnexion";
            this.buttonConnexion.Size = new System.Drawing.Size(99, 31);
            this.buttonConnexion.TabIndex = 9;
            this.buttonConnexion.Text = "Rafraichir";
            this.buttonConnexion.UseVisualStyleBackColor = true;
            this.buttonConnexion.Click += new System.EventHandler(this.buttonConnexion_Click);
            // 
            // numericUpDownPort
            // 
            this.numericUpDownPort.Location = new System.Drawing.Point(157, 65);
            this.numericUpDownPort.Name = "numericUpDownPort";
            this.numericUpDownPort.Size = new System.Drawing.Size(194, 22);
            this.numericUpDownPort.TabIndex = 8;
            this.numericUpDownPort.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Port";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(157, 144);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(194, 22);
            this.textBoxPassword.TabIndex = 5;
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(157, 104);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(194, 22);
            this.textBoxUser.TabIndex = 4;
            // 
            // textBoxHost
            // 
            this.textBoxHost.Location = new System.Drawing.Point(157, 24);
            this.textBoxHost.Name = "textBoxHost";
            this.textBoxHost.Size = new System.Drawing.Size(194, 22);
            this.textBoxHost.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Utilisateur";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Mot de passe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "IP serveur Linux";
            // 
            // tabPageCreateVhost
            // 
            this.tabPageCreateVhost.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabPageCreateVhost.Controls.Add(this.label16);
            this.tabPageCreateVhost.Controls.Add(this.label15);
            this.tabPageCreateVhost.Controls.Add(this.label14);
            this.tabPageCreateVhost.Controls.Add(this.comboBoxSousDomaine);
            this.tabPageCreateVhost.Controls.Add(this.buttonAddSubDomain);
            this.tabPageCreateVhost.Controls.Add(this.label12);
            this.tabPageCreateVhost.Controls.Add(this.labelLoading);
            this.tabPageCreateVhost.Controls.Add(this.buttonBrowseLocal);
            this.tabPageCreateVhost.Controls.Add(this.buttonCreerVhost);
            this.tabPageCreateVhost.Controls.Add(this.labelCheminDistant);
            this.tabPageCreateVhost.Controls.Add(this.textBoxCheminLocal);
            this.tabPageCreateVhost.Controls.Add(this.textBoxNomDomaine);
            this.tabPageCreateVhost.Controls.Add(this.label3);
            this.tabPageCreateVhost.Controls.Add(this.label2);
            this.tabPageCreateVhost.Controls.Add(this.label1);
            this.tabPageCreateVhost.Location = new System.Drawing.Point(4, 23);
            this.tabPageCreateVhost.Name = "tabPageCreateVhost";
            this.tabPageCreateVhost.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCreateVhost.Size = new System.Drawing.Size(780, 266);
            this.tabPageCreateVhost.TabIndex = 1;
            this.tabPageCreateVhost.Text = "Créer vhost";
            this.tabPageCreateVhost.UseVisualStyleBackColor = true;
            // 
            // comboBoxSousDomaine
            // 
            this.comboBoxSousDomaine.FormattingEnabled = true;
            this.comboBoxSousDomaine.Items.AddRange(new object[] {
            "www"});
            this.comboBoxSousDomaine.Location = new System.Drawing.Point(195, 60);
            this.comboBoxSousDomaine.Name = "comboBoxSousDomaine";
            this.comboBoxSousDomaine.Size = new System.Drawing.Size(221, 22);
            this.comboBoxSousDomaine.TabIndex = 12;
            this.comboBoxSousDomaine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxSousDomaine_KeyDown);
            // 
            // buttonAddSubDomain
            // 
            this.buttonAddSubDomain.BackgroundImage = global::VhostManager.Properties.Resources.add;
            this.buttonAddSubDomain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonAddSubDomain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddSubDomain.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonAddSubDomain.Location = new System.Drawing.Point(425, 59);
            this.buttonAddSubDomain.Name = "buttonAddSubDomain";
            this.buttonAddSubDomain.Size = new System.Drawing.Size(24, 22);
            this.buttonAddSubDomain.TabIndex = 11;
            this.buttonAddSubDomain.UseVisualStyleBackColor = true;
            this.buttonAddSubDomain.Click += new System.EventHandler(this.buttonAddSubDomain_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(31, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Sous domaines";
            // 
            // labelLoading
            // 
            this.labelLoading.AutoSize = true;
            this.labelLoading.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoading.Location = new System.Drawing.Point(31, 140);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(0, 15);
            this.labelLoading.TabIndex = 8;
            // 
            // buttonBrowseLocal
            // 
            this.buttonBrowseLocal.BackgroundImage = global::VhostManager.Properties.Resources.folder_explore;
            this.buttonBrowseLocal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonBrowseLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrowseLocal.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonBrowseLocal.Location = new System.Drawing.Point(737, 93);
            this.buttonBrowseLocal.Name = "buttonBrowseLocal";
            this.buttonBrowseLocal.Size = new System.Drawing.Size(31, 20);
            this.buttonBrowseLocal.TabIndex = 7;
            this.buttonBrowseLocal.UseVisualStyleBackColor = true;
            this.buttonBrowseLocal.Click += new System.EventHandler(this.buttonBrowseLocal_Click);
            // 
            // buttonCreerVhost
            // 
            this.buttonCreerVhost.Location = new System.Drawing.Point(474, 198);
            this.buttonCreerVhost.Name = "buttonCreerVhost";
            this.buttonCreerVhost.Size = new System.Drawing.Size(257, 56);
            this.buttonCreerVhost.TabIndex = 6;
            this.buttonCreerVhost.Text = "Créer";
            this.buttonCreerVhost.UseVisualStyleBackColor = true;
            this.buttonCreerVhost.Click += new System.EventHandler(this.buttonCreerVhost_Click);
            // 
            // labelCheminDistant
            // 
            this.labelCheminDistant.AutoSize = true;
            this.labelCheminDistant.Location = new System.Drawing.Point(192, 129);
            this.labelCheminDistant.Name = "labelCheminDistant";
            this.labelCheminDistant.Size = new System.Drawing.Size(105, 14);
            this.labelCheminDistant.TabIndex = 5;
            this.labelCheminDistant.Text = "/var/www/vhosts/";
            // 
            // textBoxCheminLocal
            // 
            this.textBoxCheminLocal.Location = new System.Drawing.Point(195, 93);
            this.textBoxCheminLocal.Name = "textBoxCheminLocal";
            this.textBoxCheminLocal.Size = new System.Drawing.Size(536, 22);
            this.textBoxCheminLocal.TabIndex = 4;
            // 
            // textBoxNomDomaine
            // 
            this.textBoxNomDomaine.Location = new System.Drawing.Point(195, 27);
            this.textBoxNomDomaine.Name = "textBoxNomDomaine";
            this.textBoxNomDomaine.Size = new System.Drawing.Size(536, 22);
            this.textBoxNomDomaine.TabIndex = 3;
            this.textBoxNomDomaine.TextChanged += new System.EventHandler(this.textBoxNomDomaine_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(31, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Chemin Distant";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(31, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chemin Local";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(31, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom de Domaine";
            // 
            // folderBrowserDialogLocal
            // 
            this.folderBrowserDialogLocal.Description = "Choisissez le dossier httpdocs du client";
            this.folderBrowserDialogLocal.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialogLocal.ShowNewFolderButton = false;
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelEtat});
            this.statusStripMain.Location = new System.Drawing.Point(0, 292);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(784, 22);
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabelEtat
            // 
            this.toolStripStatusLabelEtat.Name = "toolStripStatusLabelEtat";
            this.toolStripStatusLabelEtat.Size = new System.Drawing.Size(189, 17);
            this.toolStripStatusLabelEtat.Text = "Veuillez entrer les parametres ssh...";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(24, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(187, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Des changemgents locaux vers le vhosts";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(41, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "ex. : web-alliance.fr";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(41, 109);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 13);
            this.label15.TabIndex = 15;
            this.label15.Text = "Racine httpdocs";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(43, 76);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 13);
            this.label16.TabIndex = 16;
            this.label16.Text = "par défaut www";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(137, 38);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(13, 13);
            this.label17.TabIndex = 14;
            this.label17.Text = "0";
            // 
            // labelMaxHddSize
            // 
            this.labelMaxHddSize.AutoSize = true;
            this.labelMaxHddSize.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaxHddSize.Location = new System.Drawing.Point(346, 38);
            this.labelMaxHddSize.Name = "labelMaxHddSize";
            this.labelMaxHddSize.Size = new System.Drawing.Size(29, 13);
            this.labelMaxHddSize.TabIndex = 15;
            this.labelMaxHddSize.Text = "-1Go";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 314);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.tabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 353);
            this.MinimumSize = new System.Drawing.Size(800, 353);
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Vhosts Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageOptions.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxParamGlobal.ResumeLayout(false);
            this.groupBoxParamGlobal.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxSSH.ResumeLayout(false);
            this.groupBoxSSH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
            this.tabPageCreateVhost.ResumeLayout(false);
            this.tabPageCreateVhost.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageCreateVhost;
        private System.Windows.Forms.Button buttonCreerVhost;
        private System.Windows.Forms.Label labelCheminDistant;
        private System.Windows.Forms.TextBox textBoxCheminLocal;
        private System.Windows.Forms.TextBox textBoxNomDomaine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBrowseLocal;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogLocal;
        private System.Windows.Forms.TabPage tabPageOptions;
        private System.Windows.Forms.GroupBox groupBoxSSH;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxHost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownPort;
        private System.Windows.Forms.Button buttonConnexion;
        private System.Windows.Forms.Label labelLoading;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelEtat;
        private System.Windows.Forms.GroupBox groupBoxParamGlobal;
        private System.Windows.Forms.RadioButton radioButtonSyncNon;
        private System.Windows.Forms.RadioButton radioButtonSyncOui;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButtonBoth;
        private System.Windows.Forms.RadioButton radioButtonDownload;
        private System.Windows.Forms.RadioButton radioButtonUpload;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelTailleVhosts;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonAddSubDomain;   
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxSousDomaine;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label labelMaxHddSize;       
    }
}

