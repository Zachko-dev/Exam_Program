using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Vector3 turnAngle;
    [SerializeField]
    private GameObject objectToTurn;
    [SerializeField]
    private int initialLeftClickPoints = 10;
    [SerializeField]
    private int leftClickPoints;
    [SerializeField]
    private int rightClickCost = 100;
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private GameObject restartBtn;

    private int score = 0;

    private void Awake()
    {
        leftClickPoints = initialLeftClickPoints;
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if(Input.GetMouseButtonDown(0))
        {
            objectToTurn.transform.Rotate(turnAngle);
            score += leftClickPoints;
            scoreText.text = "Score: " + score;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if(score >= rightClickCost)
            {
                leftClickPoints++;
                score -= rightClickCost;
                scoreText.text = "Score: " + score;
            }
        }
    }

    public void Reset()
    {
        score = 0;
        leftClickPoints = initialLeftClickPoints;
        scoreText.text = "Score: " + score;
    }

}
