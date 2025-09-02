using TMPro;
using UnityEngine;

public class PointingSystemScript : MonoBehaviour
{
    public TMP_Text pointText;
    [SerializeField]
    private int points = 0;

    //changes depending on the points
    public float speed = 2f;
    public float spawnInterval = 2f;

    private int lastMilestone = 0;

    public void AddPoint()
    {
        points++;
        pointText.text = points.ToString();
    }

    // Extra Challenge every 5 points increase speed and increase spawn interval

    private void FixedUpdate()
    {
        if (points != 0 && points % 5 == 0 && points != lastMilestone)
        {
            if (speed <= 4f)
            {
                speed += 0.2f;
            }
            else
            {
                return;
            }
            if (spawnInterval <= 1f)
            {
                return;
            }
            else
            {
                spawnInterval -= 0.1f;
            }
            lastMilestone = points;
        }
    }


}
