using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public Transform hero;
    public float h;
    public float r;

    private HeroController heroController;

    private Vector3 heroPos;
    private float a;
    private float rad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        heroController = hero.GetComponent<HeroController>();
    }

    // Update is called once per frame
    void Update()
    {
        heroPos = hero.transform.position;
        a = heroController.GetA();
        rad = a * Mathf.Deg2Rad;

        float x = heroPos.x + (-Mathf.Sin(rad) * r);
        float y = heroPos.y + h;
        float z = heroPos.z + (-Mathf.Cos(rad) * r);

        transform.position = new Vector3(x, y, z);
        transform.LookAt(heroPos);
    }
}
