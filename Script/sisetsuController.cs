using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using System;

public class sisetsuController : MonoBehaviour
{
    public GameObject text_coin;
    public GameObject text_alldia;
    GameObject[] buckcolor=new GameObject[10];
    GameObject[] text_line=new GameObject[10];
    GameObject[] text_time=new GameObject[10];
    GameObject[] text_moveorno=new GameObject[10];
    public GameObject text_numberemployee;
    public GameObject text_exemplyee;
    public GameObject text_diaemployee;
    int[] num_line=new int[10];
    int[] moveorno=new int[10];
    int allmoney;
    int alldia;
    int employee;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        allmoney=PlayerPrefs.GetInt("allmoney",0);
        text_coin.GetComponent<Text> ().text=""+allmoney;
        alldia=PlayerPrefs.GetInt("alldia",0);
        text_alldia.GetComponent<Text> ().text=""+alldia;

        employee=PlayerPrefs.GetInt("employee",1);

        text_diaemployee.GetComponent<Text>().text="："+(int) Mathf.Floor(Mathf.Sqrt(169*employee)-7.5f);
        text_numberemployee.GetComponent<Text>().text="人数："+employee;


        for(i=0;i<10;i++)
        {
            buckcolor[i]=GameObject.Find("buckcolor"+(i+1));
            num_line[i]=PlayerPrefs.GetInt("num_line"+(i+1),0);
            moveorno[i]=PlayerPrefs.GetInt("moveorno"+(i+1),1);
            text_moveorno[i]=GameObject.Find("text_moveorno"+(i+1));
            if(num_line[i]==0 || moveorno[i]==0)
            {
                buckcolor[i].SetActive(false);
                text_moveorno[i].GetComponent<Text>().text="動かす";
            }

            text_line[i]=GameObject.Find("text_line"+(i+1));
            text_line[i].GetComponent<Text>().text="生産ライン: "+num_line[i];

            text_time[i]=GameObject.Find("text_time"+(i+1));
            int producttime=PlayerPrefs.GetInt("time"+(i+1),0);            
            text_time[i].GetComponent<Text>().text="生産時間: "+(producttime/employee+1);

            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buyButton(int number)
    {
        num_line[number-1]=PlayerPrefs.GetInt("num_line"+number,0);
        if(num_line[number-1]==0)
        {
            int now=(System.DateTime.Now.Year-2020)*365*24*3600+System.DateTime.Now.Month*31*24*3600+System.DateTime.Now.Day*24*3600+System.DateTime.Now.Hour*3600+System.DateTime.Now.Minute*60+System.DateTime.Now.Second;
            PlayerPrefs.SetInt("nowtime"+number,now);
            PlayerPrefs.Save();
        }
        
        int price=PlayerPrefs.GetInt("price"+number,0);
        allmoney=PlayerPrefs.GetInt("allmoney",0);
        if(allmoney>=price && num_line[number-1]<100)
        {
            //num_line[number-1]=PlayerPrefs.GetInt("num_line"+number,0);
            num_line[number-1]++;
            PlayerPrefs.SetInt("num_line"+number,num_line[number-1]);
            allmoney-=price;
            PlayerPrefs.SetInt("allmoney",allmoney);
            PlayerPrefs.Save();
            text_line[number-1].GetComponent<Text>().text="生産ライン: "+num_line[number-1];
            text_coin.GetComponent<Text> ().text=""+allmoney;
            moveorno[number-1]=1;
            buckcolor[number-1].SetActive(true);
            text_moveorno[number-1].GetComponent<Text>().text="止める";
            PlayerPrefs.SetInt("moveorno"+number,moveorno[number-1]);
            PlayerPrefs.Save();
        }
        else if(allmoney<price)
        {
            text_line[number-1].GetComponent<Text>().text="所持金不足";
        }
        else
        {
            text_line[number-1].GetComponent<Text>().text="最大です";   
        }

    }

    public void moveButton(int number)
    {
        moveorno[number-1]=PlayerPrefs.GetInt("moveorno"+number,1);
        num_line[number-1]=PlayerPrefs.GetInt("num_line"+number,0);
        if(moveorno[number-1]==0 )
        {
            if(num_line[number-1]>0)
            {
                moveorno[number-1]=1;//動かす
                buckcolor[number-1].SetActive(true);
                text_moveorno[number-1].GetComponent<Text>().text="止める";
            }
            
        }
        else
        {
            moveorno[number-1]=0;
            buckcolor[number-1].SetActive(false);
            text_moveorno[number-1].GetComponent<Text>().text="動かす";
        }
        PlayerPrefs.SetInt("moveorno"+number,moveorno[number-1]);
        PlayerPrefs.Save();
    }

    public void buyenployee()
    {
        employee=PlayerPrefs.GetInt("employee",1);
        alldia=PlayerPrefs.GetInt("alldia",0);
        if(alldia>=(int) Mathf.Floor(Mathf.Sqrt(169*employee)-7.5f))
        {
            alldia-=(int) Mathf.Floor(Mathf.Sqrt(169*employee)-7.5f);
            employee++;
            PlayerPrefs.SetInt("employee",employee);
            PlayerPrefs.SetInt("alldia",alldia);
            PlayerPrefs.Save();
            text_alldia.GetComponent<Text> ().text=""+alldia;
            text_diaemployee.GetComponent<Text>().text="："+(int) Mathf.Floor(Mathf.Sqrt(169*employee)-7.5f);
            text_numberemployee.GetComponent<Text>().text="人数："+employee;
            for(i=0;i<10;i++)
            {
                int producttime=PlayerPrefs.GetInt("time"+(i+1),0); 
                text_time[i].GetComponent<Text>().text="生産時間: "+(producttime/employee+1);
            }
        }
        else
        {
            text_exemplyee.GetComponent<Text>().text="ダイヤが足りません。";
        }

    }
}
