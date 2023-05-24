using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOffAll : MonoBehaviour
{
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTalkAndOffLight();
    }
    void CheckTalkAndOffLight()
    {
        if(Talk.curentTalk == 83)
        {
            Destroy(obj);
        }
    }
}
