using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public int index;

    public Sprite xSprite;
    public Sprite oSprite;

    private Image image;
    private Button button;

    public GameManager gameManager;

    private bool isUsed = false;

    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();

        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (isUsed || gameManager.IsGameOver()) return;

        gameManager.MakeMove(this);
        isUsed = true;
    }

    public void SetO()
    {
        image.sprite = oSprite;
    }

    public void SetX()
    {
        image.sprite = xSprite;
    }

    public bool IsSame(Cell other)
    {
        return image.sprite != null && image.sprite == other.image.sprite;
    }

    public void ResetCell()
    {
        image.sprite = null;
        isUsed = false;
    }
}