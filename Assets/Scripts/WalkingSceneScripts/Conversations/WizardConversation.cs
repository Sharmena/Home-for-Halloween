using Fluent;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This example introduces writing text to the dialog.
/// You also need a WriteHandler to specify the Text UI element to write to.
/// Write() will write some text with a pause at the end.
/// </summary>
public class WizardConversation : MyFluentDialogue
{
    public TextMeshProUGUI OtherTextElement;

    public override void OnFinish()
    {
        OtherTextElement.text = "";
        base.OnFinish();
    }

    private void startBattle() {
        SceneManager.LoadScene(sceneName: "Deck System Wizard");
    }

    public override FluentNode Create()
    {
        return
            Show() *
            Write(0, "(They look like they're feeling down)") *

            Options
            (
                Option("What's wrong?") *
                    Write(0.5f, "Its almost Halloween, and I barely feel like casting spells anymore. It just hasn't been fun lately.") *
                    
                    Options
                    (
                        Option("Let me try to help (start card game)") *
                        Do(() => startBattle()) *
                        End()
                    //Eventually want to add this when player wins - "That was so fun! Its been a while since I�ve cast spells on someone else. Can I go with you for this Halloween?" 
                    )
             );
    }
}
