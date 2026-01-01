using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    int currentInventoryIndex=0;
    int maxInventoryAmount=3;
    [SerializeField] Image[] Slots = new Image[3];

    [SerializeField] Color selectedColor;
    [SerializeField] Color unselectedColor;

    void Start()
    {
        ChangeColor(currentInventoryIndex,true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
        SelectNextItem();
        }
    }
    public void SelectNextItem() 
    {
        ChangeAllColoSlots();
        currentInventoryIndex = (currentInventoryIndex+1)%maxInventoryAmount;
        ChangeColor(currentInventoryIndex, true);
        AssignPlayerState();
    }
    public void SelectPreviousItem()
    {
        ChangeAllColoSlots();

        currentInventoryIndex =
        (currentInventoryIndex - 1 + maxInventoryAmount) % maxInventoryAmount;
        ChangeColor(currentInventoryIndex, true);
        AssignPlayerState();

    }
    void ChangeColor(int index, bool selected)
    {
        Slots[index].color = selected ? selectedColor : unselectedColor;
    }
    void ChangeAllColoSlots()
    {
        for (int i =0; i<3;i++) 
        {
            ChangeColor(i,false);
        }
    }
    void AssignPlayerState() 
    {
        if (currentInventoryIndex==0) 
        {
            GameManager.Instance.playerState = GameManager.PlayerState.Farming;
        }
        else if (currentInventoryIndex == 1 )
        {
            GameManager.Instance.playerState = GameManager.PlayerState.Cleaning;
        }else
            GameManager.Instance.playerState = GameManager.PlayerState.Trade;
    }
}
