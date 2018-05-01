using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour {


	//May adjust how fast background runs here:
	public float speed = 0.5f;

	public float offset;



	void Start () {
	}

	//Works with quad gameObject
	//Insert Background into quad

	void Update () {

		//Move the background in a horizontal direction:
		Vector2 offset = new Vector2 (Time.time * speed, 0);

		//Keep readjusting offset to ensure image loops:
		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
