using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Combat;
using UnityEngine;
namespace ApolionGames.JamOne.Core{

    public class OnDestryLoadNextLevel : MonoBehaviour
    {
        void OnDestroy(){
            if(GetComponent<Health>().IsDead())
                ConfigurationObjectScript.getInstance().LevelCompleated();
        }
    }
}
