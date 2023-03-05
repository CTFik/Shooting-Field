using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    
    public AudioSource audioSource;
    public AudioClip ammoPick;
    public int ammo = 10;


    //START
    void start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    public void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.CompareTag("Player"))
        {

            GameManager.Instance.gunAmmo += ammo;
            Destroy(this.gameObject);

            audioSource.PlayOneShot(ammoPick);
        }
    }

}
