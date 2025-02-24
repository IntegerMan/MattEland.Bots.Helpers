﻿namespace AccessibleAI.Bots.Intents.DefaultIntents.Curious;

public class AreYouABotIntent : ChitChatIntentBase
{
    public AreYouABotIntent(string intentName = "AreYouABot") : base(intentName)
    {
    }

    public override async Task ReplyAsync(ConversationContext context)
    {
        await context.TypeReplyAsync("Of course I'm a bot. I was built using the Microsoft Bot Framework with added components from the Accessible AI Bots project.");
    }
}


