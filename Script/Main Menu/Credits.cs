using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField] GameObject creditsObjTEXT;
    [SerializeField] float textUpSpeed;
    [SerializeField] bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Anim();
    }
    public void AnimatedTextCredits()
    {
        if (!creditsObjTEXT.active)
        {
            creditsObjTEXT.SetActive(true);
            isActive = true;
        }
        if (creditsObjTEXT.active)
        {
            creditsObjTEXT.SetActive(false);
            isActive = false;
        }
    }
    void Anim()
    {
        if (isActive) {
        creditsObjTEXT.transform.Translate(Vector3.up * Time.deltaTime * textUpSpeed);
        }
    }
}
