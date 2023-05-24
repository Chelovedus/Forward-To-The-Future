using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerZombies : MonoBehaviour
{
  

    [SerializeField] static public bool waweIsActive; 
    [SerializeField] public int countWawe; 
    [SerializeField] public static int killsInWawe;

    [SerializeField] GameObject w1;
    [SerializeField] GameObject w2;
    [SerializeField] GameObject w3;
    [SerializeField] GameObject w4;
    [SerializeField] GameObject w5;
    [SerializeField] GameObject w6;
    [SerializeField] GameObject w7;
    [SerializeField] GameObject w8;
    [SerializeField] GameObject w9;
    [SerializeField] GameObject w10;
    [SerializeField] GameObject w11;
    [SerializeField] GameObject w12;


    // Start is called before the first frame update
    void Start()
    {
        countWawe = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Stats.countWawe = countWawe;
        CheckWaweAndSpawn();
        CheckAndEndWawe();
        UpdateReputationStat();
    }

    void UpdateReputationStat()
    {
        Stats.reputationStat = countWawe - 1;
    }

    void CheckWaweAndSpawn()
    {
        if (waweIsActive)
        {
            HelpMePlsDontWriteThisText(countWawe);
        }
    }
    void HelpMePlsDontWriteThisText(int countWawe)
    {
        switch (countWawe) {

            case 1:
        w1.SetActive(true);
                break;

            case 2:
        w2.SetActive(true);
                break;
            case 3:
        w3.SetActive(true);
                break;

            case 4:
                w4.SetActive(true);
                break;

                case 5:
                w5.SetActive(true);
                break;

                case 6:
                w6.SetActive(true);
                break;

                case 7:
                w7.SetActive(true);
                break;

                case 8:
                w8.SetActive(true);
                break;

                case 9:
                w9.SetActive(true);
                break;

                case 10:
                w10.SetActive(true);
                break;

            case 11:
                w11.SetActive(true);
                break;

            case 12:
                w12.SetActive(true);
                break;
        }
    }
    void CheckAndEndWawe()
    {
        switch (countWawe)
        {

            case 1:
                if (killsInWawe == 7)
                {
                    SetValueInWawes();
                }
                break;

            case 2:
                if (killsInWawe == 8)
                {
                    SetValueInWawes();
                }
                break;

            case 3:
                if (killsInWawe == 9)
                {
                    SetValueInWawes();
                }
                break;

            case 4:
                if (killsInWawe == 9)
                {
                    SetValueInWawes();
                }
                break;

            case 5:
                if (killsInWawe == 12)
                {
                    SetValueInWawes();
                }
                break;

            case 6:
                if (killsInWawe == 10)
                {
                    SetValueInWawes();
                }
                break;

            case 7:
                if (killsInWawe == 10)
                {
                    SetValueInWawes();
                }
                break;

            case 8:
                if (killsInWawe == 10)
                {
                    SetValueInWawes();
                }
                break;

            case 9:
                if (killsInWawe == 9)
                {
                    SetValueInWawes();
                }
                break;

            case 10:
                if (killsInWawe == 9)
                {
                    SetValueInWawes();
                }
                break;

            case 11:
                if (killsInWawe == 16)
                {
                    SetValueInWawes();
                }
                break;

            case 12:
                if (killsInWawe == 15)
                {
                    SetValueInWawes();
                }
                break;
        }
    }
    void SetValueInWawes()
    {
        killsInWawe = 0;
        waweIsActive = false;
        countWawe = countWawe + 1;
        Talk.needTalkNow = true;
    }
}
