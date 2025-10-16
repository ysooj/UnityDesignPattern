using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] bool state = true;

    [SerializeField] static GameManager instance;

    public static GameManager Instance { get { return instance; } }

    public bool State {  get { return state; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void OnClick()
    {
        state = !state;
    }
}
// Data 영역, managed heap
// Scene 전환
// GameManager.Instance.멤버함수