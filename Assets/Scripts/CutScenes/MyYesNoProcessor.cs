using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Combat;
using ApolionGames.JamOne.Core;
using UnityEngine;
namespace ApolionGames.JamOne.CutScenes{

    public class MyYesNoProcessor : MonoBehaviour
    {   
        [SerializeField]
        private GameObject gambelerSwordPrefab;

        // Start is called before the first frame update
        void Start()
        {
            string v = ConfigurationObjectScript.getInstance().getLatestYesNo();
            if(v==null||v.Length<=0)
                return;
            PlayerScript playerScript = ConfigurationObjectScript.getInstance().getPlayer();
            if(v.Equals("Yes")){
                playerScript.GetComponent<Fighter>().ClearWeaponInventory();
                GameObject gambelersSword = Instantiate(gambelerSwordPrefab,transform.position,gambelerSwordPrefab.transform.rotation);
            } else if(v.Equals("No")){
                //Do nothing
            }
        }

    }
}
