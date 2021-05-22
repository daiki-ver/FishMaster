using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFish : MonoBehaviour
{

    public GameObject killedMV;

    void OnTriggerEnter(Collider other) {
        // if(other.tag=="Bullet")
        // {
            Destroy(other.gameObject);
            Destroy(gameObject);
        // }
    }
}
