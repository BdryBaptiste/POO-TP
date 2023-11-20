using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TP2
{
    public class Tardis : Spaceship, IAbility
    {
        public Tardis(string _name) : base(1, 0, _name) 
        {
            Name= _name;
        }

        public override void UseAbility(List<Spaceship> spaceships)
        {
            Random random = new Random();
            int shipToMoveIndex = random.Next(spaceships.Count);
            int newPosition = random.Next(spaceships.Count);

            Spaceship shipToMove = spaceships[shipToMoveIndex];
            Spaceship movedShip = spaceships[newPosition];
            spaceships[shipToMoveIndex] = spaceships[newPosition];
            spaceships[newPosition] = shipToMove;

            Console.WriteLine($"Tardis has teleported {shipToMove.Name} and {movedShip.Name}: positions {shipToMoveIndex} and {newPosition}.");

        }
    }
}
