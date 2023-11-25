using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Service.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.Service.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Programm
{
    public static void Main()
    {
        var state = new FileSystemState(new FileSystemFactory(), new WriterFactory());
        string? input = "exit";
        var parser = new MainParser();
        while (true)
        {
            // input = Console.ReadLine(); пока так, чтобы на всякий случай не положить Github Actions
            if (input is null || input.Equals("exit", StringComparison.Ordinal))
            {
                break;
            }

            try
            {
                ICommand? command = parser.Parse(input);
                if (command is null)
                {
                    Console.WriteLine("Command was not found!");
                    continue;
                }

                command.Execute(state);
            }
            catch (IOException e)
            {
                Console.WriteLine("Error by operation! Check possibility of your request!");
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Possible error in request text!");
                Console.WriteLine(e.Message);
            }
        }
    }
}