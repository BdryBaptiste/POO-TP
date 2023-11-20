using System;

namespace TP2
{
    class SpaceInvaders
    {
        private Armory armory;
        private List<Spaceship> enemyShips = new List<Spaceship>();
        private ViperMKII playerShip;

        private void Init()
        {
            string firstName, lastName;

            Console.WriteLine("What's your the firstname and lastname ?");
            firstName = Console.ReadLine();
            lastName = Console.ReadLine();

            Player Player1 = new Player(firstName, lastName, "Player1", playerShip);

            enemyShips.Add(new Tardis());
            enemyShips.Add(new F18());
            enemyShips.Add(new Dart());
            enemyShips.Add(new BWings());
            enemyShips.Add(new Rocinante());
        }

        public SpaceInvaders()
        {
            Init();
        }

        public void PlayRound()
        {
            foreach (var ship in enemyShips)
            {
                ship.RepairShield(2);
            }

            foreach (var enemy in enemyShips)
            {
                enemy.ShootTarget(playerShip);
            }

            var livingEnemies = enemyShips.Where(e => !e.IsDestroyed).ToList();
            if (livingEnemies.Any())
            {
                var target = livingEnemies[new Random().Next(livingEnemies.Count)];
                playerShip.ShootTarget(target);
            }

            Console.WriteLine("Status :");
        }

        static void Main()
        {
            SpaceInvaders game = new SpaceInvaders();

            while (!game.playerShip.IsDestroyed && game.enemyShips.Any(e => !e.IsDestroyed))
            {
                game.PlayRound();
            }

            Console.WriteLine(game.playerShip.IsDestroyed ? "GameOver" : "You Win");
        }
    }
}
