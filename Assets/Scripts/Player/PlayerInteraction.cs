using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.CompareTag("GunAmmo"))
        {

            GameManager.Instance.gunAmmo += other.gameObject.GetComponent<AmmoBox>().ammo;

            Destroy(other.gameObject);
        }
    }
}
