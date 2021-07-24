using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructable : MonoBehaviour
{
    public float hp = 50f;

    public void TakeDamager(float amount) {
        hp -= amount;
        if (hp <= 0f) {
            Destroy(gameObject);
        }
    }
}
