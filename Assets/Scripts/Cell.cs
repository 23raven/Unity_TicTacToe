using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public int index;

    public Sprite xSprite;
    public Sprite oSprite;

    private Image image;
    private Button button;

    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();

        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        SetX();
    }

    void SetX()
    {
        image.sprite = xSprite;
    }
}