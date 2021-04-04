using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Combat;
using ApolionGames.JamOne.Controls;
using UnityEngine;

public class ShowSlash : MonoBehaviour
{
    private Fighter transform1;
    private bool imageUp = false;
    private float currTime = 0;
    [SerializeField]
    private float timeToDisplayImage = 0.5f;

    void Start(){
        transform1 = GetComponentInParent<Fighter>();
    }
    void Update(){
        if(!transform1)
         return;
        if(transform1.getAttackTimeOut()>0.9f&&Input.GetKey(PlayerController.pSWINGKEYCODE)){
            imageUp=true;
            transform.GetChild(0).gameObject.SetActive(true);
        }
        if(!imageUp)
            return;
        currTime-=Time.deltaTime;
        if(currTime<=0){
            currTime=timeToDisplayImage;
            imageUp=false;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
