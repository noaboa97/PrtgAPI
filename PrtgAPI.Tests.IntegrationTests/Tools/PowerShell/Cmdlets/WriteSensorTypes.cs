﻿using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using System.Text.RegularExpressions;

namespace PrtgAPI.Tests.IntegrationTests.Tools.PowerShell.Cmdlets
{
    [Cmdlet(VerbsCommunications.Write, "SensorTypes")]
    public class WriteSensorTypes : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public List<MissingSensorType> Types { get; set; }

        protected override void ProcessRecord()
        {
            var builder = new StringBuilder();

            builder.AppendLine("// This code was generated by a tool. Any changes made manually will be lost");
            builder.AppendLine("// the next time this code is regenerated.");

            builder.AppendLine("using System.Xml.Serialization;\r\n");

            builder.AppendLine("namespace PrtgAPI");
            builder.AppendLine("{");

            builder.AppendLine("    /// <summary>");
            builder.AppendLine("    /// <para type=\"description\">Specifies types of sensors that can be created in PRTG.</para>");
            builder.AppendLine("    /// </summary>");
            builder.AppendLine("    public enum SensorTypeInternal");
            builder.AppendLine("    {");

            for(int i = 0; i < Types.Count; i++)
            {
                builder.AppendLine($"        /// <summary>");
                builder.AppendLine($"        /// {Types[i].Description}");
                builder.AppendLine($"        /// </summary>");
                builder.AppendLine($"        [XmlEnum(\"{Types[i].Id}\")]");

                var enumName = Regex.Replace(Types[i].Name, "[^a-zA-Z0-9_]", string.Empty);

                enumName = enumName.Replace("BETA", "");

                builder.Append($"        {enumName}");

                if (i < Types.Count - 1)
                    builder.AppendLine(",\r\n");
                else
                    builder.AppendLine();
            }

            builder.AppendLine("    }");

            builder.Append("}");

            WriteObject(builder.ToString());
        }
    }
}
