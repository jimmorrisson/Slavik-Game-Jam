using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FuelBar : MonoBehaviour
{

    public Image ImgFuelBar;

    private int min;
    private int max;
    public Text amount;

    private float mCurrentValue;
    private float mCurrentPercentage;

    void Start()
    {
        max = 100;
        min = 0;
    }

    void Update()
    {
        if (GameMenager.instance != null)
        {
            Debug.Log("DUPA");
            //SetFuel(GameMenager.instance.FuelLeft);
            //ImgFuelBar.fillAmount = mCurrentPercentage;
        }
    }

    public void SetFuel(float fuel)
    {
        Debug.Log(string.Format("Fuel: {0}", fuel));
        mCurrentPercentage = fuel / max;
        amount.text = string.Format("{0} %", Mathf.RoundToInt(mCurrentPercentage * 100));
        //amount.text = fuel.ToString();
    }
}
