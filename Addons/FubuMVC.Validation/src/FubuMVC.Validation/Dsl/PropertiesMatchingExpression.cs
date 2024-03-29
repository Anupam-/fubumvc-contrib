using System;
using System.Linq.Expressions;
using FubuMVC.Validation.Rules;
using FubuMVC.Validation.SemanticModel;

namespace FubuMVC.Validation.Dsl
{
    public class PropertiesMatchingExpression<TViewModel> where TViewModel : class
    {
        private readonly ValidationConfiguration _validationConfiguration;

        public PropertiesMatchingExpression(ValidationConfiguration validationConfiguration)
        {
            _validationConfiguration = validationConfiguration;
        }

        public PropertiesMatchingExpression<TViewModel> Property(Expression<Func<TViewModel, object>> propertySelector, Action<ExtendedRuleExpression<TViewModel>> rules)
        {
            rules(new ExtendedRuleExpression<TViewModel>(_validationConfiguration, propertySelector));
            return this;
        }

        public PropertiesMatchingExpression<TViewModel> WillNotBeValidated()
        {
            _validationConfiguration.DiscoveredTypes.RemoveAllRulesFor<TViewModel>();
            return this;
        }

        public PropertiesMatchingExpression<TViewModel> WillNotBeValidatedBy<TValidationRule>() where TValidationRule : IValidationRule<TViewModel>
        {
            _validationConfiguration.DiscoveredTypes.RemoveRuleFrom<TViewModel, TValidationRule>();
            return this;
        }
    }
}