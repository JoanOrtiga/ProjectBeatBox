using UnityEngine;

namespace _Anark.Scripts.Logger
{
    public class ConsoleLog : MonoBehaviour
    {
        public enum Tags
        {
            Reference, InMatch
        }

        public static void LogMessage(object message, Tags tag)
        {
            Debug.Log($"{tag.ToString().ToUpper()}: {message}");
        }
        
        public static void LogWarning(object message, Tags tag)
        {
            Debug.Log($"{tag.ToString().ToUpper()}: {message}");
        }
        
        public static void LogError(object message, Tags tag)
        {
            Debug.Log($"{tag.ToString().ToUpper()}: {message}");
        }
    }
}