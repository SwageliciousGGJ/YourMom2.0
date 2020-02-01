using System.Collections;
using System.Collections.Generic;
using SpeechLib;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class TextToSpeech : MonoBehaviour
{
    void Start()
    {
        SpVoice voice;
        voice = new SpVoice();
        //voice.Speak("Knock knock knock, suck my big fat cock");
        //voice.Speak("Kyle I think you got the Corona Virus");
    }
}
