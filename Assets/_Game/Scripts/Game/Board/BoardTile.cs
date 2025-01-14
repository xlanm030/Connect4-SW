using UnityEngine;

public class BoardTile : MonoBehaviour
{
    // prom�nn� je vid�t v inspektoru pokud m� parametr SerializeField
    [SerializeField] private SpriteRenderer _renderer;

    public void SetColor(Color color)
    {
        _renderer.color = color;
    }
}
