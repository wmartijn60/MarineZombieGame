using UnityEngine;

public class FmodPlayer : MonoBehaviour
{
    public void PlaySound(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
    }
}
