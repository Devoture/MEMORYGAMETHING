using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour {
	public SpriteRenderer[] colors;
	public float timeLit;
	public float waitBetweenFlash;
	public List<int> sequence;
	
	private int colorPicker;
	private int positionInSequence;
	private float timeLitCounter;
	private float waitBetweenCounter;
	private bool shouldBeLit;
	private bool shouldBeDark;

	void Start () {
	
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
			} else {
				if(waitBetweenCounter < 0) {
					colorPicker = Random.Range(0, colors.Length);
					//sequence.Add(colorPicker);
					colors[sequence[positionInSequence]].color = new Color(colors[sequence[positionInSequence]].color.r, colors[sequence[positionInSequence]].color.g, colors[sequence[positionInSequence]].color.b, 1f);
					timeLitCounter = timeLit;
					shouldBeLit = true;
					shouldBeDark = false;
				}
			}
		}
	}

	public void Begin() {
		positionInSequence = 0;
		colorPicker = Random.Range(0, colors.Length);
		sequence.Add(colorPicker);
		colors[sequence[positionInSequence]].color = new Color(colors[sequence[positionInSequence]].color.r, colors[sequence[positionInSequence]].color.g, colors[sequence[positionInSequence]].color.b, 1f);
		timeLitCounter = timeLit;
		shouldBeLit = true;
	}

	public void ColorClicked(int buttonNum) {
		if(colorPicker == buttonNum) {
			Debug.Log("Correct");
		} else {
			Debug.Log("Incorrect");
		}
	}
}
