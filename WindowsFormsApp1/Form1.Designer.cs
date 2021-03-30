namespace WindowsFormsApp1
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
            this.pictureBoxMap = new System.Windows.Forms.PictureBox();
            this.groupBoxMesh = new System.Windows.Forms.GroupBox();
            this.buttonNewMesh = new System.Windows.Forms.Button();
            this.checkBoxMeshVisible = new System.Windows.Forms.CheckBox();
            this.numericUpDownColumns = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxObjectColor = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButtonObjectColorT = new System.Windows.Forms.RadioButton();
            this.pictureBoxObjectColor = new System.Windows.Forms.PictureBox();
            this.radioButtonConstObjectColor = new System.Windows.Forms.RadioButton();
            this.colorDialogObjectColor = new System.Windows.Forms.ColorDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBoxLight = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownR = new System.Windows.Forms.NumericUpDown();
            this.radioButtonChanginColorRotating = new System.Windows.Forms.RadioButton();
            this.pictureBoxLightColor = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonLightRotating = new System.Windows.Forms.RadioButton();
            this.radioButtonLightStationary = new System.Windows.Forms.RadioButton();
            this.trackBarKs = new System.Windows.Forms.TrackBar();
            this.groupBoxFactors = new System.Windows.Forms.GroupBox();
            this.labelmValue = new System.Windows.Forms.Label();
            this.trackBarm = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.labelKdValue = new System.Windows.Forms.Label();
            this.trackBarKd = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.labelKsValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonInterpolatedFilling = new System.Windows.Forms.RadioButton();
            this.radioButtonAccurateFilling = new System.Windows.Forms.RadioButton();
            this.buttonChangeTexture = new System.Windows.Forms.Button();
            this.groupBoxNormalMap = new System.Windows.Forms.GroupBox();
            this.radioButtonNormalMapFromFile = new System.Windows.Forms.RadioButton();
            this.radioButtonNormalMapConst = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).BeginInit();
            this.groupBoxMesh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBoxObjectColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxObjectColor)).BeginInit();
            this.groupBoxLight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLightColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarKs)).BeginInit();
            this.groupBoxFactors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarKd)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxNormalMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxMap
            // 
            this.pictureBoxMap.BackColor = System.Drawing.Color.White;
            this.pictureBoxMap.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxMap.Name = "pictureBoxMap";
            this.pictureBoxMap.Size = new System.Drawing.Size(500, 500);
            this.pictureBoxMap.TabIndex = 0;
            this.pictureBoxMap.TabStop = false;
            this.pictureBoxMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMap_Paint);
            this.pictureBoxMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMap_MouseDown);
            this.pictureBoxMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMap_MouseMove);
            this.pictureBoxMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMap_MouseUp);
            // 
            // groupBoxMesh
            // 
            this.groupBoxMesh.Controls.Add(this.buttonNewMesh);
            this.groupBoxMesh.Controls.Add(this.checkBoxMeshVisible);
            this.groupBoxMesh.Controls.Add(this.numericUpDownColumns);
            this.groupBoxMesh.Controls.Add(this.label2);
            this.groupBoxMesh.Controls.Add(this.label1);
            this.groupBoxMesh.Controls.Add(this.numericUpDownRows);
            this.groupBoxMesh.Location = new System.Drawing.Point(698, 12);
            this.groupBoxMesh.Name = "groupBoxMesh";
            this.groupBoxMesh.Size = new System.Drawing.Size(256, 100);
            this.groupBoxMesh.TabIndex = 1;
            this.groupBoxMesh.TabStop = false;
            this.groupBoxMesh.Text = "Mesh";
            // 
            // buttonNewMesh
            // 
            this.buttonNewMesh.Location = new System.Drawing.Point(19, 70);
            this.buttonNewMesh.Name = "buttonNewMesh";
            this.buttonNewMesh.Size = new System.Drawing.Size(113, 23);
            this.buttonNewMesh.TabIndex = 6;
            this.buttonNewMesh.Text = "New Mesh";
            this.buttonNewMesh.UseVisualStyleBackColor = true;
            this.buttonNewMesh.Click += new System.EventHandler(this.buttonNewMesh_Click);
            // 
            // checkBoxMeshVisible
            // 
            this.checkBoxMeshVisible.AutoSize = true;
            this.checkBoxMeshVisible.Location = new System.Drawing.Point(167, 43);
            this.checkBoxMeshVisible.Name = "checkBoxMeshVisible";
            this.checkBoxMeshVisible.Size = new System.Drawing.Size(71, 21);
            this.checkBoxMeshVisible.TabIndex = 5;
            this.checkBoxMeshVisible.Text = "Visible";
            this.checkBoxMeshVisible.UseVisualStyleBackColor = true;
            this.checkBoxMeshVisible.CheckedChanged += new System.EventHandler(this.checkBoxMeshVisible_CheckedChanged);
            // 
            // numericUpDownColumns
            // 
            this.numericUpDownColumns.Location = new System.Drawing.Point(88, 42);
            this.numericUpDownColumns.Name = "numericUpDownColumns";
            this.numericUpDownColumns.Size = new System.Drawing.Size(62, 22);
            this.numericUpDownColumns.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Columns";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Rows";
            // 
            // numericUpDownRows
            // 
            this.numericUpDownRows.Location = new System.Drawing.Point(6, 42);
            this.numericUpDownRows.Name = "numericUpDownRows";
            this.numericUpDownRows.Size = new System.Drawing.Size(62, 22);
            this.numericUpDownRows.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBoxMap);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(675, 625);
            this.panel1.TabIndex = 1;
            // 
            // groupBoxObjectColor
            // 
            this.groupBoxObjectColor.Controls.Add(this.label7);
            this.groupBoxObjectColor.Controls.Add(this.radioButtonObjectColorT);
            this.groupBoxObjectColor.Controls.Add(this.pictureBoxObjectColor);
            this.groupBoxObjectColor.Controls.Add(this.radioButtonConstObjectColor);
            this.groupBoxObjectColor.Location = new System.Drawing.Point(698, 119);
            this.groupBoxObjectColor.Name = "groupBoxObjectColor";
            this.groupBoxObjectColor.Size = new System.Drawing.Size(256, 82);
            this.groupBoxObjectColor.TabIndex = 2;
            this.groupBoxObjectColor.TabStop = false;
            this.groupBoxObjectColor.Text = "Object color";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(121, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Color:";
            // 
            // radioButtonObjectColorT
            // 
            this.radioButtonObjectColorT.AutoSize = true;
            this.radioButtonObjectColorT.Location = new System.Drawing.Point(12, 48);
            this.radioButtonObjectColorT.Name = "radioButtonObjectColorT";
            this.radioButtonObjectColorT.Size = new System.Drawing.Size(77, 21);
            this.radioButtonObjectColorT.TabIndex = 2;
            this.radioButtonObjectColorT.TabStop = true;
            this.radioButtonObjectColorT.Text = "Texture";
            this.radioButtonObjectColorT.UseVisualStyleBackColor = true;
            this.radioButtonObjectColorT.CheckedChanged += new System.EventHandler(this.radioButtonObjectColorT_CheckedChanged);
            // 
            // pictureBoxObjectColor
            // 
            this.pictureBoxObjectColor.BackColor = System.Drawing.Color.White;
            this.pictureBoxObjectColor.Location = new System.Drawing.Point(173, 23);
            this.pictureBoxObjectColor.Name = "pictureBoxObjectColor";
            this.pictureBoxObjectColor.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxObjectColor.TabIndex = 1;
            this.pictureBoxObjectColor.TabStop = false;
            this.pictureBoxObjectColor.Click += new System.EventHandler(this.pictureBoxObjectColor_Click);
            // 
            // radioButtonConstObjectColor
            // 
            this.radioButtonConstObjectColor.AutoSize = true;
            this.radioButtonConstObjectColor.Location = new System.Drawing.Point(13, 21);
            this.radioButtonConstObjectColor.Name = "radioButtonConstObjectColor";
            this.radioButtonConstObjectColor.Size = new System.Drawing.Size(65, 21);
            this.radioButtonConstObjectColor.TabIndex = 0;
            this.radioButtonConstObjectColor.TabStop = true;
            this.radioButtonConstObjectColor.Text = "Const";
            this.radioButtonConstObjectColor.UseVisualStyleBackColor = true;
            this.radioButtonConstObjectColor.CheckedChanged += new System.EventHandler(this.radioButtonConstObjectColor_CheckedChanged);
            // 
            // groupBoxLight
            // 
            this.groupBoxLight.Controls.Add(this.label8);
            this.groupBoxLight.Controls.Add(this.numericUpDownR);
            this.groupBoxLight.Controls.Add(this.radioButtonChanginColorRotating);
            this.groupBoxLight.Controls.Add(this.pictureBoxLightColor);
            this.groupBoxLight.Controls.Add(this.label3);
            this.groupBoxLight.Controls.Add(this.radioButtonLightRotating);
            this.groupBoxLight.Controls.Add(this.radioButtonLightStationary);
            this.groupBoxLight.Location = new System.Drawing.Point(698, 395);
            this.groupBoxLight.Name = "groupBoxLight";
            this.groupBoxLight.Size = new System.Drawing.Size(256, 109);
            this.groupBoxLight.TabIndex = 3;
            this.groupBoxLight.TabStop = false;
            this.groupBoxLight.Text = "Light";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(170, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "R:";
            // 
            // numericUpDownR
            // 
            this.numericUpDownR.Location = new System.Drawing.Point(198, 77);
            this.numericUpDownR.Name = "numericUpDownR";
            this.numericUpDownR.Size = new System.Drawing.Size(51, 22);
            this.numericUpDownR.TabIndex = 5;
            this.numericUpDownR.ValueChanged += new System.EventHandler(this.numericUpDownR_ValueChanged);
            // 
            // radioButtonChanginColorRotating
            // 
            this.radioButtonChanginColorRotating.AutoSize = true;
            this.radioButtonChanginColorRotating.Location = new System.Drawing.Point(13, 77);
            this.radioButtonChanginColorRotating.Name = "radioButtonChanginColorRotating";
            this.radioButtonChanginColorRotating.Size = new System.Drawing.Size(149, 21);
            this.radioButtonChanginColorRotating.TabIndex = 4;
            this.radioButtonChanginColorRotating.TabStop = true;
            this.radioButtonChanginColorRotating.Text = "Colors and rotating";
            this.radioButtonChanginColorRotating.UseVisualStyleBackColor = true;
            this.radioButtonChanginColorRotating.CheckedChanged += new System.EventHandler(this.radioButtonChanginColorRotating_CheckedChanged);
            // 
            // pictureBoxLightColor
            // 
            this.pictureBoxLightColor.BackColor = System.Drawing.Color.White;
            this.pictureBoxLightColor.Location = new System.Drawing.Point(173, 36);
            this.pictureBoxLightColor.Name = "pictureBoxLightColor";
            this.pictureBoxLightColor.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxLightColor.TabIndex = 3;
            this.pictureBoxLightColor.TabStop = false;
            this.pictureBoxLightColor.Click += new System.EventHandler(this.pictureBoxLightColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Color:";
            // 
            // radioButtonLightRotating
            // 
            this.radioButtonLightRotating.AutoSize = true;
            this.radioButtonLightRotating.Location = new System.Drawing.Point(13, 50);
            this.radioButtonLightRotating.Name = "radioButtonLightRotating";
            this.radioButtonLightRotating.Size = new System.Drawing.Size(82, 21);
            this.radioButtonLightRotating.TabIndex = 1;
            this.radioButtonLightRotating.TabStop = true;
            this.radioButtonLightRotating.Text = "Rotating";
            this.radioButtonLightRotating.UseVisualStyleBackColor = true;
            this.radioButtonLightRotating.CheckedChanged += new System.EventHandler(this.radioButtonLightRotating_CheckedChanged);
            // 
            // radioButtonLightStationary
            // 
            this.radioButtonLightStationary.AutoSize = true;
            this.radioButtonLightStationary.Location = new System.Drawing.Point(13, 22);
            this.radioButtonLightStationary.Name = "radioButtonLightStationary";
            this.radioButtonLightStationary.Size = new System.Drawing.Size(93, 21);
            this.radioButtonLightStationary.TabIndex = 0;
            this.radioButtonLightStationary.TabStop = true;
            this.radioButtonLightStationary.Text = "Stationary";
            this.radioButtonLightStationary.UseVisualStyleBackColor = true;
            this.radioButtonLightStationary.CheckedChanged += new System.EventHandler(this.radioButtonLightStationary_CheckedChanged);
            // 
            // trackBarKs
            // 
            this.trackBarKs.AutoSize = false;
            this.trackBarKs.Location = new System.Drawing.Point(82, 18);
            this.trackBarKs.Name = "trackBarKs";
            this.trackBarKs.Size = new System.Drawing.Size(104, 30);
            this.trackBarKs.TabIndex = 4;
            this.trackBarKs.Scroll += new System.EventHandler(this.trackBarKs_Scroll);
            // 
            // groupBoxFactors
            // 
            this.groupBoxFactors.Controls.Add(this.labelmValue);
            this.groupBoxFactors.Controls.Add(this.trackBarm);
            this.groupBoxFactors.Controls.Add(this.label6);
            this.groupBoxFactors.Controls.Add(this.labelKdValue);
            this.groupBoxFactors.Controls.Add(this.trackBarKd);
            this.groupBoxFactors.Controls.Add(this.label5);
            this.groupBoxFactors.Controls.Add(this.labelKsValue);
            this.groupBoxFactors.Controls.Add(this.label4);
            this.groupBoxFactors.Controls.Add(this.trackBarKs);
            this.groupBoxFactors.Location = new System.Drawing.Point(698, 510);
            this.groupBoxFactors.Name = "groupBoxFactors";
            this.groupBoxFactors.Size = new System.Drawing.Size(256, 127);
            this.groupBoxFactors.TabIndex = 5;
            this.groupBoxFactors.TabStop = false;
            this.groupBoxFactors.Text = "Factors";
            // 
            // labelmValue
            // 
            this.labelmValue.AutoSize = true;
            this.labelmValue.Location = new System.Drawing.Point(196, 95);
            this.labelmValue.Name = "labelmValue";
            this.labelmValue.Size = new System.Drawing.Size(11, 17);
            this.labelmValue.TabIndex = 12;
            this.labelmValue.Text = "l";
            // 
            // trackBarm
            // 
            this.trackBarm.AutoSize = false;
            this.trackBarm.Location = new System.Drawing.Point(82, 91);
            this.trackBarm.Name = "trackBarm";
            this.trackBarm.Size = new System.Drawing.Size(104, 30);
            this.trackBarm.TabIndex = 11;
            this.trackBarm.Scroll += new System.EventHandler(this.trackBar1_Scroll_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "m [1, 100]: ";
            // 
            // labelKdValue
            // 
            this.labelKdValue.AutoSize = true;
            this.labelKdValue.Location = new System.Drawing.Point(196, 58);
            this.labelKdValue.Name = "labelKdValue";
            this.labelKdValue.Size = new System.Drawing.Size(11, 17);
            this.labelKdValue.TabIndex = 9;
            this.labelKdValue.Text = "l";
            // 
            // trackBarKd
            // 
            this.trackBarKd.AutoSize = false;
            this.trackBarKd.Location = new System.Drawing.Point(82, 54);
            this.trackBarKd.Name = "trackBarKd";
            this.trackBarKd.Size = new System.Drawing.Size(104, 30);
            this.trackBarKd.TabIndex = 8;
            this.trackBarKd.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "kd [0, 1]: ";
            // 
            // labelKsValue
            // 
            this.labelKsValue.AutoSize = true;
            this.labelKsValue.Location = new System.Drawing.Point(196, 21);
            this.labelKsValue.Name = "labelKsValue";
            this.labelKsValue.Size = new System.Drawing.Size(11, 17);
            this.labelKsValue.TabIndex = 6;
            this.labelKsValue.Text = "l";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "ks [0, 1]: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonInterpolatedFilling);
            this.groupBox1.Controls.Add(this.radioButtonAccurateFilling);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(698, 304);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 85);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Color filling";
            // 
            // radioButtonInterpolatedFilling
            // 
            this.radioButtonInterpolatedFilling.AutoSize = true;
            this.radioButtonInterpolatedFilling.Location = new System.Drawing.Point(13, 50);
            this.radioButtonInterpolatedFilling.Name = "radioButtonInterpolatedFilling";
            this.radioButtonInterpolatedFilling.Size = new System.Drawing.Size(104, 21);
            this.radioButtonInterpolatedFilling.TabIndex = 1;
            this.radioButtonInterpolatedFilling.TabStop = true;
            this.radioButtonInterpolatedFilling.Text = "Interpolated";
            this.radioButtonInterpolatedFilling.UseVisualStyleBackColor = true;
            this.radioButtonInterpolatedFilling.CheckedChanged += new System.EventHandler(this.radioButtonInterpolatedFilling_CheckedChanged);
            // 
            // radioButtonAccurateFilling
            // 
            this.radioButtonAccurateFilling.AutoSize = true;
            this.radioButtonAccurateFilling.Location = new System.Drawing.Point(13, 22);
            this.radioButtonAccurateFilling.Name = "radioButtonAccurateFilling";
            this.radioButtonAccurateFilling.Size = new System.Drawing.Size(85, 21);
            this.radioButtonAccurateFilling.TabIndex = 0;
            this.radioButtonAccurateFilling.TabStop = true;
            this.radioButtonAccurateFilling.Text = "Accurate";
            this.radioButtonAccurateFilling.UseVisualStyleBackColor = true;
            this.radioButtonAccurateFilling.CheckedChanged += new System.EventHandler(this.radioButtonAccurateFilling_CheckedChanged);
            // 
            // buttonChangeTexture
            // 
            this.buttonChangeTexture.Location = new System.Drawing.Point(114, 46);
            this.buttonChangeTexture.Name = "buttonChangeTexture";
            this.buttonChangeTexture.Size = new System.Drawing.Size(79, 28);
            this.buttonChangeTexture.TabIndex = 3;
            this.buttonChangeTexture.Text = "Change";
            this.buttonChangeTexture.UseVisualStyleBackColor = true;
            this.buttonChangeTexture.Click += new System.EventHandler(this.buttonChangeTexture_Click);
            // 
            // groupBoxNormalMap
            // 
            this.groupBoxNormalMap.Controls.Add(this.buttonChangeTexture);
            this.groupBoxNormalMap.Controls.Add(this.radioButtonNormalMapFromFile);
            this.groupBoxNormalMap.Controls.Add(this.radioButtonNormalMapConst);
            this.groupBoxNormalMap.Location = new System.Drawing.Point(698, 207);
            this.groupBoxNormalMap.Name = "groupBoxNormalMap";
            this.groupBoxNormalMap.Size = new System.Drawing.Size(256, 91);
            this.groupBoxNormalMap.TabIndex = 7;
            this.groupBoxNormalMap.TabStop = false;
            this.groupBoxNormalMap.Text = "Normal map";
            // 
            // radioButtonNormalMapFromFile
            // 
            this.radioButtonNormalMapFromFile.AutoSize = true;
            this.radioButtonNormalMapFromFile.Location = new System.Drawing.Point(12, 50);
            this.radioButtonNormalMapFromFile.Name = "radioButtonNormalMapFromFile";
            this.radioButtonNormalMapFromFile.Size = new System.Drawing.Size(83, 21);
            this.radioButtonNormalMapFromFile.TabIndex = 1;
            this.radioButtonNormalMapFromFile.TabStop = true;
            this.radioButtonNormalMapFromFile.Text = "From file";
            this.radioButtonNormalMapFromFile.UseVisualStyleBackColor = true;
            this.radioButtonNormalMapFromFile.CheckedChanged += new System.EventHandler(this.radioButtonNormalMapFromFile_CheckedChanged);
            // 
            // radioButtonNormalMapConst
            // 
            this.radioButtonNormalMapConst.AutoSize = true;
            this.radioButtonNormalMapConst.Location = new System.Drawing.Point(12, 22);
            this.radioButtonNormalMapConst.Name = "radioButtonNormalMapConst";
            this.radioButtonNormalMapConst.Size = new System.Drawing.Size(109, 21);
            this.radioButtonNormalMapConst.TabIndex = 0;
            this.radioButtonNormalMapConst.TabStop = true;
            this.radioButtonNormalMapConst.Text = "Const [0,0,1]";
            this.radioButtonNormalMapConst.UseVisualStyleBackColor = true;
            this.radioButtonNormalMapConst.CheckedChanged += new System.EventHandler(this.radioButtonNormalMapConst_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 638);
            this.Controls.Add(this.groupBoxNormalMap);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxFactors);
            this.Controls.Add(this.groupBoxLight);
            this.Controls.Add(this.groupBoxObjectColor);
            this.Controls.Add(this.groupBoxMesh);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "GK1 Lab2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).EndInit();
            this.groupBoxMesh.ResumeLayout(false);
            this.groupBoxMesh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBoxObjectColor.ResumeLayout(false);
            this.groupBoxObjectColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxObjectColor)).EndInit();
            this.groupBoxLight.ResumeLayout(false);
            this.groupBoxLight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLightColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarKs)).EndInit();
            this.groupBoxFactors.ResumeLayout(false);
            this.groupBoxFactors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarKd)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxNormalMap.ResumeLayout(false);
            this.groupBoxNormalMap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxMap;
        private System.Windows.Forms.GroupBox groupBoxMesh;
        private System.Windows.Forms.CheckBox checkBoxMeshVisible;
        private System.Windows.Forms.NumericUpDown numericUpDownColumns;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownRows;
        private System.Windows.Forms.Button buttonNewMesh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxObjectColor;
        private System.Windows.Forms.RadioButton radioButtonConstObjectColor;
        private System.Windows.Forms.RadioButton radioButtonObjectColorT;
        private System.Windows.Forms.PictureBox pictureBoxObjectColor;
        private System.Windows.Forms.ColorDialog colorDialogObjectColor;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBoxLight;
        private System.Windows.Forms.PictureBox pictureBoxLightColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonLightRotating;
        private System.Windows.Forms.RadioButton radioButtonLightStationary;
        private System.Windows.Forms.TrackBar trackBarKs;
        private System.Windows.Forms.GroupBox groupBoxFactors;
        private System.Windows.Forms.Label labelKsValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBarKd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelKdValue;
        private System.Windows.Forms.Label labelmValue;
        private System.Windows.Forms.TrackBar trackBarm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonInterpolatedFilling;
        private System.Windows.Forms.RadioButton radioButtonAccurateFilling;
        private System.Windows.Forms.Button buttonChangeTexture;
        private System.Windows.Forms.GroupBox groupBoxNormalMap;
        private System.Windows.Forms.RadioButton radioButtonNormalMapFromFile;
        private System.Windows.Forms.RadioButton radioButtonNormalMapConst;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButtonChanginColorRotating;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownR;
    }
}

