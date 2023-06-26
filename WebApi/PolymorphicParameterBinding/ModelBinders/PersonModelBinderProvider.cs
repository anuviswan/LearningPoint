using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PolymorphicParameterBinding.Models;
using System.Reflection;

namespace PolymorphicParameterBinding.ModelBinders
{
    public class PersonModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if(context.Metadata.ModelType != typeof(Person))
            {
                return null;
            }

            return new PersonModelBinder();
        }
    }

    public class PersonModelBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var modelKindName = ModelNames.CreatePropertyModelName(bindingContext.ModelName, nameof(Person.EntityType));
            var modelTypeValue = bindingContext.ValueProvider.GetValue(modelKindName).FirstValue;

            using var sr = new StreamReader(bindingContext.HttpContext.Request.Body);
            var json = await sr.ReadToEndAsync();
            JObject requestJObject = JObject.Parse(json);
            string? type = requestJObject["entityType"]?.ToObject<string>();

            Person? person = type switch
            {
                nameof(Employee) => JsonConvert.DeserializeObject<Employee>(json),
                nameof(Student) => JsonConvert.DeserializeObject<Student>(json),
                _ => throw new Exception()
            };

            
            bindingContext.Result =  ModelBindingResult.Success(person);
        }
    }
}
