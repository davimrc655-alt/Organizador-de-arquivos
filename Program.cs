using System;
using System.Collections;
namespace ex39;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.Write("Insira o caminho da pasta aonde esta os arquivos a serem organizados: ");
            string sourcePath = Console.ReadLine();

            if (!Directory.Exists(sourcePath))
            {
                throw new DirectoryNotFoundException($"o Diretorio informado nao existe ou o caminho esta errado! {nameof(sourcePath)}");
            }

            string[] files = Directory.GetFiles(sourcePath);

            foreach (string file in files)
            {
                string extensionFile = Path.GetExtension(file);
                string nameFile = Path.GetFileNameWithoutExtension(file);

                System.Console.WriteLine($"{nameFile} -- {extensionFile}");
            }

            string subPng = Path.Combine(sourcePath, "subPng");
            string subJpeg = Path.Combine(sourcePath, "subJpeg");
            string subPdf = Path.Combine(sourcePath, "subPdf");
            string subTxt = Path.Combine(sourcePath, "subTxt");
            string subCsv = Path.Combine(sourcePath, "subCsv");
            string subDocx = Path.Combine(sourcePath, "subDocx");
            string outros = Path.Combine(sourcePath, "outros");

            if(!Directory.Exists(subPng)) 
            {
                Directory.CreateDirectory(subPng);
            }
            if(!Directory.Exists(subJpeg)) 
            {
                Directory.CreateDirectory(subJpeg);
            }
            if(!Directory.Exists(subPdf)) 
            {
                Directory.CreateDirectory(subPdf);
            }
            if(!Directory.Exists(subTxt)) 
            {
                Directory.CreateDirectory(subTxt);
            }
            if(!Directory.Exists(subCsv)) 
            {
                Directory.CreateDirectory(subCsv);
            }
            if(!Directory.Exists(subDocx)) 
            {
                Directory.CreateDirectory(subDocx);
            }
            if(!Directory.Exists(outros)) 
            {
                Directory.CreateDirectory(outros);
            }
            
            foreach (string file in files)
            {
                string extensionFile = Path.GetExtension(file).ToLower();
                string nameFile = Path.GetFileName(file);
                string fileDestino; 
                if (extensionFile == ".txt")
                {
                    fileDestino = Path.Combine(subTxt, nameFile);
                }
                else if (extensionFile == ".pdf")
                {
                    fileDestino = Path.Combine(subPdf, nameFile);
                }
                else if (extensionFile == ".jpeg")
                {
                    fileDestino = Path.Combine(subJpeg, nameFile);
                }
                else if (extensionFile == ".png")
                {
                    fileDestino = Path.Combine(subPng, nameFile);
                }
                else if (extensionFile == ".csv")
                {
                    fileDestino = Path.Combine(subCsv, nameFile);
                }
                else if (extensionFile == ".docx")
                {
                    fileDestino = Path.Combine(subDocx, nameFile);
                }

                else
                {
                    fileDestino = Path.Combine(outros, nameFile); 
                }

                string path = Path.GetDirectoryName(fileDestino); 
                string name = Path.GetFileNameWithoutExtension(file);
                string namePath = Path.Combine(path, name); 
                int i = 0; 
                while (File.Exists(fileDestino))
                {
                    i++; 
                    fileDestino = Path.Combine(namePath + i + extensionFile); 
                }


                File.Move(file, fileDestino);
            }
            System.Console.WriteLine("Todos os arquivos foram movidos com sucesso");
        }
        catch (DirectoryNotFoundException de)
        {
            System.Console.WriteLine("Ocorreu um erro com o Diretorio informado: " + de.Message);
        }
        catch (Exception e)
        {
            System.Console.WriteLine("Ocorreu um erro: " + e.Message);
        }
    }
}