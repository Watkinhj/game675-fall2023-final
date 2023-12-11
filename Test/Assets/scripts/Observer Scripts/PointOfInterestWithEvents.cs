using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PointOfInterestWithEvents : MonoBehaviour
{
    public static event Action<PointOfInterestWithEvents> OnPointOfInterestEntered;

    [SerializeField]
    private string _poiName;

    public string PoiName {  get { return _poiName; } }

    private void OnTriggerEnter(Collider other)
    {
        if (OnPointOfInterestEntered != null)
            OnPointOfInterestEntered(this);
    }
}
