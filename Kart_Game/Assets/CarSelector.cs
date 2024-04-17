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

    int index;
    // Start is called before the first frame update
    void Start()
    {
        index = PlayerPrefs.GetInt("carIndex");

        for(int i = 0; i < karts.Length; i++)
        {
            karts[i].SetActive(false);
            karts[index].SetActive(true);
        }        
    }

    // Update is called once per frame
    void Update()
    {
        if(index >= 3)
        {
            next.interactable = false;
        }
        else
        {
            next.interactable = true;
        }

        if(index <= 0)
        {
            prev.interactable = false;
        }
        else{
            prev.interactable = true;
        }
        
    }

    public void Next()
    {
        index++;

        for (int i = 0; i < karts.Length; i++)
        {
            karts[i].SetActive(false);
            karts[index].SetActive(true);
        }

        PlayerPrefs.SetInt("carIndex", index);
        PlayerPrefs.Save();
    }

    public void Prev()
    {
        index--;

        for (int i = 0; i < karts.Length; i++)
        {
            karts[i].SetActive(false);
            kartss[index].SetActive(true);
        }

        PlayerPrefs.SetInt("carIndex", index);
        PlayerPrefs.Save();
    }

    public void Race()
    {
        SceneManager.LoadSceneAsync("Multi");
    }
}
