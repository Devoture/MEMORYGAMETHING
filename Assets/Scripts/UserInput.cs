using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour {
	public int buttonNumber;

	private SpriteRenderer spritecolor;
	private GameManager gm;
	// Use this for initialization
	void Start () {
		spritecolor = GetComponent<SpriteRenderer>();
		gm = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		spritecolor.color = new Color(spritecolor.color.r, spritecolor.color.g, spritecolor.color.b, 1f);
	}


	void OnMouseUp()
	{
		spritecolor.color = new Color(spritecolor.color.r, spritecolor.color.g, spritecolor.color.b, 0.5f);
		gm.colorClicked(buttonNumber);
	}
}
