using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Controls;
using UnityEngine;

public class LookAtEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(PlayerController.pSWINGKEYCODE)&&PlayerController.targets!=null&&PlayerController.targets.Count>0){
            Vector3 diff = (PlayerController.targets[0].transform.position - transform.position);
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z -270);
        } 
        if(Input.GetKey(PlayerController.pLEFTKEYCODE)){
            transform.rotation = Quaternion.Euler(0f, 0f,-90f);
        } 
        if(Input.GetKey(PlayerController.pRIGHTKEYCODE)){
            transform.rotation = Quaternion.Euler(0f, 0f,90f);
        } 
        if(Input.GetKey(PlayerController.pUPKEYCODE)){
            transform.rotation = Quaternion.Euler(0f, 0f,180f);
        } 
        if(Input.GetKey(PlayerController.pDOWNKEYCODE)){
            transform.rotation = Quaternion.Euler(0f, 0f,0f);
        }
    }

}
