﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace TotalCommander
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SHFILEINFO
    {
        public IntPtr hIcon;
        public IntPtr iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    };
    class SpyIcon
    {
        public const uint SHGFI_ICON = 0x100;
        public const uint SHGFI_LARGEICON = 0x0;    // 'Large icon
        public const uint SHGFI_SMALLICON = 0x1;    // 'Small icon

        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath,
                                    uint dwFileAttributes,
                                    ref SHFILEINFO psfi,
                                    uint cbSizeFileInfo,
                                    uint uFlags);
        public static System.Drawing.Icon GetIcon(string path)
        {
            SHFILEINFO sinfo = new SHFILEINFO();
            IntPtr iconHwnd = SHGetFileInfo(path, 0, ref sinfo, (uint)Marshal.SizeOf(sinfo), SHGFI_ICON | SHGFI_LARGEICON | SHGFI_SMALLICON);
            return System.Drawing.Icon.FromHandle(sinfo.hIcon);
        }
    }
}
