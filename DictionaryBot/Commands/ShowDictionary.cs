using TelegramBot.EnglishTrainer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBot.Commands
{
    public class ShowDictionary : AbstractCommand, IChatTextCommandWithAction
    {
        private ITelegramBotClient botClient;
        private Dictionary<string, Word> dictionary;

        public ShowDictionary(ITelegramBotClient botClient)
        {
            CommandText = "/dictionary";

            this.botClient = botClient;
        }

        public bool DoAction(Conversation chat)
        {
            foreach(var record in chat.dictionary)
            {
                dictionary = chat.dictionary;
                botClient.SendTextMessageAsync(chat.GetId(), string.Concat(record.Value.Russian, " <==> ", record.Value.English));
            };
            return !chat.IsAddingInProcess;
        }

        public string ReturnText()
        {
            return $"В словарь введено {dictionary?.Count ?? 0} пар слов";
        }
    }
}
