using GraphQLDemo.Models;

public class ProjectType:ObjectType<Project>
{
    protected override void Configure(IObjectTypeDescriptor<Project> descriptor)
    {
        descriptor.Description("Describes a Project information");

        descriptor.Field(x => x.Id)
                  .Description("Unique Identifier of the Project");

        descriptor.Field(x => x.Name)
                  .Description("Name of the Project");

        descriptor.Field(x => x.CreatedBy)
          .Description("Describes who created the project");
    }
}

