namespace ConnectFour
{
    internal class Board
    {
        private readonly Dictionary<ConsoleKey, int> _keyToColumn = new()
        {
            {ConsoleKey.D1, 0},
            {ConsoleKey.D2, 1},
            {ConsoleKey.D3, 2},
            {ConsoleKey.D4, 3},
            {ConsoleKey.D5, 4},
            {ConsoleKey.D6, 5},
            {ConsoleKey.D7, 6},
        };
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
                    Position position = new(row, column);
                    Console.Write($"| ");
                    PrintColoredToken(position);
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

        public void SetTokenAt(int column, Player player)
        {
            Position position = NextAvailablePosition(column)!;
            _tokens[position.Row, position.Column] = player.Token;
        }

        public bool HasWon(Token token)
        {
            if (_tokens[0, 0] == token &&
                (_tokens[1, 0] == token &&
                (_tokens[2, 0] == token &&
                (_tokens[3, 0] == token))))
            {
                return true;
            }
            return false;
        }

        public Token GetTokenAt(Position position) => _tokens[position.Row, position.Column];

        public int GetUserChoice()
        {
            int column;
            Console.WriteLine("Which column do you want to place your token?");
            Console.Write("> ");
            ConsoleKeyInfo response = Console.ReadKey();
            Console.WriteLine();

            bool isValidKey = _keyToColumn.TryGetValue(response.Key, out column);

            while (!isValidKey || ColumnIsFull(column))
            {
                Console.WriteLine(isValidKey ? "That column is full!" : "Invalid choice!");
                Console.WriteLine("Which column do you want to place your token?");
                Console.Write("> ");
                response = Console.ReadKey();
                Console.WriteLine();
                isValidKey = _keyToColumn.TryGetValue(response.Key, out column);
            }

            return column;
        }

        private bool ColumnIsFull(int column) => _tokens[0, column] != Token.Empty;
        public Position? NextAvailablePosition(int column)
        {
            for (int row = _tokens.GetLength(0) - 1; row >= 0; row--)
            {
                if (_tokens[row, column] == Token.Empty)
                {
                    return new(row, column);
                }
            }

            return null;
        }

        public void PrintColoredToken(Position position)
        {
            Token token = GetTokenAt(position);
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
