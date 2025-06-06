﻿using FluentValidation;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Behaviour
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
           where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly IStringLocalizer<SharedResources> localizer;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, IStringLocalizer<SharedResources> localizer)
        {
            _validators = validators;
            this.localizer = localizer;
        }



        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    var message = failures.Select(x => localizer[x.PropertyName] + " :" + localizer[x.ErrorMessage]).FirstOrDefault();

                    throw new ValidationException(message);

                }
            }
            return await next();
        }
    }

}
