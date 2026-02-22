using UnityEngine;
using UnityEngine.InputSystem;

public class HeroController : MonoBehaviour
{
    public float speed;
    private float a;
    public float aStep;

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        a = 0;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update is called every 0.02 s
    void FixedUpdate()
    {
        ChangeA();
        Walk();
    }

    // -- Behaviour functions -- //
    private void ChangeA()
    {
        float rotDirection = OppositeKeys(Key.Q, Key.E);
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
    private void Walk()
    {
        float rad = a * Mathf.Deg2Rad;
        float x = 0;
        float z = 0;
        float ver = OppositeKeys(Key.S, Key.W);
        float hor = OppositeKeys(Key.A, Key.D);
        //        float sM = (ver != hor ? 1f : (ver != 0f ? 0.7f : 0f));
        float sM = ((ver != 0 && hor != 0) ? 0.7f : ((ver == 0 && hor == 0) ? 0f : 1f));
        if (sM == 1f)
        {
            if (ver != 0)
            {
                x = Mathf.Sin(rad) * speed * ver;
                z = Mathf.Cos(rad) * speed * ver;
            }
            else
            {
                x = Mathf.Cos(rad) * speed * hor;
                z = -Mathf.Sin(rad) * speed * hor;
            }
        }
        else if(sM == 0.7f)
        {
            if(ver + hor != 0f)
            {
                x = (Mathf.Sin(rad) + Mathf.Cos(rad)) / 2 * speed * hor;
                z = (Mathf.Cos(rad) - Mathf.Sin(rad)) / 2 * speed * ver;
            }
            else
            {
                x = -(Mathf.Sin(rad) - Mathf.Cos(rad)) / 2 * speed * hor;
                z = (Mathf.Cos(rad) + Mathf.Sin(rad)) / 2 * speed * ver;
            }
        }
        rb.linearVelocity = new Vector3(x, rb.linearVelocity.y, z);
    }

    // -- Get functions -- //
    public float GetA()
    {
        return a;
    }

    // -- DRY functions -- //
    private float OppositeKeys(Key negative,Key positive)
    {
        bool nPress = Keyboard.current[negative].isPressed;
        bool pPress = Keyboard.current[positive].isPressed;
        /*if(nPress && !pPress)
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
        return 0f;*/
        float direction = (pPress ? 1f : 0f) - (nPress ? 1f : 0f);
        return direction;
    }
}
