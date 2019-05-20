using UnityEngine;

public class ButtonBlock : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target.GetComponent<IButtonBlockTarget>().OnButtonTrigger();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target.GetComponent<IButtonBlockTarget>().OnButtonTrigger();
        }
    }
}