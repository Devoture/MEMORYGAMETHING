using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour {
	public SpriteRenderer[] colors;
	public float timeLit;
	public float waitBetweenFlash;
	public List<int> sequence;
	public Text scoreText;
	public int finalScore;
	
	
	private int colorPicker;
	private int positionInSequence;
	private int inputInSequence;
	private float timeLitCounter;
	private float waitBetweenCounter;
	private bool shouldBeLit;
	private bool shouldBeDark;
	private bool gameActive;
	private GameManager gm;
	

	void Start () {
		gm = FindObjectOfType<GameManager>();
		gm.hasLost = false;
		if(!PlayerPrefs.HasKey("HighScore")) {
			PlayerPrefs.SetInt("HighScore", 0);
		}
			scoreText.text = "Score: 0 - HighScore: " + PlayerPrefs.GetInt("HighScore");
	}

	void Update () {
		if(shouldBeLit) {
			timeLitCounter -= Time.deltaTime;
			if(timeLitCounter < 0) {
		colors[sequence[positionInSequence]].color = new Color(colors[sequence[positionInSequence]].color.r, colors[sequence[positionInSequence]].color.g, colors[sequence[positionInSequence]].color.b, 0.5f);
				shouldBeLit = false;
				shouldBeDark = true;
				waitBetweenCounter = waitBetweenFlash;
				positionInSequence++;
			}
		}
		if(shouldBeDark) {
			waitBetweenCounter -= Time.deltaTime;
			if(positionInSequence >= sequence.Count) {
				shouldBeDark = false;
				gameActive = true;
			} else {
				if(waitBetweenCounter < 0) {
					colorPicker = Random.Range(0, colors.Length);
					colors[sequence[positionInSequence]].color = new Color(colors[sequence[positionInSequence]].color.r, colors[sequence[positionInSequence]].color.g, colors[sequence[positionInSequence]].color.b, 1f);
					timeLitCounter = timeLit;
					shouldBeLit = true;
					shouldBeDark = false;
				}
			}
		}
	}

	public void Begin() {
		sequence.Clear();
		positionInSequence = 0;
		inputInSequence = 0;
		colorPicker = Random.Range(0, colors.Length);
		sequence.Add(colorPicker);
		colors[sequence[positionInSequence]].color = new Color(colors[sequence[positionInSequence]].color.r, colors[sequence[positionInSequence]].color.g, colors[sequence[positionInSequence]].color.b, 1f);
		timeLitCounter = timeLit;
		shouldBeLit = true;
		scoreText.text = "Score: 0 - HighScore: " + PlayerPrefs.GetInt("HighScore");

	}

	public void ColorClicked(int buttonNum) {
		if(gameActive) {
			if(sequence[inputInSequence] == buttonNum) {
				inputInSequence++;
				if(inputInSequence >= sequence.Count) {
					if(sequence.Count > PlayerPrefs.GetInt("HighScore")) {
						PlayerPrefs.SetInt("HighScore", sequence.Count);
					}
					scoreText.text = "Score: " + sequence.Count + " - HighScore: " + PlayerPrefs.GetInt("HighScore");
					positionInSequence = 0;
					inputInSequence = 0;
					colorPicker = Random.Range(0, colors.Length);
					sequence.Add(colorPicker);
					colors[sequence[positionInSequence]].color = new Color(colors[sequence[positionInSequence]].color.r, colors[sequence[positionInSequence]].color.g, colors[sequence[positionInSequence]].color.b, 1f);
					timeLitCounter = timeLit;
					shouldBeLit = true;
					gameActive = false;
				}
			} else {
				gameActive = false;
				gm.hasLost = true;
				finalScore = sequence.Count;
			}
		}
	}
}