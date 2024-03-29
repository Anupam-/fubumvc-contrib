using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Text.RegularExpressions;
using FubuMVC.Core;
using FubuMVC.Validation.SemanticModel;

namespace FubuMVC.Validation.Rules
{
    public class IsEmail<TViewModel> : IValidationRule<TViewModel> 
    {
        private const string regexPattern = @"^(([^<>()[\]\\.,;:\s@\""]+"
                                            + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                                            + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                                            + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                                            + @"[a-zA-Z]{2,}))$";

        private readonly Expression<Func<TViewModel, string>> _propToValidateExpression;

        public IsEmail(Expression<Func<TViewModel, string>> propToValidateExpression)
        {
            ConstructorArguments = new List<object>{ propToValidateExpression };
            _propToValidateExpression = propToValidateExpression;
            PropertyFilter = new UglyExpressionConvertor().ToString(_propToValidateExpression);
        }

        public bool IsValid(TViewModel viewModel)
        {
            var value = _propToValidateExpression.Compile().Invoke(viewModel);
            return string.IsNullOrEmpty(value) || (new Regex(regexPattern).IsMatch(value) && IsValidEmailDomain(value));
        }

        public string PropertyFilter { get; private set; }
        public IList<object> ConstructorArguments { get; private set; }

        private static bool IsValidEmailDomain(string value)
        {
            if (value.IndexOf("@") == -1)
                return false;

            var emailDomain = value.Substring(value.IndexOf("@") + 1);
            try
            {
                return Dns.GetHostEntry("www.{0}".ToFormat(emailDomain)).AddressList.Length > 0;
            }
            catch (Exception)
            {
                try
                {
                    return Dns.GetHostEntry(emailDomain).AddressList.Length > 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}