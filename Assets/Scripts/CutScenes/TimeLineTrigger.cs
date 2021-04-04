using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Core;
using UnityEngine;
using UnityEngine.Playables;
namespace ApolionGames.JamOne.CutScenes{

    public class TimeLineTrigger : MonoBehaviour
    {
        [SerializeField] private bool removeTrigger=false;
        void OnTriggerEnter2D(Collider2D c){
            Debug.Log("collision");
            PlayerScript playerScript = c.GetComponent<PlayerScript>();
            if(playerScript!=null){
                GetComponent<PlayableDirector>().Play();
                if(removeTrigger)
                    Destroy(this);
            }
        }
    }
}
