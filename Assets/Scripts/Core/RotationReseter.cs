using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ApolionGames.JamOne.Controls{
    public class RotationReseter : MonoBehaviour
    {
        // Start is called before the first frame update
        void Update() {
             GetComponent<RectTransform>().rotation = Quaternion.identity;
             transform.rotation = Quaternion.identity;
        }
    }

}
