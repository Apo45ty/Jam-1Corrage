using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Combat;
using ApolionGames.JamOne.Controls;
using ApolionGames.JamOne.Core;
using UnityEngine;
namespace ApolionGames.JamOne.Interactable{
    public class GiveItem : MonoBehaviour
    {
    
        [SerializeField] private GameObject itemToGive;
        [SerializeField]
        private float radiousToGive=1;

        // Update is called once per frame
        void Update()
        {
            PlayerScript playerScript = ConfigurationObjectScript.getInstance().getPlayer();
            if(Vector2.Distance(playerScript.transform.position,this.transform.position)<radiousToGive&&itemToGive!=null){
                if(Input.GetKeyDown(PlayerController.pINTERACTKEYCODE)){
                    itemToGive.transform.parent=playerScript.transform;
                    itemToGive.transform.localPosition = new Vector2(-0.13f,-0.2f);
                    itemToGive.transform.localScale = Vector3.one;
                    playerScript.GetComponent<Fighter>().UpdateWeaponInventory();
                }
            }   
        }
    }
}
