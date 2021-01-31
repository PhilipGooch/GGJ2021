using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnWin : MonoBehaviour
{
    public RatAudioFeedback audioFeedback;
    // Start is called before the first frame update
    void Start()
    {
        audioFeedback.RatRegards();
    }
}
