using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Talk : MonoBehaviour
{
    [SerializeField] public static int curentTalk;
    [SerializeField] public static bool needTalkNow;
    [SerializeField] int curentTalkDebug;
    [SerializeField] bool isDebug;
    [SerializeField] public bool uiIsActive;
    [SerializeField] GameObject TalkUI;
    [SerializeField] TMP_Text talkText;
    [SerializeField] GameObject pistolObj;
    [SerializeField] ShootingManager shootingManager;
    [SerializeField] GameObject PlayerObj;
    [SerializeField] GameObject BlackScreen;
    Buttons buttonsScript;

    void Start()
    {
        curentTalk = 1;
        needTalkNow = true;
        shootingManager = PlayerObj.GetComponent<ShootingManager>();
        PlayerObj.GetComponent<SC_FPSController>().canMove = false;
        buttonsScript = PlayerObj.GetComponent<Buttons>();
    }

    void Update()
    {
        GetPressGButton();
        GetPressFButton();
        ChangeTextUI();
        UpdateCurentTalkDebug();
        ShowCredits();
    }
    void UpdateBoolIsActive()
    {
        if (TalkUI.active)
        {
            uiIsActive = true;
        }
        if (!TalkUI.active)
        {
            uiIsActive = false;
        }
    }

    void ShowCredits()
    {
        if (curentTalk == 86 && TalkUI.active)
        {
            BlackScreen.SetActive(true);
            PlayerObj.GetComponent<SC_FPSController>().canMove = false;
        }
        if(curentTalk == 93)
        {
            TalkUI.SetActive(false);
            buttonsScript.ShowCredits();
        }
    }

    void UpdateCurentTalkDebug()
    {
        if (isDebug)
        {
            curentTalk = curentTalkDebug;
        }
    }
    public void ShowTalk()
    {
        TalkUI.SetActive(true);
    }
    void HideTalk()
    {
        TalkUI.SetActive(false);
    }

    void ChangeTextUI()
    {
        talkText.GetComponent<I18nTextTranslator>().TextId = "t" + curentTalk.ToString();
    }

    void GetPressGButton()
    {
        if(TalkUI.active && Input.GetKeyDown(KeyCode.G) && curentTalk != 1 && curentTalk != 42 
            && curentTalk != 41)
        {
            curentTalk--;

        }
        
    }

    void TalkUINextPageAndHide()
    {
        TalkUI.SetActive(false);
        curentTalk++;
        needTalkNow = false;
    }

    void GetPressFButton() 
    {
        if (TalkUI.active && Input.GetKeyDown(KeyCode.F))
        {
            switch (curentTalk)
            {
                case 1:
                    PlayerObj.GetComponent<ShootingManager>().slotUseNow = 0;
                    curentTalk++;
                    break;
                case 12:
                    TalkUINextPageAndHide();
                    needTalkNow = true;
                    BlackScreen.SetActive(false);
                    PlayerObj.GetComponent<SC_FPSController>().canMove = true;
                    break;
                case 41:
                    pistolObj.SetActive(true);
                    shootingManager.slotUseNow = 2;
                    curentTalk++;
                    break;
                case 48:
                    TalkUINextPageAndHide();
                    break;
                case 50:
                    TalkUINextPageAndHide();
                    break;
                case 52:
                    TalkUINextPageAndHide();
                    break;
                case 53:
                    TalkUINextPageAndHide();
                    break;
                case 54:
                    TalkUINextPageAndHide();
                    break;
                case 58:
                    TalkUINextPageAndHide();
                    break;
                case 59:
                    TalkUINextPageAndHide();
                    break;
                case 62:
                    TalkUINextPageAndHide();
                    break;
                case 65:
                    TalkUINextPageAndHide();
                    break;
                case 68:
                    TalkUINextPageAndHide();
                    break;
                case 71:
                    TalkUINextPageAndHide();
                    break;
                case 74:
                    TalkUINextPageAndHide();
                    break;
                case 85:
                    TalkUINextPageAndHide();
                    break;
                case 92:
                    TalkUINextPageAndHide();
                    break;
                default:
                    curentTalk++;
                    break;
            }
            
        }
    }
}
