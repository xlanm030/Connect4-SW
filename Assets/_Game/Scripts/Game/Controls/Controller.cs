using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private GameBoard _gameBoard;

    private Column _selectedColumn;
    private BaseCanvasController _activeCanvas;

    // najde prvn� objekt
    private void Awake()
    {
        _activeCanvas = FindFirstObjectByType<BaseCanvasController>();
    }

    // po spln�n� podm�nek m��eme um�stit token
    private void Update()
    {
        if (_activeCanvas.ActiveGameScreen != null && _activeCanvas.ActiveGameScreen.GameScreenType == GameScreenType.Pause)
        {
            return;
        }

        HandleMouseInput();

        if (_selectedColumn == null)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
        {
            _selectedColumn.PlaceToken(_gameBoard);
            _selectedColumn.SetHighlight(false);
            _selectedColumn = null;
        }
    }

    // kontrola my�i se sloupcema
    // p�i detekci kolize se nastav� vybran� sloupec na vybran�
    private void HandleMouseInput()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Column"))
            {
                Column column = hit.collider.GetComponent<Column>();
                if (column != _selectedColumn && !column.IsOccupied())
                {
                    _selectedColumn?.SetHighlight(false);
                    _selectedColumn = column;
                    _selectedColumn.SetHighlight(true);
                }
            }
        }
    }
}
