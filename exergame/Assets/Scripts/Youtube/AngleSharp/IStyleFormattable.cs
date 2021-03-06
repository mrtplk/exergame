namespace AngleSharp
{
    using System.IO;

    /// <summary>
    /// Allows basic serialization.
    /// </summary>
    public interface IStyleFormattable
    {
        /// <summary>
        /// Writes the serialization of the node guided by the formatter.
        /// </summary>
        /// <param name="writer">The output target of the serialization.</param>
        /// <param name="formatter">The formatter to use.</param>
        void ToCss(TextWriter writer, IStyleFormatter formatter);
    }
}
