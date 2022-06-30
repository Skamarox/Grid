using System.Collections;
using UnityEngine;

public interface IMover
{
    void SetTarget(Vector2 vector2);
}

public class CellMove : MonoBehaviour, IMover
{
    [SerializeField] private float Duration = 2f;
    private Vector2 Target;
    private RectTransform myTransform;
    private bool IsMoving = false;

    private void Awake() 
    {
        myTransform = GetComponent<RectTransform>();
    }

    public void SetTarget(Vector2 vector2)
    {
        if (IsMoving == true)
            return;
        Target = vector2;
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        IsMoving = true;
        Vector2 startPosition = myTransform.position;
        float time = 0f;
        float exipredTime = Time.time;
        while(time < 1f)
        {
            time = (Time.time - exipredTime)/ Duration;
            myTransform.position = Vector2.Lerp(startPosition, Target, time);
            yield return null;
        }
        IsMoving = false;
    }
}
