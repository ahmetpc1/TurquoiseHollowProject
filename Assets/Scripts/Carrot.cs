using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] Color selectedColor, originColor;
    [SerializeField] float speed;
    [SerializeField] GameObject WinPanel;
    bool isOnCarrot;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);

        if (isOnCarrot && Input.GetKeyDown(KeyCode.P))
        {
            WinPanel.SetActive(true);

        } else if (!isOnCarrot) 
        {
            WinPanel.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerOnCarrot(true);
            isOnCarrot = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerOnCarrot(false);
            isOnCarrot = false;
        }
    }
    void PlayerOnCarrot(bool isOnTile)
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

    public void CarrotBuyButton() 
    {
        if (ResourceManager.Instance.gold>=600) 
        {
            GameManager.Instance.GameWinTimerText.text = "Your Score=" + ((int)GameManager.Instance.timer).ToString()+"s";
            GameManager.Instance.OpenGameWýnPanel();
        }
    }
    public void ExitButton()
    {
        WinPanel?.SetActive(false); 
    }
}
