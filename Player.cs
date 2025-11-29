namespace ConnectFour
{
    internal class Player(Token tokenColor)
    {
        public string Name => Token.ToString();
        public Token Token { get; } = tokenColor;
        public ConsoleColor PlayerColor
        { get
            {
                return Token switch
                {
                    Token.Red => ConsoleColor.Red,
                    Token.Yellow => ConsoleColor.Yellow,
                };
            }
        }
    }
}
