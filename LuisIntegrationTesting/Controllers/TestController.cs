using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System.Collections.Generic;
using System.IO;

namespace Bot_Application2
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        public virtual async Task<HttpResponseMessage> Post([FromBody] Activity activity)
        {
            // check if activity is of type message
            if (activity != null && activity.GetActivityType() == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity, () => new EchoDialog());
            }
            else
            {
                HandleSystemMessage(activity);
            }
            return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
        }


        [LuisModel("650bfbb2-eec4-4d51-a197-7a800d21f1a9", "405e762ea3b840e6a415b11731e26c08")]
        [Serializable]
        public class EchoDialog : LuisDialog<object>
        {
            [LuisIntent("")]
            public async Task None(IDialogContext context, LuisResult result)
            {
                await context.PostAsync("I'm sorry. I didn't understand you.");
                context.Wait(MessageReceived);
            }

            [LuisIntent("order food")]
            public async Task OrderFood(IDialogContext context, LuisResult result)
            {
                await context.PostAsync("Here is what I'm going to search for:");
                var entities = new List<EntityRecommendation>(result.Entities);
                foreach (var entity in entities)
                    await context.PostAsync($"{entity.Entity} of type {entity.Type}");
                context.Wait(MessageReceived);
            }

            [LuisIntent("remove")]
            public async Task RemoveItem(IDialogContext context, LuisResult result)
            {
                await context.PostAsync("Here is what I will remove:");
                var entities = new List<EntityRecommendation>(result.Entities);
                foreach (var entity in entities)
                    await context.PostAsync($"{entity.Entity} of type {entity.Type}");
                context.Wait(MessageReceived);
            }

            [LuisIntent("show menu")]
            public async Task ShowMenu(IDialogContext context, LuisResult result)
            {
                await context.PostAsync("Here is the menu I'll show:");
                var entities = new List<EntityRecommendation>(result.Entities);
                foreach (var entity in entities)
                    await context.PostAsync($"{entity.Entity} of type {entity.Type}");
                context.Wait(MessageReceived);
            }

            [LuisIntent("show order")]
            public async Task ShowOrder(IDialogContext context, LuisResult result)
            {
                await context.PostAsync("Here are your entities:");
                var entities = new List<EntityRecommendation>(result.Entities);
                foreach (var entity in entities)
                    await context.PostAsync($"{entity.Entity} of type {entity.Type}");
                context.Wait(MessageReceived);
            }
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
} 