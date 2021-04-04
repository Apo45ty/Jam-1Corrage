using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Combat;
using ApolionGames.JamOne.Core;
using UnityEngine;
using UnityEngine.AI;

namespace ApolionGames.JamOne.AI{

[RequireComponent(typeof(Fighter),typeof(NavMeshAgent),typeof(CombatTarget))]
    public class MyAIBehaviours : MonoBehaviour
    {
        public virtual void tick(PlayerScript player){}
        public virtual AIStates myState(){return AIStates.thinking;}
    }
}
