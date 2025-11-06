using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI gameOverText;
    public GameObject gameOverObject;
    public GameObject playerObject;
    public GameObject gameBarObject;
    public GameObject menuObject;

    public enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        GameOver
    }

    private BackgroundController background;
    private CameraController cameraController;
    private PlayerController playerController;
    private CollectableManager collectableManager;
    private ObstacleManager obstacleManager;
    private LifeManager lifeManager;

    private int points = 0;
    private int life = 3;
    private int startPoints;
    private int startLife;

    void Awake()
    {
        startPoints = points;
        startLife = life;
    }

    private void StartGame()
    {
        cameraController = FindFirstObjectByType<CameraController>();
        playerController = FindFirstObjectByType<PlayerController>();
        background = FindFirstObjectByType<BackgroundController>();
        collectableManager = FindFirstObjectByType<CollectableManager>();
        obstacleManager = FindFirstObjectByType<ObstacleManager>();
        lifeManager = FindFirstObjectByType<LifeManager>();
        AddDynamicObjects();
        points = startPoints;
        SetPointText(points);
        life = startLife;
        SetLifeText(life);
    }

    private void InitialState()
    {

        if (cameraController)
            cameraController.Reload();
        
        if (playerController)
            playerController.Reload();

        ClearDynamicObjects();
    }

    private void AddDynamicObjects()
    {

        ClearDynamicObjects();

        if (collectableManager)
            collectableManager.SpawnObjects();

        if (obstacleManager)
            obstacleManager.SpawnObjects();

        if (lifeManager)
        {
            lifeManager.quantity = 2;
            lifeManager.SpawnObjects();    
        }
        
    }

    private void ClearDynamicObjects()
    {
        if (collectableManager)
            collectableManager.ClearObjects();

        if (obstacleManager)
            obstacleManager.ClearObjects();

        if (lifeManager)
            lifeManager.ClearObjects();

    }

    private void SetLifeText(int lifeValue)
    {
        lifeText.text = lifeValue.ToString("D3");
    }
    
    private void SetPointText(int pointValue)
    {
        pointsText.text = pointValue.ToString("D5");
    }

    public void AdvancePhase()
    {

        background.AdvancePhase();
        cameraController.Reload();
        playerController.Reload();

        AddDynamicObjects();

    }

    public void PlayerHit()
    {
        playerController.Hit();
        life -= 1;
        SetLifeText(life);
        if (life <= 0)
            SetGameState(GameState.GameOver);
        
    }

    public void AddPoint()
    {
        points += 10;
        SetPointText(points);
    }

    public void AddLife()
    {
        life += 1;
        SetLifeText(life);
    }

    public void GameOverTotalScore()
    {
        gameOverText.text = points.ToString();
    }
    
    public void SetGameState(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu:
                InitialState();
                gameOverObject.SetActive(false);
                menuObject.SetActive(true);
                gameObject.SetActive(false);
                gameBarObject.SetActive(false);
                playerObject.GetComponent<PlayerController>().enabled = false;
                break;
            case GameState.Playing:
                gameOverObject.SetActive(false);
                menuObject.SetActive(false);
                gameObject.SetActive(true);
                this.StartGame();
                gameBarObject.SetActive(true);
                playerObject.GetComponent<PlayerController>().enabled = true;
                break;
            case GameState.GameOver:
                GameOverTotalScore();
                gameOverObject.SetActive(true);
                playerObject.GetComponent<PlayerController>().enabled = false;
                break;
            
            default:
                SetGameState(GameState.MainMenu);
                break;
        }
    }

}
