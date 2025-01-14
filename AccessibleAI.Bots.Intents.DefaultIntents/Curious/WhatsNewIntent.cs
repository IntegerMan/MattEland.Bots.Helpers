﻿namespace AccessibleAI.Bots.Intents.DefaultIntents.Curious;

public class WhatsNewIntent : ChitChatIntentBase
{
    public WhatsNewIntent(string intentName = "WhatsNew") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I don't generally keep up with current events, unfortunately.");
    }
}
