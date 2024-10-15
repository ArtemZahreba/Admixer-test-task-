using System;

public class HedgehogColoring
{
    public static int MinMeetings(int[] hedgehogs, int targetColor)
    {
        int red = hedgehogs[0];
        int green = hedgehogs[1];
        int blue = hedgehogs[2];

        // Якщо всі їжачки вже одного кольору
        if ((red == 0 && green == 0) || (green == 0 && blue == 0) || (red == 0 && blue == 0))
        {
            if ((red == 0 && green == 0 && targetColor == 0) ||
                (green == 0 && blue == 0 && targetColor == 1) ||
                (red == 0 && blue == 0 && targetColor == 2))
            {
                return 0; // Вже досягнуто цільового кольору
            }
            return -1; // Невозможно досягти цільового кольору
        }

        int meetings = 0;

        // Якщо цільовий колір є вже в популяції
        if (hedgehogs[targetColor] > 0)
        {
            return 0;
        }

        // Визначити кількість зустрічей, необхідних для досягнення цільового кольору
        while (true)
        {
            // Якщо немає їжачків іншого кольору
            if (hedgehogs[(targetColor + 1) % 3] == 0 && hedgehogs[(targetColor + 2) % 3] == 0)
            {
                return -1; // Невозможно досягти цільового кольору
            }

            // Зменшити кількість їжачків, які потрібно перефарбувати
            int other1 = (targetColor + 1) % 3;
            int other2 = (targetColor + 2) % 3;

            // Змінити колір їжачків
            int canMeet = Math.Min(hedgehogs[other1], hedgehogs[other2]);
            hedgehogs[other1] -= canMeet;
            hedgehogs[other2] -= canMeet;
            hedgehogs[targetColor] += canMeet * 2; // Два їжачка стають цільовим кольором

            meetings += canMeet;

            // Перевірити, чи досягнуто цільового кольору
            if (hedgehogs[targetColor] == red + green + blue)
            {
                break;
            }
        }

        return meetings;
    }
}
