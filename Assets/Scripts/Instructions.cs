using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<TextMesh>().text = "Find the 5 keys to open \nthe cabin and find the satellite phone \nto call for rescue.";
	}
}
