﻿namespace AccessibleAI.Bots.Intents.DefaultIntents.Curious;

public class WhatIsYourGenderIntent : ChitChatIntentBase
{
    public WhatIsYourGenderIntent(string intentName = "WhatIsYourGender") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("I've been programmed to not care about genders.");
    }
}
