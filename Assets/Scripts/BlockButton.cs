using UnityEngine;
using UnityEngine.UI;

public class BlockButton : MonoBehaviour
{

    Button buttonPressed;
    void Awake()
    {
        buttonPressed = GetComponent<Button>();
        buttonPressed.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        buttonPressed.interactable = false;
    }
}
