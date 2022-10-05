﻿namespace AccessibleAI.Bots.Intents.DefaultIntents.Curious;

public class TellMeAboutMeIntent : ChitChatIntentBase
{
    public TellMeAboutMeIntent(string intentName = "TellMeAboutMe") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm not really programmed with information about you.");
    }
}
