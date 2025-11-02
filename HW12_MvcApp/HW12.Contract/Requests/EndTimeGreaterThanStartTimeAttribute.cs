using System;
using System.ComponentModel.DataAnnotations;
using HW12.Contract.Requests;

namespace HW12.Contract.Requests
{
    public class EndTimeGreaterThanStartTimeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var instance = (UpsertSessionRequest)validationContext.ObjectInstance;

            if (instance.StartTime >= instance.EndTime)
            {
                // Возвращаем ошибку валидации
                return new ValidationResult(ErrorMessage ?? "Время окончания должно быть позже времени начала.");
            }

            // Если всё в порядке
            return ValidationResult.Success;
        }
    }

}