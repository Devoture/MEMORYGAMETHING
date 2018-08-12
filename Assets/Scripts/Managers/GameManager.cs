using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager Instance { get{ return instance; } }
	public StateManager stateManager;
	public GameState currentState;
	public StateGameIntro stateGameIntro { get; set; }
	public StateGameMenu stateGameMenu { get; set; }
	public StateGamePlay stateGamePlay { get; set; }
	public StateGameLose stateGameLose { get; set; }
	public bool hasLost = false;
	public Text scoreText;
	
	private static GameManager instance = null;
	private GameScript gs;

	void Awake() {
		if(instance != null && instance != this) {
			Destroy(this.gameObject); 
			return;
		} else {
			instance = this;
		}
			DontDestroyOnLoad(this.gameObject);
			stateGameIntro = new StateGameIntro(this);
			stateGameMenu = new StateGameMenu(this);
			stateGamePlay = new StateGamePlay(this);
			stateGameLose = new StateGameLose(this);
	}

	void Start () {
		gs = FindObjectOfType<GameScript>();
		NewGameState(stateGameIntro);
	}

	void Update () {
		if(currentState != null) {
			currentState.Execute();
		}
		if(hasLost) {
			GameOver();
		}

		scoreText.text = gs.scoreText.text;
	}

	public void StartGame(){
		NewGameState(stateGameIntro);
	}

	public void NewGameState(GameState newState) {
		if(currentState != null) {
			currentState.Exit();
		}
		currentState = newState;
		currentState.Enter();
	}

	public void UpdateFSM(GameStates newState) {
		stateManager.ChangeState(newState);
	}

	public void GameOver() {
		NewGameState(stateGameLose);
	}
}

