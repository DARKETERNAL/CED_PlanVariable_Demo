using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    [SerializeField]
    private Text winLabel;

    private void Start()
    {
        if (winLabel)
        {
            winLabel.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (winLabel)
            {
                winLabel.gameObject.SetActive(true);
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (winLabel)
            {
                winLabel.gameObject.SetActive(false);
            }
        }
    }
}