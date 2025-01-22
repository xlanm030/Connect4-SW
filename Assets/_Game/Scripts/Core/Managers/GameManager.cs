public class GameManager : MonoSingleton<GameManager>
{
    // rozm�ry hrac�ho pole
    public int RowCount = 7;
    public int ColumnCount = 7;

    // jm�na hr���
    public string PlayerOneName;
    public string PlayerTwoName;

    // v�sledek hry
    public bool PlayerOneWon;
    public bool IsTie;

    // hr�� na �ad�
    public bool IsRedTurn { get; private set; } = true;

    // p�ep�n�n� hr��e na �ad�
    public void SwitchTurn()
    {
        IsRedTurn = !IsRedTurn;
    }

    // restar hry a nastaven� prom�nn�ch do p�vodn�ho stavu
    public void Restart()
    {
        PlayerOneWon = false;
        IsTie = false;
        IsRedTurn = true;
    }
}
