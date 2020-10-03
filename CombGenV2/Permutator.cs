using System;
using System.Text;
using System.IO;

namespace CombGenV2
{
    class Permutator
    {
        public int pCount = 0;
        public int notepadFiles = 1;
        public int[] dataForMain = new int[2];
        private string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\output";
        private StringBuilder stringBuilder = new StringBuilder();

        private static bool shouldSwap(char[] str, int start, int curr)
        {
            for (int index = start; index < curr; ++index)
            {
                if (str[index] == str[curr])
                    return false;
            }
            return true;
        }

        private void FindPermutations(char[] str, int index, int n)
        {
            if (pCount > 12000000)
            {
                ++notepadFiles;
                File.WriteAllText(Path.Combine(docPath, "outputTxt " + notepadFiles + ".txt"), string.Empty);
                File.AppendAllText(Path.Combine(docPath, "outputTxt " + notepadFiles + ".txt"), stringBuilder.ToString());
                stringBuilder.Clear();
                pCount = 0;
            }
            if (index >= n)
            {
                stringBuilder.Append(new string(str) + Environment.NewLine);
                ++pCount;
            }
            else
            {
                for (int index1 = index; index1 < n; ++index1)
                {
                    if (Permutator.shouldSwap(str, index, index1))
                    {
                        Swap(str, index, index1);
                        FindPermutations(str, index + 1, n);
                        Swap(str, index, index1);
                    }
                }
            }
        }

        public void Swap(char[] str, int i, int j)
        {
            char ch = str[i];
            str[i] = str[j];
            str[j] = ch;
        }

        public void Permute(string s)
        {
            if (!Directory.Exists(docPath))
                Directory.CreateDirectory(docPath);
            File.WriteAllText(Path.Combine(docPath, "outputTxtFinal.txt"), string.Empty);
            char[] charArray = s.ToCharArray();
            int length = charArray.Length;
            FindPermutations(charArray, 0, length);
            File.AppendAllText(Path.Combine(docPath, "outputTxtFinal.txt"), stringBuilder.ToString());
            dataForMain[0] = pCount;
            dataForMain[1] = notepadFiles;
            notepadFiles = 1;
            pCount = 0;
            stringBuilder.Clear();
        }
    }
}
