using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class loginConyroller : MonoBehaviour
{
    public GameObject logingamen;
    public GameObject text_playdays;
    public GameObject text_getdia;

    int login=0;
    int alldia=0;
    int playdays=0;

    float time=0;

    // Start is called before the first frame update
    void Start()
    {
        login=PlayerPrefs.GetInt("login",0);
        alldia=PlayerPrefs.GetInt("alldia",0);
        playdays=PlayerPrefs.GetInt("playdays",0);
        if(login==1)
        {
            logingamen.SetActive(true);
            text_playdays.GetComponent<Text>().text=""+playdays;
            if(playdays<=5)
            {
                alldia=alldia+4+playdays;
                text_getdia.GetComponent<Text>().text="×　"+(4+playdays);
            }
            else
            {
                alldia+=10;
                text_getdia.GetComponent<Text>().text="×　10";
            }
            PlayerPrefs.SetInt("login",0);
            PlayerPrefs.SetInt("alldia",alldia);
            PlayerPrefs.Save();
        }
    }

    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime;

        if(login==1)
        {
            if(time>=0.6f)
            {
                if (Input.GetMouseButtonUp(0)) 
                {
                    SceneManager.LoadScene("koujyouScene");
                }
            }
            
        }
        else
        {
            SceneManager.LoadScene("koujyouScene");
        }
    }
}
