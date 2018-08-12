using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates {INTRO, MENU, PLAY, LOSE}
public class StateManager : MonoBehaviour {
	public GameObject[] gameState;

	private GameStates activeState;
	private int numStates;

	void Start () {
		numStates = gameState.Length;
		for(int i = 0; i < numStates; i++) {
			gameState[i].SetActive(false);
		}
		activeState = GameStates.INTRO;
		gameState[(int)activeState].SetActive(true);
		GameManager.Instance.StartGame();
	}

	void Update() {
		if(GameManager.Instance.hasLost) {
			GameOver();
		}
	}

	public void ChangeState(GameStates newState) {
		gameState[(int)activeState].SetActive(false);
		activeState = newState;
		gameState[(int)activeState].SetActive(true);
	}
	
	public void PlayGame() {
		ChangeState(GameStates.PLAY);
		GameManager.Instance.NewGameState(GameManager.Instance.stateGamePlay);
	}

	public void QuitGame() {
		GameManager.Instance.stateGameMenu.QuitGame();
	}

	public void GameOver() {
		ChangeState(GameStates.LOSE);
	}
}