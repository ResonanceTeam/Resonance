using UnityEngine;

public class GameController : MonoBehaviour {
    public int currentScore = 0;
    public AudioListener audioListener;

    public enum GameStates {
        Game,
        Paused
    }

    public GameStates currentState;

	// Use this for initialization
	void Start () {
        currentState = GameStates.Game;
	}
	
	// Update is called once per frame
	void Update () {
        switch(currentState) {
            case GameStates.Game:
                break;
            case GameStates.Paused:
                break;
        }
	}


    public void AddScore(int amt) {
        currentScore++;
    }
}
