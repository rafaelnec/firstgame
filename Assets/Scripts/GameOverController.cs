using UnityEngine;
using UnityEngine.EventSystems;

public class GameOverController : MonoBehaviour
{

    private GameManager gameManager;
    public GameObject backToMenu;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.SetGameState(GameManager.GameState.GameOver);
    }

    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(backToMenu);
    }

    public void BackToMenuOnBtnClick()
    {
        gameManager.SetGameState(GameManager.GameState.MainMenu);
    }

}
