using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))] 
public class StartButton : MonoBehaviour
{
    private Button _btn;

    // Start is called before the first frame update
    void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(StartGame);
    }

    private void OnDestroy()
    {
        _btn.onClick.RemoveListener(StartGame);   
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
