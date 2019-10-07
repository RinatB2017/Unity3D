using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    private Text label;

    void OnEnable()
    {
        EventManager.StartListening ("MyEvent", MyFunction);
    }

    void OnDisable()
    {
        EventManager.StopListening ("MyEvent", MyFunction);
    }

    void Awake()
    {
        label = GetComponent<Text>();
    }

    void MyFunction (string param)
    {
        label.text = param;
    }
}
