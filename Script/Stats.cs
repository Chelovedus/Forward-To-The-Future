using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    // Inspector-------------------------------------
    GameObject playerObj;
    [SerializeField] bool Debug;
    [SerializeField] float repInspector;
    [SerializeField] float moneyInspector;

    // PLAYER STATS-------------------------------------
    public static float reputationStat;
    public static float moneyStat;
    public static float killsCount;// For missions
    public static float killsConfirmForBank;
    public static int slotUseNow;

    public static int countWawe;

    public static float zombieCost = 73;
    

    // Wawes Zombie-----------------------------------------



    // ZOMBIE STATS-------------------------------------------
    public static int DamageByZombie = 1;
    public static float rangeAttackByZombie = 6f;
    public static float timeDelayByZombie = 5f; // 0.45f
    





    void Start()
    {
        playerObj = this.gameObject;
    }
    void Update()
    {
        GiveMoneyOrReputationByInspector();

    }




    void GiveMoneyOrReputationByInspector()
    {
        if (Debug)
        {
            reputationStat = repInspector;
            moneyStat = moneyInspector;
        }
    }
}
