using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkCollider : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] GameObject TalkUI;

    // Start is called before the first frame update
    void Start()
    {
        obj = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Stay" + other);
        if(Talk.needTalkNow == true)
        {
            //Debug.Log("ColliderIsWorking");
            TalkUI.SetActive(true);
        }
    }
    
}
