using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI lifeText;

    private BackgroundController background;
    private CameraController cameraController;
    private PlayerController playerController;
    private CollectableManager collectableManager;
    private ObstacleManager obstacleManager;
    private LifeManager lifeManager;

    private int points = 0;
    private int life = 3;

    public void Start()
    {
        cameraController = FindFirstObjectByType<CameraController>();
        playerController = FindFirstObjectByType<PlayerController>();
        background = FindFirstObjectByType<BackgroundController>();
        collectableManager = FindFirstObjectByType<CollectableManager>();
        obstacleManager = FindFirstObjectByType<ObstacleManager>();
        lifeManager = FindFirstObjectByType<LifeManager>();

        AddDynamicObjects();
    }

    private void AddDynamicObjects()
    {

        ClearDynamicObjects();

        collectableManager.SpawnObjects();
        obstacleManager.SpawnObjects();

        lifeManager.quantity = 2;
        lifeManager.SpawnObjects();
    }

    private void ClearDynamicObjects()
    {
        collectableManager.ClearObjects();
        obstacleManager.ClearObjects();
        lifeManager.ClearObjects();
        
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
        if (life > 0)
        {
            life -= 1;
            lifeText.text = life.ToString("D3");    
        }
    }

    public void AddPoint()
    {
        points += 10;
        pointsText.text = points.ToString("D5");
    }
    
    public void AddLife()
    {
        life += 1;
        lifeText.text = life.ToString("D3");
    }

}
