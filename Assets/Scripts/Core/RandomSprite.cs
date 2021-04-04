using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Controls;
using ApolionGames.JamOne.Core;
using UnityEngine;
using UnityEngine.UI;

namespace ApolionGames.JamOne.Core{

public class RandomSprite : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public SlotMachineItem[] possibleColors;
    [SerializeField]
    private    float milesecondsPerColor=500; 

    private bool isRunning = true;
    private float millisecondsSinceChange = 0;
    private int currentColorTime=0;
        void Start()
    {
        currentColorTime=0;
        if(!isRunning||possibleColors==null||possibleColors.Length==0)
            return;
        this.currentColorTime=Random.Range(0,possibleColors.Length);
        this.GetComponent<Image>().sprite = possibleColors[currentColorTime].image;
    }

    // Update is called once per frame
    void Update()
    {
//        Debug.Log(isRunning);
        isRunning=true;
        if(Input.GetKey(PlayerController.pSWINGKEYCODE))
            isRunning = false;
        if(!isRunning||possibleColors==null||possibleColors.Length==0)
            return;
        millisecondsSinceChange += Time.deltaTime;
        if(millisecondsSinceChange>milesecondsPerColor){
            millisecondsSinceChange=0;
            currentColorTime=(currentColorTime+1)%possibleColors.Length;
            this.GetComponent<Image>().sprite = possibleColors[currentColorTime].image;
        }
    }

    public SlotMachineItem getCurrentSlotMachineItem(){
        return  possibleColors[currentColorTime];
    }
    public bool getIsRunning(){
        return isRunning;
    }
}
}
