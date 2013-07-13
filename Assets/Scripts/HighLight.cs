using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HighLight : MonoBehaviour {
	
	public List<Block> deathList = new List<Block>();
	
	public static Block currentBlock;
	public static Block previousBlock;
	public static int clickCount = 0;
	public Transform prevHilite;

	Bounce bounceI;
	
	// Use this for initialization
	void Start () {

		bounceI = GetComponent<Bounce> ();
     	
	}
	
	// Update is called once per frame
	void Update () {

	if (Input.GetKeyDown (KeyCode.Space)) {

			transform.position = new Vector3 (10f, .49f, 10f);

	}

	if (Input.GetKeyDown (KeyCode.N)) {

			transform.position = new Vector3 (10f, .49f, 10f);

	}

	RaycastHit rayHit = new RaycastHit();	
	Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
	if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out rayHit, 10000f)) {

			bounceI.ShakeThis( rayHit.collider.GetComponent<Transform>());

						
						
				//first click? if so, make this the currentBlock, highlight it, and increment clickCounter
			
			    if (clickCount == 0) {
					currentBlock = rayHit.collider.GetComponent<Block>();
					currentBlock.clicked = true;
					transform.position = new Vector3 (currentBlock.transform.position.x, .49f, currentBlock.transform.position.z);
					bounceI.ShakeThis( transform );
					clickCount++;	
					}
				
				//if not the first click AND never been clicked before...
			
			    else if (rayHit.collider.GetComponent<Block>().clicked != true) {

					if (rayHit.collider.GetComponent<Block>().symbol == currentBlock.symbol) {
							previousBlock = currentBlock;
							currentBlock = rayHit.collider.GetComponent<Block>();
							currentBlock.clicked = true;
							transform.position = new Vector3 (currentBlock.transform.position.x, .49f, currentBlock.transform.position.z);
							Instantiate( prevHilite, new Vector3(previousBlock.transform.position.x, .49f, previousBlock.transform.position.z), Quaternion.identity);
							bounceI.ShakeThis( transform );
							clickCount++;	
					}

					else if (rayHit.collider.GetComponent<Block>().word == currentBlock.word) {
						previousBlock = currentBlock;
						currentBlock = rayHit.collider.GetComponent<Block>();
						currentBlock.clicked = true;
						transform.position = new Vector3 (currentBlock.transform.position.x, .49f, currentBlock.transform.position.z);
						Instantiate( prevHilite, new Vector3(previousBlock.transform.position.x, .49f, previousBlock.transform.position.z), Quaternion.identity);
						bounceI.ShakeThis( transform );
						clickCount++;	
					}	

					else if (rayHit.collider.GetComponent<Block>().number == currentBlock.number) {
						previousBlock = currentBlock;
						currentBlock = rayHit.collider.GetComponent<Block>();
						currentBlock.clicked = true;
						transform.position = new Vector3 (currentBlock.transform.position.x, .49f, currentBlock.transform.position.z);
						Instantiate( prevHilite, new Vector3(previousBlock.transform.position.x, .49f, previousBlock.transform.position.z), Quaternion.identity);
						bounceI.ShakeThis( transform );
						clickCount++;	
					}	

// 			scoreKeeper.ScoreMove();
					
					}				
					
			}
		

		}
			
}