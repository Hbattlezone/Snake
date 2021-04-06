using System.Collections.Generic;

namespace Snake
{
    public class Player
    {
        private string _name { get; set; }
        private int _amount { get; set; }
        private int _coordinates { get; set; }

        public Player()
        {

        }

        public string GetName()
        {
            return _name;
        }
        public void SetName(string name)
        {
            _name = name;
        }

        public int GetAmount()
        {
            return _amount;
        }
        public void SetAmount(int amount)
        {
            _amount = amount;
        }

        public int GetCoord()
        {
            return _coordinates;
        }
        public void SetCoord(int coord)
        {
            _coordinates = coord;
        }

        public void MovePlayer()
        {
            
        }
    }
}