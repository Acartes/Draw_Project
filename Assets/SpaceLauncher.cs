using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceLauncher : MonoBehaviour {

	// Use this for initialization
	void Start () {
    GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
	}
	
	// Update is called once per frame
	void Update () {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
  }
}
