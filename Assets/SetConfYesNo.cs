using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ApolionGames.JamOne.Core{

    public class SetConfYesNo : MonoBehaviour
    {
        public void VotedYes(){
            ConfigurationObjectScript.getInstance().setLatestYesNo("Yes");
        }
        
        public void VotedNo(){
            ConfigurationObjectScript.getInstance().setLatestYesNo("No");
        }
    }
}
