using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

namespace Player
{
    public class PlayerScript : MonoBehaviour
    {
        public Rigidbody rb;
        public Transform playerTr;
        public float xv, yv, zv;
        public float runSpeed = 8;
        public float runSpeed2 = 8;

        public PlayerStandState standingState;
        public PlayerRunState runningState;

        public PlayerStateMachine psm;
        public Animator anim;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            psm = gameObject.AddComponent<PlayerStateMachine>();
            anim = GetComponent<Animator>();
            playerTr = GetComponent<Transform>();
            standingState = new PlayerStandState(this, psm);
            runningState = new PlayerRunState(this, psm);

            psm.Init(standingState);
        }

        public void Update()
        {
            psm.CurrentState.HandleInput();
            psm.CurrentState.LogicUpdate();
        }

        void FixedUpdate()
        {
            psm.CurrentState.PhysicsUpdate();
            rb.velocity = new Vector3(xv, yv, zv);
        }

        public void CheckForStand()
        {
            if (Input.GetKey("left") == false)
            {
                if (Input.GetKey("right") == false)
                {
                    if (Input.GetKey("down") == false)
                    {
                        if (Input.GetKey("up") == false)
                        {
                            psm.ChangeState(standingState);
                            anim.SetBool("run", false);
                        }
                    }
                }
            }
        }

        public void CheckForRun()
        {
            if (Input.GetKey("left"))
            {
                runSpeed = -4;
                runSpeed2 = 0;
                psm.ChangeState(runningState);
                anim.SetBool("run", true);
                
                return;
            }

            if (Input.GetKey("right"))
            {
                runSpeed = 4;
                runSpeed2 = 0;
                psm.ChangeState(runningState);
                anim.SetBool("run", true);
            }

            if (Input.GetKey("down"))
            {
                runSpeed2 = -4;
                runSpeed = 0;
                psm.ChangeState(runningState);
                anim.SetBool("run", true);
            }

            if (Input.GetKey("up"))
            {
                runSpeed2 = 4;
                runSpeed = 0;
                psm.ChangeState(runningState);
                anim.SetBool("run", true);
            }
        }

        void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

    }

}