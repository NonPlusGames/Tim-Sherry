using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CatGod : MonoBehaviour {
	public GameObject catPrefab;
	public List<GameObject> listOfCats;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit rayHit=new RaycastHit();
		if(Input.GetMouseButtonDown(1)){
			if(Physics.Raycast(ray, out rayHit, 100f))
			{
				GameObject newTree=(GameObject)Instantiate(catPrefab, rayHit.point+new Vector3(0,1,0), Quaternion.identity);
				listOfCats.Add(newTree);
			}
		}
	}
}
