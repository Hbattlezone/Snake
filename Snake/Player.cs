using System.Collections.Generic;

namespace Snake
{
    public class Player
    {
        private List<(string, int, int)> snakeAttributes = new List<(string Name, int Amount, int Coordinates)>
        {
            (Name: "S", Amount: 0, Coordinates: 0)
        };

        public Player()
        {

        }
    }
}