using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameController : MonoBehaviour
{
    GameObject[] product = new GameObject[10];
    public GameObject coinUI;
    public GameObject text_coin;
    public GameObject text_alldia;
    public GameObject text_attention;
    int[] num_product=new int[10];
    int[] num_product_d=new int[10];
    int allmoney;
    int alldia;
    int i,j;
    int allproduct;
    float time=1;
    // Start is called before the first frame update
    void Start()
    {
        allproduct=0;
        for(i=0;i<10;i++)
        {
            product[i]=GameObject.Find("product"+(i+1));
            product[i].SetActive(false);
            num_product[i]=PlayerPrefs.GetInt("num_product"+(i+1),0);
            if(num_product[i]>0)
            {
                for(j=0;j<num_product[i];j++)
                {
                    var prd = Instantiate(product[i],new Vector3( product[i].transform.position.x+Random.Range(-1.8f,1.8f), product[i].transform.position.y+Random.Range(-3.0f,-1.5f), product[i].transform.position.z), Quaternion.identity);
                    prd.SetActive(true);
                }
            }
            allproduct+=num_product[i];
        }
        coinUI.SetActive(false);
        allmoney=PlayerPrefs.GetInt("allmoney",0);
        text_coin.GetComponent<Text> ().text=""+allmoney;
        alldia=PlayerPrefs.GetInt("alldia",0);
        text_alldia.GetComponent<Text> ().text=""+alldia;
        if(allproduct>=100)
        {
            text_attention.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime;
        if(time>0.8f)
        {
            time=0;
            if(allproduct>=100)
            {
                text_attention.SetActive(true);
            }
            else
            {
                text_attention.SetActive(false);
            }
        }
        allproduct=0;


        for(i=0;i<10;i++)
        {
            num_product_d[i]=PlayerPrefs.GetInt("num_product"+(i+1),0);
            if(num_product_d[i]-num_product[i]>0)
            {
                for(j=0;j<num_product_d[i]-num_product[i];j++)
                {
                    var prd = Instantiate(product[i],new Vector3( product[i].transform.position.x+Random.Range(-1.8f,1.8f), product[i].transform.position.y+Random.Range(-2.0f,3.0f), product[i].transform.position.z), Quaternion.identity);
                    prd.SetActive(true);
                }
                num_product[i]=num_product_d[i];
            }
            else if(num_product_d[i]-num_product[i]<=-1)
            {
                num_product[i]=PlayerPrefs.GetInt("num_product"+(i+1),0);
                
            }
            allproduct+=num_product[i];
        }


        
    }
}
