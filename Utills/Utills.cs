namespace Employees.Utills
{
    public class Utills
    {
        public static int GetOverlappingDays(DateTime firstStart, DateTime firstEnd, DateTime secondStart, DateTime secondEnd)
        {
            if (firstStart >= secondEnd || secondStart >= firstEnd)
            {
                // Няма сечение
                return 0;
            }

            DateTime overlapStart = firstStart < secondStart ? secondStart : firstStart;
            DateTime overlapEnd = firstEnd < secondEnd ? firstEnd : secondEnd;

            return (int)(overlapEnd.Date - overlapStart.Date).TotalDays + 1; // +1, защото overlapEnd започва от 00:00 часа, а не от 23:59
        }
    }
}
