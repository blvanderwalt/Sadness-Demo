﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;
using Valve.VR;
using System.IO;

public class InteractionLevel : MonoBehaviour
{
    public Text levelText;
    public Text levelDescription;
    public Slider slider;
    public GameObject levelLoader;
    public GameObject canvas;

    private int level;
    private string[] level0 = { "Level 0", "-> Control Environment\n-> Basic Interactions\n-> No Selection of Dog\n-> AI Implemented\n-> Basic Tutorial" };
    private string[] level1 = { "Level 1", "-> Intermediate Environment: Additions to Previous\n-> Choice of Dog\n-> Multiple Object Interactivity\n-> Dog Fetches Objects\n-> Navigation in Park\n-> Handed Ball at Vet\n-> Tutorial Adds Teleportation" };
    private string[] level2 = { "Level 2", "-> Advanced Environment: Additions to Previous\n-> Hand Gestures\n-> Butterfly Interaction/Flower Grove \n-> Stroking the Dog\n-> After the Accident Interaction\n-> Special Object at Vet\n-> Tutorial Adds Stroking and Gestures" };

    // Start is called before the first frame update
    void Start()
    {
        levelText.text = level0[0];
        levelDescription.text = level0[1];
        level = 0;
    }

    //Set the Level based on the slider
    public void value() {
        int val = (int)slider.value;
        level = val;
        if ( val == 0)
        {
            levelText.text = level0[0];
            levelDescription.text = level0[1];
        }
        else if (val == 1)
        {
            levelText.text = level1[0];
            levelDescription.text = level1[1];
        }
        else if (val == 2)
        {
            levelText.text = level2[0];
            levelDescription.text = level2[1];
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Tutorial", LoadSceneMode.Single);
        asyncLoad.allowSceneActivation = false;
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {

            if (asyncLoad.progress >= 0.9f)
            {
                //Destroy(playerObj);
                
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }

    }
    //Set all the values for the environment
    public void confirm()
    {
        canvas.SetActive(false);
        Destroy(canvas);
        PlayerPrefs.SetInt("Level", level);
        levelLoader.SetActive(true);
        string path = "Times.txt";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("====== Level Chosen: " + level + " ======");
        writer.Close();
        //StartCoroutine(LoadYourAsyncScene());
    }
}
