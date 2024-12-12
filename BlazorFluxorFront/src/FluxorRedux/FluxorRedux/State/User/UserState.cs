using Fluxor;

namespace FluxorRedux.State.User
{
    [FeatureState]
    public record UserState
    {
        public List<Models.User> Users { get; set; } = new List<Models.User>();
        public string Error { get; set; } = "";
        public bool IsFirstLoad { get; set; } = true;
        public bool IsLoading { get; set; } = false;
    }
};

