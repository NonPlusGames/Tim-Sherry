using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class Cat : MonoBehaviour {
	public GameObject mouseGod;
	public AudioClip hiss;
	public AudioClip crunch;
	AudioSource audio;
	
	void Start() {
		audio = GetComponent<AudioSource>();
	}
	// Update is called once per frame
	void FixedUpdate () {

		foreach(GameObject mouse in mouseGod.GetComponent<MouseGod>().listOfMice)
		{
			Vector3 directionToMouse=mouse.transform.position-transform.position;
			float targetDir=Vector3.Angle(transform.forward, directionToMouse);
			if(targetDir<90.0f)
			{
				Ray catRay=new Ray(transform.position, directionToMouse);
				RaycastHit catRayHitInfo=new RaycastHit();
				if(Physics.Raycast(catRay, out catRayHitInfo, 100))
				{
					if(catRayHitInfo.collider.tag=="Mouse")
					{
						if(catRayHitInfo.distance<=5)
						{
							audio.clip=crunch;
							audio.PlayDelayed(.1F);
							mouseGod.GetComponent<MouseGod>().listOfMice.Remove(mouse.gameObject);
							Destroy(mouse.gameObject);
						}
						else
						{
							audio.clip=hiss;
							audio.PlayDelayed(.1F);
							GetComponent<Rigidbody>().AddForce(directionToMouse.normalized*1000f);
						}
					}
				}
			}
		}
	}
}
