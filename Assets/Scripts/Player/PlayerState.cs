using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Player
{
    public abstract class PlayerState
    {
        protected PlayerScript player;
        protected PlayerStateMachine psm;

        protected PlayerState(PlayerScript player, PlayerStateMachine psm)
        {
            this.player = player;
            this.psm = psm;
        }
        public virtual void Enter()
        {
        }

        public virtual void HandleInput()
        {
        }

        public virtual void LogicUpdate()
        {
        }

        public virtual void PhysicsUpdate()
        {
        }

        public virtual void Exit()
        {
        }
    }
}