using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{
    [SerializeField] GameObject model;
    [SerializeField] public float Health = 100f;
    [SerializeField] public bool isPlayer;
    
    
    void Start()
    {
        model = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        CheckHpPlayerAndSetNormalValue();
        Died();
    }

    void CheckHpPlayerAndSetNormalValue()
    {
        if (isPlayer && Health > 100)
        {
            Health = 100;
        }
    }

    void Died () 
    {
        if(Health <= 0 && isPlayer == false) 
        {
            Stats.killsCount = Stats.killsCount + 1;
            Stats.killsConfirmForBank = Stats.killsConfirmForBank + 1;
            SpawnerZombies.killsInWawe = SpawnerZombies.killsInWawe + 1;
            Destroy(model);
        }
    }
    public void TakeDamage (GameObject enemy, float damage) 
    {
        Health = Health -  damage;
    }
    public void Healing(GameObject playerObj, float heal)
    {
        Health = Health + heal;
    }
    
    
}
