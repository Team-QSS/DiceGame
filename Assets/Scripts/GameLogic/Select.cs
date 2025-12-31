using UnityEngine;
using UnityEngine.EventSystems;

public class Select : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private static Select selectedCharacter;
    public static PlayerMove SelectedCharacterObject { get; private set; }
    private Color originalColor;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (selectedCharacter != null && selectedCharacter != this)
        {
            selectedCharacter.Deselect();
        }
        
        selectedCharacter = this;
        SelectedCharacterObject = transform.parent.GetComponent<PlayerMove>();
        spriteRenderer.color = Color.green;
        Debug.Log(SelectedCharacterObject);
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

    private void Deselect()
    {
        spriteRenderer.color = originalColor;
    }
}