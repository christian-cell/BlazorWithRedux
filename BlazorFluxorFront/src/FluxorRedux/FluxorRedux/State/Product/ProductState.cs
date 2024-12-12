using Fluxor;

namespace FluxorRedux.State.Product
{
    [FeatureState]
    public record ProductState
    {
        public string ProductName { get; set; } = "mi producto";

    }
};
