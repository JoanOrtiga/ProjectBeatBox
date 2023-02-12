using _Anark.Scripts.Game.TurnSystem;
using UnityEngine;
using UnityEngine.ResourceManagement.Util;

namespace _ProjectBeatBox.GameElements.Game
{
    public class GameManager : ComponentSingleton<GameManager>
    {
        [SerializeField] private TurnManagerClient turnManagerClient;
        [SerializeField] private PlayerReferences playerReferences;
        [SerializeField] private DeckProvider deckProvider;
        [SerializeField] private CardProvider cardProvider;
        [SerializeField] private TurnSettings turnSettings;
        [SerializeField] private PlayerReferenceProvider playerReferenceProvider;
        
        public TurnManagerClient TurnManagerClient => turnManagerClient;
        public PlayerReferences PlayerReferences => playerReferences;
        public DeckProvider DeckProvider => deckProvider;
        public CardProvider CardProvider => cardProvider;
        public TurnSettings TurnSettings => turnSettings;
        public PlayerReferenceProvider PlayerReferenceProvider => playerReferenceProvider;
    }
}
