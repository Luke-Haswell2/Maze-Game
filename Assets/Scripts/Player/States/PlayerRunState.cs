using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Player
{
    public class PlayerRunState : PlayerState
    {
        public PlayerRunState(PlayerScript player, PlayerStateMachine psm) : base(player, psm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.xv = player.runSpeed;
            player.zv = player.runSpeed2;
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
            base.LogicUpdate();
            player.CheckForStand();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
