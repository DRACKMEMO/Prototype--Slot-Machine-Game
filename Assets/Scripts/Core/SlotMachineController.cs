using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachineController : MonoBehaviour
{
    [Header("Reels")]
    [SerializeField] private ReelController reel1;
    [SerializeField] private ReelController reel2;
    [SerializeField] private ReelController reel3;

    [Header("Result")]
    [SerializeField] private SlotResultEvaluator resultEvaluator;

    [Header("Economy")]
    [SerializeField] private SlotMachineEconomy economy;

    [Header("Lever")]
    [SerializeField] private Image leverImage;
    [SerializeField] private Sprite leverIdleSprite;
    [SerializeField] private Sprite leverPressedSprite;

    [SerializeField] private float leverPressDuration = 0.15f;

    [Header("Audio")]
    [SerializeField] private SlotMachineAudio audioController;

    public void SpinAll()
    {
        // Prevent a new spin from starting while any reel is still moving.
        if (reel1.IsSpinning || reel2.IsSpinning || reel3.IsSpinning)
            return;

        // Deduct the spin cost before starting the animation.
        if (!economy.SpendForSpin())
        {
            Debug.Log("Not enough credits to spin.");
            return;
        }

        StartCoroutine(SpinSequence());
    }

    private IEnumerator SpinSequence()
    {
        // Change the lever appearance and play its pull sound.
        leverImage.sprite = leverPressedSprite;
        audioController.PlayLeverPull();

        yield return new WaitForSeconds(leverPressDuration);

        // Generate an independent random result for each reel.
        reel1.SetRandomResult();
        reel2.SetRandomResult();
        reel3.SetRandomResult();

        // Start the first reel.
        reel1.Spin();

        yield return new WaitForSeconds(0.5f);

        // Start the second reel after a short delay.
        reel2.Spin();

        yield return new WaitForSeconds(0.5f);

        // Start the final reel to create a staggered spinning effect.
        reel3.Spin();

        // Reset the lever to its original appearance.
        leverImage.sprite = leverIdleSprite;

        // Wait until all three reels have completed their animations.
        while (reel1.IsSpinning ||
               reel2.IsSpinning ||
               reel3.IsSpinning)
        {
            yield return null;
        }

        Debug.Log("All reels stopped.");

        // Pass the final symbols to the evaluator to determine the outcome.
        resultEvaluator.Evaluate(
            reel1.CurrentResult,
            reel2.CurrentResult,
            reel3.CurrentResult
        );
    }
}