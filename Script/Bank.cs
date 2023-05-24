using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] public GameObject BankUI;
    [SerializeField] float bankKilledConfirm; // <-- add new kills zombies
    [SerializeField] GameObject bankKillsObj;
    TMP_Text killed;
    void Start()
    {
        killed = bankKillsObj.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    void UpdateKillCountUI()
    {
        killed.text = bankKilledConfirm.ToString();
        Debug.Log("updateKill");
    }
    public void UpdateKilled() 
    {
        bankKilledConfirm = bankKilledConfirm + Stats.killsConfirmForBank;
        Stats.killsConfirmForBank = 0;
        Debug.Log("killConfir");
        UpdateKillCountUI();
    }
    public void GetMoney()
    {
        Stats.moneyStat = Stats.moneyStat + (bankKilledConfirm * Stats.zombieCost);
        CheckPayDayAndCloseBankMenu(bankKilledConfirm);
        bankKilledConfirm = 0;
        killed.text = bankKilledConfirm.ToString();
        Debug.Log("GetMoney");
    }
    void CheckPayDayAndCloseBankMenu(float bankKilledConfirm)
    {
        if(bankKilledConfirm > 0) {
            UI.CloseBankMenu(BankUI);
        }
    }
}
