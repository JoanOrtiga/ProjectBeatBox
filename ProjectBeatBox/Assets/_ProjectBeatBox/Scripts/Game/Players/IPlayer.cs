using System.Collections.Generic;
using _Anark.Scripts.Cards.Data;
using Unity.Collections;

namespace _ProjectBeatBox.GameElements.Game.Players
{
    public interface IPlayer
    {
        void StringifyDeck(List<FixedString32Bytes> cards);
        void ChangePlayerState(string state);
    }
}