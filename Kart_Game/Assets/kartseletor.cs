using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KartSelector : MonoBehaviour
{
    public GameObject[] carList;
    public int selectedCar = 0;
    public int selectedCar2= 0;
    public static GameObject currentCar;
    public static GameObject currentCar2;
    public GameObject carousel;
    public GameObject carousel2;
    public string sceneName;

    private bool selected = false;
     

    private void Start()
    {
        selected = false;
        
        carousel2.SetActive(false);
    }

    public void Update()
     {

        carousel.transform.position = Vector3.Lerp(carousel.transform.position, new Vector3 (selectedCar * -5, 0, 0), Time.deltaTime*1);
        carousel2.transform.position = Vector3.Lerp(carousel2.transform.position, new Vector3(selectedCar2 * -5, 0, 0), Time.deltaTime * 1);

        if (Input.GetKeyDown(KeyCode.RightArrow) && selected == false)
         {
             RightButton();
         }

         if (Input.GetKeyDown(KeyCode.LeftArrow) && selected == false)
         {
             LeftButton();
         }

        if (Input.GetKeyDown(KeyCode.RightArrow) && selected == true)
        {
            RightButton2();
           
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && selected == true)
        {
            LeftButton2();
        }
    }

    public void RightButton()
     {
        if(selected == false)
        {
            currentCar = carList[selectedCar];

            selectedCar++;


            if (selectedCar > carList.Length - 1)
            {
                selectedCar = 0;
            }
        }
        

    }

    public void RightButton2()
    {
        if (selected == true)
        {
            currentCar2 = carList[selectedCar2];

            selectedCar2++;

            if (selectedCar2 > carList.Length - 1)
            {
                selectedCar2 = 0;
            }
        }
    }


    public void LeftButton()
     {
        if (selected == false)
        {
            currentCar = carList[selectedCar];

            selectedCar--;



            if (selectedCar < 0)
            {
                selectedCar = carList.Length - 1;
            }
        }
     }
        public void LeftButton2()
    {
        if (selected == true)
        {
            currentCar2 = carList[selectedCar2];

            selectedCar2--;



            if (selectedCar2 < 0)
            {
                selectedCar2 = carList.Length - 1;
            }
        }
        
    }
    
    public void SelectCar()
     {
         if (!selected)
         {
             
             currentCar = carList[selectedCar];
             selected = true;
             Debug.Log("Selected1");
             carousel.SetActive(false);
             carousel2.SetActive(true);
         }
         else
         {
             currentCar2 = carList[selectedCar2];
             Debug.Log("Selected2");
             SceneManager.LoadSceneAsync(sceneName);
         }

     } 
    

}
