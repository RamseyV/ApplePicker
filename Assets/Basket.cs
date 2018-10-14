using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour {

    public Text scoreGT;

	// Use this for initialization
	void Start () {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
        //get position of mouse
        Vector3 mousepos2D = Input.mousePosition;

        //Camera's z position sets how far to push mouse into 3d
        mousepos2D.z = -Camera.main.transform.position.z;

        //Convert point from 2d into 3d game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousepos2D);
        
        Vector3 pos = this.transform.position;

        pos.x = mousePos3D.x;
        this.transform.position = pos;

	}

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collideWith = collision.gameObject;
        int score = int.Parse(scoreGT.text);
        if (collideWith.tag == "GreenApple") 
        {
            Destroy(collideWith);

            score += 100;
        }
        else if(collideWith.tag == "YellowApple")
        {
            Destroy(collideWith);

            score += 200;
        }
        else if (collideWith.tag == "Apple")
        {
            Destroy(collideWith);

            score += 300;
        }


        scoreGT.text = score.ToString();


        if(score > HighScore.score){
            HighScore.score = score;
        }
    }
}

