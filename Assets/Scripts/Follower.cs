using UnityEngine;
using PathCreation;
using Unity.VisualScripting;

public class Follower : MonoBehaviour
{
    public static Follower instance = null;
    public PathCreator leftLane;
    public PathCreator rightLane;
    public PathCreator middleLane;
    float speed;
    float distTravelled;
    int lane = 1;
    private PathCreator pathCreator;

    private void Start()
    {
        Lane();
        speed = 15;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (lane == 1 || lane == 2)
            {
                lane--;
                Lane();
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (lane == 0 || lane == 1)
            {
                lane++;
                Lane();
            }
        }

        distTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distTravelled);
    }

    void Lane()
    {
        if (lane == 1)
        {
            pathCreator = middleLane;
        } else if (lane == 2)
        {
            pathCreator = rightLane;
        } else if (lane == 0)
        {
            pathCreator = leftLane;
        }
    }

    public void increaseSpeed()
    {
        speed += 5;
    }

    public void setLane(int val)
    {
        lane = val;
    }
}
