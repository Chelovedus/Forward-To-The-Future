using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject creditsObjTEXT;
    [SerializeField] float textUpSpeed;
    [SerializeField] GameObject newGameCanvas;
    public bool creditsIsActive;
    // Start is called before the first frame update
    void Start()
    {
        creditsIsActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCreditsBool();

    }
    private void FixedUpdate()
    {
    }

    public void ShowOrHideNewGameCanvas()
    {
        if (newGameCanvas.active)
        {
            newGameCanvas.SetActive(false);
        }
        else
        {
            newGameCanvas.SetActive(true);
        }
    }
    public void ChangeCreditsMode()
    {
        if (creditsObjTEXT.active)
        {
            creditsObjTEXT.SetActive(false);
        }
    }
    void UpdateCreditsBool()
    {
        if (creditsIsActive)
        {
            AnimatedTextCredits();
        }
    }
    public void ShowCredits() // call this 
    {
        
        creditsObjTEXT.SetActive(true);
        AnimatedTextCredits();
        creditsIsActive = true;

    }
    void AnimatedTextCredits()
    {
        creditsObjTEXT.transform.Translate(Vector3.up * Time.deltaTime * textUpSpeed);
    }
    public void SelectNewGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void ExitAplication()
    {
        Application.Quit();
    }
}
