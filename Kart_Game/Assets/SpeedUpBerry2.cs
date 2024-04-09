using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;

public class SpeedUpBerry : MonoBehaviour
{
    public float powerupTime = 5;
    public float powerupTimer;
    public float powerupSpeed = 25;
    ArcadeKart arcadeKart;
    public float defaultSpeed;

    // Start is called before the first frame update
    void Start()
    {
        arcadeKart = GetComponent<ArcadeKart>();
        defaultSpeed = arcadeKart.baseStats.TopSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            StartCoroutine(ActivatePowerUp());
        }
    }

    IEnumerator ActivatePowerUp()
    {
        arcadeKart.baseStats.TopSpeed = powerupSpeed;
        powerupTimer = 0;
        while(powerupTimer <= powerupTime)
        {
            powerupTimer += 0.1f;

            yield return new WaitForSeconds(0.1f);
        }

        arcadeKart.baseStats.TopSpeed = defaultSpeed;
    }
}