using Fluent;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// This example introduces writing text to the dialog.
/// You also need a WriteHandler to specify the Text UI element to write to.
/// Write() will write some text with a pause at the end.
/// </summary>
public class ScarConversation : MyFluentDialogue
{
    public TextMeshProUGUI OtherTextElement;
    public bool defeated;

    public override void OnFinish()
    {
        OtherTextElement.text = "";
        base.OnFinish();
    }

    private void defeat()
    {
        defeated = true;
    }

    public override FluentNode Create()
    {
        return
            Show() *
            Write(0, "Hello? I’m glad you’re awake. We wandered a bit too far away from home and I’m not sure we can get there in time for Halloween dinner. Do you think you could get us back?") *

            Options
            (
                Option("Sure thing!") *
                    Write(0.5f, "Really? I just don’t know if we will make it…") *
                    
                    Options
                    (
                        Option("Let me cheer you up (Start card game)") *
                        Write(0.5f, "(Did you win)") *

                        Options
                        (
                            
                            Option("Yes") *
                            Do(() => defeat()) *
                                End() *

                            Option("No") *
                                End()

                        ) 

                        
                    )
             );
    }
}
