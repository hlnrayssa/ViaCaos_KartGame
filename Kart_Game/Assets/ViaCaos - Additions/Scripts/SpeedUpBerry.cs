using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;

public class SpeedUpBerry : MonoBehaviour
{
    public float powerupSpeed = 25;
    bool isPowerupOn;
    public float powerupTime = 5;
    ArcadeKart arcadeKart;
    public float defaultSpeed;

    // Start is called before the first frame update
    void Start()
    {
        arcadeKart = GetComponent<ArcadeKart>();
        defaultSpeed = 15;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if  (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            StartCoroutine(ActivatePowerUp());
        }
    }

    IEnumerator ActivatePowerUp()
    {
        arcadeKart.baseStats.TopSpeed = powerupSpeed;
        isPowerupOn = true;
        float powerupTimer = 0;
        while(powerupTimer <= powerupTime)
        {
            powerupTimer += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        arcadeKart.baseStats.TopSpeed = defaultSpeed;
        isPowerupOn = false;

    }
}
