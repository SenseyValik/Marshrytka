using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelSystem : MonoBehaviour
{
    public float currentFuel;

    public float maxFuel = 100f;

    public float fuelConsumptionRate;

    public Slider fuelIndicatorSlider;

    public Text fuelIndicatorText;

    public float lightningPower = 30f;
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
        fuelIndicatorText.text = currentFuel.ToString("0") + "%";

        if (currentFuel <= 0)
        {
            currentFuel = 0;
            fuelIndicatorText.text = "Out of fuel!";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Lightning"))
        {
            currentFuel += lightningPower;
            if (currentFuel > maxFuel)
                currentFuel = maxFuel;
            UpdateUI();

            Destroy(other.gameObject);
        }
    }
}
