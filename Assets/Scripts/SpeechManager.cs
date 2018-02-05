using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Use this for initialization
    void Start()
    {
      
        Debug.Log(this.gameObject.name+" Have Speech Manager");
        keywords.Add("Full Size", () =>
        {
            Debug.Log("Full Size");
            // Call the OnReset method on every descendant object.
            this.BroadcastMessage("FullSize");
        });

        keywords.Add("Half Size", () =>
        {
            Debug.Log("Half Size");
            // Call the OnReset method on every descendant object.
            this.BroadcastMessage("HalfSize");
        });

        keywords.Add("Broke", () =>
        {
            Debug.Log("Broke");
            // Call the OnReset method on every descendant object.
            this.BroadcastMessage("Broke");
        });

        keywords.Add("Unite", () =>
        {
            Debug.Log("Half Size");
            // Call the OnReset method on every descendant object.
            this.BroadcastMessage("Unite");
        });

        keywords.Add("Show Command", () =>
        {
            
            // Call the OnReset method on every descendant object.
            this.BroadcastMessage("ShowCommand");
        });
        keywords.Add("Hide Command", () =>
        {
            Debug.Log("Half Size");
            // Call the OnReset method on every descendant object.
            this.BroadcastMessage("HideCommand");
        });
        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}
