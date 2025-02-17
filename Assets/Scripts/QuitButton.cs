using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class QuitButton : MonoBehaviour
{
    private Button _btn;

    // Start is called before the first frame update
    void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(QuitGame);
    }

    private void OnDestroy()
    {
        _btn.onClick.RemoveListener(QuitGame);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Saliendo del programa");
    }
}
