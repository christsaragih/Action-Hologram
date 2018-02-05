// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

namespace HoloToolkit.Unity
{
    /// <summary>
    /// HandsManager determines if the hand is currently detected or not.
    /// </summary>
    public partial class HandsTrackingManager : Singleton<HandsTrackingManager>
    {
        /// <summary>
        /// HandDetected tracks the hand detected state.
        /// Returns true if the list of tracked hands is not empty.
        /// </summary>
        public bool HandDetected
        {
            get { return trackedHands.Count > 0; }
        }
     
        public GameObject TrackingObject;
     
        public Vector3 pos;
        public Transform left, right, up, bottom;
        private HashSet<uint> trackedHands = new HashSet<uint>();
        public GameObject FocusedGameObject;

        private Dictionary<uint, GameObject> trackingObject = new Dictionary<uint, GameObject>();
        void Awake()
        {
            InteractionManager.SourceDetected += InteractionManager_SourceDetected;
            InteractionManager.SourceLost += InteractionManager_SourceLost;
            InteractionManager.SourcePressed += InteractionManager_SourcePressed;
            InteractionManager.SourceUpdated += InteractionManager_SourceUpdated;
            InteractionManager.SourceReleased += InteractionManager_SourceReleased;
        }

        private void InteractionManager_SourceUpdated(InteractionSourceState state)
        {
            uint id = state.source.id;
           

            if (state.source.kind == InteractionSourceKind.Hand)
            {
                if (trackingObject.ContainsKey(state.source.id))
                {
                    if (state.properties.location.TryGetPosition(out pos))
                    {
                        trackingObject[state.source.id].transform.position = pos;
                    }
                }
            }

        }

        private void InteractionManager_SourceDetected(InteractionSourceState state)
        {
            // Check to see that the source is a hand.
            if (state.source.kind != InteractionSourceKind.Hand)
            {
                return;
            }
            trackedHands.Add(state.source.id);

            var obj = Instantiate(TrackingObject) as GameObject;
            
            if (state.properties.location.TryGetPosition(out pos))
            {
                obj.transform.position = pos;
            }

            trackingObject.Add(state.source.id, obj);
        }

        private void InteractionManager_SourceLost(InteractionSourceState state)
        {
            // Check to see that the source is a hand.
            if (state.source.kind != InteractionSourceKind.Hand)
            {
                return;
            }

            if (trackedHands.Contains(state.source.id))
            {
                trackedHands.Remove(state.source.id);
            }

            if (trackingObject.ContainsKey(state.source.id))
            {
                var obj = trackingObject[state.source.id];
                trackingObject.Remove(state.source.id);
                Destroy(obj);
            }
        }


        private void InteractionManager_SourcePressed(InteractionSourceState hand)
        {
            if (GazeGestureManager.Instance.FocusedObject != null)
            {
                FocusedGameObject = GazeGestureManager.Instance.FocusedObject;
                Debug.Log("PRESS "+FocusedGameObject.name);
                
            }
        }

        private void InteractionManager_SourceReleased(InteractionSourceState hand)
        {
            Debug.Log("Realese");
            ResetFocusedGameObject();
        }

        private void ResetFocusedGameObject()
        {
            FocusedGameObject = null;
        }

        void OnDestroy()
        {
            InteractionManager.SourceDetected -= InteractionManager_SourceDetected;
            InteractionManager.SourceLost -= InteractionManager_SourceLost;


            InteractionManager.SourceReleased -= InteractionManager_SourceReleased;
            InteractionManager.SourcePressed -= InteractionManager_SourcePressed;
        }
        void Update()
        {
            if (GazeGestureManager.Instance.FocusedObject != FocusedGameObject)
            {
                FocusedGameObject = null;
            }
        }
        
        class Posisi
        {
            private string yAkhir;
            private string xAkhir;
            private string xAwal;
            private string yAwal;

            public string XAkhir
            {
                get
                {
                    return xAkhir;
                }

                set
                {
                    xAkhir = value;
                }
            }

            public string XAwal
            {
                get
                {
                    return xAwal;
                }

                set
                {
                    xAwal = value;
                }
            }

            public string YAwal
            {
                get
                {
                    return yAwal;
                }

                set
                {
                    yAwal = value;
                }
            }

            public string YAkhir
            {
                get
                {
                    return yAkhir;
                }

                set
                {
                    yAkhir = value;
                }
            }
        }
        public string []GetDirectionRotate(bool isSumbuRotate,float x=0,float y=0,float z=0) {
            Posisi P;
                
            string[] rotateStatus = new string[4];
            float[] distanceFromHand = new float[4];
            if (isSumbuRotate) {
                pos = new Vector3(x, y, z);
            }
            distanceFromHand[0] = Vector3.Distance(left.transform.position, pos);
            distanceFromHand[1] = Vector3.Distance(right.transform.position, pos);
            //distanceFromHand[2] = Vector3.Distance(up.transform.position, pos);
            //distanceFromHand[3] = Vector3.Distance(bottom.transform.position, pos);
            float[] temp = distanceFromHand;
         //  Array.Sort(distanceFromHand);
            if (distanceFromHand[1] < distanceFromHand[0])
            {
                rotateStatus[0] = "kanan";
            }
            else {
                rotateStatus[0] = "kiri";
            }
          
            
            return rotateStatus;
        }
    }
}