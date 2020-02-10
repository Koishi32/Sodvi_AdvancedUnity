// Patrol.cs
    using UnityEngine;
    using UnityEngine.AI;
    using System.Collections;


    public class Patrol : MonoBehaviour {
        public float stopDistance=2f;
        public Transform[] points;
        private int destPoint = 0;
        public NavMeshAgent agent;
        public bool enNearby=false;
        Transform character;
        void Start () {
            agent = GetComponent<NavMeshAgent>();

            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            agent.autoBraking = false;
            
            character=GameObject.FindGameObjectWithTag("Player").transform;
            GotoNextPoint();
        }


        void GotoNextPoint() {

            
            // Returns if no points have been set up
            if (points.Length == 0)
                return;

            // Set the agent to go to the currently selected destination.
            agent.destination = points[destPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
        }
        void GoToEnemy(){
            agent.destination=character.position;
            agent.stoppingDistance=stopDistance;
        }

        void Update () {
            agent.stoppingDistance=0f;

            // Choose the next destination point when the agent gets
            // close to the current one.
            if ( !enNearby && !agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
            if (enNearby){
                GoToEnemy();
                transform.LookAt(character.position);
            }
        }
    }