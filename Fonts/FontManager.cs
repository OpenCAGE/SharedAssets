using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;

static class FontManager
{
    static PrivateFontCollection fonts;

    static FontManager()
    {
        fonts = new PrivateFontCollection();
    }

    static public void AddFont(byte[] fontData)
    {
        IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
        Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
        fonts.AddMemoryFont(fontPtr, fontData.Length);
        Marshal.FreeCoTaskMem(fontPtr);
    }

    static public Font GetFont(int index, int size)
    {
        return new Font(fonts.Families[index], size);
    }
}