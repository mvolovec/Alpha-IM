using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Interop;
using System.Windows.Media;

namespace WPF_IM_CLIENT
{
    public class WindowTemplate : Window
    {
        #region CustomProperties
        private bool _canResize;
        public bool CanResize 
        {
            get
            {
                return _canResize;
            }
            set
            {
                _canResize = value;
            }
        }
        #endregion


        private Button _close;
        private Button _minimize;
        private Button _maximize;
        private Border _dragWindow;
        private Image _resizeButton;

        public WindowTemplate()
        {
            this.SourceInitialized += new EventHandler(InitializeWindowSource);
        }

        public virtual void Window_Loaded()
        {
            HandlersSetUp();
        }

        /// <summary>
        /// Metoda nastavuje controlkam 
        /// </summary>
        private void HandlersSetUp()
        {
            this._close = (Button)this.Template.FindName("btnClose", this);
            this._minimize = (Button)this.Template.FindName("btnMinimize", this);
            //this._maximize = (Button)this.Template.FindName("btnMaximize", this);
            this._dragWindow = (Border)this.Template.FindName("template_header", this);
            this._resizeButton = (Image)this.Template.FindName("bottomRight", this);

            this._close.Click += new RoutedEventHandler(_close_Click);
            this._minimize.Click += new RoutedEventHandler(_minimize_Click);
            //this._maximize.Click += new RoutedEventHandler(_maximize_Click);

            this._dragWindow.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(_dragWindow_MouseLeftButtonDown);

            if (CanResize)
            {
                this._resizeButton.MouseMove += new MouseEventHandler(DisplayResizeCursor);
                this._resizeButton.PreviewMouseDown += new MouseButtonEventHandler(Resize);
                this._resizeButton.MouseLeave += new MouseEventHandler(ResetCursor);
            }
            else
                this._resizeButton.Visibility = Visibility.Hidden;
        }

        void _maximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

        void _minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        void _dragWindow_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        void _close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Neautenticke metody vyuzivajici nebezpecny kod windows win32 api
        /// </summary>
        #region resize
        private const int WM_SYSCOMMAND = 0x112;
        private HwndSource hwndSource;

        //public Window1()
        //{
        //    this.InitializeComponent();
			
        //    // Insert code required on object creation below this point.

        //    this.SourceInitialized += new EventHandler(InitializeWindowSource);
        //}

        private void InitializeWindowSource(object sender, EventArgs e)
        {
            hwndSource = PresentationSource.FromVisual((Visual)sender) as HwndSource;
            hwndSource.AddHook(new HwndSourceHook(WndProc));
        }

        IntPtr retInt = IntPtr.Zero;

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            Debug.WriteLine("WndProc messages: " + msg.ToString());
            //
            // Check incoming window system messages
            //
            if (msg == WM_SYSCOMMAND)
            {
                Debug.WriteLine("WndProc messages: " + msg.ToString());
            }
            
            return IntPtr.Zero;
        }

        public enum ResizeDirection
        {
            Left = 1,
            Right = 2,
            Top = 3,
            TopLeft = 4,
            TopRight = 5,
            Bottom = 6,
            BottomLeft = 7,
            BottomRight = 8,
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private void ResizeWindow(ResizeDirection direction)
        {
            SendMessage(hwndSource.Handle, WM_SYSCOMMAND, (IntPtr) (61440 + direction), IntPtr.Zero);
        }

        private void ResetCursor(object sender, MouseEventArgs e)
        {
            if (Mouse.LeftButton != MouseButtonState.Pressed)
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void Resize(object sender, MouseButtonEventArgs e)
        {
            Image clickedRectangle = sender as Image;

            switch (clickedRectangle.Name)
            {
                case "top":
                    this.Cursor = Cursors.SizeNS;
                    ResizeWindow(ResizeDirection.Top);
                    break;
                case "bottom":
                    this.Cursor = Cursors.SizeNS;
                    ResizeWindow(ResizeDirection.Bottom);
                    break;
                case "left":
                    this.Cursor = Cursors.SizeWE;
                    ResizeWindow(ResizeDirection.Left);
                    break;
                case "right":
                    this.Cursor = Cursors.SizeWE;
                    ResizeWindow(ResizeDirection.Right);
                    break;
                case "topLeft":
                    this.Cursor = Cursors.SizeNWSE;
                    ResizeWindow(ResizeDirection.TopLeft);
                    break;
                case "topRight":
                    this.Cursor = Cursors.SizeNESW;
                    ResizeWindow(ResizeDirection.TopRight);
                    break;
                case "bottomLeft":
                    this.Cursor = Cursors.SizeNESW;
                    ResizeWindow(ResizeDirection.BottomLeft);
                    break;
                case "bottomRight":
                    this.Cursor = Cursors.SizeNWSE;
                    ResizeWindow(ResizeDirection.BottomRight);
                    break;
                default:
                    break;
            }
        }

        private void DisplayResizeCursor(object sender, MouseEventArgs e)
        {
            Image clickedRectangle = sender as Image;

            switch (clickedRectangle.Name)
            {
                case "top":
                    this.Cursor = Cursors.SizeNS;
                    break;
                case "bottom":
                    this.Cursor = Cursors.SizeNS;
                    break;
                case "left":
                    this.Cursor = Cursors.SizeWE;
                    break;
                case "right":
                    this.Cursor = Cursors.SizeWE;
                    break;
                case "topLeft":
                    this.Cursor = Cursors.SizeNWSE;
                    break;
                case "topRight":
                    this.Cursor = Cursors.SizeNESW;
                    break;
                case "bottomLeft":
                    this.Cursor = Cursors.SizeNESW;
                    break;
                case "bottomRight":
                    this.Cursor = Cursors.SizeNWSE;
                    break;
                default:
                    break;
            }
        }

        private void Drag(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion

    }
}
