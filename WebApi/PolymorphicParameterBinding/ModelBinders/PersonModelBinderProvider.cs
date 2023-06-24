using Microsoft.AspNetCore.Mvc.ModelBinding;
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

            var baseType = typeof(Person);

            // In this particular case, all derieved types are defined in
            // same assembly as base. If it is not, either hardcode them or 
            // get them from respective assemblies
            var derievedTypes = Assembly.GetAssembly(baseType)?
                                        .GetTypes()
                                        .Where(t => t != baseType && baseType.IsAssignableFrom(t))
                                        .ToList();

            if(derievedTypes is null or [])
            {
                return null;
            }
            var resultBinders = new Dictionary<Type, (ModelMetadata, IModelBinder)>();
            foreach (var type in derievedTypes)
            {
                var modelMetadata = context.MetadataProvider.GetMetadataForType(type);
                resultBinders[type] = (modelMetadata, context.CreateBinder(modelMetadata));
            }

            return new PersonModelBinder(resultBinders);
        }
    }

    public class PersonModelBinder : IModelBinder
    {
        private Dictionary<Type, (ModelMetadata, IModelBinder)> resultBinders;

        public PersonModelBinder(Dictionary<Type, (ModelMetadata, IModelBinder)> resultBinders)
        {
            this.resultBinders = resultBinders;
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var modelKindName = ModelNames.CreatePropertyModelName(bindingContext.ModelName, nameof(Person.EntityType));
            var modelTypeValue = bindingContext.ValueProvider.GetValue(modelKindName).FirstValue;

            var json = await new
        StreamReader(bindingContext.HttpContext.Request.Body).
        ReadToEndAsync();

            var modelMetaData = modelTypeValue switch
            {
                nameof(Employee) => resultBinders[typeof(Employee)],
                nameof(Student) => resultBinders[typeof(Student)],
                _ => throw new Exception()
            };

            
            bindingContext.ModelMetadata = modelMetaData.Item1;

        }
    }
}
