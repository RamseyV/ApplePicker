﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

	}

    public void PlayGame(){
        SceneManager.LoadScene("_scene_0");
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("_Start_scene");
    }


}
