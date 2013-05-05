// ********************************
// <copyright file="Figure.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Abstraction
{
    using System;

    /// <summary>
    /// Represent abstract figure methods to be inherited.
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Calculates figure perimeter.
        /// </summary>
        /// <returns>Calculated figure's perimeter.</returns>
        public abstract double CalcPerimeter();

        /// <summary>
        /// Calculates figure surface.
        /// </summary>
        /// <returns>Calculated figure's surface.</returns>
        public abstract double CalcSurface();
    }
}
