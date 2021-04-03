using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ApolionGames.JamOne.Core{

    public class ConfigurationObjectScript : MonoBehaviour
    {
        public ConfigurationObjectScript me;
        void Awake()
        {
            if (me != null && me != this)
            {
                Destroy(this.gameObject);
                return;
            }
            me = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
