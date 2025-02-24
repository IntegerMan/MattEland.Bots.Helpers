﻿namespace AccessibleAI.Bots.Intents.DefaultIntents.Relationships;

public class ILoveYouIntent : ChitChatIntentBase
{
    public ILoveYouIntent(string intentName = "ILoveYou") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I don't think it's appropriate to respond to that.");
    }
}
