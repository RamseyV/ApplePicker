using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {

    // bottom of screen
    public static float bottomY = -20f;
    public static float yellowSpeed = -30f;
    public static float appleSpeed = -50f;


    // Use this for initialization
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
        Rigidbody rb = GetComponent<Rigidbody>();

        if(this.tag == "Apple"){
            rb.velocity = new Vector3(0, appleSpeed, 0);
            Debug.Log(rb.velocity.ToString());
        }
        else if(this.tag == "YellowApple"){
            rb.velocity = new Vector3(0, yellowSpeed, 0);

        }
        if (transform.position.y < bottomY)
        {
            //destroy object if it gets below screen bottom
            Destroy(this.gameObject);


            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.AppleDestroyed();
        }

	}
}
