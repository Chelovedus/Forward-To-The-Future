using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Music : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Slider obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = this.GetComponent<UnityEngine.UI.Slider>();
        obj.value = 0.2f;
    }


    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = obj.value;
        //Debug.Log(AudioListener.volume);
    }
}
