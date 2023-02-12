using System.Collections;
using System.Collections.Generic;
using _Anark.Scripts.Logger;
using _ProjectBeatBox_SinglePlayer;
using UnityEngine;

public abstract class Reference<T> : ScriptableObject
{
    private T reference;

    public T Get
    {
        get
        {
            if (reference == null)
            {
                ConsoleLog.LogMessage($"Reference {typeof(T)} not found when it was requested.", ConsoleLog.Tags.Reference);
            }
            return reference;
        }
    }

    public void SetReference(T newReference)
    {
        reference = newReference;
    }
}

/*
[CreateAssetMenu(menuName = "Create TurnSystem_Reference", fileName = "TurnSystem_Reference", order = 0)]
public class TurnSystem_Reference : Reference<TurnSystem>
{
    
}
*/
