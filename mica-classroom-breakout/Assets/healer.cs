using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        HealthManager hm = other.gameObject.GetComponent<HealthManager>();
        if (hm) {
            hm.Heal();
        }  
    }
}
