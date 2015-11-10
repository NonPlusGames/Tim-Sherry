using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	// Use this for initialization
	void FixedUpdate () {
		Vector3 position=transform.position;
		if(GetComponent<Rigidbody>().velocity.magnitude < 10)
		{
			transform.Rotate(0,180,0);
		}
		GetComponent<Rigidbody>().velocity=transform.forward*10f+Physics.gravity;
		Ray moveRay=new Ray(transform.position, transform.forward);
		if(Physics.SphereCast(moveRay, 1f, 1f))
		{
			if(Random.Range(0,2)==0)
			{
				transform.Rotate(0,90,0);
			}
			else
			{
				transform.Rotate(0,-90,0);
			}
		}
	}
}
