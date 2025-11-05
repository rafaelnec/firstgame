using UnityEngine;

public class GameOverController : MonoBehaviour
{

    public GameObject player;

    void Awake()
    {
        player.GetComponent<PlayerController>().enabled = false;
    }


}
