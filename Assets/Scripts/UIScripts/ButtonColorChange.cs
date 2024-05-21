using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonColorChange : MonoBehaviour
{
    public Color normalButtonColor = Color.white; // Normal color of the button
    public Color pressedButtonColor = Color.red; // Color of the button when pressed

    public TextMeshProUGUI textMeshProText;
    public Color pressedTextColor;

    private Color normalTextColor;

    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChangeColor);

        // Store the normal color of the text
        normalTextColor = textMeshProText.color;
    }

    // Change color when button is clicked
    void ChangeColor()
    {
        // Change the button color to the pressed color
        button.image.color = pressedButtonColor;

        // Change the text color to the pressed text color
        textMeshProText.color = pressedTextColor;

        // Invoke method to change color back to normal after a short delay (e.g., 0.2 seconds)
        Invoke("ResetColor", 0.2f);
    }

    // Reset color to normal after button is released
    void ResetColor()
    {
        button.image.color = normalButtonColor;
        textMeshProText.color = normalTextColor;
    }
}