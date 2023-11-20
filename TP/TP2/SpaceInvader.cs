using Microsoft.VisualBasic;
using System;

namespace TP2
{
    class SpaceInvaders
    {
        private Armory armory;
        private List<Spaceship> enemyShips = new List<Spaceship>();
        private ViperMKII playerShip = new ViperMKII("Viper");
        private List<string> viperWinQuoteList = new List<string> { "You need to move faster than that son, speed is life.", "When you get to hell, tell em' Viper sent you.", "You hitched your last ride, son. This is your stop.", "Voodoo 1, Viper's on station. Your journey ends here, Pilot. The skies belong to me. Nowhere to run, nowhere to hide.", "You're just too weak for the Skies son." };
        private List<string> viperLoseQuoteList = new List<string> { "Viper one lost control! I'm losing control! Going down! Mayday! Mayday! Going down!", "Argh! Taking fire! O nine zero for twenty, it's, uh, getting a little hot up here.", "Viper one is hit" };

        private void Init()
        {
            string firstName, lastName;

            Console.WriteLine("What's your the firstname and lastname ?");
            firstName = Console.ReadLine();
            lastName = Console.ReadLine();

            Player Player1 = new Player(firstName, lastName, "Player1", playerShip);

            enemyShips.Add(new Tardis("Tardis"));
            enemyShips.Add(new F18("F18"));
            enemyShips.Add(new Dart("Dart"));
            enemyShips.Add(new BWings("BWing"));
            enemyShips.Add(new Rocinante("Rocicante"));
        }

        public SpaceInvaders()
        {
            Init();
        }

        public void PlayRound()
        {
            var allShips = enemyShips.Concat(new List<Spaceship> { playerShip }).ToList();
            var livingEnemies = enemyShips.Where(e => !e.IsDestroyed).ToList();

            Console.WriteLine("************************************************");
            Console.WriteLine("Status at turn start :");

            foreach (var ship in allShips)
            {
                string status = ship.IsDestroyed ? "Détruit" : "Actif";
                if (ship == playerShip)
                {
                    Console.WriteLine($"You: ({ship.Name}) - Structure: {ship.CurrentStructure}, Shield: {ship.CurrentShield}, Status: {status}");
                }
                else
                {
                    Console.WriteLine($"Enemy ({ship.Name}) - Structure: {ship.CurrentStructure}, Shield: {ship.CurrentShield}, Status: {status}");
                }
            }
            Console.WriteLine("************************************************");

            foreach (var ship in livingEnemies)
            {
                ship.UseAbility(allShips);
                ship.RepairShield(2);
            }

            playerShip.RepairShield(1);

            foreach (var enemy in livingEnemies)
            {
                enemy.ShootTarget(playerShip);
            }

            if (livingEnemies.Any())
            {
                var target = livingEnemies[new Random().Next(livingEnemies.Count)];
                playerShip.ShootTarget(target);
            }

            Console.WriteLine("************************************************");

            Console.WriteLine("Status at turn end:");
           
            foreach (var ship in allShips)
            {
                string status = ship.IsDestroyed ? "Détruit" : "Actif";
                if (ship == playerShip)
                {
                    Console.WriteLine($"You: ({ship.Name}) - Structure: {ship.CurrentStructure}, Shield: {ship.CurrentShield}, Status: {status}");
                }
                else
                {
                    Console.WriteLine($"Enemy ({ship.Name}) - Structure: {ship.CurrentStructure}, Shield: {ship.CurrentShield}, Status: {status}");
                }
            }
            if (playerShip.IsDestroyed)
            {
                Console.WriteLine("Your ship was destroyed !");
            }
            Console.WriteLine("Appuyez sur Entrée pour continuer...");
            Console.ReadLine();
            Console.WriteLine("************************************************");
        }

        string RandomStringSelection(List<string> list)
        {
            Random random = new Random();
            int index = random.Next(list.Count);
            return list[index];
        }

        static void Main()
        {
            SpaceInvaders game = new SpaceInvaders();

            while (!game.playerShip.IsDestroyed && game.enemyShips.Any(e => !e.IsDestroyed))
            {
                game.PlayRound();
            }

            if (game.playerShip.IsDestroyed)
            {
                Console.WriteLine("GameOver. Viper: " + game.RandomStringSelection(game.viperLoseQuoteList));
            }
            else
            {
                Console.WriteLine("You Win. Viper: " + game.RandomStringSelection(game.viperWinQuoteList));
            }
        }
    }
}
