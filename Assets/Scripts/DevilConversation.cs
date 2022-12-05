using Fluent;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// This example introduces writing text to the dialog.
/// You also need a WriteHandler to specify the Text UI element to write to.
/// Write() will write some text with a pause at the end.
/// </summary>
public class DevilConversation : MyFluentDialogue
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
            Write(0, "Hello there. Done any great pranks lately?") *

            Options
            (
                Option("What?") *
                    Write(0.5f, "I’ve been trying to think of new pranks to pull, but I can’t think of anything.") *

                    Options(
                        Option("Maybe I can help (Start Card Game)") *
                            Write(0.5f, "(Did you win)") *

                        Options
                        (
                            Option("Yes") *
                                Write(0.5f, "I’ll get you next time! Let me follow to see new ghosts I can prank with what you taught me.") *
                                End() *

                            Option("No") *
                                End() 
                        ) *
                        
                    
                    Option("Yeah, of course.") *
                        Write(0.5f, "Really? I haven’t been able to think of anything new lately, mind showing inspiring me a bit?") *
                        
                        Options(
                        Option("Maybe I can help (Start Card Game)") *
                            Write(0.5f, "(Did you win)") *

                        Options
                        (
                            Option("Yes") *
                                Write(0.5f, "Thanks! I’ll follow to see what else you can do.") *
                                End() *

                            Option("No") *
                                End()
                        )
                )
                )
             );
    }
}
