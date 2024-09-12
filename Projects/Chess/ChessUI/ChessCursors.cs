using System.IO;
using System.Windows;
using System.Windows.Input;


namespace FinalProjectWPF.Chess
{
    public static class ChessCursors
    {
        public static readonly Cursor WhiteCursor = LoadCursor("ChessAssets/CursorW.cur");
        public static readonly Cursor BlackCursor = LoadCursor("ChessAssets/CursorB.cur");




        public static Cursor LoadCursor(string filePath)
        {
            Stream stream = Application.GetResourceStream(new Uri(filePath, UriKind.Relative)).Stream;
            return new Cursor(stream, true);
        }
    }
}
