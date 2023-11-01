using UnityEngine;

namespace Player
{
    public class PlayerStateMachine : MonoBehaviour
    {
        public PlayerState CurrentState { get; private set; }
        public PlayerState LastState { get; private set; }

        public void Init(PlayerState startingState)
        {
            CurrentState = startingState;
            LastState = null;
            startingState.Enter();
        }

        public void ChangeState(PlayerState newState)
        {
            CurrentState.Exit();

            LastState = CurrentState;
            CurrentState = newState;
            newState.Enter();
        }

        public PlayerState GetState()
        {
            return CurrentState;
        }
    }
}