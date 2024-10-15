using System;

public class HedgehogColoringTests
{
    // Метод для запуску всіх тестів
    public void RunTests()
    {
        Test_AllHedgehogsSameColor_TargetColorIsSame();
        Test_AllHedgehogsSameColor_TargetColorIsDifferent();
        Test_MixOfHedgehogs_TargetColorAchievable();
        Test_MixOfHedgehogs_TargetColorUnachievable();
        Test_OneColorTarget_Success();
        Test_OneColorTarget_Failure();
        Test_AllColorsMixed_TargetColorIsBlue();
        Test_OnlyOneHedgehog();
        Test_LargePopulation();
        Test_ZeroHedgehogs();
    }

    // Метод для перевірки, чи є очікуваний результат таким же, як фактичний
    private void AssertEqual(int expected, int actual)
    {
        if (expected != actual)
        {
            Console.WriteLine($"Test failed: expected {expected}, but got {actual}.");
        }
        else
        {
            Console.WriteLine("Test passed.");
        }
    }

    // Тест 1: Всі їжачки одного кольору і цільовий колір той же
    private void Test_AllHedgehogsSameColor_TargetColorIsSame()
    {
        int[] hedgehogs = { 10, 0, 0 }; // 10 червоних їжаків
        int targetColor = 0; // Цільовий колір - червоний
        int result = HedgehogColoring.MinMeetings(hedgehogs, targetColor);
        AssertEqual(0, result); // Очікуємо 0 зустрічей
    }

    // Тест 2: Всі їжачки одного кольору, цільовий колір інший
    private void Test_AllHedgehogsSameColor_TargetColorIsDifferent()
    {
        int[] hedgehogs = { 5, 0, 0 }; // 5 червоних їжаків
        int targetColor = 1; // Цільовий колір - зелений
        int result = HedgehogColoring.MinMeetings(hedgehogs, targetColor);
        AssertEqual(-1, result); // Невозможно досягти цільового кольору
    }

    // Тест 3: Комбінація їжаків, цільовий колір досяжний
    private void Test_MixOfHedgehogs_TargetColorAchievable()
    {
        int[] hedgehogs = { 3, 2, 5 }; // 3 червоних, 2 зелених, 5 синіх
        int targetColor = 0; // Цільовий колір - червоний
        int result = HedgehogColoring.MinMeetings(hedgehogs, targetColor);
        AssertEqual(5, result); // Очікуємо 5 зустрічей
    }

    // Тест 4: Комбінація їжаків, цільовий колір недосяжний
    private void Test_MixOfHedgehogs_TargetColorUnachievable()
    {
        int[] hedgehogs = { 1, 1, 1 }; // 1 червоний, 1 зелений, 1 синій
        int targetColor = 2; // Цільовий колір - синій
        int result = HedgehogColoring.MinMeetings(hedgehogs, targetColor);
        AssertEqual(-1, result); // Невозможно досягти цільового кольору
    }

    // Тест 5: Один цільовий колір, успішний
    private void Test_OneColorTarget_Success()
    {
        int[] hedgehogs = { 2, 2, 0 }; // 2 червоних, 2 зелених, 0 синіх
        int targetColor = 1; // Цільовий колір - зелений
        int result = HedgehogColoring.MinMeetings(hedgehogs, targetColor);
        AssertEqual(2, result); // Очікуємо 2 зустрічі
    }

    // Тест 6: Один цільовий колір, невдалий
    private void Test_OneColorTarget_Failure()
    {
        int[] hedgehogs = { 4, 0, 4 }; // 4 червоних, 0 зелених, 4 синіх
        int targetColor = 1; // Цільовий колір - зелений
        int result = HedgehogColoring.MinMeetings(hedgehogs, targetColor);
        AssertEqual(-1, result); // Невозможно досягти цільового кольору
    }

    // Тест 7: Усі кольори змішані, цільовий колір - синій
    private void Test_AllColorsMixed_TargetColorIsBlue()
    {
        int[] hedgehogs = { 3, 3, 3 }; // 3 червоних, 3 зелених, 3 синіх
        int targetColor = 2; // Цільовий колір - синій
        int result = HedgehogColoring.MinMeetings(hedgehogs, targetColor);
        AssertEqual(-1, result); // Невозможно досягти цільового кольору
    }

    // Тест 8: Тільки один їжачок
    private void Test_OnlyOneHedgehog()
    {
        int[] hedgehogs = { 0, 0, 1 }; // 0 червоних, 0 зелених, 1 синій
        int targetColor = 2; // Цільовий колір - синій
        int result = HedgehogColoring.MinMeetings(hedgehogs, targetColor);
        AssertEqual(0, result); // Вже досягнуто цільового кольору
    }

    // Тест 9: Велика популяція їжаків
    private void Test_LargePopulation()
    {
        int[] hedgehogs = { 1000, 2000, 3000 }; // 1000 червоних, 2000 зелених, 3000 синіх
        int targetColor = 1; // Цільовий колір - зелений
        int result = HedgehogColoring.MinMeetings(hedgehogs, targetColor);
        AssertEqual(1000, result); // Очікуємо 1000 зустрічей
    }

    // Тест 10: Нуль їжаків
    private void Test_ZeroHedgehogs()
    {
        int[] hedgehogs = { 0, 0, 0 }; // Немає їжаків
        int targetColor = 0; // Цільовий колір - червоний
        int result = HedgehogColoring.MinMeetings(hedgehogs, targetColor);
        AssertEqual(0, result); // Вже досягнуто цільового кольору (немає їжаків)
    }
}
