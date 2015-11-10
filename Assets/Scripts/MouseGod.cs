using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseGod : MonoBehaviour {
	public GameObject mousePrefab;
	public List<GameObject> listOfMice;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit rayHit=new RaycastHit();
		if(Input.GetMouseButtonDown(0)){
			if(Physics.Raycast(ray, out rayHit, 100f))
			{
				GameObject newTree=(GameObject)Instantiate(mousePrefab, rayHit.point+new Vector3(0,1,0), Quaternion.identity);
				listOfMice.Add(newTree);
			}
		}
	}
}
