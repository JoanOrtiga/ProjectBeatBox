using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button hostButton; 
    [SerializeField] private Button serverButton; 
    [SerializeField] private Button clientButton; 
    
    private void Awake()
    {
        hostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
            Debug.Log("You are client & server");
            gameObject.SetActive(false);

        });
        serverButton.onClick.AddListener(() =>
        {
            Debug.Log("You are a server");
            NetworkManager.Singleton.StartServer();
            gameObject.SetActive(false);

        });
        clientButton.onClick.AddListener(() =>
        {
            Debug.Log("You are a client");
            NetworkManager.Singleton.StartClient();
            gameObject.SetActive(false);
        });
    }
}
