using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gachaeffectController : MonoBehaviour
{
    public GameObject gachaeffect1;
    public GameObject gachaeffect2;
    public GameObject gachaeffect3;
    float alpha;
    int i;//エフェクトの段階
    int j;

    public GameObject testcollection;
    public Sprite[] collectionSprite;

    // Start is called before the first frame update
    void Start()
    {
        alpha=1;
        i=0;

        testcollection.transform.position=new Vector3(562,3000,-1);
        for(i=0;i<30;i++)
        {
            j=PlayerPrefs.GetInt("collection"+(i+1),0);
            if(j==1 || j==3)
            {
                testcollection.GetComponent<SpriteRenderer>().sprite=collectionSprite[i];
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gachaeffect1.transform.position.x>2200)
        {
            gachaeffect1.transform.position=new Vector3(gachaeffect1.transform.position.x-300*Time.deltaTime,1200,0);
        }
        else if(gachaeffect1.transform.position.x>500)
        {
            gachaeffect1.transform.position=new Vector3(gachaeffect1.transform.position.x-15000*Time.deltaTime,1200,0);
        }
        else
        {
            i=1;
        }
        
        if(i==1)
        {
            i=2;
            gachaeffect1.SetActive(false);
            gachaeffect2.SetActive(true);
            gachaeffect3.SetActive(true);

            testcollection.SetActive(true);
        }
        
        if(i==2)
        {
            alpha-=0.7f*Time.deltaTime;
            gachaeffect2.GetComponent<SpriteRenderer>().color=new Color (1.0f, 1.0f, 1.0f, alpha);
            testcollection.GetComponent<SpriteRenderer>().color=new Color (1.0f-alpha, 1.0f-alpha, 1.0f-alpha, 1.0f);

            if(testcollection.transform.position.y>1600)
            {
                testcollection.transform.position=new Vector3(562,testcollection.transform.position.y-9000*Time.deltaTime,-1);
            }
            else if(testcollection.transform.position.y>1200)
            {
                testcollection.transform.position=new Vector3(562,testcollection.transform.position.y-300*Time.deltaTime,-1);
            }
            else if(testcollection.transform.position.y>1018)
            {
                testcollection.transform.position=new Vector3(562,testcollection.transform.position.y-100*Time.deltaTime,-1);
            }
            else
            {
                i=3;
            }
            
        }

        if(i==3)
        {
            SceneManager.LoadScene("gachaScene");
        }
    }
}
