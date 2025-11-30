namespace ConnectFour
{
    internal class Board
    {
        private readonly Token[,] _tokens = new Token[6, 7];
        private const char Right = '\u251C';
        private const char Down = '\u252C';
        private const char Left = '\u2524';
        private const char Up = '\u2534';
        private const char TopLeft = '\u250C';
        private const char TopRight = '\u2510';
        private const char BottomLeft = '\u2514';
        private const char BottomRight = '\u2518';
        private readonly string _divider = $"{Right}---+---+---+---+---+---+---{Left}";
        private readonly string _topBorder = $"{TopLeft}---{Down}---{Down}---{Down}---{Down}---{Down}---{Down}---{TopRight}";
        private readonly string _bottomBorder = $"{BottomLeft}---{Up}---{Up}---{Up}---{Up}---{Up}---{Up}---{BottomRight}";

        public void RenderBoard()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            
            Console.WriteLine(_topBorder);
            for (int row = 0; row < _tokens.GetLength(0); row++)
            {
                for (int column = 0; column < _tokens.GetLength(1); column++)
                {
                    Console.Write($"| ");
                    PrintColoredToken(row, column);
                    Console.Write($" ");
                }
                Console.WriteLine("|");
                if (row < (_tokens.GetLength(0) - 1))
                {
                    Console.WriteLine(_divider);
                }
            }
            Console.WriteLine(_bottomBorder);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  1   2   3   4   5   6   7");
            
            Console.WriteLine();
        }

        public void SetTokenAt(int row, int column, Player player) => _tokens[row, column] = player.Token;
        public Token GetTokenAt(int row, int column) => _tokens[row, column];

        public void PrintColoredToken(int row, int column)
        {
            Token token = GetTokenAt(row, column);
            ConsoleColor previousColor = Console.ForegroundColor;
            char tokenDisplay = ' ';

            switch (token)
            {
                case Token.Red:
                    tokenDisplay = 'O';
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Token.Yellow:
                    tokenDisplay = 'O';
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }
            Console.Write(tokenDisplay);

            Console.ForegroundColor = previousColor;
        }
    }
}
