namespace ConnectFour
{
    internal class Player(Token tokenColor)
    {
        public string Name => Token.ToString();
        public Token Token { get; } = tokenColor;
        public ConsoleColor PlayerColor => Token == Token.Red ? ConsoleColor.Red : ConsoleColor.Yellow;
    }
}
