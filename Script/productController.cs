using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using System.Runtime.InteropServices;

public class productController : MonoBehaviour
{
    public GameObject coinUI;
    public GameObject coinUI_text;
    public GameObject canvas;//キャンバス
    public GameObject text_coin;
    int allmoney;
    int maxmoney;

    [DllImport("__Internal")]
    private static extern void playSystemSound(int n);

    // Start is called before the first frame update
    void Start()
    {
        maxmoney=PlayerPrefs.GetInt("maxmoney",0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void productOnClic(int n)//nはどの製品か
    {
        int money=PlayerPrefs.GetInt("shippedprice"+n,0);
        Destroy (this.gameObject);
        coinUI_text.GetComponent<Text> ().text=""+money;
        var prd = Instantiate(coinUI);
        prd.transform.SetParent(canvas.transform, false);
        prd.GetComponent<RectTransform>().position=RectTransformUtility.WorldToScreenPoint (Camera.main, this.transform.position);
        prd.SetActive(true);
        allmoney=PlayerPrefs.GetInt("allmoney",0);
        allmoney+=money;
        if(maxmoney<allmoney)
        {
            maxmoney=allmoney;
            PlayerPrefs.SetInt("maxmoney",maxmoney);
        }
        PlayerPrefs.SetInt("allmoney",allmoney);
        PlayerPrefs.Save();
        text_coin.GetComponent<Text> ().text=""+allmoney;
        int num_product=PlayerPrefs.GetInt("num_product"+n,0);
        num_product--;
        PlayerPrefs.SetInt("num_product"+n,num_product);
        PlayerPrefs.Save();
        
        /*
        if (SystemInfo.supportsVibration) 
        {
			//Handheld.Vibrate ();
            Touch3D(1519);
		} else {
			print ("振動に対応してないよ〜");
		}
        */
        #if UNITY_EDITOR
       Debug.Log("Play system sound or vibration on real devices");
       #else
       playSystemSound(1519);
       #endif
        
    }
}
