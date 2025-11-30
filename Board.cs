namespace ConnectFour
{
    internal class Board
    {
        private readonly Token[,] _tokens = new Token[6, 7];

        public void RenderBoard()
        {
            char right = '\u251C';
            char left = '\u2524';
            char down = '\u252C';
            char up = '\u2534';
            char topLeft = '\u250C';
            char topRight = '\u2510';
            char bottomLeft = '\u2514';
            char bottomRight = '\u2518';
            string divider = $"{right}---+---+---+---+---+---+---{left}";
            string topBorder = $"{topLeft}---{down}---{down}---{down}---{down}---{down}---{down}---{topRight}";
            string bottomBorder = $"{bottomLeft}---{up}---{up}---{up}---{up}---{up}---{up}---{bottomRight}";

            Console.ForegroundColor = ConsoleColor.Blue;
            
            Console.WriteLine(topBorder);
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
                    Console.WriteLine(divider);
                }
            }
            Console.WriteLine(bottomBorder);
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
