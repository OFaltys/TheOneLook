using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nomove : MonoBehaviour {

	private GameObject kamera, novakm;
	public GameObject pripevneni_na_pevno;

	// Use this for initialization
	void Start () {
		//kamera = GameObject.Find ("SDKSetups");
		//novakm = kamera;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if( kamera != novakm ){
		for (int i = 0; i < 5; i++) {
				if (kamera.transform.GetChild (i).gameObject.activeInHierarchy == true) {
					novakm = kamera.transform.GetChild (i).GetChild (0).gameObject;
					break;
					print ("what");
				}print ("what");
			}
		}*/

		this.transform.position = pripevneni_na_pevno.transform.position;
	}
}
