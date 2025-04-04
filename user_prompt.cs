using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Collections.Generic;

namespace do_while_prompt
{
    public class user_prompt
    {
        // Variable declaration
        private string user_name = string.Empty;
        private string user_question = string.Empty;
        private Dictionary<string, string> replies = new Dictionary<string, string>();
        private List<string> ignores = new List<string>();

        public user_prompt()
        {
            WelcomeUser();
            GetUserInput();
        }

        // Welcoming the user and prompting the name 
        private void WelcomeUser()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("_------------------------------------------------------------------------------------_");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("  Secure your digital world: Ask us anything!" + "");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("_------------------------------------------------------------------------------------_");
            // Different color for the chatbot and user 
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Chatbot:->");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            // AI asks user for a name 
            Console.WriteLine(" Please enter your name.");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            // User answers the question using a different color
            Console.Write("You:-> ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            user_name = Console.ReadLine();
        }

        // Collected user name 
        private void GetUserInput()
        {
            bool isFirstInteraction = true; // Flag to track the first interaction

            do
            {
                if (isFirstInteraction)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan; // Change greeting color to DarkCyan
                    Console.Write("ChatBot:-> ");
                    Console.ForegroundColor = ConsoleColor.Green; // Change greeting text color to green
                    Console.WriteLine($"Hello {user_name}, how can I assist you?");
                    isFirstInteraction = false; // Set the flag to false after the first greeting
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan; // Change follow-up prompt color to DarkCyan
                    Console.Write("ChatBot:-> ");
                    Console.ForegroundColor = ConsoleColor.Green; // Change follow-up text color to green
                    Console.WriteLine("Great! What would you like to ask?");
                }

                Console.ForegroundColor = ConsoleColor.DarkBlue; // Change user prompt color to dark Blue 
                Console.Write($"{user_name}:->");
                Console.ForegroundColor = ConsoleColor.Cyan; // Keep user input color as cyan
                user_question = Console.ReadLine();

                if (user_question.ToLower() == "exit")
                {
                    // Print exit message before breaking the loop
                    Console.ForegroundColor = ConsoleColor.DarkCyan; // Change exit message color to darkCyan
                    Console.WriteLine("ChatBot:->");
                    Console.ForegroundColor = ConsoleColor.DarkRed; // Keep exit message color as dark red
                    Console.WriteLine("Session over, Thank you for using AI. BYE!");
                    break; // Exit the loop
                }
                else
                {
                    Answer(user_question);
                }

                // Ask if the user would like to ask something else
                Console.ForegroundColor = ConsoleColor.DarkCyan; // Change continuation prompt color to dark cyan
                Console.Write("ChatBot:-> ");
                Console.ForegroundColor = ConsoleColor.Green; // Change continuation text color to green
                Console.WriteLine("Would you like to ask something else? (yes/no)");
                Console.ForegroundColor = ConsoleColor.DarkBlue; // Change user prompt color to DarkBlue
                Console.Write($"{user_name}: ");
                Console.ForegroundColor = ConsoleColor.Cyan; // Keep user input color as  cyan
                string continueResponse = Console.ReadLine();

                if (continueResponse.ToLower() != "yes")
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan; // Change exit message color to dark cyan 
                    Console.WriteLine("ChatBot:->");
                    Console.ForegroundColor = ConsoleColor.DarkRed; // Keep exit message color as dark red
                    Console.WriteLine("Session over, Thank you for using AI. BYE!");
                    break; // Exit the loop if the user does not want to continue
                }

            } while (true); // Keep looping until "exit" is typed
        }

        // Answering method 
        private void Answer(string asked)
        {
            LoadReplies();
            LoadIgnores();
            //Tell user to ask anything related to cyber security
            string response = "I'm sorry, I can only help with cybersecurity related questions.";
            foreach (var keyword in replies.Keys)
            {
                if (asked.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    response = replies[keyword];
                    break; // Return the first matching reply
                }
            }

            // Use the typing effect for the response
            TypingEffect(response);
        }

        // Static method for typing effect
        private static void TypingEffect(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen; // Change color for the typing effect
            Console.Write("Typing ");
            for (int i = 0; i < 3; i++) // Show "..." for 3 seconds
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(500); // Wait for half a second
            }
            Console.WriteLine(); // Move to the next line after typing effect

            // Print the response character by character
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(50); // Adjust the speed of typing effect
            }
            Console.WriteLine(); // Move to the next line after the response
        }

        private void LoadReplies()
        {
            replies.Clear();
            replies.Add("password", "Password safety refers to the practices and guidelines for creating and managing strong, unique passwords.\n" +
                "This includes:\n- Using a combination of uppercase and lowercase letters, numbers, and special characters\n" +
                "- Avoiding easily guessable information such as names, birthdays, or common words\n-" +
                " Using a password manager to generate and store unique, complex passwords\n-" +
                " Avoiding password reuse across multiple accounts\n-" +
                " Regularly updating and changing passwords.");
            replies.Add("SQL Injection", "SQL injection is a type of web application security vulnerability where an attacker injects malicious SQL code into a web application's database. This can allow the attacker to:\n" + " Access sensitive data\n-" + " Modify or delete data\r\n" + " Execute system-level commands\n" + " Elevate privileges\n" + "SQL injection attacks can be prevented by using prepared statements, parameterized queries, and input validation.");
            replies.Add("Suspicious Links", "Suspicious links refer to URLs or hyperlinks that appear to be legitimate but may lead to malicious websites, download malware, or steal sensitive information.\n " +
                "It's essential to be cautious when clicking on links, especially from unknown sources.");
            replies.Add("phishing", "Phishing is a type of cyber attack where attackers send fake emails, messages,\n or websites that appear to be from a legitimate source." +
                "\n The goal is to trick victims into revealing sensitive information such as passwords,\n credit card numbers, or personal data.");
            replies.Add("Malware", "Malware, short for malicious software, refers to any type of software designed to harm or exploit a computer system. Common types of malware include:\n- Viruses\n- Worms\r\n- Trojans\r\n- Spyware\r\n- Adware\r\n- Ransomware");
            //  keywords and responses as needed
        }

        private void LoadIgnores()
        {
            ignores.Clear();
            ignores.Add("tell");
            ignores.Add("me");
            ignores.Add("about");
            ignores.Add("what");
        }
    }
}