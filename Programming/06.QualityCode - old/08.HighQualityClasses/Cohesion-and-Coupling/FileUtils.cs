// ********************************
// <copyright file="FileUtils.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace CohesionAndCoupling
{
    using System;

    /// <summary>
    /// Class containing methods to operate over file names.
    /// </summary>
    public static class FileUtils
    {
        /// <summary>
        /// Extracts file name extension.
        /// </summary>
        /// <param name="fileName">Initial file name string.</param>
        /// <returns>Only file name extension.</returns>
        public static string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return null;
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        /// <summary>
        /// Extracts file name without extension.
        /// </summary>
        /// <param name="fileName">Initial file name string.</param>
        /// <returns>Only file name without extension.</returns>
        public static string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            string extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }
    }
}
