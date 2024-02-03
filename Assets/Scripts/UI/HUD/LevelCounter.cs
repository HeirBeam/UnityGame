
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCounter : MonoBehaviour
{
    Text levelPrint; 
    public string levelName;
    // Start is called before the first frame update
    void Start()
    {
        string levelName = SceneManager.GetActiveScene().name;
        int levelNumber = int.Parse(levelName.Remove(0,5));
        levelPrint = GetComponent<Text>();
        levelPrint.text  ="LEVEL "+ levelNumber;

    }
}
