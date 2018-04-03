using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bulletmovement : MonoBehaviour {
	// Use this for initialization
	void Start () {
        InvokeRepeating("DestroyAtTime", 2.0f, 10.0f);
    }

    // Update is called once per frame
    void Update() {
        transform.position += transform.up * Time.deltaTime * -5;
    
        
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Cube(Clone)")
        {
            
            Destroy(this.gameObject);
            

        }
    }
    void DestroyAtTime()
    {
        Destroy(this.gameObject);
    }
}

    

