using UnityEngine;
using System.Collections;

public class ScoreKeeper: MonoBehaviour {

	public static int score;
	public static int bestScore;

	public static int symPts;
	public static int wrdPts;
	public static int seqPts;
	public static int prxPts;

	public static Vector3 oldBlockLoc;
	public static Vector3 newBlockLoc;

	public static int newPts;

//	public static int symVal = 1;
//	public static int wrdVal = 1;
	public static int symWrdVal = 1;
	public static int seqVal = 1;
	public static int prxVal = 1;

	public static bool symFlag;
	public static bool wrdFlag;

	public static void ScoreMove() {

		// CHECK FOR SYMBOL

		if (HighLight.currentBlock.symbol == HighLight.previousBlock.symbol) {
			symPts = symWrdVal;
			symFlag = true;
		}

		else {
			symPts = 0;
			symFlag = false;
		}

		// CHECK FOR WORD

		if (HighLight.currentBlock.word == HighLight.previousBlock.word) {
			wrdPts = symWrdVal;
			wrdFlag = true;
		} 

		else {
			wrdPts = 0;
			wrdFlag = false;
		}

		if (symFlag == true || wrdFlag == true) {
			symWrdVal++;
			if (symWrdVal > 4) {
				symWrdVal = 1;
			}

		} 

		else {
			symWrdVal = 1;
		}

		// CHECK FOR SEQUENCE

		if ((HighLight.currentBlock.number - HighLight.previousBlock.number == 1) || (HighLight.currentBlock.number - HighLight.previousBlock.number == -9)) {
			seqPts = seqVal;
			seqVal++;
			if (seqVal > 3) {
				seqVal = 1;
			}
		}

		else {
			seqPts = 0;
			seqVal = 1;
		}

		// CHECK FOR PROXIMITY

		newBlockLoc = HighLight.currentBlock.transform.position;
		oldBlockLoc = HighLight.previousBlock.transform.position;
		if (Vector3.Distance(newBlockLoc, oldBlockLoc) == 1) {
			prxPts = prxVal;
			prxVal++;
			if (prxVal > 2) {
				prxVal = 1;
			}
		}
		else {
			prxPts = 0;
			prxVal = 1;
		}

		// TALLY SCORE\

		newPts = (symPts + wrdPts + seqPts + prxPts);
		score = score + newPts;

		if (score > bestScore)
			bestScore = score;

//		Interface.UpdateScore();

	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
