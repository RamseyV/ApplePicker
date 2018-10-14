using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {

    //apple prefab
    public GameObject applePrefab;
    public GameObject yellowApplePrefab;
    public GameObject greenApplePrefab;

    //speed of apple tree
    public float speed = 10f;


    //chance of apples falling
    public float greenAppleChance = 1.0f;
    public float yellowAppleChance = 0.0f;
    public float redAppleChance = 0.0f;

    public static int difficultyIcrease = 0;


    //Distance for tree to turn around
    public float leftAndRightEdge = 20f;

    //chance of changing direction 
    public float changeDirectionChance = .1f;

    //time between dropping apples
    public float seconds = 1f;

	void Start () {
        Invoke("DropApple", 2f);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if(pos.x < -leftAndRightEdge){
            speed = Mathf.Abs(speed);

        }
        else if(pos.x > leftAndRightEdge){
            speed = -Mathf.Abs(speed);
        }
     
	}

    void FixedUpdate()
    {
        if (Random.value < changeDirectionChance)
        {
            speed *= -1;
        }

        if(difficultyIcrease%75 ==0 && yellowAppleChance < 1){
            yellowAppleChance += .01f;
        }
        if (difficultyIcrease % 300 == 0 && redAppleChance < 1)
        {
            redAppleChance += .01f;
        }

        difficultyIcrease += 1;

    }

    void DropApple(){
        if (Random.value < redAppleChance)
        {
            GameObject apple = Instantiate<GameObject>(applePrefab);
            apple.transform.position = transform.position;
        }
        else if(Random.value < yellowAppleChance){
            GameObject apple = Instantiate<GameObject>(yellowApplePrefab);
            apple.transform.position = transform.position;
        }
        else
        {
            GameObject apple = Instantiate<GameObject>(greenApplePrefab);
            apple.transform.position = transform.position;
        }
        Invoke("DropApple", seconds);
    }
}
