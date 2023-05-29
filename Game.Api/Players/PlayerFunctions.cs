using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Api.Players
{
    public static class PlayerFunctions
    {
        public static void AddCrystals(this PlayerProfile player, int crystalNumber)
        {
            player.Crystal += crystalNumber;
        }

        public static void ChangeName(this PlayerProfile player, string name)
        {
            player.Name = name;
        }
        public static void BuyCommonTicket(this PlayerProfile player) {

            if (player.Crystal >= 10)
            { 
             player.CommonTicketAmount += 1;
             player.Crystal -= 10;
            }              
        }
        public static void BuyUncommonTicket(this PlayerProfile player)
        {

            if (player.Crystal >= 100)
            {
                player.UncommonTicketAmount += 1;
                player.Crystal -= 100;
            }
        }
        public static void BuyRareTicket(this PlayerProfile player)
        {

            if (player.Orb >= 50)
            {
                player.RareTicketAmount += 1;
                player.Orb -= 50;
            }
        }
        public static void BuySuperRareTicket(this PlayerProfile player)
        {

            if (player.HeroSoul >= 1)
            {
                player.SuperRareTicketAmount += 1;
                player.HeroSoul -= 1;
            }
        }


    }
 }
    

