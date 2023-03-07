using System;

namespace _ProjectBeatBox_SinglePlayer.Turns
{
    public class ShopTurnBehaviour : TurnBehaviour
    {
        public ShopTurnSettings ShopTurnSettings => TurnSettings as ShopTurnSettings;
    }
}