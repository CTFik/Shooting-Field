using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{



    public static GameManager Instance {get; private set;}

    public int gunAmmo = 10;
    public int scorePoints = 0;

    public Text ammoText;
    public Text pointsText;

    public void Awake()
    {
        Instance = this;
        
    }

    public void Update()
    {
        ammoText.text = gunAmmo.ToString();
        pointsText.text = scorePoints.ToString();
    }


}
