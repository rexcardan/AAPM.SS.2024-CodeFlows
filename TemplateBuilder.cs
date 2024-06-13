using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAPM.SS._2024_CodeFlows
{
    public class TemplateBuilder
    {
        public static void BuildTemplate()
        {

            var aapmStatement = """
                The mission of AAPM is advancing medicine through excellence in the science, education and professional practice of medical physics; a broad-based scientific and professional discipline which encompasses physical principles with applications in biology and medicine. With members in 88 countries, AAPM supports the Medical Physics community with a focus on advancing patient care through education, improving safety and efficacy of radiation oncology and medical imaging procedures through research, and the maintenance of professional standards.
                """;
            var allFiles = Directory.GetFiles("../../../WordMakers");
            foreach (var file in allFiles)
            {
                File.Delete(file);
            }

            var missionSplit = aapmStatement.Split(" ");
            for (int i = 0; i < 74; i++)
            {
                ///Generate new file called "Group_#.cs" based on the iteration number in the loop. Each class inherits from "Template" and overrides the "Generate" method to return "World".
                ///The class will be placed in the "AAPM.SS._2024_CodeFlows.WordMakers" namespace.
                var text = new StringBuilder();
                var template = """
                    using System;
                    using System.Collections.Generic;
                    using System.Linq;
                    using System.Text;
                    using System.Threading.Tasks;

                    namespace AAPM.SS._2024_CodeFlows
                    {
                        internal class Group_{0} : Template
                        {
                            public override string Generate()
                            {
                                 return "incomplete (Group {0})";
                                //return "{1}";
                            }
                        }
                    }
                    """;

                text.Append(template.Replace("{0}", $"{i + 1}").Replace("{1}", $"{missionSplit[i]}"));
                File.WriteAllText($"../../../WordMakers/Group_{i+1}.cs", text.ToString());
            }
        }
    }
}
