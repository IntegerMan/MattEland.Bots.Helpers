﻿using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class YoureWelcomeIntent : ChitChatIntentBase
{
    public YoureWelcomeIntent(string intentName = "YoureWelcome") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("What do you want to talk about next?");
    }
}