using UnityEngine;

public class PaytableController : MonoBehaviour
{
    [SerializeField] private GameObject paytablePanel;

    public void OpenPaytable()
    {
        paytablePanel.SetActive(true);
    }

    public void ClosePaytable()
    {
        paytablePanel.SetActive(false);
    }
}