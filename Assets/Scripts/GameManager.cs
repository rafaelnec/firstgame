using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI multiplerPointsText;
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
    private AudioManager AudioManager;

    private long points = 0L;
    private int life = 3;
    private long startPoints;
    private int startLife;

    private float[] weights = { 0f, 0.005f, 0.01f, 0.015f };
    private int currentWeightIdx = 0;
    private int countWeightPoints = 0;

    // private int currentPhase = 0;

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
        AudioManager = FindFirstObjectByType<AudioManager>();
        
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

        if (background)
            background.SetCurrentPhase(0);

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

    private void SetPointText(long pointValue)
    {
        pointsText.text = pointValue.ToString("D12");
    }
    
    private void SetMultiplerPointText(int multiplerPointsValue)
    {
        multiplerPointsText.text = $"x{multiplerPointsValue.ToString()}";
    }

    public void AdvancePhase()
    {

        background.AdvancePhase();
        cameraController.Reload();
        playerController.Reload();

        AddDynamicObjects();

        playerController.moveSpeed += 1f;
        playerController.jumpLength -= 1f;

    }

    public void PlayerHit()
    {
        playerController.Hit();
        countWeightPoints = 0;
        life -= 1;
        SetLifeText(life);
        if (life <= 0)
            SetGameState(GameState.GameOver);
        
    }

    public void AddPoint()
    {
        countWeightPoints += 1;
        if (countWeightPoints <= 5)
            currentWeightIdx = 0;
        else if (countWeightPoints <= 10)
            currentWeightIdx = 1;
        else if (countWeightPoints <= 15)
            currentWeightIdx = 2;
        else if (countWeightPoints > 15)
            currentWeightIdx = 3;
        else
            currentWeightIdx = 0;

        points += 1;
        points += (long)(points * weights[currentWeightIdx]);

        if (points > 999999999999)
            points = 999999999999;

        SetPointText(points);
        SetMultiplerPointText(currentWeightIdx);
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
