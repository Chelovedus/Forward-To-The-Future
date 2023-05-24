using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacherUseItem : MonoBehaviour
{
    [SerializeField] float maxDistanseUse;
    [SerializeField] GameObject buySprite;
    [SerializeField] GameObject useEasterEggSprite;
    [SerializeField] GameObject useSprite;
    [SerializeField] GameObject obj;
    [SerializeField] Camera _camera;
    [SerializeField] bool isActiveUseUI;
    [SerializeField] LayerMask LayerUse;


    void Start()
    {
        obj = this.gameObject;
        _camera = Camera.main;
    }
    private void FixedUpdate()
    {
        //RayCastCheck();

    }
    // Update is called once per frame
    void Update()
    {
        CheckUIisOpenOrNo();
        RayCastCheck();
    }
    void CheckUIisOpenOrNo()
    {
        if (buySprite.active) { isActiveUseUI = true; } else { isActiveUseUI = false; };
        if (useEasterEggSprite.active) { isActiveUseUI = true; } else { isActiveUseUI = false; };
        if(useSprite.active) { isActiveUseUI = true; } else { isActiveUseUI = false; };
    }

    void RayCastCheck()
    {
        Vector3 screen—enter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        RaycastHit hit;
        
        if (Physics.Raycast(_camera.ScreenPointToRay(screen—enter), out hit, maxDistanseUse, LayerUse))
        {

            Debug.Log("Create " + hit.collider.gameObject);
            if (hit.transform.gameObject.GetComponent<PrefabItemUse>() != null)
            {
                CheckSeeInObjAndShowSprite(hit);
            }
            else
            {
                buySprite.SetActive(false);
                useEasterEggSprite.SetActive(false);
                useSprite.SetActive(false);

            }
        }
    }

    void CheckSeeInObjAndShowSprite(RaycastHit hit1)
    {
        PrefabItemUse objUseScript = hit1.collider.gameObject.GetComponent<PrefabItemUse>();
        //buy sprite
        if(objUseScript.key == "ak" ||
            objUseScript.key == "tamohawk" ||
            objUseScript.key == "ammo" ||
            objUseScript.key == "med" || 
            objUseScript.key == "gascan")
            {
                buySprite.SetActive(true);
            StartCoroutine(resetSprite());
                WaitUseItemSee(objUseScript);
            } else { buySprite.SetActive(false); };
        // easter egg
        if(objUseScript.key == "tv")
        {
            useEasterEggSprite.SetActive(true);
            StartCoroutine(resetSprite());
            WaitUseItemSee(objUseScript);
        } else { useEasterEggSprite.SetActive(false); };
        // use
        if (objUseScript.key == "bank" ||
            objUseScript.key == "red_button")
        {
            useSprite.SetActive(true);
            StartCoroutine(resetSprite());
            WaitUseItemSee(objUseScript);
        }
        else useSprite.SetActive(false);
    }
    IEnumerator resetSprite()
    {
        yield return new WaitForSeconds(1f);
        buySprite.SetActive(false);
        useEasterEggSprite.SetActive(false);
        useSprite.SetActive(false);

    }
    void WaitUseItemSee(PrefabItemUse hitObj)
    {
        if (Input.GetKeyDown(KeyCode.E)){
            hitObj.CheckKeyAndPerformAnAction();
        }
    }
}
