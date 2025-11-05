using UnityEngine;

public class GameManager : MonoBehaviour
{

    private BackgroundController background;
    private CameraController cameraController;
    private PlayerController playerController;
    private CollectableManager collectableManager;
    private ObstacleManager obstacleManager;

    public void Start()
    {
        cameraController = FindFirstObjectByType<CameraController>();
        playerController = FindFirstObjectByType<PlayerController>();
        background = FindFirstObjectByType<BackgroundController>();
        collectableManager = FindFirstObjectByType<CollectableManager>();
        obstacleManager = FindFirstObjectByType<ObstacleManager>();

        AddDynamicObjects();
    }

    private void AddDynamicObjects()
    {

        ClearDynamicObjects();

        collectableManager.SpawnObjects();
        obstacleManager.SpawnObjects();
    }

    private void ClearDynamicObjects()
    {
        collectableManager.ClearObjects();
        obstacleManager.ClearObjects();
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
    }

}
