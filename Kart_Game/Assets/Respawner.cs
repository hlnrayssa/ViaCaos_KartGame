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
   public void Start()
    {

        //check if the car is selected
        GameObject carSelected1; 
        GameObject carSelected2;
        if (KartSelector.currentCar == null && KartSelector.currentCar == null)
        {
            //if not, select the first car in the list
            carSelected1 = carList[0];
            carSelected2 = carList[0];
        }
        
        else
        {
            carSelected1 = KartSelector.currentCar;
            carSelected2 = KartSelector.currentCar2;
        }

        


        //spawn the car
        GameObject car = Instantiate(carSelected1, spawnPoints[0].position, spawnPoints[0].rotation);
        
        GameObject car2 = Instantiate(carSelected2, spawnPoints[1].position, spawnPoints[1].rotation);

        car.tag = "Player";
        car2.tag = "Player2";

        //set the virtual camera to follow the car
        virtualCameras[0].Follow = car.transform;
        virtualCameras[0].LookAt = car.transform;

        virtualCameras[1].Follow = car2.transform;
        virtualCameras[1].LookAt = car2.transform;

        KeyboardInput input = car.GetComponent<KeyboardInput>();
        KeyboardInput input2 = car2.GetComponent<KeyboardInput>();

        input.TurnInputName = "Horizontal";
        input.AccelerateButtonName = "Accelerate";
        input.BrakeButtonName = "Brake";

        input2.TurnInputName = "HorizontalP2";
        input2.AccelerateButtonName = "AccelerateP2";
        input2.BrakeButtonName = "BrakeP2";


    }

}