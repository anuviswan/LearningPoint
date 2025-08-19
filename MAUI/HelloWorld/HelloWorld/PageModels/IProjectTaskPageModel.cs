using CommunityToolkit.Mvvm.Input;
using HelloWorld.Models;

namespace HelloWorld.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}