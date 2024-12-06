namespace fix_black_lines_on_TV
{
    partial class PatternBrushSettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private NumericUpDown numericUpDownHeight;
        private NumericUpDown numericUpDownSize;
        private NumericUpDown numericUpDownOffset;
        private NumericUpDown numericUpDownOpacity;
        private Button buttonOK;
        private Button buttonCancel;
        private Button buttonApply;
        private ComboBox comboBoxScreen;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.numericUpDownHeight = new NumericUpDown();
            this.numericUpDownSize = new NumericUpDown();
            this.numericUpDownOffset = new NumericUpDown();
            this.numericUpDownOpacity = new NumericUpDown();
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.buttonApply = new Button();
            this.comboBoxScreen = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Location = new Point(20, 20);
            this.numericUpDownHeight.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numericUpDownHeight.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new Size(150, 30);
            this.numericUpDownHeight.TabIndex = 0;
            // 
            // numericUpDownSize
            // 
            this.numericUpDownSize.Location = new Point(20, 60);
            this.numericUpDownSize.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numericUpDownSize.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numericUpDownSize.Name = "numericUpDownSize";
            this.numericUpDownSize.Size = new Size(150, 30);
            this.numericUpDownSize.TabIndex = 1;
            // 
            // numericUpDownOffset
            // 
            this.numericUpDownOffset.Location = new Point(20, 100);
            this.numericUpDownOffset.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numericUpDownOffset.Name = "numericUpDownOffset";
            this.numericUpDownOffset.Size = new Size(150, 30);
            this.numericUpDownOffset.TabIndex = 2;
            // 
            // numericUpDownOpacity
            // 
            this.numericUpDownOpacity.Location = new Point(20, 140);
            this.numericUpDownOpacity.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numericUpDownOpacity.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numericUpDownOpacity.DecimalPlaces = 1;
            this.numericUpDownOpacity.Increment = new decimal(new int[] { 1, 0, 0, 65536 }); // 0.1
            this.numericUpDownOpacity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numericUpDownOpacity.Name = "numericUpDownOpacity";
            this.numericUpDownOpacity.Size = new Size(150, 30);
            this.numericUpDownOpacity.TabIndex = 3;
            // 
            // comboBoxScreen
            // 
            this.comboBoxScreen.Location = new Point(20, 180);
            this.comboBoxScreen.Name = "comboBoxScreen";
            this.comboBoxScreen.Size = new Size(150, 30);
            this.comboBoxScreen.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxScreen.TabIndex = 4;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new Point(20, 270);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(100, 40);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new Point(130, 270);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(100, 40);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new Point(20, 220);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new Size(100, 40);
            this.buttonApply.TabIndex = 4;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new EventHandler(this.buttonApply_Click);
            // 
            // PatternBrushSettingsForm
            // 
            this.ClientSize = new Size(260, 330);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.comboBoxScreen);
            this.Controls.Add(this.numericUpDownOpacity);
            this.Controls.Add(this.numericUpDownOffset);
            this.Controls.Add(this.numericUpDownSize);
            this.Controls.Add(this.numericUpDownHeight);
            this.Name = "PatternBrushSettingsForm";
            this.Text = "Brush Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOpacity)).EndInit();
            this.ResumeLayout(false);
        }
    }
}