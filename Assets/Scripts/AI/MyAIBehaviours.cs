using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Core;
using UnityEngine;
namespace ApolionGames.JamOne.AI{
    public interface MyAIBehaviours
    {
        void tick(PlayerScript player);
        AIStates myState();
    }
}
