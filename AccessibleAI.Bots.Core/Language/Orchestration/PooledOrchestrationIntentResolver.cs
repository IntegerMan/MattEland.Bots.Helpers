﻿using System.Collections.Generic;
using System.Linq;
using AccessibleAI.Bots.Core.Language;

namespace AccessibleAI.Bots.Core.Orchestration;

/// <summary>
/// This class is a pooled approach to orchestrating multiple IntentResolvers by confidence with priority weighting.
///
/// In this model each IIntentResolver is asked to resolve the intent and the most confident individual result above a cutoff point will win.
/// 
/// This is a manual alternative to orchestration workflows that helps with class imbalances between orchestration layers and
/// allows you to set a priority order for each layer.
/// </summary>
public class PooledOrchestrationIntentResolver : OrchestrationIntentResolverBase
{
    /// <summary>
    /// Creates a new instance of the <see cref="PooledOrchestrationIntentResolver"/> class.
    /// </summary>
    public PooledOrchestrationIntentResolver() : base()
    {
    }

    /// <summary>
    /// Creates a new instance of the <see cref="PooledOrchestrationIntentResolver"/> class.
    /// </summary>
    /// <param name="layers">The starting layers</param>
    public PooledOrchestrationIntentResolver(IEnumerable<OrchestrationLayer> layers) : base(layers)
    {
    }

    /// <summary>
    /// Finds a match for a given utterance.
    /// 
    /// All intent resolvers will be evaluated and their best result will be multiplied by the layer's priority.
    /// The best overall result will be returned. If there is no overall best, the DefaultIntent will be returned.
    /// </summary>
    /// <param name="utterance">The utterance to be evaluated</param>
    /// <returns>The matching IntentResolutionResult or null if none matched.</returns>
    public override IntentResolutionResult FindIntent(string utterance)
    {
        List<IntentMatch> matches = new();

        IntentResolutionResult bestResult = new();
        double bestConfidence = 0;

        foreach (OrchestrationLayer layer in Layers)
        {
            IntentResolutionResult intent = layer.IntentResolver.FindIntent(utterance);
            intent.OrchestrationIntentName = layer.OrchestrationIntentName;

            matches.AddRange(intent.Intents);

            // Ignore empty and None intents
            if (intent.IntentName == "None") continue;

            // If the intent is below the layer's threshold, ignore it
            if (intent.ConfidenceScore < layer.MinConfidence) continue;

            // Calculate the effective confidence, taking the layer's priority into account
            double confidence = intent.ConfidenceScore * layer.Priority;

            // If this is the best confidence so far, this is now our best result
            if (confidence > bestConfidence)
            {
                bestResult = intent;
                bestConfidence = confidence;
            }
        }

        // Add diagnostic intents
        matches.Where(m => !bestResult.Intents.Contains(m)).ToList().ForEach(m => bestResult.AddMatchingIntent(m));

        return bestResult;
    }
}