using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextSwapper : MonoBehaviour
{
    public TextMeshProUGUI label;
    public string textA = "Halo";
    public string textB = "Selamat Tinggal";

    private bool isTextA = true;

    public void SwapText()
    {
        if (label != null)
        {
            label.text = isTextA ? textB : textA;
            isTextA = !isTextA;
        }
    }
}