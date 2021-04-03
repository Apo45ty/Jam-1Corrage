using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Combat;
using UnityEngine;
using UnityEngine.UI;
namespace ApolionGames.JamOne.UI{
    public class TotlaPointsUpdater : MonoBehaviour
    {
        [SerializeField]
        private string scoreTextName="pointsToScoreText";
        [SerializeField]
        private Text scoreText;
        private GambelerSword sword;

        // Start is called before the first frame update
        void Start()
        {
            Text[] texts = GetComponentsInChildren<Text>();
            foreach(Text t in texts){
                if(t.name.Equals(scoreTextName)){
                    scoreText = t; 
                } 
            }
            sword = GetComponentInParent<GambelerSword>();
        }

        // Update is called once per frame
        void Update()
        {
            if(sword!=null&&scoreText!=null){
                scoreText.text="You needed:"+sword.pointsScore;
            }
        }
    }
}