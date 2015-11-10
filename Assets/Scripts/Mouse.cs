using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class Mouse : MonoBehaviour {
	public GameObject catGod;
	public AudioClip squeak;
	AudioSource audio;
	
	void Start() {
		audio = GetComponent<AudioSource>();
	}
	// Update is called once per frame
	void FixedUpdate () {
		foreach(GameObject cat in catGod.GetComponent<CatGod>().listOfCats)
		{
			Vector3 directionToCat=cat.transform.position-transform.position;
			float targetDir=Vector3.Angle(transform.forward, directionToCat);
			if(targetDir<180.0f)
			{
				Ray mouseRay=new Ray(transform.position, directionToCat);
				RaycastHit mouseRayHitInfo=new RaycastHit();
				if(Physics.Raycast(mouseRay, out mouseRayHitInfo, 100))
				{
					if(mouseRayHitInfo.collider.tag=="Cat")
					{
						GetComponent<Rigidbody>().AddForce(-directionToCat.normalized*1000f);
						audio.clip=squeak;
						audio.PlayDelayed(.1F);
					}
				}
			}
		}
	}
}
