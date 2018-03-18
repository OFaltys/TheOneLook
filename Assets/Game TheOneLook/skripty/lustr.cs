using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lustr : MonoBehaviour {

	public GameObject bodikus;

	// Use this for initialization
	void Start () {
		casovat (15);

	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator casovat(float cas)
	{
		yield return new WaitForSeconds (cas);
		bodikus.GetComponent<Manager_body> ().vitezstvi += 1;
		Destroy (this.gameObject);

	}
}
