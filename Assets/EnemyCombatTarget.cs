using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Combat;
using UnityEngine;
namespace ApolionGames.JamOne.Combat{
    public class EnemyCombatTarget : CombatTarget
    {
        
            public override void AfterAttackCallback(){
                if(GetComponent<Health>().currentHealth<=0)
                    Destroy(this.gameObject);
            }
    }
}
