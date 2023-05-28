using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using WatchFace.Parser.Interfaces;

namespace WatchFace.Parser.Models.Elements
{
    public class ContainerElement : CompositeElement, IDrawable
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public ContainerElement() { }

        public ContainerElement(IEnumerable<Parameter> parameters) : base(parameters) { }

        public ContainerElement(Parameter parameter, Element parent, string name = null) :
            base(parameter, parent, name) { }

        public virtual void Draw(Graphics drawer, Bitmap[] images, WatchState state)
        {
            foreach (var element in Children.OfType<IDrawable>())
            {
                try
                {
                    element.Draw(drawer, images, state);
                }
                catch (Exception e)
                {
                    Logger.Warn(e, "Exception thrown during drawing preview");
                }
            }
        }
    }
}