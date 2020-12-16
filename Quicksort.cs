    using System.Collections.Generic;
	using System.IO;
	
	public class SortingDirectoriesMethods
    {
        public static List<DirectoryInfo> SortDaysDirectories(List<DirectoryInfo> dirDayList, string systemMain)
        {
            QuickSort(dirDayList, 0, dirDayList.Count - 1, systemMain);
            return dirDayList;
        }

        //--------------------------------------
        private static void QuickSort(List<DirectoryInfo> dirDayList, int start, int end, string systemMain)
        {
            int pivotPosition;
            if (start < end)
            {
                pivotPosition = Partition(dirDayList, start, end, systemMain);

                QuickSort(dirDayList, start, pivotPosition - 1, systemMain);
                QuickSort(dirDayList, pivotPosition + 1, end, systemMain);
            }
        }

        private static int Partition(List<DirectoryInfo> dirDayList, int start, int end, string systemMain)
        {
            DirectoryInfo temp;
            DirectoryInfo pivotValue = dirDayList[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
            {
                if (CompareDirInfo(dirDayList[j], pivotValue, systemMain)) //prima o uguale
                {
                    i++;
                    temp = dirDayList[i];
                    dirDayList[i] = dirDayList[j];
                    dirDayList[j] = temp;
                }
            }

            temp = dirDayList[i + 1];
            dirDayList[i + 1] = dirDayList[end];
            dirDayList[end] = temp;
            return i + 1;
        }

        //Metodo che restituisce true se il primo elemento deve stare prima del secondo nella lista (a <= b TRUE)
        private static bool CompareDirInfo(DirectoryInfo firstDir, DirectoryInfo secondDir, string systemMain)
        {
            if ((firstDir.Name.CompareTo(secondDir.Name) == 0 && (firstDir.Parent.Name == systemMain || firstDir.Parent.Parent.Name == systemMain) ||
                firstDir.Name.CompareTo(secondDir.Name) == -1))
                return true;
            else
                return false;
        }
	}
	