using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Core;
using UnityEngine;
namespace ApolionGames.JamOne.AI{

    public class AiBehaviour : MonoBehaviour, MyAIBehaviours
    {
        AIStates state ;

        public AIStates myState()
        {
            return state;
        }

        public void tick(PlayerScript player)
        {
            
        }
    }
}
