using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    [SerializeField] private int currentPhase = 0;
    [SerializeField] private List<Sprite> backgroundSprites = new List<Sprite>();

    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (backgroundSprites != null && backgroundSprites.Count > 0)
            spriteRenderer.sprite = backgroundSprites[currentPhase];
    }
    public void AdvancePhase()
    {

        Debug.Log("Advancing background phase.");
        
        if (backgroundSprites == null || backgroundSprites.Count == 0) return;

        currentPhase++;
        spriteRenderer.sortingOrder = -1;

        if (currentPhase >= backgroundSprites.Count)
        {
            currentPhase = 0;
            spriteRenderer.sortingOrder = 1;
        }

        if (spriteRenderer != null)
            spriteRenderer.sprite = backgroundSprites[currentPhase];

    }

}
