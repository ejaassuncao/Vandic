using System.ComponentModel;

namespace Vandic.CrossCutting.Resources.Configurations
{
    public enum EnumDirection
    {
        /// <summary>
        /// No sort direction.
        /// </summary>
        [Description("none")]
        None,

        /// <summary>
        /// Results are sorted in ascending order (A-Z).
        /// </summary>
        [Description("ascending")]
        Ascending,

        /// <summary>
        /// Results are sorted in descending order (Z-A).
        /// </summary>
        [Description("descending")]
        Descending,
    }
}
