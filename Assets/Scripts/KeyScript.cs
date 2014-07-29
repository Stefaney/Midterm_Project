using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
		//Sets the color of the keys to red so they stand out. 
		gameObject.renderer.material.color = Color.red;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//Also kills the key on trigger. This could also happen in the Controller script. But placing it here keeps my OnTriggerEnter()
	//function in Controller less cluttered.
	void OnTriggerEnter()
	{
		Destroy(gameObject);
	}
}
