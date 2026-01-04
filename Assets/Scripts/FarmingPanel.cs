using UnityEngine;

public class FarmingPanel : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void BuyPlant1() 
    {
        if (GameManager.Instance.activeTile.currentTileState== Tile.TileStates.Empty&& ResourceManager.Instance.ChangeGoldAmount(-GameManager.Instance.plantsDataSO.plantPrice[0])) 
        {
            GameManager.Instance.activeTile.StartPlantingProcess(0);
        }
    }
    public void BuyPlant2()
    {
        if (GameManager.Instance.activeTile.currentTileState == Tile.TileStates.Empty && ResourceManager.Instance.ChangeGoldAmount(-GameManager.Instance.plantsDataSO.plantPrice[1]))
        {
            GameManager.Instance.activeTile.StartPlantingProcess(1);
        }
    }
    public void BuyPlant3()
    {
        if (GameManager.Instance.activeTile.currentTileState == Tile.TileStates.Empty && ResourceManager.Instance.ChangeGoldAmount(-GameManager.Instance.plantsDataSO.plantPrice[2]))
        {
            GameManager.Instance.activeTile.StartPlantingProcess(2);
        }
    }
}
