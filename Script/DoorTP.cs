using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorTP : MonoBehaviour
{
    [SerializeField] Vector3 tpCords = new Vector3();
    [SerializeField] Quaternion tpRotate;
    [SerializeField] Transform tpTransform;
    [SerializeField] AudioSource tpAudioSource;
    [SerializeField] AudioClip tpAudioClip;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void TpPlayer(Collider player)
    {
        StartCoroutine(RepositionToFinalPosition(player));
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8 && other.gameObject.GetComponent<Hp>())
        {
            
            //StartCoroutine(RepositionToFinalPosition(other));
            TpPlayer(other);
        }
    }
    IEnumerator RepositionToFinalPosition(Collider other)
    {
        yield return new WaitForSecondsRealtime(0.2f);
        other.gameObject.transform.position = tpTransform.position;
        other.gameObject.transform.rotation = tpTransform.rotation;
        yield return new WaitForSeconds(0.0f);
        other.gameObject.transform.position = tpTransform.position;
        other.gameObject.transform.rotation = tpTransform.rotation;
        PlaySound();

    }
    void PlaySound()
    {
        tpAudioSource.clip = tpAudioClip;
        tpAudioSource.Play();
    }
}
