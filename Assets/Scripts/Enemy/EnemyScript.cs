using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyScript : MonoBehaviour
    {
        public EnemyStandState standingState;
        public EnemyRunState runningState;

        public EnemyStateMachine esm;
        public Animator anim;

        public Transform[] points;

        private NavMeshAgent nav;
        private int destPoint;

        public bool IsRunning = false;

        void Start()
        {
            esm = gameObject.AddComponent<EnemyStateMachine>();
            anim = GetComponent<Animator>();

            nav = GetComponent<NavMeshAgent>();

            standingState = new EnemyStandState(this, esm);
            runningState = new EnemyRunState(this, esm);

            esm.Init(standingState);
        }

        public void Update()
        {
            esm.CurrentState.HandleInput();
            esm.CurrentState.LogicUpdate();
        }

        void FixedUpdate()
        {
            esm.CurrentState.PhysicsUpdate();

            if (!nav.pathPending && nav.remainingDistance < 0.5f)
                //IsRunning = false;
                GoToNextPoint();

            //print ("current point is " + destPoint);
        }

        public void CheckForStand()
        {
            if (IsRunning == false)
            {
                esm.ChangeState(standingState);
                anim.SetBool("run", false);
            }
        }

        public void CheckForRun()
        {
            if (IsRunning == true)
            {
                esm.ChangeState(runningState);
                anim.SetBool("run", true);
            }
        }

        void GoToNextPoint()
        {
            if (points.Length == 0)
            {
                return;
            }
            nav.destination = points[destPoint].position;
            destPoint = (destPoint + 1) % points.Length;
            IsRunning = true;
        }
    }

}