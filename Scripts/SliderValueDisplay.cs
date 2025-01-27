using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueDisplay : MonoBehaviour
{
    public Slider slider;        // Reference to the slider
    public TMP_Text valueText;       // Reference to the Text UI element (for TextMeshPro, use TMP_Text)

    void Start()
    {
        // Initialize the text with the slider's starting value
        UpdateValueText(slider.value);

        // Add a listener to update the text whenever the slider value changes
        slider.onValueChanged.AddListener(UpdateValueText);
    }

    // Update the text to display the slider's value
    private void UpdateValueText(float value)
    {
        valueText.text = value.ToString("F2"); // Format the value to 2 decimal places
    }

    // Remove listener to prevent memory leaks (optional, but good practice)
    void OnDestroy()
    {
        slider.onValueChanged.RemoveListener(UpdateValueText);
    }
}