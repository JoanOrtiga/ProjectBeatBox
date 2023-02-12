using Unity.Netcode;
using UnityEngine;

namespace _ProjectBeatBox.GameElements.Game
{
    public static class NetworkReference
    {
        public static ulong ClientId => NetworkManager.Singleton.LocalClient.ClientId;
        public static int ClientIdAsInt => (int)NetworkManager.Singleton.LocalClient.ClientId;
        public static GameObject ClientObject => NetworkManager.Singleton.LocalClient.PlayerObject.gameObject;
    }
}