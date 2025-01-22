public class GameManager : MonoSingleton<GameManager>
{
    // rozmìry hracího pole
    public int RowCount = 7;
    public int ColumnCount = 7;

    // jména hráèù
    public string PlayerOneName;
    public string PlayerTwoName;

    // výsledek hry
    public bool PlayerOneWon;
    public bool IsTie;

    // hráè na øadì
    public bool IsRedTurn { get; private set; } = true;

    // pøepínání hráèe na øadì
    public void SwitchTurn()
    {
        IsRedTurn = !IsRedTurn;
    }

    // restar hry a nastavení promìnných do pùvodního stavu
    public void Restart()
    {
        PlayerOneWon = false;
        IsTie = false;
        IsRedTurn = true;
    }
}
