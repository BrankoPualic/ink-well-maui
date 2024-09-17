using InkWell.MAUI.ViewModels;

namespace InkWell.MAUI.Business.Dtos.Post;

public class LikeDto
{
	public Guid PostId { get; set; }

	public void ToDtoFromVm(PostPageVM vm) => PostId = vm.Id.Value;
}