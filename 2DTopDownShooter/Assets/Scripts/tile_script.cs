using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile_script : MonoBehaviour {

    //[HideInInspector]
	public GameObject turret;
    public GameObject turretPrefab;

	void OnMouseDown()
	{
        if (turret == null)
        {
            turret = Instantiate(turretPrefab, transform);
        }
        Debug.Log("Works");
	}

	// Use this for initialization
	void Start () {
		turret = null;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
