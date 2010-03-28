using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF_IM_CLIENT
{
    public static class WindowManager
    {
        public static WindowTemplate CreateChildWindow(WindowTemplate parent)
        {
            WindowTemplate w = new WindowTemplate();
            w.ParentWindow = parent;
            parent.ChildWindows.Add(w);
            return w;
        }
    }
}
