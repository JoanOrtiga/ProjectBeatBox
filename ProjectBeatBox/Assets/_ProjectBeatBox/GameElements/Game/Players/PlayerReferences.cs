using UnityEngine;
using UnityEngine.UI;

public class PlayerReferences : MonoBehaviour
{
    public static PlayerReferences Instance { get; private set; }

    public Button button;
    
    private void OnEnable()
    {
        Instance = this;
    }
}
