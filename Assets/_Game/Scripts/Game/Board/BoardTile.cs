using UnityEngine;

public class BoardTile : MonoBehaviour
{
    // renderuje sprity
    [SerializeField] private SpriteRenderer _renderer;

    // nastaví barvu políèka
    public void SetColor(Color color)
    {
        _renderer.color = color;
    }
}
