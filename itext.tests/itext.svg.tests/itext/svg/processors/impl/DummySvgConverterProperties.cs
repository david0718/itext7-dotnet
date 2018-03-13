using iText.Svg.Css;
using iText.Svg.Css.Impl;
using iText.Svg.Processors;
using iText.Svg.Renderers.Factories;

namespace iText.Svg.Processors.Impl {
    public class DummySvgConverterProperties : ISvgConverterProperties {
        internal ICssResolver cssResolver;

        internal ISvgNodeRendererFactory rendererFactory;

        public DummySvgConverterProperties() {
            cssResolver = new DummyCssResolver();
            rendererFactory = new DummySvgNodeFactory();
        }

        public virtual ICssResolver GetCssResolver() {
            return cssResolver;
        }

        public virtual ISvgNodeRendererFactory GetRendererFactory() {
            return rendererFactory;
        }
    }
}
