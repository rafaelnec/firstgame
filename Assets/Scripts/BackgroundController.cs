using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

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
        if (backgroundSprites == null || backgroundSprites.Count == 0) return;

        currentPhase++;
        SetPhase();
    }

    public void SetCurrentPhase(int phase)
    {
        if (backgroundSprites == null || backgroundSprites.Count == 0) return;

        currentPhase = phase;
        SetPhase();
    }
    
    private void SetPhase()
    {
        spriteRenderer.sortingOrder = -1;

        if (currentPhase >= backgroundSprites.Count)
            currentPhase = 0;

        if (currentPhase == 0)
            spriteRenderer.sortingOrder = 1;

        if (spriteRenderer != null)
            spriteRenderer.sprite = backgroundSprites[currentPhase];
    }

}
