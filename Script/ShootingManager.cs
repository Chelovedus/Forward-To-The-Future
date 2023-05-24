using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] public LayerMask layerMaskPlayer;
    [SerializeField] Transform parrentWeapons;
    [SerializeField] Animator animator1;
    [SerializeField] Animator animator2;
    [SerializeField] Animator animator3;

    [Header("Player")]
    [SerializeField] GameObject lowHpUI;
    [SerializeField] SC_FPSController FPS_Controller;
    [SerializeField] bool hitDelayTimer;
    [SerializeField] bool isRunning;
    [SerializeField] bool isMove;
    [SerializeField] bool isJumping;
    [SerializeField] bool isEmptyMagazine;
    [SerializeField] bool unlockPistol;
    [SerializeField] public bool unlockKnife;
    [SerializeField] public bool unlockAutomaticRifle;

    [Header("Now const")]
    [SerializeField] public int slotUseNow;
    [SerializeField] int previousSlot;
    [SerializeField] float meleeRange;

    [SerializeField] bool canShooting;
    [SerializeField] bool canScope;
    [SerializeField] bool canSwap;
    [SerializeField] bool canReload;
    [SerializeField] float speedShooting;
    [SerializeField] public int curentAmmo;
    [SerializeField] int maxAmmo;
    [SerializeField] public int reserveAmmo;
    [SerializeField] float damage;
    [SerializeField] float timeReload;

    

    [Header("Weapons")]
    [SerializeField] List<GameObject> equipedWeapons;
    [SerializeField] List<GameObject> allWeapons;

    [Header("AutamaticWeapon")]
    [SerializeField] bool canShooting_1;
    [SerializeField] bool canScope_1;
    [SerializeField] bool canSwap_1;
    [SerializeField] bool canReload_1;
    [SerializeField] float speedShooting_1;
    [SerializeField] int curentAmmo_1;
    [SerializeField] int maxAmmo_1;
    [SerializeField] int reserveAmmo_1;
    [SerializeField] float damage_1;
    [SerializeField] float timeReload_1;

    [Header("Pistol")]
    [SerializeField] bool canShooting_2;
    [SerializeField] bool canScope_2;
    [SerializeField] bool canSwap_2;
    [SerializeField] bool canReload_2;
    [SerializeField] float speedShooting_2;
    [SerializeField] int curentAmmo_2;
    [SerializeField] int maxAmmo_2;
    [SerializeField] int reserveAmmo_2;
    [SerializeField] float damage_2;
    [SerializeField] float timeReload_2;

    [Header("MeleeWeapon")]
    [SerializeField] bool canShooting_3;
    [SerializeField] bool canScope_3;
    [SerializeField] bool canSwap_3;
    [SerializeField] bool canReload_3;
    [SerializeField] float speedShooting_3;
    [SerializeField] int curentAmmo_3;
    [SerializeField] int maxAmmo_3;
    [SerializeField] int reserveAmmo_3;
    [SerializeField] float damage_3;
    [SerializeField] float timeReload_3;

    void Start()
    {
        layerMaskPlayer = ~layerMaskPlayer;
        meleeRange = 2.8f;
        slotUseNow = 2;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        equipedWeapons[1] = allWeapons[1];
        _camera = Camera.main;
        LoadVeaponStatsFromPistol();
        canShooting = true;
        canSwap = true;
        FPS_Controller = this.GetComponent<SC_FPSController>();
        unlockPistol = true;
        isEmptyMagazine = false;
        hitDelayTimer = false;

    }
 
    void Update()
    {
        BadScript();
        SwapWeapon();
        Shooting();
        Reload();
        GetFPSControllerValues();
        UpdateWeaponEquip();
        UpdateSlotUseNowInStats();
        UpdateUILowHP();
    }

    void UpdateSlotUseNowInStats()
    {
        Stats.slotUseNow = slotUseNow;
    }

    // 1 - ak | 3 - knife
    void UpdateWeaponEquip()
    {
        if(PrefabItemUse.AKunlock == true)
        {
            unlockAutomaticRifle = true;
            equipedWeapons[0] = allWeapons[0];
        }
        if(PrefabItemUse.Knifeunlock == true)
        {
            unlockKnife = true;
            equipedWeapons[2] = allWeapons[2];
        }
    }


    void LoadVeaponStatsFromPistol()
    {
        canScope = canScope_2;
        speedShooting = speedShooting_2;
        curentAmmo = curentAmmo_2;
        reserveAmmo = reserveAmmo_2;
        damage = damage_2;
        timeReload = timeReload_2;
        maxAmmo = maxAmmo_2;
    }

    void SwapWeapon()
    {
        StartCoroutine(swapDelay());
    }

    void SwapWeaponTo(int index)
    {
        previousSlot = slotUseNow;
        CheckSlotAndSave();
        int previousSlotIndex = slotUseNow - 1;
        CheckWeaponOnUnlockAndHideAndShow(index, previousSlotIndex);
        CheckSlotAndLoad(index);
        canShooting = true;
    }

    // 0 rifle | 1 pistol | 2 knife
    void CheckWeaponOnUnlockAndHideAndShow(int index, int previous)
    {
        switch (index)
        {
            case 0:
                // 0 rifle
                if (unlockAutomaticRifle) {

                    equipedWeapons[previous].gameObject.SetActive(false);
                    equipedWeapons[index].gameObject.SetActive(true); }
                break;
            case 1:
                // 1 pistol
                if (unlockPistol) {
                    equipedWeapons[previous].gameObject.SetActive(false);
                    equipedWeapons[index].gameObject.SetActive(true); }
                break;
            case 2:
                // 2 knife
                if (unlockKnife) {
                    equipedWeapons[previous].gameObject.SetActive(false);
                    equipedWeapons[index].gameObject.SetActive(true); }
                break;
        }
    }

    void CheckSlotAndLoad(int  index)
    {
        if (index == 0)
        {
            canScope = canScope_1;
            speedShooting = speedShooting_1;
            curentAmmo = curentAmmo_1;
            reserveAmmo = reserveAmmo_1;
            damage = damage_1;
            timeReload = timeReload_1;
            maxAmmo = maxAmmo_1;
        }
        if (index == 1)
        {
            canScope = canScope_2;
            speedShooting = speedShooting_2;
            curentAmmo = curentAmmo_2;
            reserveAmmo = reserveAmmo_2;
            damage = damage_2;
            timeReload = timeReload_2;
            maxAmmo = maxAmmo_2;
        }
        if (index == 2)
        {
            canScope = canScope_3;
            canShooting = true;
            speedShooting = speedShooting_3;
            curentAmmo = curentAmmo_3;
            reserveAmmo = reserveAmmo_3;
            damage = damage_3;
            timeReload = timeReload_3;
            maxAmmo = maxAmmo_3;
        }

    }

    void CheckSlotAndSave()
    {
        if (previousSlot == 1)
        {
            canScope_1 = canScope;
            speedShooting_1 = speedShooting;
            curentAmmo_1 = curentAmmo;
            reserveAmmo_1 = reserveAmmo;
            damage_1 = damage;
            timeReload_1 = timeReload;
            maxAmmo_1 = maxAmmo;
        }
        if (previousSlot == 2)
        {
            canScope_2 = canScope;
            speedShooting_2 = speedShooting;
            curentAmmo_2 = curentAmmo;
            reserveAmmo_2 = reserveAmmo;
            damage_2 = damage;
            timeReload_2 = timeReload;
            maxAmmo_2 = maxAmmo;
        }
        if (previousSlot == 3)
        {
            canScope_3 = canScope;
            speedShooting_3 = speedShooting;
            curentAmmo_3 = curentAmmo;
            reserveAmmo_3 = reserveAmmo;
            damage_3 = damage;
            timeReload_3 = timeReload;
            maxAmmo_3 = maxAmmo;
        }
    }

    void Shooting()
    {
        if (canShooting && UI.interfaceIsOpened == false) {
            if (slotUseNow == 1) {

                if (Input.GetMouseButton(0)) {
                    StartCoroutine(shootDelay());
                }
            } else if (slotUseNow == 2)
            {
                if (Input.GetMouseButton(0)) {
                    StartCoroutine(shootDelay());
                }
            }
            else if (slotUseNow == 3)
            {
                if (Input.GetMouseButtonDown(0) && hitDelayTimer == false) {
                    StartCoroutine(HitDelay());
                }
            }
        }
    }
    IEnumerator swapDelay()
    {
        if (Input.GetKeyDown("1") || Input.GetKeyDown("2") || Input.GetKeyDown("3") && canSwap == true)
        {
            canSwap = false;

            if (Input.GetKeyDown("1") && equipedWeapons[0] != null && slotUseNow != 1)
            {
                SwapWeaponTo(0); // slot 1
                slotUseNow = 1;
            }
            if (Input.GetKeyDown("2") && equipedWeapons[1] != null && slotUseNow != 2)
            {
                SwapWeaponTo(1); // slot 2
                slotUseNow = 2;
            }
            if (Input.GetKeyDown("3") && equipedWeapons[2] != null && slotUseNow != 3)
            {
                SwapWeaponTo(2); // slot 3
                slotUseNow = 3;
            }
            yield return new WaitForSeconds(1);
            canSwap = true;
        }
    }
    IEnumerator shootDelay()
    {
            Vector3 screenÑenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

            Ray ray = _camera.ScreenPointToRay(screenÑenter);
            RaycastHit hit;  

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMaskPlayer) && canShooting == true)
            {
                curentAmmo--;
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<Hp>() != null)
                {
                    
                    hitObject.GetComponent<Hp>().TakeDamage(hitObject.gameObject, damage);
                Debug.Log("Hit!");
                }
                else
                {
                    
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
                    sphere.transform.position = hit.point;
                    Destroy(sphere, 6);
                    Debug.DrawLine(this.transform.position, hit.point, Color.green, 6);
                }
                canShooting = false; 
            yield return new WaitForSeconds(speedShooting);
            if (curentAmmo > 0)
            {
                canShooting = true;
            }
            else
            {
                canShooting = false;
            }
        }
            
    }
    IEnumerator HitDelay()
    {
        bool hitDelayTimer = true;
        yield return new WaitForSeconds(speedShooting);
        hitDelayTimer = false;
        Vector3 screenÑenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        Ray ray = _camera.ScreenPointToRay(screenÑenter);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, meleeRange) && canShooting == true)
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<Hp>() != null && hitObject.GetComponent<Hp>().isPlayer == false)
            {
                //yield return new WaitForSeconds(speedShooting);
                hitObject.GetComponent<Hp>().TakeDamage(hitObject.gameObject, damage);
                canShooting = false;
            }/*yield return new WaitForSeconds(speedShooting);*/
        canShooting = true;
        }
        
    }
    void Reload()
    {

        if (slotUseNow != 3 && Input.GetKeyDown(KeyCode.R) && curentAmmo < maxAmmo && reserveAmmo > 0 && canReload == true)
        {
            canShooting = false;
            EditAnimator(1, true);

            StartCoroutine(ReloadDelay());
        }

    }
    void BadScript()
    {
        if (curentAmmo <= 0)
        {
            isEmptyMagazine = true;

        }
        if (curentAmmo >= 1) { isEmptyMagazine = false; }

        if (isEmptyMagazine == false) { EditAnimator(3, true); }
        if (isEmptyMagazine == true) { EditAnimator(3, false); }

        if (canShooting == false && curentAmmo == 0 || canShooting == false && canReload == false
            || canReload == false && curentAmmo == 0 || maxAmmo > curentAmmo)
        {
            canReload = true;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            EditAnimator(6, true);
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            EditAnimator(6, false);
        }

        if (isMove)
        {
            EditAnimator(5, true);
        }
        if (!isMove)
        {
            EditAnimator(5, false);
        }
        if (isJumping)
        {
            EditAnimator(4, true);
        }
        if (!isJumping)
        {
            EditAnimator(4, false);
        }

        if (Input.GetMouseButton(0) && curentAmmo > 0 && slotUseNow != 3) // shoot | (Input.GetMouseButton(0) && canShooting)
        {
            EditAnimator(2, true);
            //StartCoroutine(forShoot());
        } else EditAnimator(2, false);

        if (Input.GetMouseButtonDown(0) && hitDelayTimer == false && slotUseNow == 3)
        {
            animator3.SetBool("shoot", true);
        }
        else { animator3.SetBool("shoot", false); }





    }

    IEnumerator ReloadDelay() {

        yield return new WaitForSeconds(timeReload);
        EditAnimator(1, false);
        reserveAmmo = reserveAmmo - (maxAmmo - curentAmmo);
        curentAmmo = maxAmmo;
        canShooting = true;
    }

    

    // 1 - reload | 2 - shoot | 3 - ammo | 4 - jump | 5 - move | 6 - run
    void EditAnimator(int index, bool i)
    {
        switch (index)
        {
            case 1:
                //1 - reload.
                animator1.SetBool("reload", i);
                animator2.SetBool("reload", i);
                animator3.SetBool("reload", i);
                break;

            case 2:
                //2 - shoot 
                animator1.SetBool("shoot", i);
                animator2.SetBool("shoot", i);
                //animator3.SetBool("shoot", i);
                break;

            case 3:
                // ammo
                animator1.SetBool("ammo", i);
                animator2.SetBool("ammo", i);
                animator3.SetBool("ammo", i);

                break;

            case 4:
                // 4 - jump
                animator1.SetBool("jump", i);
                animator2.SetBool("jump", i);
                animator3.SetBool("jump", i);
                break;

            case 5:
                // 5 - move
                animator1.SetBool("move", i);
                animator2.SetBool("move", i);
                animator3.SetBool("move", i);
                break;

            case 6:
                // 6 - run
                animator1.SetBool("run", i);
                animator2.SetBool("run", i);
                animator3.SetBool("run", i);
                break;
        }
    }

    void GetFPSControllerValues()
    {
        isRunning = FPS_Controller.isRunning;
        isMove = FPS_Controller.isMove;
        isJumping = FPS_Controller.isJumping;
    }

    public void SetSlotUseNow2()
    {
        slotUseNow = 2;
    }
    void UpdateUILowHP()
    {
        if(this.gameObject.GetComponent<Hp>().Health <= 35)
        {
            lowHpUI.SetActive(true);
        }
        if (this.gameObject.GetComponent<Hp>().Health > 35)
        {
            lowHpUI.SetActive(false);
        }
    }
}

