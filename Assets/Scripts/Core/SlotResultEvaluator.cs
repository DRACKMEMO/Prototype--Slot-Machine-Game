using TMPro;
using UnityEngine;

public class SlotResultEvaluator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SlotMachineEconomy economy;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private SlotMachineAudio audioController;

    [Header("Payouts")]
    [SerializeField] private int sevenPayout = 100;
    [SerializeField] private int cherryPayout = 50;
    [SerializeField] private int bellPayout = 30;
    [SerializeField] private int barPayout = 20;

    public void Evaluate(
        SymbolType reel1Result,
        SymbolType reel2Result,
        SymbolType reel3Result)
    {
        if (reel1Result == reel2Result &&
            reel2Result == reel3Result)
        {
            switch (reel1Result)
            {
                case SymbolType.Seven:
                    Jackpot("JACKPOT! 7 - 7 - 7", sevenPayout);
                    break;

                case SymbolType.Cherry:
                    Win("BIG WIN! Cherry - Cherry - Cherry", cherryPayout);
                    break;

                case SymbolType.Bell:
                    Win("WIN! Bell - Bell - Bell", bellPayout);
                    break;

                case SymbolType.Bar:
                    Win("WIN! BAR - BAR - BAR", barPayout);
                    break;
            }
        }
        else
        {
            resultText.text = "NO WIN";
            Debug.Log("No Win");
        }
    }

    private void Win(string message, int payout)
    {
        resultText.text = message + "\n+" + payout;
        Debug.Log(message + " | Payout: " + payout);

        economy.AddCredits(payout);
        audioController.PlayWin();
    }

    private void Jackpot(string message, int payout)
    {
        resultText.text = message + "\n+" + payout;
        Debug.Log(message + " | Payout: " + payout);

        economy.AddCredits(payout);
        audioController.PlayJackpot();
    }
}