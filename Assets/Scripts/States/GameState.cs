using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState {

	protected GameManager gm;
	public GameState(GameManager gameManager) {
		gm = gameManager;
	}

	public abstract void Enter();
	public abstract void Execute();
	public abstract void Exit();

}