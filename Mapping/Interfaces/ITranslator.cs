namespace Mapping.Interfaces;

public interface ITranslator<in TIn, TOut>
{
    TOut Translate(TIn input);
    Task<TOut> TranslateAsync(TIn input);
}