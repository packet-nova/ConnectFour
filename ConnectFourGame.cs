namespace ConnectFour
{
    internal class ConnectFourGame
    {
        private readonly Player _red = new(Token.Red);
        private readonly Player _yellow = new(Token.Yellow);
        private readonly Board _board = new();
        private Player _currentPlayer;

        public ConnectFourGame()
        {
            _currentPlayer = Random.Shared.Next(2) == 0 ? _yellow : _red;
        }

        public void Run()
        {
            DisplayPlayerTurn(_currentPlayer);
            _board.RenderBoard();
            _currentPlayer = _currentPlayer == _red ? _yellow : _red;
            Console.ReadLine();
            Console.Clear();
        }

        private void DisplayPlayerTurn(Player player)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = player.PlayerColor;
            Console.WriteLine($"It is {_currentPlayer.Name.ToUpper()}'s turn.");
            Console.ForegroundColor = previousColor;
        }
    }

    public enum Token { Empty, Red, Yellow }
}
