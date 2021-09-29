using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public AudioSource audioPlayer;
    public AudioClip laserShoot;
    public AudioClip explosion;


    // Start is called before the first frame update
    void Start()
    {
        audioPlayer.PlayOneShot(laserShoot);
    }


    private void OnCollisionEnter(Collision collision)
    {
        // collision happened!!
        audioPlayer.PlayOneShot(explosion);

        Destroy(gameObject, 1.5f);
        Destroy(collision.gameObject);

    }

}
