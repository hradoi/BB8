//using Microsoft.Bot.Builder.Dialogs;
//using Microsoft.Bot.Builder.Luis;
//using Microsoft.Bot.Builder.Luis.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;

//namespace MasterBB8.Controllers
//{
//    [LuisModel("14ca534c-a2c0-45b9-8f9e-59c418594f09", "405e762ea3b840e6a415b11731e26c08")]
//    [Serializable]
//    public class FoodBotDialog : LuisDialog<object>
//    {
//        //public const string Entity_location = "Location";

//        [LuisIntent("")]
//        public async Task None(IDialogContext context, LuisResult result)
//        {
//            string message = $"Sorry I did not understand: " + string.Join(", ", result.Intents.Select(i => i.Intent));
//            await context.PostAsync(message);
//            context.Wait(MessageReceived);
//        }

//        //enum City { Paris, London, Seattle, Munich };

//        //[LuisIntent("GetWeather")]
//        //public async Task GetWeather(IDialogContext context, LuisResult result)
//        //{
//        //    var obj = (IEnumerable<City>)Enum.GetValues(typeof(City));
//        //    EntityRecommendation location;

//        //    if (!result.TryFindEntity(Entity_location, out location))
//        //    {
//        //        PromptDialog.Choice(context, SelectCity, City, "In which city do you want to know the weather forecast?");
//        //    }
//        //    else
//        //    {
//        //        //Add code to retrieve the weather
//        //        await context.PostAsync($"The weather in {location} is ");
//        //        context.Wait(MessageReceived);
//        //    }
//        //}

//        //private async Task SelectObject(SelectCity context, IAwaitable<City> city)
//        //{
//        //    var message = string.Empty;
//        //    switch (await city)
//        //    {
//        //        case City.Paris:
//        //        case City.London:
//        //        case City.Seattle:
//        //        case City.Munich:
//        //            message = $"The weather in {city} is ";
//        //            break;
//        //        default:
//        //            message = $"Sorry!! I don't have know the weather in {city}";
//        //            break;
//        //    }
//        //    await context.PostAsync(message);
//        //    context.Wait(MessageReceived);
//        //}
//    }
//}