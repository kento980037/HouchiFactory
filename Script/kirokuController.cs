using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class kirokuController : MonoBehaviour
{
    public GameObject data_playtime;
    public GameObject data_playdays;
    public GameObject data_maxmoney;
    public GameObject data_allnumproduct;
    public GameObject data_adtimes;
    public GameObject text_coin;
    public GameObject text_alldia;
    int playtime_m;
    int playtime_h;
    int playdays;
    int adtimes;
    int allnumproduct;
    int maxmoney;
    int allmoney;
    int alldia;


    // Start is called before the first frame update
    void Start()
    {
        playtime_m=PlayerPrefs.GetInt("playtime_m",0);
        playtime_h=PlayerPrefs.GetInt("playtime_h",0);
        playdays=PlayerPrefs.GetInt("playdays",0);
        adtimes=PlayerPrefs.GetInt("adtimes",0);
        allnumproduct=PlayerPrefs.GetInt("allnumproduct",0);
        maxmoney=PlayerPrefs.GetInt("maxmoney",0);

        data_playtime.GetComponent<Text>().text=""+playtime_h+"："+playtime_m.ToString("D2");
        data_playdays.GetComponent<Text>().text=""+playdays;
        data_adtimes.GetComponent<Text>().text=""+adtimes;
        data_allnumproduct.GetComponent<Text>().text=""+allnumproduct;
        data_maxmoney.GetComponent<Text>().text=""+maxmoney;

        allmoney=PlayerPrefs.GetInt("allmoney",0);
        text_coin.GetComponent<Text> ().text=""+allmoney;
        alldia=PlayerPrefs.GetInt("alldia",0);
        text_alldia.GetComponent<Text> ().text=""+alldia;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
