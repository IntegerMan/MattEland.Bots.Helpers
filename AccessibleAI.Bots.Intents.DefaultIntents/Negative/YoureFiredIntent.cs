﻿namespace AccessibleAI.Bots.Intents.DefaultIntents.Negative;

public class YoureFiredIntent : ChitChatIntentBase
{
    public YoureFiredIntent(string intentName = "YoureFired") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("That's unfortunate.");
    }
}
