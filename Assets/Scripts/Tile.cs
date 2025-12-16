using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Color originColor, selectedColor;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&& GameManager.Instance.activeTile==null) 
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
            }
        }
    }

    void PlayerOnTile(bool isOnTile) 
    {
        if (isOnTile)
        {
            this.GetComponent<SpriteRenderer>().color = selectedColor;
        }
        else { 
            this.GetComponent<SpriteRenderer>().color = originColor;
        }

    }
}
