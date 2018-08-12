using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGameIntro : GameState {
	private float m_countdown = 5.0f;
	public StateGameIntro(GameManager gm):base(gm) { }

	public override void Enter() { }
	public override void Execute() {
		if(m_countdown <= 0 || Input.anyKey) {
			gm.NewGameState(gm.stateGameMenu);
			gm.UpdateFSM(GameStates.MENU);
		} else {
			m_countdown -= Time.deltaTime;
		}
	 }
	public override void Exit() { }

	

}