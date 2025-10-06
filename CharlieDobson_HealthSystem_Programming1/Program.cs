using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
        static void Main(string[] args)
        {
        
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
        }

        static void IncreaseXP(int exp)
        {
            xp += exp;
            int levelUP = 100;

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

    }
}

