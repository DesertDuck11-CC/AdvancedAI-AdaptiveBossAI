using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TMP_Text endText;

    private void Start()
    {
        endText.text = GameState.playerWon ? "You Won!" : "You Lost!";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("BattleScreen");
    }
}
