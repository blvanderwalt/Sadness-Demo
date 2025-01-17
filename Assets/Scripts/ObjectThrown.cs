﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ObjectThrown : MonoBehaviour
{
    public DogParkDalmation doggo;
    public bool thrown;
    public int objType; // [ 0 = tennis ball ]
                        // [ 1 = toy ]
                        // [ 2 = found toy ]
                        // [ -1 = bouncy ball ]
                        // [ -2 = other objects ] 

    private bool detached;
    private float timer;
    private Rigidbody rigidbody;

     void Start()
    {
        detached = false;
        thrown = false;
        timer = 0;
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnDetachedFromHand(Hand hand)
    {
        detached = true;
        rigidbody.useGravity = true;
        rigidbody.isKinematic = false;
    }

    void Update()
    {
        //When object detached, wait before checking if it was thrown or just dropped
        if (detached)
        {
            timer += Time.deltaTime;
            if (timer > 0.3f)
            {
                if (rigidbody.velocity.magnitude > 3)
                {
                    //Let dog know object has been thrown
                    timer = 0;
                    thrown = true;
                    detached = false;
                    SendMessage();
                }
                else
                {
                    detached = false;
                }
            }
        }
        //ensure object doesnt fall through ground
        if (transform.position.y < 40)
        {
            transform.position = new Vector3(transform.position.x, 51, transform.position.z);
        }
    }

    //Tells dog the ball was thrown
    public void SendMessage()
    {
        doggo.SendMessage("onObjectThrown", this.gameObject);
        thrown = true;
    }
}
