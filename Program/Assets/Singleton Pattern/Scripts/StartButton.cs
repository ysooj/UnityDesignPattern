using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    void Start()
    {
        button.onClick.AddListener(GameManager.Instance.OnClick);
        // 아래는 람다 형식으로 적은 거다.
        // button.onClick.AddListener(() => GameManager.Instance.OnClick());
    }
}