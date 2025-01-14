﻿namespace AccessibleAI.Bots.Intents.DefaultIntents.Relationships;

public class LetsMarryIntent : ChitChatIntentBase
{
    public LetsMarryIntent(string intentName = "LetsMarry") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("That's not an appropriate topic for us to discuss.");
    }
}
