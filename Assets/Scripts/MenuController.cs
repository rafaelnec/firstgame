using UnityEngine;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject newButton;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.SetGameState(GameManager.GameState.MainMenu);
    }
    
    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(newButton);
    }

    public void NewOnBtnClick()
    {
        Debug.Log("New Clicked");
        gameManager.SetGameState(GameManager.GameState.Playing);
    }

    public void SettingsOnBtnClick()
    {
        Debug.Log("Settings Clicked");
    }

    public void ExitOnBtnClick()
    {
        Debug.Log("Exit Clicked");
    }

    public void ScoreRankOnBtnClick()
    {
        Debug.Log("Score Rank Clicked");
    }

}
