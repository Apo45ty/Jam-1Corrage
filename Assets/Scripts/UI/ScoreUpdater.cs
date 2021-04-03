using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Core;
using UnityEngine;
using UnityEngine.UI;
namespace ApolionGames.JamOne.UI{
    public class ScoreUpdater : MonoBehaviour
    {
        [SerializeField]
        private string scoreTextName="scoreText";
        [SerializeField]
        private Text scoreText;
        private SlotMachinePointAggegator aggregator;

        // Start is called before the first frame update
        void Start()
        {
            Text[] texts = GetComponentsInChildren<Text>();
            foreach(Text t in texts){
                if(t.name.Equals(scoreTextName)){
                    scoreText = t; 
                } 
            }
            aggregator = GetComponentInChildren<SlotMachinePointAggegator>();
        }

        // Update is called once per frame
        void Update()
        {
            if(aggregator!=null&&scoreText!=null){
                scoreText.text="You Score:"+aggregator.total;
            }
        }
    }
}
