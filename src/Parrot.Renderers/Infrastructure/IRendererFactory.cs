namespace Parrot.Renderers.Infrastructure
{
    public interface IRendererFactory
    {
        void RegisterFactory(IRenderer renderer);
        IRenderer GetRenderer(string blockName);
    }
}