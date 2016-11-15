using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("a")){
			print("rock");

		}
		else if(Input.GetKey("s")){
			print ("paper");
		}
		else if(Input.GetKey("d")){
			print ("scissors");
		}
	}
}
