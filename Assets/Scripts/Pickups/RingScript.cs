using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingScript : MonoBehaviour {

    public Transform poof;
    public AudioClip ringGrabSound;
    
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Collect();
            other.GetComponent<AudioSource>().PlayOneShot(ringGrabSound);
        }
    }

    public void Collect ()
    {
        anim.SetTrigger("Collect");
        ScoreManagerScript.CollectScore(1);
    }

    public void Delete()
    {
        poof.SetParent(null);
        poof.gameObject.SetActive(true);
        Destroy(poof.gameObject, 1);
        Destroy(gameObject);
    }
}
