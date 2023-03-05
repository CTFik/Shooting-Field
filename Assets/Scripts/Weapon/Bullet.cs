using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.CompareTag("Target"))
        {
            GameManager.Instance.scorePoints += other.gameObject.GetComponent<JackSpot>().point;
            
            Destroy(this.gameObject);
        }
    }

}
