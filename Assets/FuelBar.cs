using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FuelBar : MonoBehaviour
{

    public Image ImgFuelBar;

    public int min;
    public int max;
    public Text amount;

    private float mCurrentValue;
    private float mCurrentPercentage;

    public void Start()
    {
        SetFuel(100);
    }

    public void Update () {
        ImgFuelBar.fillAmount = mCurrentPercentage;    
    }

    
    

    public void SetFuel(float Fuel) {
        
        if (Fuel != mCurrentValue) {
            if (max - min == 0) {
                mCurrentPercentage = 0;
                mCurrentValue = 0;
            }
            else {
                mCurrentValue = Fuel;
                mCurrentPercentage = (float)mCurrentValue / (float)(max - min);
 
               Fuel -= Time.deltaTime;
        
               
            }
            amount.text = string.Format("{0} %", Mathf.RoundToInt(mCurrentPercentage * 100));
            
        }
    }

    public float CurrentPercentage {
        get { return mCurrentPercentage; }
    }

        public float CurrentValue {
        get { return mCurrentValue; }
    }


}
