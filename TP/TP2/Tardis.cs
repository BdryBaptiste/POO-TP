using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class Tardis : Spaceship, IAbility
    {
        public Tardis() : base(1, 0)
        {
        }

        public void UseAbility(List<Spaceship> spaceships)
        {
            Random random = new Random();
            int shipToMoveIndex = random.Next(spaceships.Count);
            int newPosition = random.Next(spaceships.Count);

            Spaceship shipToMove = spaceships[shipToMoveIndex];
            spaceships[shipToMoveIndex] = spaceships[newPosition];
            spaceships[newPosition] = shipToMove;

            Console.WriteLine($"Tardis has teleported {shipToMove.Name} from position {shipToMoveIndex} to {newPosition}.");
        }
    }
}
