using System.Threading.Tasks;

public interface INoResponseAsyncCommand<in TInput>
{
    Task Execute(TInput data);
}
