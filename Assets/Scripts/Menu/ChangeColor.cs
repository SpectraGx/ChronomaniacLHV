using TMPro;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void ChangeWhiteColor()
    {
        text.color = new Color(0.8490566f,0.8490566f, 0.8490566f);
    }

    public void ChangeOrangeColor()
    {
        text.color = new Color(1, 0.5f, 0f);
    }

    private void OnMouseEnter()
    {
        ChangeWhiteColor();
    }
    private void OnMouseExit()
    {
        ChangeOrangeColor();
    }
}


