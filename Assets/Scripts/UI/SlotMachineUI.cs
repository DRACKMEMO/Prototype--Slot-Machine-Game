using TMPro;
using UnityEngine;

public class SlotMachineUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SlotMachineEconomy economy;
    [SerializeField] private TMP_Text creditsText;

    private void Update()
    {
        creditsText.text = economy.CurrentCredits.ToString();
    }
}