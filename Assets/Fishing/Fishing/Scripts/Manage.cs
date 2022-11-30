using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manage : MonoBehaviour {
	public int Startgame;
	public int Score;
	public int BestScore;
	public int Sound;
	public int R;
	public int Randomfish;
	public GameObject Again;
	public GameObject Again_lose;
	public GameObject Again_win;
	public GameObject Fish;
	public bool Supply;
	public float TimeScale;
	public bool End;
	public GameObject F1;
	public GameObject F2;
	public GameObject F3;
	public GameObject F4;
	public GameObject F5;
	public GameObject F6;
	public GameObject F7;
	public GameObject F8;
	public GameObject F9;
	public GameObject F10;
	public GameObject F11;
	public GameObject F12;
	public GameObject F13;
	public GameObject Black1; 
	public GameObject Black2; 
	public GameObject Black3;
    public GameObject Bubble;
    public GameObject Tolid;
    public float H;
    public int Once;
    public bool PlayMusic;
	public bool W_or_L;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Globe", 3f, 5f);
        Score = 0;
		TimeScale = 1;
		BestScore = PlayerPrefs.GetInt ("BestScore", BestScore);

		Sound = PlayerPrefs.GetInt ("Sound", Sound);
	}
	
	// Update is called once per frame
	void Update () {
        /*if (true)
        {
            GameObject.Find("Soundgame1").GetComponent<AudioSource>().Stop();
            if (Sound == 0 && PlayMusic == true)
            {
                GameObject.Find("Soundgame2").GetComponent<AudioSource>().Play();
                GameObject.Find("Bird").GetComponent<AudioSource>().Play();
                PlayMusic = false;
            }
            if (Sound == 1)
            {
                GameObject.Find("Soundgame2").GetComponent<AudioSource>().Stop();
                GameObject.Find("Bird").GetComponent<AudioSource>().Stop();
                PlayMusic = true;
            }

        }*/
       /* if (Score >= 10) {
			Black1.SetActive (true);
		}
		if (Score >= 20) {
			Black2.SetActive (true);
		}
		if (Score >= 40) {
			Black3.SetActive (true);
		}*/
		if (Score >= 9999) {
			Score = 9999;
		}
		if (Score <= 0) {
			Score = 0;
		}
		Time.timeScale = (float)TimeScale;
		if (End == true) {
            Once += 1;
            if (Once == 1)
            {
                TimeScale = 0.2f;
				StartCoroutine (Endgame ());
            }
        }
		/*if (Sound >= 2) {
			Sound = 0;
		}*/




		if (Supply == true) {
			Randomfish = Random.Range (1, 14);
			if (Randomfish == 1) {
				Fish = F1;
			}
			if (Randomfish == 2) {
				Fish = F2;
			}
			if (Randomfish == 3) {
				Fish = F3;
			}
			if (Randomfish == 4) {
				Fish = F4;
			}
			if (Randomfish == 5) {
				Fish = F5;
			}
			if (Randomfish == 6) {
				Fish = F6;
			}
			if (Randomfish == 7) {
				Fish = F7;
			}
			if (Randomfish == 8) {
				Fish = F9;
			}
			if (Randomfish == 9) {
				Fish = F9;
			}
			if (Randomfish == 10) {
				Fish = F10;
			}
			if (Randomfish == 11) {
				Fish = F11;
			}
			if (Randomfish == 12) {
				Fish = F12;
			}
			if (Randomfish == 13) {
				Fish = F13;
			}
			R = Random.Range (0, 1);
			if (R == 1) {
				Instantiate (Fish, new Vector3 (GameObject.Find ("Main Camera").transform.position.x-5.5f, Random.Range (-0.5f, -2.0f), 0), Quaternion.identity);
			}
			if (R == 0) {
				Instantiate (Fish, new Vector3 (GameObject.Find ("Main Camera").transform.position.x+5.5f, Random.Range (-0.5f, -2.0f), 0), Quaternion.identity);
			}
			Supply = false;
		}
		if (Score >= BestScore) {
			BestScore = Score;
		}

		PlayerPrefs.SetInt ("BestScore", BestScore);

		PlayerPrefs.SetInt ("Sound", Sound);
	}
	IEnumerator Endgame(){
		yield return new WaitForSeconds (0.2f);

		if (W_or_L) {
			Instantiate(Again_win, new Vector3(0, 0, -5f), Quaternion.identity);
		}
		if (!W_or_L)
		{
			Instantiate(Again_lose, new Vector3(0, 0, -5f), Quaternion.identity);
		}
		TimeScale = 0;

		/*StartCoroutine (T ());*/
	}
	/*IEnumerator T(){
		yield return new WaitForSeconds (0.2f);
		TimeScale = 0;
	}*/
    void Globe()
    {
        H = Random.Range(0.3f, 1f);
        Tolid=Instantiate(Bubble, new Vector3(Random.Range(-4f, 4f),-5f, 0), Quaternion.identity)as GameObject;
        Tolid.transform.localScale = new Vector3(H, H, H);
        H = Random.Range(0.3f, 1f);
        Tolid = Instantiate(Bubble, new Vector3(Random.Range(-4f, 4f), -5f, 0), Quaternion.identity) as GameObject;
        Tolid.transform.localScale = new Vector3(H, H, H);
        H = Random.Range(0.3f, 1f);
        Tolid = Instantiate(Bubble, new Vector3(Random.Range(-4f, 4f), -5f, 0), Quaternion.identity) as GameObject;
        Tolid.transform.localScale = new Vector3(H, H, H);
        H = Random.Range(0.3f, 1f);
        Tolid = Instantiate(Bubble, new Vector3(Random.Range(-4f, 4f), -5f, 0), Quaternion.identity) as GameObject;
        Tolid.transform.localScale = new Vector3(H, H, H);
        H = Random.Range(0.3f, 1f);
        Tolid = Instantiate(Bubble, new Vector3(Random.Range(-4f, 4f), -5f, 0), Quaternion.identity) as GameObject;
        Tolid.transform.localScale = new Vector3(H, H, H);
        H = Random.Range(0.3f, 1f);
        Tolid = Instantiate(Bubble, new Vector3(Random.Range(-4f, 4f), -5f, 0), Quaternion.identity) as GameObject;
        Tolid.transform.localScale = new Vector3(H, H, H);
    }
    }
