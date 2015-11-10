using UnityEngine;
using System.Collections;

public class WallGod : MonoBehaviour {
	public Transform wallPrefab;
	// Use this for initialization
	void Start () {
		int x=0;
		int y=0;
		int z=0;
		for(int i=0;i<5;i++)
		{
			for(int j=0;j<5;j++)
			{
				int angle=0;
				int random =Random.Range(0,4);
				if(random==1)
					angle=90;
				if(random==2)
					angle=180;
				if(random==3)
					angle=270;
				//if(Random.Range(0, 2)==1)
					Instantiate(wallPrefab, new Vector3(x,y,z), Quaternion.Euler(0,angle,0));
				x+=21;
			}
			x=0;
			z+=21;
		}
	}
}
