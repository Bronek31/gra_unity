using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Settings_Panel_Script : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI valueText;

    void Start()
    {
        GameManagerScript gameManagerScript = FindObjectOfType<GameManagerScript>();
        // Access script
        if (gameManagerScript != null)
        {
            float initialValue = gameManagerScript.GetGameSpeedValue()*100;
            Debug.Log(initialValue);
            slider.value = initialValue;
            slider.onValueChanged.AddListener(UpdateValueText);
            UpdateValueText(slider.value);
        }
    }

    void UpdateValueText(float value)
    {
        // Update the Text component's text to display the Slider's value
        string roundedString = (value*10).ToString("0.00");
        valueText.text = roundedString;
    }

            
}
