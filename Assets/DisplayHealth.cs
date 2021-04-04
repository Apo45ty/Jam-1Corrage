using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Combat;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    [SerializeField] private Health health;
    private Text textAsset;

    // Start is called before the first frame update
    void Start()
    {
        textAsset = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(textAsset!=null&&health!=null){
            textAsset.text="Health:"+health.currentHealth;
        }
    }
}
