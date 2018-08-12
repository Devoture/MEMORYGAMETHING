using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGameIntro : GameState {
	private float countdown = 5.0f;
	public StateGameIntro(GameManager gm):base(gm) { }

	public override void Enter() { }
	public override void Execute() {
		if(countdown <= 0 || Input.anyKey) {
			gm.NewGameState(gm.stateGameMenu);
			gm.UpdateFSM(GameStates.MENU);
		} else {
			countdown -= Time.deltaTime;
		}
	 }
	public override void Exit() { }

	

}