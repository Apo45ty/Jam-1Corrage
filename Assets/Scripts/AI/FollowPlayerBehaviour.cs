using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Combat;
using ApolionGames.JamOne.Core;
using UnityEngine;
using UnityEngine.AI;

namespace ApolionGames.JamOne.AI{
    public class FollowPlayerBehaviour : MyAIBehaviours
    {
        AIStates state = AIStates.thinking;
        private NavMeshAgent navMeshAgent;
        private float minChaseDistance=3;
        private Fighter fighter;
        private float minAttackDistance=1;

        void Start(){
            navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.updateUpAxis=false;
            navMeshAgent.updateRotation=false;
            fighter = GetComponent<Fighter>();
        }

        public override AIStates myState()
            {
                return state;
            }

            public override void tick(PlayerScript player)
            {
                if(Vector2.Distance(player.transform.position,transform.position)<minAttackDistance)
                {
                    if(fighter.GetCurrentWeapon()!=null)
                         fighter.swing(CaptureEnemies(1),this.GetComponent<CombatTarget>());
                } else if(Vector2.Distance(player.transform.position,transform.position)<minChaseDistance){
                    navMeshAgent.SetDestination(player.transform.position);
                }
            }
            public List<CombatTarget> CaptureEnemies(float range)
        {
            List<CombatTarget> targets= new List<CombatTarget>();
            Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, Vector2.one*range,0);
            foreach(Collider2D col in colliders){
                CombatTarget combatTarget = col.gameObject.GetComponent<CombatTarget>();
                if (combatTarget!=null)
                {
                    targets.Add(combatTarget);
                }
            }
            return targets;
        }
        }
        
}
