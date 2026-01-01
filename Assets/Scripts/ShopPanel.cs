using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SellPlant(int plantIndex) 
    {
        GameManager.Instance.RefreshTextData();

        Debug.Log(plantIndex);
        if (ResourceManager.Instance.plantAmountArray[plantIndex]>=1) 
        {
            ResourceManager.Instance.plantAmountArray[plantIndex]--;
            ResourceManager.Instance.ChangeGoldAmount(GameManager.Instance.plantsDataSO.plantSellingPrice[plantIndex]);
            Debug.Log("sattin");
        }
    }
}
