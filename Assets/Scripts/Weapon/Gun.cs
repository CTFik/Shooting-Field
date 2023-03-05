using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.SceneManagement;

public class Gun : MonoBehaviour
{
    //VARIABLES
    public Transform spawnPoint;
    public GameObject bullet;
    public float shotForce = 1500f;
    public float shotRate = 0.5f;
    private float shotRateTime = 0;

    public AudioSource audioSource;
    public AudioClip shotSound;

    [SerializeField] private Animator gunAnimator;

    public Text textEnd;

    //START
    void start()
    {
        textEnd.text = "";
        audioSource = GetComponent<AudioSource>();
    }


    //UPDATE
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(Time.time > shotRateTime && GameManager.Instance.gunAmmo > 0)
            {
                
                gunAnimator.SetTrigger("Fire");

                audioSource.clip = shotSound;
                audioSource.Play();

                GameManager.Instance.gunAmmo --;

                GameObject newBullet;
                newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation); //Aparición
                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce); //Velocidad   

                shotRateTime = Time.time + shotRate; //Delay entre disparos
                Destroy(newBullet, 2); //Destruir balas

                if(GameManager.Instance.gunAmmo <= 0){
                    StartCoroutine(DelayTimeTMP());
                }
            }
        }
	}

	IEnumerator DelayTimeTMP()
    {
			yield return new WaitForSeconds(2);
            TextoFinal();
	}

	void TextoFinal()
    {
            textEnd.text = "Tú puntuación final es: " + GameManager.Instance.scorePoints;
		    StartCoroutine(DelayTime());
	}



	IEnumerator DelayTime()
    {
			yield return new WaitForSeconds(10);
            SceneManager.LoadScene("Practica");
	}

}

