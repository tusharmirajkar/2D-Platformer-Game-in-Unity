using UnityEngine;

public class Arrow : MonoBehaviour
{
    //public float ArrowSpeed = 20f;

    private void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    void Update()
    {
      
    }
}
