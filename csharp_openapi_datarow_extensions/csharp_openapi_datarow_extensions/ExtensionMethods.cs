using System;
using System.Data;
using System.Collections.Generic;
namespace csharp_openapi_extensions
{
    public static class CSharpDataRowExtensions
    {
        /// <summary>
        /// Convert an individual data row to an instance of type T
        /// </summary>
        /// <typeparam name="T">The type to convert to. Must have a constructor that accepts a DataRow as its only (required) parameter.</typeparam>
        /// <param name="row">The datarow to convert.</param>
        /// <param name="con">A lambda function that calls the constructor for the type.</param>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// DataRow row;
        /// T = row.ToObj<T>(r => new T(r));
        /// </code>
        /// </example>
        /// <exception cref="System.InvalidCastException"></exception>
        public static T ToObj<T>(this DataRow row, Func<DataRow, T> con)
        {
            return con(row);
        }

        public static List<T> ToObjList<T>(this DataTable table, Func<DataRow, T> con)
        {
            List<T> objs = new List<T>();
            foreach (DataRow r in table.Rows)
            {
                objs.Add(r.ToObj<T>(con));
            }
            return objs;
        }
    }
}
