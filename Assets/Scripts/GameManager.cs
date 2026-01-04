using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum PlayerState
    {
    Farming,Cleaning,Trade
    }
    public static GameManager Instance { get; private set; }
    public PlayerState playerState;
    public Tile activeTile;
    public Obstecale activeObstecale;
    public Npc activeNpc;
    public GameObject FarmingPanel;
    public GameObject ShopPanel;
    public PlantsDataSO plantsDataSO;
    public float timer;
    public GameObject GameWinPanel;

    [Header("Texts")]
    public TMP_Text Plant1PriceText, Plant2PriceText, Plant3PriceText;
    public TMP_Text Plant1SellingPrice, Plant2SellingPrice, Plant3SellingPrice;
    public TMP_Text Plant1Amount, Plant2Amount, Plant3Amount;
    public TMP_Text timerText,GameWinTimerText;

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        CloseFarmingPanel();
        CloseShopPanel();
        CloseGameWýnPanel();
        timer = 0f;
    }


    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = "Time="+ ((int)timer).ToString()+"s";

        if (Input.GetKeyDown(KeyCode.M)) 
        {
            SceneManager.LoadScene(0);
        }
    }

    public void OpenFarmingPanel()
    {
        RefreshTextData();
        GameManager.Instance.FarmingPanel.SetActive(true);

    }
    public void CloseFarmingPanel()
    {
        RefreshTextData();

        GameManager.Instance.FarmingPanel.SetActive(false);
    }
    public void OpenShopPanel()
    {
        RefreshTextData();

        GameManager.Instance.ShopPanel.SetActive(true);

    }
    public void CloseShopPanel()
    {
        RefreshTextData();

        GameManager.Instance.ShopPanel.SetActive(false);
    }
    public void OpenGameWýnPanel()
    {

        GameManager.Instance.GameWinPanel.SetActive(true);

    }
    public void CloseGameWýnPanel()
    {

        GameManager.Instance.GameWinPanel.SetActive(false);
    }
    public void RefreshTextData()
    {
        Plant1PriceText.text = plantsDataSO.plantPrice[0]+"$";
        Plant2PriceText.text = plantsDataSO.plantPrice[1] + "$";
        Plant3PriceText.text = plantsDataSO.plantPrice[2] + "$";

        Plant1Amount.text = ResourceManager.Instance.plantAmountArray[0]+ " pcs";
        Plant2Amount.text = ResourceManager.Instance.plantAmountArray[1] + " pcs";
        Plant3Amount.text = ResourceManager.Instance.plantAmountArray[2] + " pcs";

        Plant1SellingPrice.text = plantsDataSO.plantSellingPrice[0] + "$";
        Plant2SellingPrice.text = plantsDataSO.plantSellingPrice[1] + "$";
        Plant3SellingPrice.text = plantsDataSO.plantSellingPrice[2] + "$";

    }

}
