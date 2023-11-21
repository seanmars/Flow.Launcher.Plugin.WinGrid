using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using Flow.Launcher.Plugin;

namespace Flow.Launcher.Plugin.WinGrid
{
    public class WinGrid : IPlugin
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, System.Text.StringBuilder text, int count);

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);


        private IntPtr _foregroundWindowHandle;

        private PluginInitContext _context;
        private Timer _timer;

        private static List<string> windowHistory = new List<string>();

        public void Init(PluginInitContext context)
        {
            _context = context;

            var callback = new TimerCallback(Update);
            _timer = new Timer(callback, null, 0, 100);
        }

        private void Update(object state)
        {
            var current = GetForegroundWindow();
            if (current != IntPtr.Zero)
            {
                return;
            }

        }

        public List<Result> Query(Query query)
        {
            return new List<Result>();
        }
    }
}