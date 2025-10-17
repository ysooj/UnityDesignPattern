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
        // // LoadScene ; 동기 방식
        // SceneManager.LoadScene(1);  // 실제 작업할 때는 '1'같은 정수 대신 enum으로 하는 게 좋다.(enum도 정수지만, 알아보기 쉽게 하려고.)
    }

    //  public IEnumerator TransitionScene(int index)
    //  {
    //      slider.value = 0;
    //  
    //      screen.SetActive(true);
    //  
    //      // LoadSceneAsync ; 비동기 방식
    //      // <AsyncOperation>
    //      // - allowSceneActivation
    //      // 장면이 준비된 즉시 장면이 활성되는 것을 허용하는 변수입니다. boolean을 반환. default값은 true, true면 장면이 넘어감
    //  }
}
