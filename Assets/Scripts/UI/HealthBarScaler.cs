using System.Collections;
using System.Collections.Generic;
using ApolionGames.JamOne.Combat;
using ApolionGames.JamOne.Core;
using UnityEngine;

public class HealthBarScaler : MonoBehaviour
{
    [SerializeField]
    private Health health;
    private float healthBarHeight;

    // Start is called before the first frame update
    void Start()
    {
        this.healthBarHeight = GetComponent<RectTransform>().sizeDelta.y;
        this.health=ConfigurationObjectScript.getInstance().getPlayer().GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale=new Vector3(transform.localScale.x,(health.currentHealth/health.maxHealth));
    }
}
