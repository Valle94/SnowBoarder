using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem snowTrail;
    [SerializeField] ParticleSystem longJump;
    [SerializeField] AudioClip longJumpSFX;
    [SerializeField] float airtime = 2f;
    float hangtime = 0;
    bool airborn = false;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            airborn = false;
            if (hangtime >= airtime)
            {
                longJump.Play();
                GetComponent<AudioSource>().PlayOneShot(longJumpSFX);
            }
            hangtime = 0;
            snowTrail.Play();
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        airborn = true;
        snowTrail.Stop();
    }

    void Update()
    {
        if (airborn)
        {
            hangtime += Time.deltaTime;
        }
    }
}