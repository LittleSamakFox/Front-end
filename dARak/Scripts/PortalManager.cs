﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PortalManager : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Room;
    private MeshRenderer[] RoomMaterials;

    // Start is called before the first frame update
    void Start()
    {
        RoomMaterials = Room.GetComponentsInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void OnTriggerStay(Collider collider)
    {
        Vector3 camPositionInPortalSpace = transform.InverseTransformPoint(MainCamera.transform.position);

        if (camPositionInPortalSpace.y < 0.5f)
        {
            for (int i = 0; i < RoomMaterials.Length; ++i)
            {
                RoomMaterials[i].material.SetInt("_StencilComp", (int)CompareFunction.Always);
            }
        }
        else
        {
            for (int i = 0; i < RoomMaterials.Length; ++i)
            {
                RoomMaterials[i].material.SetInt("_StencilComp", (int)CompareFunction.Equal);
            }
        }
    }
}
