using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int gold;

    [SerializeField] TMP_Text goldText;
    public static ResourceManager Instance { get; private set; }

    public int[] plantAmountArray= new int[3];
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        InitilaizeValues();
        RefreshUIElements();
    }

    void InitilaizeValues() 
    {
        gold = 50;
    }
    void RefreshUIElements() 
    {
        goldText.text = "GOLD="+gold;
    }

    public bool ChangeGoldAmount(int amount)
    {
        if (gold+amount>=0) 
        {
            gold+=amount;
            RefreshUIElements();
            return true;
        }
        return false;

    }
    
}
