using Fluent;
using TMPro;
using UnityEngine.UI;

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

    public override FluentNode Create()
    {
        return
            Show() *
            Write(0, "(They look like they’re feeling down)") *

            Options
            (
                Option("What’s wrong?") *
                    Write(0.5f, "Its almost Halloween, and I barely feel like casting spells anymore. It just hasn’t been fun lately.") *
                    
                    Options
                    (
                        Option("Let me try to help (start card game)") *
                        Write(0.5f, "(Did you win)") *

                        Options
                        (
                            
                            Option("Yes") *
                                Write(0, "That was so fun! Its been a while since I’ve cast spells on someone else. Can I go with you for this Halloween?") *
                                Options
                                (
                                     Option("Let's go") *
                                        End() 
                                ) *

                            Option("No") *
                                End()

                        ) 

                        
                    )
             );
    }
}
