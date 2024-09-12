using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace FinalProjectWPF.Chess
{
    public static class Images
    {
        private static readonly Dictionary<PieceType, ImageSource> whitSources = new()
        {
            {PieceType.Pawn, LoadImage("ChessAssets/PawnW.png") },
            {PieceType.Bishop, LoadImage("ChessAssets/BishopW.png") },
            {PieceType.Knight, LoadImage("ChessAssets/KnightW.png") },
            {PieceType.Rook, LoadImage("ChessAssets/RookW.png") },
            {PieceType.Queen, LoadImage("ChessAssets/QueenW.png") },
            {PieceType.King, LoadImage("ChessAssets/KingW.png") },

        };
        private static readonly Dictionary<PieceType, ImageSource> blackSources = new()
        {
            {PieceType.Pawn, LoadImage("ChessAssets/PawnB.png") },
            {PieceType.Bishop, LoadImage("ChessAssets/BishopB.png") },
            {PieceType.Knight, LoadImage("ChessAssets/KnightB.png") },
            {PieceType.Rook, LoadImage("ChessAssets/RookB.png") },
            {PieceType.King, LoadImage("ChessAssets/KingB.png") },
            {PieceType.Queen, LoadImage("ChessAssets/QueenB.png") },

        };
        private static ImageSource LoadImage(string filePath)
        {
            return new BitmapImage(new Uri(filePath, UriKind.Relative));
        }
        public static ImageSource GetImage(Player color,PieceType type)
        {
            return color switch
            {
                Player.White => whitSources[type],
                Player.Black => blackSources[type],
                _ => null
            };
        }
        public static ImageSource GetImage(Piece piece)
        {
            if (piece == null) return null;
            return GetImage(piece.Color, piece.Type);
        }
    }
}
