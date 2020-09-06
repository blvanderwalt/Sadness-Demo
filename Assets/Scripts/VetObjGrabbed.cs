﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using System.IO;

public class VetObjGrabbed : MonoBehaviour
{
    public VetController vetController;


        

    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes startingGrabType = hand.GetGrabStarting();

        if (startingGrabType != GrabTypes.None)
        {
            string path = "Times.txt";
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine("Handed Object: " + Time.time);
            writer.Close();
            vetController.TriggerEnd();
            
        }
    }


 }