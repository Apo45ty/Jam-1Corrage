using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Combat;
using ApolionGames.JamOne.Controls;
using ApolionGames.JamOne.Core;
using UnityEngine;
namespace ApolionGames.JamOne.Interactable{

    public class IncreaseHealth : MonoBehaviour
    {
        [SerializeField]
            private float radiousToGive=1;

            // Update is called once per frame
            void Update()
            {
                PlayerScript playerScript = ConfigurationObjectScript.getInstance().getPlayer();
                if(Vector2.Distance(playerScript.transform.position,this.transform.position)<radiousToGive){
                    if(Input.GetKeyDown(PlayerController.pINTERACTKEYCODE)){
                        playerScript.GetComponent<Health>().increaseHealth(15);
                        Destroy(transform.parent.gameObject);
                    }
                }   
            }
    }
}
