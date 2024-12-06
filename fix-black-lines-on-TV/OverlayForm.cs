using System.Runtime.InteropServices;

namespace fix_black_lines_on_TV;

public partial class OverlayForm : Form
{
    [DllImport("user32.dll", SetLastError = true)]
    private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    private const int GWL_EXSTYLE = -20; // Extended window styles
    private const int WS_EX_LAYERED = 0x80000; // Allows transparency
    private const int WS_EX_TOOLWINDOW = 0x80; // Hides from Alt+Tab
    private const int WS_EX_NOACTIVATE = 0x8000000; // Prevents activation on click

    private NotifyIcon _trayIcon;
    private ContextMenuStrip _trayMenu;
    private int _targetScreenIndex = 0;

    public OverlayForm()
    {
        SetVisuals();
        
        InitializeTrayIcon();
        UpdateTrayMenu();
        
        OnDisplaySizeChange();
    }

    private void InitializeTrayIcon()
    {
        _trayIcon = new NotifyIcon
        {
            Text = "FixBlackLines",
            Icon = SystemIcons.Application, // Template
            ContextMenuStrip = _trayMenu,
            Visible = true
        };

        _trayIcon.MouseDoubleClick += (sender, e) =>
        {
            if (e.Button != MouseButtons.Left) return;
            OnToggleOverlay();
        };
    }

    private void UpdateTrayMenu()
    {
        _trayMenu = new ContextMenuStrip();

        _trayMenu.Items.Add(Visible ? "Turn Off" : "Turn On", null, (sender, e) => OnToggleOverlay());
        _trayMenu.Items.Add(new ToolStripSeparator());
        _trayMenu.Items.Add("Control Panel", null, (sender, e) => OnOpenControlPanel());
        _trayMenu.Items.Add(new ToolStripSeparator());
        _trayMenu.Items.Add("Exit", null, (sender, e) => OnExit());
        
        _trayIcon.ContextMenuStrip = _trayMenu;
    }

    private void OnToggleOverlay()
    {
        Visible = !Visible;
        
        UpdateTrayMenu();
    }

    private void OnExit()
    {
        _trayIcon.Visible = false;
        
        Application.Exit();
    }

    private void SetVisuals()
    {
        this.SuspendLayout();
        this.Name = "OverlayForm";
        this.ResumeLayout(false);

        this.ShowInTaskbar = false; // Hide from taskbar
        this.FormBorderStyle = FormBorderStyle.None; // Remove window borders
        this.TopMost = true; // Keep the form on top
        this.WindowState = FormWindowState.Normal; // Set normal state
        this.BackColor = Color.White; // Set a background color (used for transparency)
        this.TransparencyKey = Color.White; // Make this color transparent
        this.AllowTransparency = true; // Enable transparency

        // Set the window styles to hide it and allow interaction
        var exStyle = GetWindowLong(this.Handle, GWL_EXSTYLE);
        SetWindowLong(this.Handle, GWL_EXSTYLE, exStyle | WS_EX_LAYERED | WS_EX_TOOLWINDOW | WS_EX_NOACTIVATE);
    }

    protected override void WndProc(ref Message m)
    {
        const int WM_DISPLAYCHANGE = 0x007E;

        if (m.Msg == WM_DISPLAYCHANGE) OnDisplaySizeChange();
        Console.WriteLine(m.Msg);

        base.WndProc(ref m);
    }

    private void OnDisplaySizeChange()
    {
        var targetScreen = Screen.AllScreens[_targetScreenIndex];
        var screenBounds = targetScreen.Bounds;

        // Fullscreen
        this.Location = new Point(screenBounds.Left, screenBounds.Top);
        this.Size = new Size(screenBounds.Width, screenBounds.Height);
        
        this.Invalidate();
    }
    
    private int _brushHeight = 4;
    private int _brushSize = 1;
    private int _brushOffset = 1;
    private decimal _opacity = 0.7m;

    private void OnOpenControlPanel()
    {
        var settingsForm = new PatternBrushSettingsForm(_brushHeight, _brushSize, _brushOffset, _opacity, _targetScreenIndex);
        settingsForm.SettingsApplied += (sender, e) =>
        {
            _brushHeight = settingsForm.BrushHeight;
            _brushSize = settingsForm.BrushSize;
            _brushOffset = settingsForm.BrushOffset;
            _opacity = settingsForm.Opacity;
            this.Opacity = (double)_opacity;
            
            if (_targetScreenIndex != settingsForm.ScreenIndex)
            {
                _targetScreenIndex = settingsForm.ScreenIndex;
                OnDisplaySizeChange();
            }
            
            this.Invalidate();
        };
        settingsForm.ShowDialog();
    }
    
    private TextureBrush CreatePatternBrush()
    {
        var pattern = new Bitmap(_brushHeight, _brushHeight);
        using (var g = Graphics.FromImage(pattern))
        {
            g.Clear(Color.Transparent);
            using (var p = new Pen(Color.Black, _brushSize))
            {
                g.DrawLine(p, 0, _brushOffset, _brushHeight - 1, _brushOffset);
            }
        }
        return new TextureBrush(pattern);
    }
    
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        
        using var brush = CreatePatternBrush();
        
        e.Graphics.FillRectangle(brush, this.ClientRectangle);
    }
}