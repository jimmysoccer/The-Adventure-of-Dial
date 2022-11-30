using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Myscore : MonoBehaviour {
	public int Score;

	private float myfirstPos;
	// Use this for initialization
	void Start () {
		myfirstPos = gameObject.transform.position.x;
		(Tens.gameObject as GameObject).SetActive(false);
		(Hundreds.gameObject as GameObject).SetActive(false);
		(Hezar.gameObject as GameObject).SetActive(false);

	}

	// Update is called once per frame
	void FixedUpdate () {

		Score = GameObject.Find ("Manage").GetComponent<Manage> ().Score;

		if (Score >= 9999) {
			Score = 9999;
		}
		if (Score <= 0) {
			Score = 0;
		}
		if (Score >= 15) {
			GameObject.Find("Manage").GetComponent<Manage>().W_or_L = true;
			GameObject.Find("Manage").GetComponent<Manage>().End = true;
		}

		if (previousScore != Score) //save perf from non needed calculations
		{ 
			if(Score < 10 && Score >= 0)
			{
				transform.position = new Vector3 (myfirstPos-0.4f,transform.position.y,0);
				Units.sprite = numberSprites[Score];
				(Units.gameObject as GameObject).SetActive(true);
				(Tens.gameObject as GameObject).SetActive(false);
				(Hundreds.gameObject as GameObject).SetActive(false);
				(Hezar.gameObject as GameObject).SetActive(false);

			}
			else if(Score >= 10 && Score < 100)
			{
				transform.position = new Vector3 (myfirstPos-0.3f,transform.position.y,0);
				(Tens.gameObject as GameObject).SetActive(true);
				(Hundreds.gameObject as GameObject).SetActive(false);
				(Hezar.gameObject as GameObject).SetActive(false);

				Tens.sprite = numberSprites[Score / 10];
				Units.sprite = numberSprites[Score % 10];
			}
			else if(Score >= 100 && Score < 1000)
			{
				transform.position = new Vector3 (myfirstPos-0.2f,transform.position.y,0);
				(Hundreds.gameObject as GameObject).SetActive(true);
				(Tens.gameObject as GameObject).SetActive(true);
				(Hezar.gameObject as GameObject).SetActive(false);

				Hundreds.sprite = numberSprites[Score / 100];
				int rest = Score % 100;
				Tens.sprite = numberSprites[rest / 10];
				Units.sprite = numberSprites[rest % 10];
			}
			else if(Score >= 1000 && Score < 100000 )
			{
				transform.position = new Vector3 (myfirstPos+0f,transform.position.y,0);
				(Hezar.gameObject as GameObject).SetActive(true);
				(Hundreds.gameObject as GameObject).SetActive(true);
				(Tens.gameObject as GameObject).SetActive(true);

				Hezar.sprite = numberSprites[Score / 1000];

				int rest = Score % 1000;
				Hundreds.sprite = numberSprites[rest / 100];
				rest = rest %100;
				Tens.sprite = numberSprites[rest / 10];
				Units.sprite = numberSprites[rest % 10];




			}
		}

	}


	int previousScore = -1;
	public Sprite[] numberSprites;
	public SpriteRenderer Units, Tens, Hundreds, Hezar;
}