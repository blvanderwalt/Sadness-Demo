﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ActionsTest : MonoBehaviour
{

    public SteamVR_Input_Sources handType; // 1
    public SteamVR_Action_Boolean teleportAction; // 2
    public SteamVR_Action_Boolean grabAction; // 3

    // Update is called once per frame
    void Update()
    {
        if (GetTeleportDown())
        {
            print("Teleport " + handType);
        }

        if (GetGrab())
        {
            print("Grab " + handType);
        }
    }

    //Poll if the Teleport action was just activated and return true if this is the case.
    public bool GetTeleportDown()
    {
        return teleportAction.GetStateDown(handType);
    }

    //Poll if the Grab action is currently activated.
    public bool GetGrab()
    {
        return grabAction.GetState(handType);
    }
}
