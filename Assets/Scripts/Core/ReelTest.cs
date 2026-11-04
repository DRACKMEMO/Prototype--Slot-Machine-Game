using UnityEngine;

public class ReelTest : MonoBehaviour
{
    [SerializeField] private SlotMachineController slotMachine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            slotMachine.SpinAll();
        }
    }
}