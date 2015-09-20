﻿using Prtg.Helpers;

namespace Prtg
{
    /// <summary>
    /// Represents a filter used to limit search results returned by a PRTG Request.
    /// </summary>
    public class ContentFilter
    {
        /// <summary>
        /// Property to filter on.
        /// </summary>
        public Property Property { get; private set; }

        /// <summary>
        /// Operator to use to filter <see cref="Property"/> with <see cref="Value"/>.
        /// </summary>
        public FilterOperator Operator { get; private set; }

        /// <summary>
        /// Value to filter on.
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Prtg.ContentFilter"/> class.
        /// </summary>
        /// <param name="property">Property (property) to filter on.</param>
        /// <param name="value">Value to filter on.</param>
        public ContentFilter(Property property, string value) : this(property, FilterOperator.Equals, value)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Prtg.ContentFilter"/> class with a specified operator.
        /// </summary>
        /// <param name="property">Property (property) to filter on.</param>
        /// <param name="operator">Operator to use to filter <paramref name="property"/> with <paramref name="value"/></param>
        /// <param name="value">Value to filter on.</param>
        public ContentFilter(Property property, FilterOperator @operator, string value)
        {
            Property = property;
            Operator = @operator;
            Value = value;
        }

        private string GetOperatorFormat()
        {
            var description = Operator.GetDescription(false);

            if (description == null)
                return Value;
            else
                return string.Format($"@{description}({Value})");
        }

        /// <summary>
        /// Returns the formatted string representation of this filter for use in a <see cref="T:Prtg.PrtgUrl"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var format = string.Format($"{Parameter.FilterXyz.GetDescription()}{Property}={GetOperatorFormat()}");

            return format;
        }
    }
}