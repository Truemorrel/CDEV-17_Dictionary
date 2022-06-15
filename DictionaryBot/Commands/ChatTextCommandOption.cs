using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBot.Commands
{
    public abstract class ChatTextCommandOption : AbstractCommand
    {
        public override bool CheckMessage(string message)
        {
            return message.StartsWith(CommandText);
        }

        public string ClearMessageFromCommand(string message)
        {
            string word = default;
            try
            {
                word = message.Substring(CommandText.Length + 1);
            }
            catch(ArgumentOutOfRangeException)
            {
                return word;
            }
            return message.Substring(CommandText.Length + 1);
        }

    }
}
