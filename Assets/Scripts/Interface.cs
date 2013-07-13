using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Interface : MonoBehaviour {

//	int right = 840;
	int right = 950;
	int left = 10;
	public static string boardCode = "";
	BlockCreator blockC;

	
	void OnGUI() {
		
		
//		GUI.Label(new Rect(left,20,500,800), "HOW TO PLAY HOBO SOLITAIRE \n \nClick any block to begin. \nClick another block. \nYour move is scored and the previous block goes away. \nContinue until there's only one block left. \n\nScore points by: \n\nWORD: matching words \nSYMBOL: matching symbols \nSEQUENCE: going up by one number (9 wraps to 0) \nPROXIMITY: the blocks are touching \n\nWhen you score points in a category, the multiplier for that \ncategory increases.");
//
//		GUI.Label(new Rect(left,290,1000,20), "------------------------------------------------------------");

		GUI.Label(new Rect(left,325,1000,20), "SPACEBAR = Reset Current Board");
		GUI.Label(new Rect(left,345,1000,20), "N = Create New Board");


//		GUI.Label(new Rect(right,20,1000,20), "CURRENT MULTIPLIERS");
//		GUI.Label(new Rect(right,40,1000,20), "Symbol / Word = x" + ScoreKeeper.symWrdVal);
//		GUI.Label(new Rect(right,58,1000,20), "Sequence = x" + ScoreKeeper.seqVal);
//		GUI.Label(new Rect(right,76,1000,20), "Proximity = x" + ScoreKeeper.prxVal);
//
//		GUI.Label(new Rect(right,105,1000,20), "------------------------------------------------------------");
//
//		GUI.Label(new Rect(right,140,1000,20), "LAST MOVE");
//		GUI.Label(new Rect(right,160,1000,20), "Symbol = " + ScoreKeeper.symPts);
//		GUI.Label(new Rect(right,178,1000,20), "Word = " + ScoreKeeper.wrdPts);
//		GUI.Label(new Rect(right,196,1000,20), "Sequence = " + ScoreKeeper.seqPts);
//		GUI.Label(new Rect(right,214,1000,20), "Proximity = " + ScoreKeeper.prxPts);
//
//		GUI.Label(new Rect(right,242,1000,20), "Total  = " + ScoreKeeper.newPts);
//
//		GUI.Label(new Rect(right,275,1000,20), "------------------------------------------------------------");
//
//		GUI.Label(new Rect(right,310,1000,20), "SCORE  = " + ScoreKeeper.score);
//		GUI.Label(new Rect(right,330,1000,20), "Best Score for this Board  = " + ScoreKeeper.bestScore);


		//BOARD CODE STUFF

		GUI.Label(new Rect(left,375,1000,20), "The code for this board = " + BlockCreator.currentSeed);

		boardCode = GUI.TextField(new Rect(left, 395, 55, 20), boardCode, 6);

		if(GUI.Button(new Rect(75,395,90,20), "Enter Code")) {
			BlockCreator.ClearBoard ();
			BlockCreator.FixedRandomizer ();
			BlockCreator.PullBlocks ();
			BlockCreator.MakeBoard ();
		}

		GUI.Label(new Rect(left,425,1000,200), BlockCreator.quote);

	}	

	// Use this for initialization
	void Start () {

		blockC = GetComponent<BlockCreator> ();
	
	}
	
	// Update is called once per frame
	void Update () {





	
		
	}
}
