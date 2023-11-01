using UnityEngine;

namespace Player
{
    public class PlayerStandState : PlayerState
    {
        public PlayerStandState(PlayerScript player, PlayerStateMachine psm) : base(player, psm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.xv = player.yv = player.zv = 0;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            player.CheckForRun();

            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
