using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGamePlay : GameState {

	public StateGamePlay(GameManager gm):base(gm) { }

	private bool isPaused = false;

	public override void Enter() {
		gm.hasLost = false;
	 }
	public override void Execute() { 
		if(Input.GetKeyDown(KeyCode.Escape)) {
			if(isPaused) {
				ResumeGame();
			} else {
				PauseGame();
			}
		}

		if(gm.hasLost) {
			gm.GameOver();
		}
	}
	public override void Exit() { }

	public void PauseGame() {
		Time.timeScale = 0.0f;
		isPaused = true;
	}

	public void ResumeGame() {
		Time.timeScale = 1.0f;
		isPaused = false;
	}
}