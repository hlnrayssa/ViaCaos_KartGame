using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems

public class BerryPowerUp : MonoBehaviour
{
    
    public float powerupTime = 5;
    public float powerupSpeed = 20;
    bool isPowerupOn;
    ArcadeKart arcadeKart;
    float defaultSpeed;

    void Start()
    {
        arcadeKart = GetComponent<ArcadeKart>();
        defaultSpeed = arcadeKart.baseStats.TopSpeed;
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Berry"))
        {
            Destroy(other.game.Object);
            StartCoroutine(ActivatePowerUp());
        }
    }

    IEnumerator ActivatePowerUp()
    {
        arcadeKart.baseStats.TopSpeed = powerupSpeed;
        isPowerupOn = true;
        float powerupTimer = 0;
        
        arcadeKart.baseStats.TopSpeed = defaultSpeed;
        isPowerupOn = false;
    }
}
