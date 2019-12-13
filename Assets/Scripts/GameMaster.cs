using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameMaster : MonoBehaviour
{
    public static GameMaster GM;

    public GameState gameState;
    [Space]

    // Buttons
    public GameObject startButton;
    public GameObject finishButton;


    void Awake()
    {
        if (GM != null)
            GameObject.Destroy(GM);
        else
            GM = this;
    }

    void Start()
    {
        gameState = GameState.StWaiting;

        finishButton.SetActive(false);
    }

    public void StartGame()
    {
        gameState = GameState.StPlaying;

        startButton.SetActive(false);
    }

    public void FinishGame()
    {
        finishButton.SetActive(true);

        gameState = GameState.StComplete;
    }

    public void ReloadGame()
    {
        Debug.Log("HERE");

        SceneManager.LoadScene(0);
    }
}
