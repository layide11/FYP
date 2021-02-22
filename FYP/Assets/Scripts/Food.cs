using UnityEngine;

public class Food : MonoBehaviour
{
    
    void Update()
    {
        if(transform.position.y < -2.2)
        {
            Destroy(gameObject);
        }
    }
}
