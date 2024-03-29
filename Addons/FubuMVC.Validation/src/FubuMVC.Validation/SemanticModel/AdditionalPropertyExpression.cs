using System;
using System.Linq.Expressions;
using System.Reflection;

namespace FubuMVC.Validation.SemanticModel
{
    public class AdditionalPropertyExpression
    {
        private readonly AdditionalProperties _additionalProperties;

        public AdditionalPropertyExpression(AdditionalProperties additionalProperties)
        {
            _additionalProperties = additionalProperties;
        }

        public void NeedsAdditionalPropertyMatching(Expression<Func<PropertyInfo, bool>> filter)
        {
            _additionalProperties.AddProperty(new Property(filter));
        }
    }
}