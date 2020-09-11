using System;
using System.Collections.Generic;
using System.Text;

namespace Pvp_text_based_fighting
{
    class Game
    {
        struct Player
        {
            public string _playerName;
            public int _damage;
            public int _defense;
            public int _health;
        }

        struct Item
        {
            public string _name;
            public int _stats;
        }


        bool gameOver = false;
        Player player1;
        Player player2;
        //Item longsword;
        //Item sledgeHammer;

        public void Run()
        {
            Start();
            while (gameOver == false)
            {
                Update();
            }
            End();
        }
        void GetInput(out char input, string option1, string option2, string query)
        {
            Console.WriteLine(query);
            input = ' ';
            while (input != '1' && input != '2')
            {
                Console.WriteLine("1." + option1);
                Console.WriteLine("2." + option2);
                input = Console.ReadKey().KeyChar;
            }

        }

        void GetInput(out char input, string option1, string option2)
        {
            input = ' ';
            while (input != '1' && input != '2')
            {
                Console.WriteLine("1." + option1);
                Console.WriteLine("2." + option2);
                input = Console.ReadKey().KeyChar;
            }
        }

        void Block(ref int opponentHealth, int attackVal, int opponentDefense)
        {
            int damage = attackVal - opponentDefense;
            if (damage < 0)
            {
                damage = 0;
            }
            opponentHealth -= damage;
        }
        void EquipWeapon()
        {
            char input;
            GetInput(out input, "Longsword", "SledgeHammer", "Player one choose you item of destruction");
            if (input == '1')
            {
                player1._damage = 10;
            }
            else
            {
                player1._damage = 30;
            }
            Console.Clear();
            GetInput(out input, "Longsword", "SledgeHammer", "Player two, you now");
            if (input == '1')
            {
                player2._damage = 10;
            }
            else
            {
                player2._damage = 30;
            }
        }

        void PrintStats(Player player)
        {
            Console.Clear();
            Console.WriteLine(player._playerName);
            Console.WriteLine("Health: " + player._health);
            Console.WriteLine("Damage: " + player._damage);
            Console.WriteLine("Defense: " + player._defense);
        }

        void StartBattle()
        {
            while (player1._health > 0 && player2._health > 0)
            {
                PrintStats(player1);
                PrintStats(player2);

                char input;
                GetInput(out input, "Attack", "Block", "Player one. Go");
                if (input == '1')
                {
                    Block(ref player1._health, player1._damage, player2._defense);
                    Console.Clear();
                    Console.WriteLine(player1._playerName + " dealt " + (player1._damage - player2._defense) + " damage.");
                    Console.Write("> ");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Block(ref player1._health, player2._damage, player1._defense);
                    Console.WriteLine(player2._playerName + " dealt " + (player2._damage - player1._defense) + " damage.");
                    Console.Write("> ");
                    Console.ReadKey();
                    Console.Clear();
                }
                Console.Clear();
                if (player2._health <= 0)
                {
                    break;
                }
                PrintStats(player1);
                PrintStats(player2);

                GetInput(out input, "Attack", "Block", "Player two. Go");
                if (input == '1')
                {
                    Block(ref player1._health, player2._damage, player1._defense);
                    Console.Clear();
                    Console.WriteLine(player2._playerName +" dealt " + (player2._damage - player1._defense) + " damage.");
                    Console.Write("> ");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Block(ref player2._health, player1._damage, player2._defense);
                    Console.WriteLine(player1._playerName + " dealt " + (player1._damage - player2._defense) + " damage.");
                    Console.Write("> ");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            gameOver = true;
        }

        //void SelectEquipment()
        //{
        //    char input = ' ';
        //    while (input != '1' || input != '2' || input != '3')
        //    {
        //        Console.WriteLine("Welcome, Player 1 please select your weapon.");
        //        Console.Write("1.Longsword /n 2.SledgeHammer /n 3.Fist-I-Cuffs");
        //        input = Console.ReadKey().KeyChar;
        //        switch(input)
        //        {
        //            case '1':
        //                {
        //                    player1Wep = "LongSword";
        //                    player1Health = 200;
        //                    player1Dmg += 5;
        //                    player1Def = 5;
        //                    break;
        //                }
        //            case '2':
        //                {
        //                    player1Wep = "Sledgehammer";
        //                    player1Health = 200;
        //                    player1Dmg += 15;
        //                    player1Def = 5;
        //                    break;
        //                }
        //            case '3':
        //                {
        //                    player1Wep = "Fist-I-Cuffs";
        //                    player1Health = 200;
        //                    player1Dmg += 25;
        //                    player1Def = 5;
        //                    break;
        //                }
        //            default:
        //                {
        //                    Console.WriteLine("I have noticed you chose no weapon./n Please chose one.");
        //                    Console.ReadKey();
        //                    break;
        //                }
        //        }

        //        Console.Clear();
        //        Console.WriteLine("Now, Player 2 you select your weapon.");
        //        Console.Write("1.Longsword /n 2.SledgeHammer /n 3.Fist-I-Cuffs");
        //        input = Console.ReadKey().KeyChar;
        //        switch (input)
        //        {
        //            case '1':
        //                {
        //                    player2Wep = "LongSword";
        //                    player2Health = 200;
        //                    player2Dmg += 5;
        //                    player2Def = 5;
        //                    break;
        //                }
        //            case '2':
        //                {
        //                    player2Wep = "Sledgehammer";
        //                    player2Health = 200;
        //                    player2Dmg += 15;
        //                    player2Def = 5;
        //                    break;
        //                }
        //            case '3':
        //                {
        //                    player2Wep = "Fist-I-Cuffs";
        //                    player2Health = 200;
        //                    player2Dmg += 25;
        //                    player2Def = 5;
        //                    break;
        //                }
        //            default:
        //                {
        //                    Console.WriteLine("I have noticed you chose no weapon./n Please chose one.");
        //                    Console.ReadKey();
        //                    break;
        //                }
        //        }
        //        Console.Clear();
        //    }
        //}
        void InitializePlayers()
        {
            player1._playerName = "Player 1";
            player1._health = 150;
            player1._defense = 10;
            player2._playerName = "Player 2";
            player2._health = 150;
            player2._defense = 10;
        }
        public void Start()
        {
            InitializePlayers();
        }

        public void Intermission()
        {
            EquipWeapon();
            StartBattle();
        }

        public void Update()
        {
            Intermission();
        }

        public void End()
        {
            if (player1._health <= 0)
            {
                Console.WriteLine("You got wrecked Player one");
                return;
            }
            Console.WriteLine("First move ez wins");
        }
    }
}
