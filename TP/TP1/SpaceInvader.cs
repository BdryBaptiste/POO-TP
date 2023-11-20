using System;

namespace TP1
{
    class SpaceInvaders
    {
        private List<Player> players;
        private Armory armory;

        private void Init()
        {
            string firstName, lastName;
            int maxStructure, maxShield;

            for (int i = 1; i < 4; ++i)
            {
                Console.WriteLine("What's the firstname and lastname of Player" + i + " ?");
                firstName = Console.ReadLine();
                lastName = Console.ReadLine();

                Console.WriteLine("What's the maximum structure and maximum shield of Player" + i + "'s spaceship ?");
                maxStructure = Convert.ToInt32(Console.ReadLine());
                maxShield = Convert.ToInt32(Console.ReadLine());

                Spaceship spaceship = new Spaceship(maxStructure,maxShield);

                players.Add(new Player(firstName, lastName, "Player" + i, spaceship));

            }
        }

        public SpaceInvaders()
        {
            armory = new Armory();
            players = new List<Player>();
            Init();
            
        }

        static void Main()
        {
            int input;
            Weapon addWeapon;
            SpaceInvaders game = new SpaceInvaders();
            

            foreach (var player in game.players)
            {
                Console.WriteLine(player.ToString());
                for(int i = 1; i < 4 ; i++)
                {
                    Console.WriteLine("************************************************");
                    Console.WriteLine("Add a weapon in slot " + i + " from your armory:");
                    game.armory.ViewArmory();
                    input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            addWeapon = game.armory.GetWeapon("Gauss");
                            break;
                        case 2:
                            addWeapon = game.armory.GetWeapon("Heavy Cannon");
                            break;
                        case 3:
                            addWeapon = game.armory.GetWeapon("Anti-Matter Missile");
                            break;
                        default:
                            addWeapon = game.armory.GetWeapon("Gauss");
                            break;
                    }
                    player.Spaceship.AddWeapon(addWeapon);
                }
                Console.WriteLine("************************************************");
                Console.WriteLine(player.ToString());
                player.Spaceship.ViewShip();
                double averageDamages = player.Spaceship.AverageDamages();
                Console.WriteLine($"Spaceship's average damage : {averageDamages}");
                Console.WriteLine("************************************************");
            }
        }
    }
}
