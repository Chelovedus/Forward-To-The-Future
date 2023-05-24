using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabItemUse : MonoBehaviour
{
    [SerializeField] GameObject PLAYERobj;
    [SerializeField] GameObject obj;
    [SerializeField] public string key;

    [SerializeField] float priceAK;
    [SerializeField] float priceAmmo;
    [SerializeField] int valueAmmo;
    [SerializeField] float priceTamohawk;
    [SerializeField] float priceMed;
    public static bool AKunlock;
    public static bool Knifeunlock;
    ShootingManager shootingManager;
    UI ui;
    Talk talkScript;
    Hp hpScript;
    [SerializeField] Transform transformUS;
    void Start()
    {
        obj = this.gameObject;
        shootingManager = PLAYERobj.GetComponent<ShootingManager>();
        talkScript = PLAYERobj.GetComponent<Talk>();
        hpScript = PLAYERobj.GetComponent<Hp>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    // ak - buy ak | tamohawk - buy tamohawk | ammo - buy ammo | med - buy medKit | gascan - buy
    // tv - easter egg |
    // bank - use bank | red_button - use | 
    //
    public void CheckKeyAndPerformAnAction()
    {

        if(key == "gascan")
        {
            if(Stats.reputationStat >= 12)
            {
                PLAYERobj.transform.position = transformUS.position;
                talkScript.ShowTalk();
            }
        }
        if (key == "ak") {
            if(Stats.moneyStat >= priceAK && AKunlock == false && Talk.needTalkNow == false 
                && Stats.reputationStat >= 6)
            {
                Stats.moneyStat = Stats.moneyStat - priceAK;
                AKunlock = true;
            }
        }
        if (key == "tamohawk" && Stats.reputationStat >= 3)
        {
            if (Stats.moneyStat >= priceTamohawk && Knifeunlock == false && Talk.needTalkNow == false)
            {
                Stats.moneyStat = Stats.moneyStat - priceTamohawk;
                Knifeunlock = true;
            }
        }
        if (key == "ammo")
        {
            if (Stats.moneyStat >= priceAmmo && Talk.needTalkNow == false 
                && shootingManager.slotUseNow != 0 && shootingManager.slotUseNow != 3)
            {
                Stats.moneyStat = Stats.moneyStat - priceAmmo;
                shootingManager.reserveAmmo = shootingManager.reserveAmmo + valueAmmo;
            }
        }
        if (key == "bank" && talkScript.uiIsActive==false)
        {
            PLAYERobj.GetComponent<Bank>().BankUI.SetActive(true);
        }
        if (key == "med" && Talk.needTalkNow == false && hpScript.Health != 100)
        {
            if (Stats.moneyStat >= priceMed)
            {
                Stats.moneyStat = Stats.moneyStat - priceMed;
                PLAYERobj.GetComponent<Hp>().Healing(PLAYERobj, 20);
            }
        }
        if (key == "tv")
        {
            
        }
        if(key == "red_button")
        {
            if (!SpawnerZombies.waweIsActive && Talk.needTalkNow == false)
            {
                SpawnerZombies.waweIsActive = true;
            }
        }
    }
}
