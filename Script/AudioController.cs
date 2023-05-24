using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip lowGasoline;
    [SerializeField] AudioClip reEntryALL;
    [SerializeField] AudioClip openDoor;
    [SerializeField] AudioClip end;
    [SerializeField] AudioClip creditsMusic;

    Buttons buttonsScript;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        buttonsScript = this.gameObject.GetComponent<Buttons>();
    }

    // Update is called once per frame
    void Update()
    {
        SoundsPlay();
    }

    void SoundsPlay() // add
    {
        playTransfer();
        PlayLowGalosine();
        PlayOpenDoor();
        PlayEngineKeypadSpeedThor();

    }
    public void playTransfer() // 1
    {
        if(Talk.curentTalk == 2)
        {
            audioSource.clip = reEntryALL;
            audioSource.Play();
        }
    }
    public void PlayOpenDoor()
    {
        if(Talk.curentTalk == 11)
        {
            audioSource.clip = openDoor;
            audioSource.Play();
        }
    }
    public void PlayLowGalosine()
    {
         if(Talk.curentTalk == 8) {
            audioSource.clip = lowGasoline;
            audioSource.Play();
            }
    }
    void PlayEngineKeypadSpeedThor()
    {
        if (Talk.curentTalk == 87)
        {
            audioSource.clip = end;
            StartCoroutine(playAudio());

            
        }
    }
    void ShowCredits()
    {
        buttonsScript.ShowCredits();

        audioSource.clip = creditsMusic;
        audioSource.Play();
    }

    IEnumerator playAudio()
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        ShowCredits();
    }


}
