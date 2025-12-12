namespace ConnectFour
{
    internal class ConnectFourGame
    {
        private readonly Player _red = new(Token.Red);
        private readonly Player _yellow = new(Token.Yellow);
        private readonly Board _board = new();
        private Player _currentPlayer;
        private void SwitchPlayers() => _currentPlayer = _currentPlayer == _red ? _yellow : _red;

        public ConnectFourGame()
        {
            _currentPlayer = Random.Shared.Next(2) == 0 ? _yellow : _red;
        }

        public void Run()
        {
            while (!_board.PlayerHasWon())
            {
                DisplayPlayerTurn(_currentPlayer);
                _board.RenderBoard();
                _board.SetTokenAt(_board.GetUserChoice(), _currentPlayer);
                if (_board.PlayerHasWon())
                {
                    Console.Clear();
                    _board.RenderBoard();
                    PlayerWinMessage();
                    break;
                }
                else
                {
                    Console.Clear();
                    SwitchPlayers();
                }
            }
        }

        private void DisplayPlayerTurn(Player player)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = player.PlayerColor;
            Console.WriteLine($"It is {_currentPlayer.Name.ToUpper()}'s turn.");
            Console.ForegroundColor = previousColor;
        }

        private void PlayerWinMessage()
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = _currentPlayer.PlayerColor;

            Console.WriteLine($"{_currentPlayer.Name} has won!");
            Console.ForegroundColor = previousColor;
            Console.WriteLine("Press any key to continue!");
            Console.ReadLine();
            Console.Clear();
            return;
        }
    }



    public enum Token { Empty, Red, Yellow }
}
