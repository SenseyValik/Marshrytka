using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelSystem : MonoBehaviour
{
    private float currentFuel;

    public float maxFuel = 100f;

    public float fuelConsumptionRate;

    public Slider fuelIndicatorSlider;

    public Text fuelIndicatorText;
    void Start()
    {
        currentFuel = maxFuel;

        fuelIndicatorSlider.maxValue = maxFuel;
        UpdateUI();
    }

    public void ReduceFuel()
    {
        currentFuel -= Time.deltaTime * fuelConsumptionRate;
        UpdateUI();
    }

    void UpdateUI()
    {
        fuelIndicatorSlider.value = currentFuel;
        fuelIndicatorText.text = currentFuel + "%";

        if (currentFuel <= 0)
        {
            currentFuel = 0;
            fuelIndicatorText.text = "Out of fuel!";
        }
    }
}
