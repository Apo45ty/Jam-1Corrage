using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ApolionGames.JamOne.Combat{

public class RandomColor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Color[] possibleColors;
    [SerializeField]
    float milesecondsPerColor=500; 
    private bool isRunning = true;
    private float millisecondsSinceChange = 0;
    [SerializeField]    
    private KeyCode STOPKEY;
    private int currentColorTime=0;
        void Start()
    {
        currentColorTime=0;
        if(!isRunning||possibleColors==null||possibleColors.Length==0)
            return;
        this.currentColorTime=Random.Range(0,possibleColors.Length);
        this.GetComponent<Image>().color = possibleColors[currentColorTime];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(this.STOPKEY))
            isRunning = true;
        if(!isRunning||possibleColors==null||possibleColors.Length==0)
            return;
        millisecondsSinceChange += Time.deltaTime;
        if(millisecondsSinceChange>milesecondsPerColor){
            millisecondsSinceChange=0;
            currentColorTime=(currentColorTime+1)%possibleColors.Length;
            this.GetComponent<Image>().color = possibleColors[currentColorTime];
        }
    }
}
}
