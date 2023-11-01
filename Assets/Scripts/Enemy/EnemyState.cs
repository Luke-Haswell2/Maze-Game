using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Enemy
{
    public abstract class EnemyState
    {
        protected EnemyScript enemy;
        protected EnemyStateMachine esm;

        protected EnemyState(EnemyScript enemy, EnemyStateMachine esm)
        {
            this.enemy = enemy;
            this.esm = esm;
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