using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Combat;
using ApolionGames.JamOne.Core;
using UnityEngine;
using UnityEngine.UI;

namespace ApolionGames.JamOne.UI{

    public class AttackReady : MonoBehaviour
    {
        private Color imageOriginalColor;
        [SerializeField] private Image myimage;
        private Fighter player;

        // Start is called before the first frame update
        void Start()
        {
            myimage=GetComponent<Image>();
            imageOriginalColor=myimage.color;
            player=ConfigurationObjectScript.getInstance().getPlayer().GetComponent<Fighter>();
        }

        // Update is called once per frame
        void Update()
        {
            if(player!=null&&myimage!=null){
                myimage.color=(1-player.getAttackTimeOut())*imageOriginalColor;
            }
        }
    }
}
