using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {
	
	double timer;
	bool onoff;
	float spawnTime;
	public Block me;
	
	// Use this for initialization
	void Start () {
		
		spawnTime = Time.time;
		me = HighLight.previousBlock;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Time.time > timer) {
		
			timer = Time.time + .05;
			onoff = !onoff;
			renderer.enabled = onoff;
			
		}	
		
		
		if ((Time.time - spawnTime) > 1f) {
			Destroy ( this.gameObject );
			me.transform.position = new Vector3(10f,0f,10f);

		}
		
	}	
}
