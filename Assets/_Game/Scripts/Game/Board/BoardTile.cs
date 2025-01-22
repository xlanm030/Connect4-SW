using UnityEngine;

public class BoardTile : MonoBehaviour
{
    // renderuje sprity
    [SerializeField] private SpriteRenderer _renderer;

    // nastav� barvu pol��ka
    public void SetColor(Color color)
    {
        _renderer.color = color;
    }
}
