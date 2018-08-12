using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateGameLose : GameState {

	public StateGameLose(GameManager gm):base(gm) { }
	
	private GameScript gs;

	public override void Enter() { }

	public override void Execute() { }

	public override void Exit() { }

	public void PlayAgain() {
		gm.NewGameState(gm.stateGamePlay);
		gm.UpdateFSM(GameStates.PLAY);
	}

	public void QuitGame() {
		Application.Quit();
	}
}