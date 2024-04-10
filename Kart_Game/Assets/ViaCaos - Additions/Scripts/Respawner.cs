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
        GameObject carSelected;
        if (CarSelector.currentCar == null)
        {
            //if not, select the first car in the list
            carSelected = carList[0];
        }else
        {
            carSelected = CarSelector.currentCar;
        }
        //spawn the car
        GameObject car = Instantiate(carSelected, spawnPoints[0].position, spawnPoints[0].rotation);
        
        GameObject car2 = Instantiate(carSelected, spawnPoints[1].position, spawnPoints[1].rotation);

        //set the virtual camera to follow the car
        virtualCameras[0].Follow = car.transform;
        virtualCameras[0].LookAt = car.transform;

        virtualCameras[1].Follow = car2.transform;
        virtualCameras[1].LookAt = car2.transform;

        KeyboardInput input = car.GetComponent<KeyboardInput>();
        KeyboardInput input2 = car2.GetComponent<KeyboardInput>();

        input.TurnInputName = "HorizontalP1";
        input.AccelerateButtonName = "AccelerateP1";
        input.BrakeButtonName = "BrakeP1";

        input2.TurnInputName = "HorizontalP2";
        input2.AccelerateButtonName = "AccelerateP2";
        input2.BrakeButtonName = "BrakeP2";
    }

}
