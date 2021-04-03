using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Core;
using UnityEngine;
namespace ApolionGames.JamOne.AI{
    public class MyAIBehaviours : MonoBehaviour
    {
        public virtual void tick(PlayerScript player){}
        public virtual AIStates myState(){return AIStates.thinking;}
    }
}
