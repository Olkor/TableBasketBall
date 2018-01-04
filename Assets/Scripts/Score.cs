using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour {
    
    [SerializeField]
    string prefix = "Score: ";
    private Text text;
    int scoreValue = 0;

    private void Start()
    {
        var target = FindObjectOfType<Target>();
        target.onScore += Target_OnScore;
        text = GetComponent<Text>();
        RefreshLabel();
    }

    void Target_OnScore()
    {
        scoreValue++;
        RefreshLabel();
    }

    void RefreshLabel(){
        text.text = prefix + scoreValue;
    }

}
