using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class I18nTextTranslator : MonoBehaviour
{
    public string TextId;

    // Use this for initialization
    void Start()
    {
        //var text = GetComponent<TMP_Text>();
        //if (text != null)
        //    if (TextId == "ISOCode")
        //        text.text = I18n.GetLanguage();
        //    else
        //        text.text = I18n.Fields[TextId];
    }

    // Update is called once per frame
    void Update()
    {
        var text = GetComponent<TMP_Text>();
        if (text != null)
            if (TextId == "ISOCode")
                text.text = I18n.GetLanguage();
            else
                text.text = I18n.Fields[TextId];
    }
}