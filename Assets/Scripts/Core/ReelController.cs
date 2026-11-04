using System.Collections;
using UnityEngine;

public class ReelController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RectTransform symbolStrip;
    [SerializeField] private SlotMachineAudio audioController;

    [Header("Spin Settings")]
    [SerializeField] private float spinDuration = 3f;
    [SerializeField] private float spinSpeed = 900f;

    [Header("Symbol Layout")]
    [SerializeField] private float symbolSpacing = 125f;
    [SerializeField] private float symbolHeight = 100f;
    [SerializeField] private float reelHeight = 323f;
    [SerializeField] private int symbolCount = 8;

    [Header("Symbol Sequence")]
    [SerializeField]
    private SymbolType[] symbolSequence =
    {
        SymbolType.Seven,
        SymbolType.Cherry,
        SymbolType.Bell,
        SymbolType.Bar,
        SymbolType.Seven,
        SymbolType.Cherry,
        SymbolType.Bell,
        SymbolType.Bar
    };

    private bool isSpinning;

    private int targetIndex;
    private SymbolType currentResult;

    public bool IsSpinning => isSpinning;
    public SymbolType CurrentResult => currentResult;

    public void SetRandomResult()
    {
        targetIndex = Random.Range(0, symbolSequence.Length);
        currentResult = symbolSequence[targetIndex];
    }

    public void Spin()
    {
        if (isSpinning)
            return;

        StartCoroutine(SpinRoutine());
    }

    private IEnumerator SpinRoutine()
    {
        isSpinning = true;

        audioController.PlayReelSpin();

        float startY = symbolStrip.anchoredPosition.y;

        // Calculate the vertical position of the randomly selected symbol.
        float targetBaseY = -(targetIndex * symbolSpacing);

        // Extend the movement distance so the reel completes multiple rotations.
        float targetY = targetBaseY;

        float totalHeight = symbolSpacing * symbolCount;

        while (targetY >= startY - (totalHeight * 2f))
        {
            targetY -= totalHeight;
        }

        float elapsedTime = 0f;

        while (elapsedTime < spinDuration)
        {
            float t = elapsedTime / spinDuration;

            // Apply easing to create a gradual slowdown as the reel approaches its destination.
            float easedT = 1f - Mathf.Pow(1f - t, 3f);

            float newY = Mathf.Lerp(startY, targetY, easedT);

            symbolStrip.anchoredPosition =
                new Vector2(
                    symbolStrip.anchoredPosition.x,
                    newY
                );

            // Move symbols back to the top when they pass beyond the visible reel area.
            RecycleSymbols();

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Snap the reel to its exact destination to prevent positional inaccuracies.
        symbolStrip.anchoredPosition =
            new Vector2(
                symbolStrip.anchoredPosition.x,
                targetY
            );

        isSpinning = false;
        audioController.PlayReelStop();
    }

    private void RecycleSymbols()
    {
        for (int i = 0; i < symbolStrip.childCount; i++)
        {
            RectTransform symbol =
                symbolStrip.GetChild(i) as RectTransform;

            if (symbol == null)
                continue;

            float symbolWorldY =
                symbolStrip.anchoredPosition.y +
                symbol.anchoredPosition.y;

            float bottomLimit =
                -(reelHeight / 2f) - symbolHeight;

            if (symbolWorldY < bottomLimit)
            {
                // Reposition the symbol above the reel to maintain a continuous scrolling loop.
                symbol.anchoredPosition +=
                    Vector2.up *
                    (symbolSpacing * symbolCount);
            }
        }
    }
}