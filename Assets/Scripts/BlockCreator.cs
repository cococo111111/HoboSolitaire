using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockCreator : MonoBehaviour {
	
	//blockList is the list of prefabs
	public List<Block> blockList = new List<Block>();
	
	//blockBag is the list of blocks once they are instantiated
	public static List<Block> blockBag = new List<Block>();
	
	//boardList is the list of blocks to add to the board
	public static List<Block> boardList = new List<Block>();

	//rList is the list that's used to make the boardlist, random but reproducible
	public static List<int> rList = new List<int>();
	public static int rnd;

	public static int currentSeed;
	
	public static int boardSize = 16;
	public static int blockCount = 100;
	public static Block boardCandidate;
	public static Block newPick;
	public static int pointer = 0;
	public static Vector3 blockLoc = new Vector3(-1.5f,0f,1.5f);


	// Use this for initialization
	void Start () {
		
		int symbolID = 0;
		int symbolCounter = 0;
		int wordID = 0;
		int wordBump = 1;
		bool wordReset = false;
		int numberID = 0;

		//make Block 100
		
		for (int i=0; i < 1; i++) {
			Block newBlock = Instantiate( blockList[i] ) as Block;		
			newBlock.symbol = 9;
			newBlock.word = 0;
			newBlock.number = 0;
			newBlock.transform.position = new Vector3(-10f,0f,(-10f + i));
			blockBag.Add( newBlock );
		}	
		
		//make Blocks 1 - 99
		
		for (int i=1; i < blockCount; i++) {
			Block newBlock = Instantiate( blockList[i] ) as Block;
			
			symbolCounter++;
			if (symbolCounter > 10) {
				symbolID++;
				symbolCounter = 1;
			}
			
			numberID++;
			if (numberID > 9) {
				numberID = 0;
			}	
			
			if (wordID > 9) {
				wordID = wordBump;
				wordBump++;
				wordReset = true;
			}	
			
			newBlock.symbol = symbolID;
			newBlock.word = wordID;
			newBlock.number = numberID;
			newBlock.transform.position = new Vector3(-10f,0f,(-10f + i));
			blockBag.Add( newBlock );
			
			wordID++;
			if (wordReset == true) {
				wordID = 0;
				wordReset = false;
			}	
		}

		Randomizer ();
		PullBlocks ();
		MakeBoard ();
		
	}
	
	// Update is called once per frame
	void Update () {

		//RESET CURRENT BOARD

		if (Input.GetKeyDown (KeyCode.Space)) {

			ScoreKeeper.score = 0;
			ScoreKeeper.symWrdVal = 1;
			ScoreKeeper.seqVal = 1;
			ScoreKeeper.prxVal = 1;

			HighLight.clickCount = 0;

			MakeBoard ();

		}

		//MAKE NEW BOARD

		if (Input.GetKeyDown (KeyCode.N)) {
			ClearBoard ();
			Randomizer ();
			PullBlocks ();
			MakeBoard ();
		}
	}

	public static void ClearBoard() {

		ScoreKeeper.score = 0;
		ScoreKeeper.symWrdVal = 1;
		ScoreKeeper.seqVal = 1;
		ScoreKeeper.prxVal = 1;
		ScoreKeeper.bestScore = 0;

		HighLight.clickCount = 0;

		//Move the blocks off the board and empty out boardList

		for (int i=0; i < boardSize; i++) {
			boardList[i].transform.position = new Vector3(-10f,0,0);
		}

		boardList.RemoveRange (0,16);

		//Empty out rList

		rList.RemoveRange (0,16);


	}
	
	public static void PullBlocks() {

		for (int i = 0; i < boardSize; i++) {
			pointer = rList[i];
			boardCandidate = blockBag [pointer];
			boardList.Add (boardCandidate);
		}

	}

	//RANDOMIZER creates a list called "rList" that has 16 unique, random numbers between 0 and 100

	void Randomizer(){
		currentSeed = (System.DateTime.Now.Millisecond * System.DateTime.Now.Millisecond);
		Random.seed = currentSeed;
		while (rList.Count < boardSize) {
			rnd = Random.Range (0, blockCount);
			if (rList.Contains (rnd) == false) {
				rList.Add (rnd);
			}	

		}
	}

	//FIXED RANDOMIZER creates a list of 16 numbers based on a board code

	public static void FixedRandomizer(){
		currentSeed = (int.Parse(Interface.boardCode));
		Random.seed = currentSeed;
		while (rList.Count < boardSize) {
			rnd = Random.Range (0, blockCount);
			if (rList.Contains (rnd) == false) {
				rList.Add (rnd);
			}	

		}
	}


	public void MakeBoard() {

		blockLoc = new Vector3(-1.5f,0f,1.5f);
		int n = 0;

		for (int i=0; i < 4; i++) {
			for (int w=0; w < 4; w++) {
				
				newPick = boardList[n];
				n = n+1;
				
				newPick.transform.position = blockLoc;
				newPick.clicked = false;
				blockLoc.x = blockLoc.x + 1f;
				
			}	
			
			blockLoc.z = blockLoc.z - 1f;
			blockLoc.x = -1.5f;
		}	
		
	}	

}