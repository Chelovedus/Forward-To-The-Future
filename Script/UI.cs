using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] public static bool interfaceIsOpened;

    [SerializeField] public GameObject bankUI;
    //MenuScript menuScript;
    
    
    
    [SerializeField] ShootingManager shootingManager;
    [SerializeField] Hp Hp;
    [SerializeField] GameObject imagePistol;
    [SerializeField] GameObject imageTomahawk;
    [SerializeField] GameObject imageAk;
    

    int slotUseNow; // weapon slot
    [SerializeField] GameObject ammoUI;
    TMP_Text ammoValue;
    [SerializeField] GameObject healthUI;
    TMP_Text healthValue;
    [SerializeField] GameObject moneyUI;
    TMP_Text moneyValue;
    [SerializeField] GameObject reputationUI;
    TMP_Text reputationValue;
    void Start()
    {
        interfaceIsOpened = false;
        ammoValue = ammoUI.GetComponent<TMP_Text>();
        healthValue = healthUI.GetComponent<TMP_Text>();
        moneyValue = moneyUI.GetComponent<TMP_Text>();
        reputationValue = reputationUI.GetComponent<TMP_Text>();
    }
    void Update()
    {
        GetAndSetUiValues();
        InterfaceCheckAndSetValue();
        CheckOpenUIAndHideOrShowCursor();
    }
    void CheckOpenUIAndHideOrShowCursor()
    {
        if (interfaceIsOpened)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void OpenBankPlayer()
    {
        bankUI.SetActive(true);
    }
    public void CloseBankPlayer()
    {
        bankUI.SetActive(false);
    }

    public static void OpenBankMenu(GameObject bankUI)
    {
        bankUI.SetActive(true);
    }

    public static void CloseBankMenu(GameObject bankUI)
    {
        bankUI.SetActive(false);
    }

    void InterfaceCheckAndSetValue()
    {
        if (bankUI.active || MenuScript.uiIsActive)
        {
            interfaceIsOpened = true;
        }
        if (!bankUI.active && !MenuScript.uiIsActive)
        {
            interfaceIsOpened = false;
        }
    }

    void GetAndSetUiValues()
    {
        slotUseNow = shootingManager.slotUseNow;
        UpdateAmmoValueUI();
        UpdateWeaponUI();
        UpdateHealthValueUI();
        UpdateMoneyValueUI();
        UpdateReputationValueUI();
    }
    void UpdateReputationValueUI()
    {
        reputationValue.text = Stats.reputationStat.ToString();
    }

    void UpdateMoneyValueUI()
    {
        moneyValue.text = Stats.moneyStat.ToString();
    }

    void UpdateHealthValueUI()
    {
        healthValue.text = Hp.Health.ToString();
    }

    void UpdateAmmoValueUI()
    {
        if(slotUseNow == 3) { ammoValue.text = " "; }
        else {
        ammoValue.text = shootingManager.curentAmmo.ToString() + "/" + shootingManager.reserveAmmo.ToString();
        }
    }
    void UpdateWeaponUI()
    {
        switch(slotUseNow)
        {
            case 1: // rifle
                imageAk.SetActive(true);
                imagePistol.SetActive(false);
                imageTomahawk.SetActive(false);
                break;

            case 2: // pistol
                imageAk.SetActive(false);
                imagePistol.SetActive(true);
                imageTomahawk.SetActive(false);
                break;

            case 3: // tomahawk
                imageAk.SetActive(false);
                imagePistol.SetActive(false);
                imageTomahawk.SetActive(true);
                break;
                
        }
    }
}
