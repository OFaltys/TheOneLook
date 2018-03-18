using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propast : MonoBehaviour {

	public GameObject propasti;
	public GameObject hrac;
	public GameObject mistnost;
	private float vyska ;

	// Use this for initialization
	void Start () {
		vyska = transform.parent.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		print (hrac.GetComponent<changeroom> ().momentalne_mistnost + "   " + transform.parent.position.y + ">" + vyska);

		if (propasti.activeInHierarchy == false) {
			if (hrac.GetComponent<changeroom> ().momentalne_mistnost == 1 && transform.parent.position.y >= vyska) {
				if (transform.parent.position.y > vyska) {
					propasti.SetActive (true);
				}
				transform.parent.Translate (0, -0.0004f, 0);
			}
			else
			transform.parent.Translate (0, 0.0003f, 0);
		}
	}


}
