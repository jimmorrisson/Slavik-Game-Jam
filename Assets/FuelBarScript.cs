using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBarScript : MonoBehaviour
{
    public Text fuelText;
    public Image imgFuelBar;

    private int maxAmount = 100;
    private float mCurrentPercentage;

    void Start()
    {
        SetFuel(100);
    }

    void Update()
    {
        if (GameMenager.instance != null)
        {
            SetFuel(GameMenager.instance.FuelLeft);
            imgFuelBar.fillAmount = mCurrentPercentage;
        }
    }

    public void SetFuel(float fuel)
    {
        mCurrentPercentage = fuel / maxAmount;
        fuelText.text = string.Format("{0} %", Mathf.RoundToInt(mCurrentPercentage * 100));
    }
}
