using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts_Core.Shared
{
    public static class ExceptionMessages
    {
        public static readonly string INVALID_AMOUNT_EXCEPTION_MESSAGE = "The amount value cannot be negative";

        public static readonly string NULL_ACCOUNT_EXCEPTION_MESSAGE = "The Accounts must have a value !";

        public static readonly string BALANCE_NOT_ENOUGH_EXCEPTION_MESSAGE = "The Account balance is not enough !";

        public static readonly string INVALID_INPUTS_EXCEPTION_MESSAGE = "Please insert valid inputs";
    }
}
