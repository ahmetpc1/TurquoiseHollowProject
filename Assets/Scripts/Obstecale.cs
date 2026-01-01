using UnityEngine;

public class Obstecale : MonoBehaviour
{
    [SerializeField] Color originColor, selectedColor;
    [SerializeField] int goldReward;
    void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)&&GameManager.Instance.activeObstecale==this) 
        {
            Debug.Log("efend'm");
            DestroyObstecale();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameManager.Instance.activeObstecale == null&&GameManager.Instance.playerState==GameManager.PlayerState.Cleaning)
        {
            PlayerOnObstacle(true);
            GameManager.Instance.activeObstecale = this;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (GameManager.Instance.activeObstecale == this)
            {

                PlayerOnObstacle(false);
                GameManager.Instance.activeObstecale = null;
            }
        }
    }

    void PlayerOnObstacle(bool isOnTile)
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
    void DestroyObstecale()
    {
        ResourceManager.Instance.ChangeGoldAmount(goldReward);
        Destroy(gameObject);
    }
}
