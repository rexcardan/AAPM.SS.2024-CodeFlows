using AAPM.SS._2024_CodeFlows;
using System.Reflection;
using System.Text;

//TemplateBuilder.BuildTemplate();
int numberOfGroups = 74;
StringBuilder paragraph = new StringBuilder();

for (int i = 1; i <= numberOfGroups; i++)
{
    // Construct the class name dynamically
    string className = $"AAPM.SS._2024_CodeFlows.Group_{i}";
    // Get the type of the class
    Type type = Type.GetType(className);

    if (type != null)
    {
        // Create an instance of the class
        object instance = Activator.CreateInstance(type);
        // Get the Generate method
        MethodInfo generateMethod = type.GetMethod("Generate");

        if (generateMethod != null)
        {
            // Invoke the Generate method
            string word = (string)generateMethod.Invoke(instance, null);

            // Set the console color based on the word
            if (word.Contains("incomplete", StringComparison.OrdinalIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            // Append the word to the paragraph with a space
            Console.Write(word + " ");
            paragraph.Append(word).Append(" ");
        }
        else
        {
            Console.WriteLine($"Method 'Generate' not found in {className}");
        }
    }
    else
    {
        Console.WriteLine($"Class '{className}' not found");
    }
}

// Trim the trailing space and print the paragraph
string resultParagraph = paragraph.ToString().Trim();
Console.WriteLine(resultParagraph);
Console.ForegroundColor = ConsoleColor.White;