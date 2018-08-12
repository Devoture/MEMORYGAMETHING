using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGameMenu : GameState {

	public StateGameMenu(GameManager gm):base(gm) { }

	public override void Enter() { }
	public override void Execute() { }
	public override void Exit() { }

	public void PlayGame() {
		gm.NewGameState(gm.stateGamePlay);
		gm.UpdateFSM(GameStates.PLAY);
	}

	public void QuitGame() {
		Application.Quit();
	}

}