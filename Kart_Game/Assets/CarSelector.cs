using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarSelector : MonoBehaviour
{

    public GameObject[] karts;

    public Button next;

    public Button prev;

    int indexPlayer1;
    int indexPlayer2;

    // Start is called before the first frame update
    void Start()
    {
        indexPlayer1 = PlayerPrefs.GetInt("carIndexPlayer1");
        indexPlayer2 = PlayerPrefs.GetInt("carIndexPlayer2");

        for(int i = 0; i < karts.Length; i++)
        {
           karts[i].SetActive(false);
           karts[indexPlayer1].SetActive(true);
           karts[indexPlayer2].SetActive(true);
        }        
    }

    // Update is called once per frame
 void Update()
    {
        if(indexPlayer1 >= 3)
        {
            next.interactable = false;
        }
        else
        {
            next.interactable = true;
        }

        if(indexPlayer1 <= 0)
        {
            prev.interactable = false;
        }
        else{
            prev.interactable = true;
        }
        
    }

    public void Next()
    {
        indexPlayer1++;

        for (int i = 0; i < karts.Length; i++)
        {
            karts[i].SetActive(false);
            karts[indexPlayer1].SetActive(true);
            karts[indexPlayer2].SetActive(true);
        }

        PlayerPrefs.SetInt("carIndexPlayer1", indexPlayer1);
        PlayerPrefs.Save();
    }

    public void Prev()
    {
        indexPlayer1--;

        for (int i = 0; i < karts.Length; i++)
        {
            karts[i].SetActive(false);
            karts[indexPlayer1].SetActive(true);
            karts[indexPlayer2].SetActive(true);
        }

        PlayerPrefs.SetInt("carIndexPlayer1", indexPlayer1);
        PlayerPrefs.Save();
    }

    public void Race()
    {
        PlayerPrefs.SetInt("carIndexPlayer2", indexPlayer2);
        PlayerPrefs.Save();
        SceneManager.LoadSceneAsync("Multi");
    }
}