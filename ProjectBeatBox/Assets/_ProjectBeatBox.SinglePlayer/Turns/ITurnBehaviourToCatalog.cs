using System;

namespace _ProjectBeatBox_SinglePlayer.Turns
{
    public interface ITurnBehaviourToCatalog
    {
        object GetTurn { get; }
        Type GetTurnType { get; }
    }
}