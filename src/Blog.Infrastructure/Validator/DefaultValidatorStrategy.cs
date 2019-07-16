using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Infrastructure.Validators
{
    public class DefaultValidatorStrategy<T> : IValidatorStrategy<T>
    {
        public bool IsValid(T validateThis)
        {
            var results = this.Validate(validateThis);

            if (results.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private ICollection<ValidationResult> Validate(T model)
        {
            var results = new List<ValidationResult>();

            var context = new ValidationContext(model);

            Validator.TryValidateObject(
                model, context, results, true);

            return results;
        }
    }
}
