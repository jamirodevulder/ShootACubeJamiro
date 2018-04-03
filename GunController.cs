using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class GunController : MonoBehaviour {

    public float rotationspeed = 1f;
    public GameObject bulletPrefab;

    public AudioClip impact;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update () {


        float xInput = -Input.GetAxisRaw("Horizontal");

        transform.Rotate(new Vector3(0, 0, xInput) * rotationspeed * Time.deltaTime);


        if (Input.GetKeyDown("space"))
        {
            audioSource.PlayOneShot(impact, 0.7F);
            Vector3 CreateBullet = new Vector3(transform.position.x, transform.position.y, 0.5f);
            Instantiate(bulletPrefab, CreateBullet, transform.rotation);
            
      


        }
         


    }
    
}
