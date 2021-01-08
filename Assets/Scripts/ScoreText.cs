/*******************
 * name: thomas allen
 * date: 1/7/2021
 * desc: updates score
 * ***********************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI myTmp;

    // Start is called before the first frame update
    void Start()
    {
        myTmp = GetComponent<TextMeshProUGUI>();
        //update when mafe to get the current score
        UpdateText();
        //listen for the event and whenver score changes update text
        GameManager.OnScoreChange.AddListener(UpdateText);
    }


    //updates text of the tmp object
    private void UpdateText()
    {
        myTmp.text = "Score: " + GameManager.Score;
    }
}
