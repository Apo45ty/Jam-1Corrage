using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Core;
using UnityEngine;
namespace ApolionGames.JamOne.AI{

    public class AiBehaviour :  MyAIBehaviours
    {
        AIStates state ;

        public override AIStates myState()
        {
            return state;
        }

        public override void tick(PlayerScript player)
        {
            
        }
    }
}
