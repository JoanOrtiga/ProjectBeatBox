using _Anark.Scripts.Game.TurnSystem;
using _Anark.Scripts.GeneralUse;
using UnityEngine;

namespace _Anark.Scripts.Cards.TurnSystem.TurnBehaviours
{
    [CreateAssetMenu(menuName = "_Anark/TurnSettings/Turns/NormalTurn", fileName = "NormalTurn", order = 0)]
    public class NormalTurn : TurnBehaviour
    {
        #if UNITY_EDITOR
        [Header(nameof(NormalTurn))] [SerializeField, TextArea, Multiline]
        private string TurnDescription;
        #endif
        
        [field: SerializeField] public float turnTime;

        private NormalTurnAssetReferences _turnAssetReferences;
        
        private CountdownTimer _countdownTimer;

        public override void SetData(TurnAssetReferences turnAssetReferences)
        {
            _turnAssetReferences = turnAssetReferences as NormalTurnAssetReferences;
        }
        
        public override void StartTurn()
        {
            _countdownTimer = new CountdownTimer(turnTime, turnTime);
            base.StartTurn();
        }

        public override void EndTurn()
        {
            base.EndTurn();
        }

        public override bool IsTurnFinished()
        {
            return _countdownTimer.CountdownCompleted; 
        }

        public override void Update()
        {
            _countdownTimer.Tick(GameTime.DeltaTime);
        }
    }
}