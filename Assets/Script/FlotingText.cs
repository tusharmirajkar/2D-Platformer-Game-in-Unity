using UnityEngine;

public class FlotingText : MonoBehaviour
{
    public TextMesh textMesh;
    void Start()
    {
        int randomNumber = Random.Range(1, 101);
        textMesh.text = randomNumber.ToString();
        Destroy(this.gameObject, 1.01f);
    }
}
