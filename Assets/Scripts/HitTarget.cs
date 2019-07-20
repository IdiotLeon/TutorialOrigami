using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTarget : MonoBehaviour
{
    // these public fields become settable properties in the Unity editor
    public GameObject underworld;
    public GameObject objectToHide;

    // Occurs when this object starts colliding with another object
    void OnCollisionEnter(Collision collision)
    {
        // to hide the stage and show the underworld
        objectToHide.SetActive(false);
        underworld.SetActive(true);

        // to disable "Spatial Mapping" to let the spheres enter the underworld
        SpatialMapping.Instance.MappingEnabled = false;
    }
}
