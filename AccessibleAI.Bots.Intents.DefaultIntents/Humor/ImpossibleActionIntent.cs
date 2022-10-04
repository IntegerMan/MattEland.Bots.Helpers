﻿using AccessibleAI.Bots.Core;
using AccessibleAI.Bots.Core.Intents;

namespace AccessibleAI.Bots.Intents.DefaultIntents.Humor;

public class ImpossibleActionIntent : ChitChatIntentBase
{
    public ImpossibleActionIntent(string intentName = "ImpossibleAction") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I'm sorry, but I'm not able to do that.");
    }
}