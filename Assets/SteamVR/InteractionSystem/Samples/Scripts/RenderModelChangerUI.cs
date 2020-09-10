﻿//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;
using Valve.VR.InteractionSystem.Sample;

    public class RenderModelChangerUI : UIElement
    {
        public GameObject leftHand;
        public GameObject rightHand;
        public Material materialMale;
        public Material materialFemale;
        public bool isMale;

        protected SkeletonUIOptions ui;

        protected override void Awake()
        {
            base.Awake();

            ui = this.GetComponentInParent<SkeletonUIOptions>();
            leftHand = GameObject.FindGameObjectWithTag("lMesh");
            rightHand = GameObject.FindGameObjectWithTag("rMesh");
            //isMale = GameObject.FindGameObjectWithTag("Player").GetComponent<>();
        }

        protected override void OnButtonClick()
        {
            base.OnButtonClick();

            if (ui != null)
            {
                //ui.SetRenderModel(this);
                //leftHand.GetComponent<SkinnedMeshRenderer>().material = material;
                //rightHand.GetComponent<SkinnedMeshRenderer>().material = material;
            }
        }
    }
