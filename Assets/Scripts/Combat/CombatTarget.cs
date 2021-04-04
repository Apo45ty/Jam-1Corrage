using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ApolionGames.JamOne.Combat{

[RequireComponent(typeof(Health),typeof(Statistics))]
    public class CombatTarget : MonoBehaviour
    {
        public virtual void AfterAttackCallback(){
            
        }
    }
}
