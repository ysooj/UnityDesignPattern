using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneryManager : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] GameObject screen;
    void Start()
    {
    }

    public void LoadScene(int buildIndex)
    {
        // // LoadScene ; ���� ���
        // SceneManager.LoadScene(1);  // ���� �۾��� ���� '1'���� ���� ��� enum���� �ϴ� �� ����.(enum�� ��������, �˾ƺ��� ���� �Ϸ���.)
    }

    //  public IEnumerator TransitionScene(int index)
    //  {
    //      slider.value = 0;
    //  
    //      screen.SetActive(true);
    //  
    //      // LoadSceneAsync ; �񵿱� ���
    //      // <AsyncOperation>
    //      // - allowSceneActivation
    //      // ����� �غ�� ��� ����� Ȱ���Ǵ� ���� ����ϴ� �����Դϴ�. boolean�� ��ȯ. default���� true, true�� ����� �Ѿ
    //  }
}
