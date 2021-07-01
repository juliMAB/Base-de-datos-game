using UnityEngine.SceneManagement;
using UnityEngine;
public class ChangeScene : MonoBehaviour
{
    public void GoTo(string name)
    {
        SceneManager.LoadScene(name);
    }
}
