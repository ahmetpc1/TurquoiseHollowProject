using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField] Color originColor, selectedColor;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && GameManager.Instance.activeNpc == this)
        {
            GameManager.Instance.OpenShopPanel();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameManager.Instance.activeNpc == null && GameManager.Instance.playerState == GameManager.PlayerState.Trade)
        {
            PlayerOnNpc(true);
            GameManager.Instance.activeNpc = this;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (GameManager.Instance.activeNpc == this)
            {

                PlayerOnNpc(false);
                GameManager.Instance.activeNpc = null;
                GameManager.Instance.CloseShopPanel();
            }
        }
    }

    void PlayerOnNpc(bool isOnTile)
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
}
