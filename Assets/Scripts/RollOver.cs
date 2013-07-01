using UnityEngine;
using System.Collections;

public class RollOver : MonoBehaviour {

	Transform rolloverBlock;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
		
	RaycastHit rayHit = new RaycastHit();	
	Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
//	if (HighLight.cursorActive == true && Physics.Raycast(ray, out rayHit, 6f)) {
	if (Physics.Raycast(ray, out rayHit, 6f)) {			
			
			rolloverBlock = rayHit.collider.transform;
			transform.position = new Vector3 (rolloverBlock.position.x, .49f, rolloverBlock.position.z);	
			}
	else transform.position = new Vector3 (-10f, .49f, -10f);
}
}
