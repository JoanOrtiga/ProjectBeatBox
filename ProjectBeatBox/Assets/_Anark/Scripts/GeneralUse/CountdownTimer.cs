using System;
using UnityEngine.Assertions;

namespace _Anark.Scripts.GeneralUse
{
    public class CountdownTimer
    {
        public float MaxTime { get; private set; }

        private bool _shouldLoop;
        private float _currentTime;

        private event Action OnTimerEnd;

        public bool CountdownCompleted => _currentTime <= 0;

        public CountdownTimer(float maxTime, float startTime = 0, bool shouldLoop = false)
        {
            Assert.IsTrue(startTime >= 0, $"Start time cannot be less than 0. Parameter given: {startTime}");
            
            MaxTime = maxTime;
            _currentTime = startTime;
            _shouldLoop = shouldLoop;
        }

        public void Tick(float deltaTime)
        {
            if (CountdownCompleted)
                return;
            
            _currentTime -= deltaTime;
            if (_currentTime <= 0)
            {
                TimerEnded();
            }
        }

        private void TimerEnded()
        {
            OnTimerEnd?.Invoke();

            if (!_shouldLoop)
                return;
            
            _currentTime = MaxTime;
        }

        public void AddListener(Action callback)
        {
            OnTimerEnd += callback;
        }

        public void RemoveListener(Action callback)
        {
            OnTimerEnd -= callback;
        }
    }
}