using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CharlieDobson_HealthSystem_Programming1
{
    internal class Program
    {
        //player stats
        static int health = 100;
        static string healthStatus = "";
        static int shield = 100;
        static int lives = 3;

        static int xp = 0;
        static int level = 1;
        static int levelUP = 100;
        static void Main(string[] args)
        {

            UnitTestHealthSystem();
            UnitTestXPSystem();
            Console.ReadKey(true);
            Console.Clear();

            ResetGame();
            ShowHUD();
            Console.ReadKey(true);
            Console.Clear();

            Console.WriteLine("Now we are going to attack the player for 50 damange. It should only take Damage from the shield.");
            TakeDamage(50);
            ShowHUD();
            Console.ReadKey(true);
            Console.Clear();

            Console.WriteLine("Now we are going to attack the player for 100 damange. It should take damage to the shield and the health as the shield goes down to zero.");
            TakeDamage(100);
            ShowHUD();
            Console.ReadKey(true);
            Console.Clear();

            Console.WriteLine("Now we are going to heal the player, both their shield and themself. We are going to heal each for 25.");
            RegenerateShield(25);
            Heal(25);
            ShowHUD();
            Console.ReadKey(true);
            Console.Clear();

            Console.WriteLine("Now we are going to heal the player, both their shield and themself. We are going to heal each for 95, however neither should go above 100.");
            RegenerateShield(95);
            Heal(95);
            ShowHUD();
            Console.ReadKey(true);
            Console.Clear();

            Console.WriteLine("Now we are going to attack the player for -100 damange. It shouldn't take any damage as you cannot attack for negative points.");
            TakeDamage(-100);
            ShowHUD();
            Console.ReadKey(true);
            Console.Clear();

            Console.WriteLine("Now we are going to heal the player, both their shield and themself. However, we are healing them for -10 each, so it should return nothing.");
            RegenerateShield(-10);
            Heal(-10);
            ShowHUD();
            Console.ReadKey(true);
            Console.Clear();

            Console.WriteLine("We are now going to kill our player.");
            TakeDamage(200);
            ShowHUD();
            Console.ReadKey(true);
            Console.Clear();

            Console.WriteLine("We are now going to revive our player, it should take a life from their lives.");
            Revive();
            ShowHUD();
            Console.ReadKey(true);
            Console.Clear();

            Console.WriteLine("We are now going to increase the player's xp up to 25.");
            IncreaseXP(25);
            ShowHUD();
            Console.ReadKey(true);
            Console.Clear();

            Console.WriteLine("We are now going to increase player's xp up to the next level. It should reset the xp back to zero.");
            IncreaseXP(75);
            ShowHUD();
            Console.ReadKey(true);
            Console.Clear();

            Console.WriteLine("We are now going to increase player's xp to 225, it should only show 25 by the end but be another level ahead..");
            IncreaseXP(225);
            ShowHUD();
            Console.ReadKey(true);
            Console.Clear();
            
        }

        //Shows the HUD
        static void ShowHUD()
        {
            HealthStatus();
            Console.WriteLine("HUD");
            Line();
            Console.WriteLine($"Lives: {lives}");
            AddSpace();
            Console.WriteLine($"Heath: {health} - {healthStatus}");
            Console.WriteLine($"Shield: {shield}");
            Console.WriteLine($"Level: {level}    EXP: {xp}");
            Line();
        }

        //Takes damage from an attack
        static void TakeDamage(int damage)
        {
            //Checks to make sure the damage inputted isn't below zero
            if (damage < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("!ERROR!");
                Console.ResetColor();
                Console.WriteLine("Player cannot take a negative value of damage. Only a positive value of damage.");
                return;
            }
            
            //States how much Damage the player took
            Console.Write("Player took ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(damage);
            Console.ResetColor();
            Console.Write(" points of damage.");
            AddSpace();

            //Checks to see if the shield has more 
            if (shield >= damage)
            {
                shield -= damage;
            }
            else
            {
                int leftover = damage - shield;
                shield = 0;
                health -= leftover;

                if (health <= leftover)
                {
                    health = 0;
                }
            }

           

        }

        static void Heal(int hp)
        {
            if (hp < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("!ERROR!");
                Console.ResetColor();
                Console.WriteLine("Player cannot be healed a negative amount, only positive");
                return;
            }

            health += hp;

            if(health > 100)
            {
                health = 100;
            }

        }
        static void RegenerateShield(int hp)
        {
            if (hp < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("!ERROR!");
                Console.ResetColor();
                Console.WriteLine("Shield cannot be healed a negative amount, only positive");
                return;
            }

            shield += hp;

            if (shield > 100)
            {
                shield = 100;
            }
        }

        static void IncreaseXP(int exp)
        {
            xp += exp;

            if (xp >= levelUP)
            {
                Console.WriteLine("You gained a level!");
                level++;
                xp -= levelUP;
                levelUP += 100;
            }
        }

        static void Revive()
        {
            if (lives > 0 && health <= 0)
            {
                lives--;
                health = 100;
                shield = 100;
                level = 1;
                xp = 0;
            }
        }

        static void ResetGame()
        {
            lives = 3;
            health = 100;
            shield = 100;
            level = 1;
            xp = 0;
        }

        static void HealthStatus()
        {
            if (health == 100)
            {
                healthStatus = "Perfectly Health";
            }
            else if (health >= 90)
            {
                healthStatus = "Healthy";
            }
            else if (health >= 75)
            {
                healthStatus = "Hurt";
            }
            else if (health >= 50)
            {
                healthStatus = "Badly Hurt";
            }
            else if (health >= 10)
            {
                healthStatus = "Imminent Danger";
            }
            else
            {
                healthStatus = "Dead";
            }
        }

        static void AddSpace()
        {
            Console.WriteLine(" ");
        }

        static void Line()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
        }

        static void UnitTestHealthSystem()
        {
            Debug.WriteLine("Unit testing Health System started...");

            // TakeDamage()

            // TakeDamage() - only shield
            shield = 100;
            health = 100;
            lives = 3;
            TakeDamage(10);
            Debug.Assert(shield == 90);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // TakeDamage() - shield and health
            shield = 10;
            health = 100;
            lives = 3;
            TakeDamage(50);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 60);
            Debug.Assert(lives == 3);

            // TakeDamage() - only health
            shield = 0;
            health = 50;
            lives = 3;
            TakeDamage(10);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 40);
            Debug.Assert(lives == 3);

            // TakeDamage() - health and lives
            shield = 0;
            health = 10;
            lives = 3;
            TakeDamage(25);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 0);
            Debug.Assert(lives == 3);

            // TakeDamage() - shield, health, and lives
            shield = 5;
            health = 100;
            lives = 3;
            TakeDamage(110);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 0);
            Debug.Assert(lives == 3);

            // TakeDamage() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            TakeDamage(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);

            // Heal()

            // Heal() - normal
            shield = 0;
            health = 90;
            lives = 3;
            Heal(5);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 95);
            Debug.Assert(lives == 3);

            // Heal() - already max health
            shield = 90;
            health = 100;
            lives = 3;
            Heal(5);
            Debug.Assert(shield == 90);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // Heal() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            Heal(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);

            // RegenerateShield()

            // RegenerateShield() - normal
            shield = 50;
            health = 100;
            lives = 3;
            RegenerateShield(10);
            Debug.Assert(shield == 60);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // RegenerateShield() - already max shield
            shield = 100;
            health = 100;
            lives = 3;
            RegenerateShield(10);
            Debug.Assert(shield == 100);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // RegenerateShield() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            RegenerateShield(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);

            // Revive()

            // Revive()
            shield = 0;
            health = 0;
            lives = 2;
            Revive();
            Debug.Assert(shield == 100);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 1);

            Debug.WriteLine("Unit testing Health System completed.");
            Console.Clear();
        }

        static void UnitTestXPSystem()
        {
            Debug.WriteLine("Unit testing XP / Level Up System started...");

            // IncreaseXP()

            // IncreaseXP() - no level up; remain at level 1
            xp = 0;
            level = 1;
            IncreaseXP(10);
            Debug.Assert(xp == 10);
            Debug.Assert(level == 1);

            // IncreaseXP() - level up to level 2 (costs 100 xp)
            xp = 0;
            level = 1;
            IncreaseXP(105);
            Debug.Assert(xp == 5);
            Debug.Assert(level == 2);

            // IncreaseXP() - level up to level 3 (costs 200 xp)
            xp = 0;
            level = 2;
            IncreaseXP(210);
            Debug.Assert(xp == 10);
            Debug.Assert(level == 3);

            // IncreaseXP() - level up to level 4 (costs 300 xp)
            xp = 0;
            level = 3;
            IncreaseXP(315);
            Debug.Assert(xp == 15);
            Debug.Assert(level == 4);

            // IncreaseXP() - level up to level 5 (costs 400 xp)
            xp = 0;
            level = 4;
            IncreaseXP(499);
            Debug.Assert(xp == 99);
            Debug.Assert(level == 5);

            Debug.WriteLine("Unit testing XP / Level Up System completed.");
            Console.Clear();
        }

    }
}

