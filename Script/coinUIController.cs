using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinUIController : MonoBehaviour
{
    float time=0;
    // Start is called before the first frame update
    void Start()
    {
        time=0;
    }

    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime;
        if(time>0.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
