using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public SpriteRenderer[] colors;
	public float timeLit;
	
	private int colorPicker;
	private float timeLitCounter;
	void Start () {
		
	}
	void Update () {
		if(timeLitCounter > 0) {
			timeLitCounter -= Time.deltaTime;
		} else {
			colors[colorPicker].color = new Color(colors[colorPicker].color.r, colors[colorPicker].color.g, colors[colorPicker].color.b, 0.5f);
		}
	}

	public void Begin() {
		colorPicker = Random.Range(0, colors.Length);
		colors[colorPicker].color = new Color(colors[colorPicker].color.r, colors[colorPicker].color.g, colors[colorPicker].color.b, 1f);
		timeLitCounter = timeLit;
	}

	public void colorClicked(int buttonNum) {
		if(colorPicker == buttonNum) {
			Debug.Log("Correct");
		} else {
			Debug.Log("Incorrect");
		}
	}
}
