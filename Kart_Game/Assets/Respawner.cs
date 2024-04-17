using Cinemachine;
using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public GameObject[] carList;
    public Transform[] spawnPoints;
    public CinemachineVirtualCamera[] virtualCameras;
    // Start is called before the first frame update
    void Start()
    {
        //check if the car is selected
        GameObject carSelected1;
        if (KartSelector.currentCar == null)
        {
            //if not, select the first car in the list
            carSelected1 = carList[0];
        }
        
        else
        {
            carSelected1 = KartSelector.currentCar;
        }

        GameObject carSelected2;
        if (KartSelector.currentCar == null)
        {
            //if not, select the first car in the list
            carSelected2 = carList[0];
        }
        
        else
        {
            carSelected2 = KartSelector.currentCar;
        }


        //spawn the car
        GameObject car = Instantiate(carSelected1, spawnPoints[0].position, spawnPoints[0].rotation);
        
        GameObject car2 = Instantiate(carSelected2, spawnPoints[1].position, spawnPoints[1].rotation);

        //set the virtual camera to follow the car
        virtualCameras[0].Follow = car.transform;
        virtualCameras[0].LookAt = car.transform;

        virtualCameras[1].Follow = car2.transform;
        virtualCameras[1].LookAt = car2.transform;

        KeyboardInput input = car.GetComponent<KeyboardInput>();

        input.TurnInputName = "Horizontal";
        input.AccelerateButtonName = "Accelerate";
        input.BrakeButtonName = "Brake";


    }

}