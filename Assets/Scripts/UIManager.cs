using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;

    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;





    private void Update()
    {
        scoreText.text = "Score: " + GameManager.instance.score.ToString();
    }
}
