namespace DotnetSampleSolution.Core.Contracts
{
    public interface IMappableTo<TModel>
    {
        TModel MapTo(TModel model);
    }
}
