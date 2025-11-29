namespace ConnectFour
{
    internal class Board
    {
        public static void RenderBoard()
        {
            //char right = '\u22A2';
            char right = '\u251C';
            char left = '\u2524';
            char down = '\u252C';
            char up = '\u2534';
            char topLeft = '\u250C';
            char topRight = '\u2510';
            char bottomLeft = '\u2514';
            char bottomRight = '\u2518';


            Console.WriteLine($"""
            {topLeft}---{down}---{down}---{down}---{down}---{down}---{down}---{topRight}
            |   |   |   |   |   |   |   |
            {right}---+---+---+---+---+---+---{left}
            |   |   |   |   |   |   |   |
            {right}---+---+---+---+---+---+---{left}
            |   |   |   |   |   |   |   |
            {right}---+---+---+---+---+---+---{left}
            |   |   |   |   |   |   |   |
            {right}---+---+---+---+---+---+---{left}
            |   |   |   |   |   |   |   |
            {right}---+---+---+---+---+---+---{left}
            |   |   |   |   |   |   |   |
            {bottomLeft}---{up}---{up}---{up}---{up}---{up}---{up}---{bottomRight}
            """
                );
        }
    }
}
