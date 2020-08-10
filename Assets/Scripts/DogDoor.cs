﻿using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using System.Collections;
using System.IO;

//An extension of OVRGrabbable to handle how puppies are selected in the dog store scene
public class DogDoor : OVRGrabbable
{
    private MeshRenderer[] m_meshRenderers = null;
    private bool m_highlight;
    public Transform master;
    public Transform pup;
    public int DogChosen;

    override public void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        //Open the door using a hinge Joint
        Rigidbody body = GetComponentInParent<Rigidbody>();
        body.isKinematic = false;
        body.WakeUp();
        HingeJoint doorJoint = GetComponentInParent<HingeJoint>();
        doorJoint.useSpring = true;

        StartCoroutine(SetMaster());
        //Start recording the Times of user actions in a text file (This can be improved on)
        string path = "Times.txt";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Puppy Chosen: " + Time.time);
        writer.Close();

    }
    //Method used to make the puppy move towards the user after a short delay
    IEnumerator SetMaster()
    {
        yield return new WaitForSeconds(2.5f);
        pup.gameObject.AddComponent<ThirdPersonCharacter>();
        pup.gameObject.AddComponent<AICharacterControl>();
        pup.GetComponent<AICharacterControl>().SetTarget(master);
        pup.GetComponent<Animator>().SetInteger("Next", 5);
        pup.gameObject.GetComponent<Puppy_Controller>().dogChosen = DogChosen;
    }
    //make sure the rigidbody is not disabled when the user stop grabbing the door
    override public void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
        Rigidbody body = GetComponentInParent<Rigidbody>();
        body.isKinematic = false;
        body.WakeUp();
    }


    //Standard awake for grabbable objet
    void Awake()
    {
        if (m_grabPoints.Length == 0)
        {
            Collider collider = this.GetComponent<Collider>();
            if (collider == null)
            {
                throw new System.ArgumentException("Grabbables cannot have zero grab points and no collider -- please add a grab point or collider.");
            }
            m_grabPoints = new Collider[1] { collider };
            m_meshRenderers = new MeshRenderer[1];
            m_meshRenderers[0] = this.GetComponent<MeshRenderer>();
        }
        else
        {
            m_meshRenderers = this.GetComponentsInChildren<MeshRenderer>();
        }
    }

   
}