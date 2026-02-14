using UnityEngine;

public class HeroController : MonoBehaviour
{
    public float speed;
    private float a;
    public float aStep;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update is called every 0.02 s
    void FixedUpdate()
    {
        ChangeA();
    }

    // -- Behaviour functions -- //
    private void ChangeA()
    {
        float rotDirection = OppositeKeys(KeyCode.Q, KeyCode.E);
        if (rotDirection != 0)
        {
            if (a >= -180 && a <= 180)
            {
                a += aStep * rotDirection;
            }
            else
            {
                if (a < 0)
                {
                    a = 180 - aStep;
                }
                else if (a > 0)
                {
                    a = -180 + aStep;
                }
            }
        }
    }

    // -- Get functions -- //
    public float GetA()
    {
        return a;
    }

    // -- DRY functions -- //
    private float OppositeKeys(KeyCode negative,KeyCode positive)
    {
        bool nPress = Input.GetKeyDown(negative);
        bool pPress = Input.GetKeyDown(positive);
        if(nPress && !pPress)
        {
            return -1f;
        }
        else if(nPress && pPress)
        {
            return 0f;
        }
        else if(!nPress && pPress)
        {
            return 1f;
        }
        return 0f;
    }
}
