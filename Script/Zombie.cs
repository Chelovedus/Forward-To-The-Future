using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField] GameObject player;
    [SerializeField] Animator animator;
    [SerializeField] GameObject ZombieObj;
    [SerializeField] Vector3 ForwardZombie;
    [SerializeField] LayerMask layerPlayer;
    [SerializeField] bool hitDelay;
    [SerializeField] float rangeAttackByZombie;
    [SerializeField] float timeDelayByZombie = Stats.timeDelayByZombie;
    [SerializeField] float DamageByZombie = Stats.DamageByZombie;
    public RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        ZombieObj = this.gameObject;
        rangeAttackByZombie = Stats.rangeAttackByZombie;
        bool hitDelay = false;
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(player.transform.position);
    }

    void animatorSet() {
        
            Debug.Log("HitDelay");
            animator.SetBool("isAttacking", true);
            animator.SetTrigger("attack");
            animator.SetBool("isAttacking", false);
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8 && hitDelay == false && other.GetComponent<Hp>() != null)
        {
            hitDelay = true;
            animator.SetTrigger("attack");
            StartCoroutine(Check(other));

        }
    }

    IEnumerator Check(Collider other)
    {
        yield return new WaitForSeconds(0.5f);
        if (other.GetComponent<Hp>() != null && other.gameObject.layer == 8)
        {
            CheckRadiusAndTakeDamage(other);
        }


    }
    void CheckRadiusAndTakeDamage(Collider other)
    {
        if (other.GetComponent<Hp>() != null && other.gameObject.layer == 8)
        {
            other.gameObject.GetComponent<Hp>().TakeDamage(other.gameObject, DamageByZombie);
            hitDelay = false;

        }
    }
}