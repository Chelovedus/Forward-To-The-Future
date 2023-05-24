using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject menuUI;
    public static bool uiIsActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetKey();
        UpdateIsActive();
    }
    void UpdateIsActive()
    {
        if (menuUI.active)
        {
            uiIsActive = true;
            Time.timeScale = 0;
        }
        if (!menuUI.active)
        {
            uiIsActive = false;
            Time.timeScale = 1;
        }
    }
    public void OpenMenu()
    {
        menuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public void CloseMenu()
    {
        menuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void GetKey()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !menuUI.active)
        {
            menuUI.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }else
        if (Input.GetKeyUp(KeyCode.Escape) && menuUI.active)
        {
            menuUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
