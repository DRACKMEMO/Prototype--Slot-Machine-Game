using UnityEngine;

public class SlotMachineEconomy : MonoBehaviour
{
    [Header("Economy Settings")]
    [SerializeField] private int startingCredits = 100;
    [SerializeField] private int spinCost = 10;

    private int currentCredits;

    public int CurrentCredits => currentCredits;
    public int SpinCost => spinCost;

    private void Awake()
    {
        currentCredits = startingCredits;
    }

    public bool CanSpin()
    {
        return currentCredits >= spinCost;
    }

    public bool SpendForSpin()
    {
        if (!CanSpin())
            return false;

        currentCredits -= spinCost;
        return true;
    }

    public void AddCredits(int amount)
    {
        if (amount <= 0)
            return;

        currentCredits += amount;
    }
}