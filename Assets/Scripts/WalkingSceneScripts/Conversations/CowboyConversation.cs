using Fluent;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This example introduces writing text to the dialog.
/// You also need a WriteHandler to specify the Text UI element to write to.
/// Write() will write some text with a pause at the end.
/// </summary>
/// 

public class CowboyConversation : MyFluentDialogue
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
            Write(0, "Hey there, doing anything fun this Halloween?") *

            Options
            (
                Option("We’re all going back to have a night with my family.") *
                    Write(0.5f, "Oh that sounds great. I usually walk this path alone.") *
                    
                    Options
                    (
                        Option("Why don’t you come with us this year?  (start card game)") *
                        Write(0.5f, "(Did you win)") *

                        Options
                        (
                            
                            Option("Yes") *
                                Write(0, "That sounds so fun, let’s giddy up.") *
                                End() *

                            Option("No") *
                                End()

                        ) 

                        
                    )
             );
    }
}
