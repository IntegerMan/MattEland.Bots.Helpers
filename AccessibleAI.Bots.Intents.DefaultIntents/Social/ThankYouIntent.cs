﻿namespace AccessibleAI.Bots.Intents.DefaultIntents.Social;

public class ThankYouIntent : ChitChatIntentBase
{
    public ThankYouIntent(string intentName = "ThankYou") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("You're welcome.");
        await context.TypeReplyAsync("What do you want to ask me next?");
    }
}
