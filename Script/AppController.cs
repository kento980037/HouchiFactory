using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AppController : MonoBehaviour
{
    int[] num_line=new int[10];
    int[] moveorno=new int[10];
    int[] producttime=new int[10];
    int[] num_product=new int[10];
    int[] nowtime=new int[10];
    int[] price=new int[10];
    int[] shippedprice=new int[10];
    int allmoney;
    int employee;
    int i;
    int now=0;
    int allproduct=0;
    int time_d=0;
    float playtime=0;
    int playtime_m=0;
    int playtime_h=0;
    int playdays=0;
    float time=0;
    int allnumproduct=0;
    int login=0;//0だとログインボーナス受け取った、1ならまだ受けってない

    // Start is called before the first frame update
    void Start()
    {
        now=(System.DateTime.Now.Year-2020)*365*24*3600+System.DateTime.Now.Month*31*24*3600+System.DateTime.Now.Day*24*3600+System.DateTime.Now.Hour*3600+System.DateTime.Now.Minute*60+System.DateTime.Now.Second;
        allmoney=PlayerPrefs.GetInt("allmoney",0);
        employee=PlayerPrefs.GetInt("employee",1);
        for(i=0;i<10;i++)
        {
            num_line[i]=PlayerPrefs.GetInt("num_line"+(i+1),0);
            moveorno[i]=PlayerPrefs.GetInt("moveorno"+(i+1),1);
            producttime[i]=PlayerPrefs.GetInt("time"+(i+1),0);   
            num_product[i]=PlayerPrefs.GetInt("num_product"+(i+1),0);
            //allproduct+=num_product[i];
            nowtime[i]=PlayerPrefs.GetInt("nowtime"+(i+1),now);
            PlayerPrefs.SetInt("nowtime"+(i+1),nowtime[i]);
            PlayerPrefs.Save();
        }


        //以下初期条件
        if(num_line[0]==0)
        {
            num_line[0]=1;
            PlayerPrefs.SetInt("num_line1",num_line[0]);
            moveorno[0]=1;
            PlayerPrefs.SetInt("moveorno1",moveorno[0]);
            num_product[0]=50;
            PlayerPrefs.SetInt("num_product1",num_product[0]);
            allmoney=100;
            PlayerPrefs.SetInt("allmoney",allmoney);
            producttime[0]=32;
            producttime[1]=1024;
            producttime[2]=1728;
            producttime[3]=4096;
            producttime[4]=800;
            producttime[5]=6912;
            producttime[6]=16000;
            producttime[7]=8192;
            producttime[8]=5832;
            producttime[9]=2048;
            price[0]=10;
            price[1]=100;
            price[2]=1000;
            price[3]=2000;
            price[4]=4000;
            price[5]=8000;
            price[6]=15000;
            price[7]=20000;
            price[8]=30000;
            price[9]=40000;
            shippedprice[0]=1;
            shippedprice[1]=32;
            shippedprice[2]=108;
            shippedprice[3]=256;
            shippedprice[4]=100;
            shippedprice[5]=864;
            shippedprice[6]=4000;
            shippedprice[7]=2048;
            shippedprice[8]=2916;
            shippedprice[9]=1024;
            for(i=0;i<10;i++)
            {
                PlayerPrefs.SetInt("time"+(i+1),producttime[i]);
                PlayerPrefs.SetInt("price"+(i+1),price[i]);
                PlayerPrefs.SetInt("shippedprice"+(i+1),shippedprice[i]);
            }
            PlayerPrefs.Save();
        }
        //ここまで

        //記録関係
        playtime=PlayerPrefs.GetFloat("playtime",0);
        playtime_m=PlayerPrefs.GetInt("playtime_m",0);
        playtime_h=PlayerPrefs.GetInt("playtime_h",0);
        time_d=PlayerPrefs.GetInt("time_d",0);
        playdays=PlayerPrefs.GetInt("playdays",0);
        allnumproduct=PlayerPrefs.GetInt("allnumproduct",0);
        if(now-time_d>86400)
        {
            playdays++;
            time_d=now;
            login=1;
            PlayerPrefs.SetInt("login",login);
            PlayerPrefs.SetInt("playdays",playdays);
            PlayerPrefs.SetInt("time_d",time_d);
            PlayerPrefs.Save();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time+=Time.deltaTime;
        playtime+=Time.deltaTime;

        if(time>1)//1秒ごとに実行
        {
            time=0;
            now=(System.DateTime.Now.Year-2020)*365*24*3600+System.DateTime.Now.Month*31*24*3600+System.DateTime.Now.Day*24*3600+System.DateTime.Now.Hour*3600+System.DateTime.Now.Minute*60+System.DateTime.Now.Second;

            if(playtime>=60)
            {
                playtime_m++;
                playtime-=60;
            }
            if(playtime_m>=60)
            {
                playtime_h++;
                playtime_m-=60;
            }
            PlayerPrefs.SetFloat("playtime",playtime);
            PlayerPrefs.SetInt("playtime_m",playtime_m);
            PlayerPrefs.SetInt("playtime_h",playtime_h);
            PlayerPrefs.Save();

            allproduct=0;
            for(i=0;i<10;i++)
            {
                num_product[i]=PlayerPrefs.GetInt("num_product"+(i+1),0);
                allproduct+=num_product[i];
            }

            for(i=0;i<10;i++)
            {
                if(num_line[i]>0)
                {
                    while(now-nowtime[i]>=producttime[i]/employee+1 )//最終ログインから製品の製造時間において十分な時間が立っている場合
                    {
                        nowtime[i]+=producttime[i]/employee+1;
                        PlayerPrefs.SetInt("nowtime"+(i+1),nowtime[i]);
                        if(allproduct<100 && moveorno[i]==1)
                        {
                            if(allproduct+num_line[i]>100)
                            {
                                num_product[i]+=100-allproduct;
                                allproduct+=100-allproduct;
                                allnumproduct+=100-allproduct;
                            }
                            else
                            {
                                num_product[i]+=num_line[i];
                                allproduct+=num_line[i];
                                allnumproduct+=num_line[i];
                            }
                            PlayerPrefs.SetInt("num_product"+(i+1),num_product[i]);
                            PlayerPrefs.SetInt("allnumproduct",allnumproduct);
                            time=0.99f;
                            break;
                        }
                        else if(allproduct>100 && now-nowtime[i]>=(producttime[i]/employee+1)*100)//最終ログインから時間が経ちすぎている場合の動作軽量のため
                        {
                            nowtime[i]=now-producttime[i]/employee+1;
                        }
                        
                    }
                }
                PlayerPrefs.Save();
            }
        }
        
    }

    public void SceneSeni(int stage)
    {
        if(SceneManager.GetActiveScene().name == "koukokuScene")
        {
            int loadnow=AdMobReward.getloadnow();
            if(loadnow==0)
            {

            }
            else 
            {
                 if(stage==1)
                {
                    SceneManager.LoadScene("koujyouScene");
                }
                else if(stage==2)
                {
                    SceneManager.LoadScene("sisetsuScene");
                }
                else if(stage==3)
                {
                    SceneManager.LoadScene("koukokuScene");
                }
                else if(stage==4)
                {
                    SceneManager.LoadScene("kirokuScene");
                }
                else if(stage==5)
                {
                    SceneManager.LoadScene("gachaScene");
                }
                else if(stage==6)
                {
                    SceneManager.LoadScene("collectionScene");
                }

            }
        }
        else
        {
             if(stage==1)
            {
                SceneManager.LoadScene("koujyouScene");
            }
            else if(stage==2)
            {
                SceneManager.LoadScene("sisetsuScene");
            }
            else if(stage==3)
            {
                SceneManager.LoadScene("koukokuScene");
            }
            else if(stage==4)
            {   
                SceneManager.LoadScene("kirokuScene");
            }
            else if(stage==5)
            {
                SceneManager.LoadScene("gachaScene");
            }
            else if(stage==6)
            {
                SceneManager.LoadScene("collectionScene");
            }
        }
    }
}
