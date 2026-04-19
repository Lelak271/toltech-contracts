using Toltech.ComputeEngine.Contracts;

namespace Toltech.ComputeEngine.Contracts
{
    /// <summary>
    /// Interface for the compute engine, responsible for performing calculations based on the provided requirements and returning the results in a concurrent dictionary format.
    /// </summary>
    public interface IComputeEngine
    {
        Task<ComputeResult> ComputeAsync(ComputeRequest request);

        Task<bool> IsPartIsostaticAsync(List<ComputeModelData> modelData, ComputePart part);

        Task<bool> IsModelIsostaticAsync(List<ComputeModelData> modelData, int partId1, int partId2, int idFixPart = 0);

    }
}
