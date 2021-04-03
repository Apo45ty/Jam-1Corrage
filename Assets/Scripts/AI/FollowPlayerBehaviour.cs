using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Core;
using UnityEngine;
using UnityEngine.AI;

namespace ApolionGames.JamOne.AI{
    public class FollowPlayerBehaviour : MyAIBehaviours
    {
        AIStates state = AIStates.thinking;
        private NavMeshAgent navMeshAgent;
        void Start(){
            navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.updateUpAxis=false;
            navMeshAgent.updateRotation=false;
        }

        public override AIStates myState()
            {
                return state;
            }

            public override void tick(PlayerScript player)
            {
                navMeshAgent.SetDestination(player.transform.position);
            }
        }
}
