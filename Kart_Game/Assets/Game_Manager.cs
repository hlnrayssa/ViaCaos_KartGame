using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{

    public int index;

    public GameObject[] karts;
    // Start is called before the first frame update
    void Start()
    {
        index = PlayerPrefs.GetInt("carIndex");
        GameObject kart = Instantiate(karts[index],Vector3.zero, Quaternion.identity);
    }


}
