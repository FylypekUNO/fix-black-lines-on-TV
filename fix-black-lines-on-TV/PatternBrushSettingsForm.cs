using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace fix_black_lines_on_TV
{
    public partial class PatternBrushSettingsForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BrushHeight { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BrushSize { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BrushOffset { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BrushAlpha { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ScreenIndex { get; private set; }

        public event EventHandler? SettingsApplied;

        public PatternBrushSettingsForm(int currentHeight, int currentSize, int currentOffset, int currentAlpha, int currentScreen)
        {
            InitializeComponent();

            // Initialize screen combo box
            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                var screen = Screen.AllScreens[i];
                comboBoxScreen.Items.Add($"Screen {i + 1}: {screen.Bounds.Width}x{screen.Bounds.Height}");
            }
            
            comboBoxScreen.SelectedIndex = currentScreen;
            numericUpDownHeight.Value = currentHeight;
            numericUpDownSize.Value = currentSize;
            numericUpDownOffset.Value = currentOffset;
            numericUpDownAlpha.Value = currentAlpha;
        }

        private void ApplySettings()
        {
            BrushHeight = (int)numericUpDownHeight.Value;
            BrushSize = (int)numericUpDownSize.Value;
            BrushOffset = (int)numericUpDownOffset.Value;
            BrushAlpha = (int)numericUpDownAlpha.Value;
            ScreenIndex = comboBoxScreen.SelectedIndex;
            SettingsApplied?.Invoke(this, EventArgs.Empty);
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            ApplySettings();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ApplySettings();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}