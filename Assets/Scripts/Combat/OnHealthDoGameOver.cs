using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Core;
using UnityEngine;

namespace ApolionGames.JamOne.Combat{
    public class OnHealthDoGameOver : MonoBehaviour
    {
        private Health health;
        void Start(){
            health = GetComponent<Health>();
        }
        // Update is called once per frame
        void Update()
        {
            if(health.IsDead()){
                ConfigurationObjectScript.getInstance().DoGameOver();
            }
        }
    }
}
