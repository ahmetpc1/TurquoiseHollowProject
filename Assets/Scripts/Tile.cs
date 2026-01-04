using System.Collections;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Color originColor, selectedColor;
    SpriteRenderer plantImage;
    int currentPlantIndex;
    public enum TileStates 
    {
    Empty, Planted,Harvest
    }
    public TileStates currentTileState;
    void Start()
    {
        currentTileState = TileStates.Empty;
        plantImage = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && GameManager.Instance.activeTile == this&& currentTileState==TileStates.Empty)
        {
            GameManager.Instance.OpenFarmingPanel();
        }
        if (Input.GetKeyDown(KeyCode.P) && GameManager.Instance.activeTile == this && currentTileState == TileStates.Harvest)
        {
            plantImage.gameObject.SetActive(false);
            ResourceManager.Instance.plantAmountArray[currentPlantIndex]++;
        currentTileState = TileStates.Empty;

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&& GameManager.Instance.activeTile== null&&GameManager.Instance.playerState == GameManager.PlayerState.Farming) 
        {
        PlayerOnTile(true);
        GameManager.Instance.activeTile = this;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameManager.Instance.activeTile==this) 
            {
                PlayerOnTile(false);
                GameManager.Instance.activeTile=null;
                GameManager.Instance.CloseFarmingPanel(); 
            }
        }
    }

    void PlayerOnTile(bool isOnTile) 
    {
        if (isOnTile)
        {
            this.GetComponent<SpriteRenderer>().color = selectedColor;
        }
        else 
        { 
            this.GetComponent<SpriteRenderer>().color = originColor;
        }

    }

    public void StartPlantingProcess(int plantIndex) 
    {
        currentTileState = TileStates.Planted;
        currentPlantIndex= plantIndex;
        StartCoroutine(Planting(plantIndex));
    }
    IEnumerator Planting(int plantIndex) 
    {
        plantImage.gameObject.SetActive(true);
        float totalTime = GameManager.Instance.plantsDataSO.plantTime[plantIndex];
        float elapsed=0f;
        int plantImageIndex = plantIndex * 2;
        plantImage.sprite = GameManager.Instance.plantsDataSO.PlantProcessImages[plantImageIndex];
        while (elapsed<totalTime) 
        {
        yield return new WaitForSeconds(0.5f);
            elapsed += 0.5f;
        }
        plantImage.sprite = GameManager.Instance.plantsDataSO.PlantProcessImages[plantImageIndex+1];

        currentTileState = TileStates.Harvest;

    }
  
}
