# Практическая работа №6
## Создание автоматизированных Unit-тестов

### Цель работы
Изучить принципы модульного тестирования и научиться создавать автоматизированные Unit-тесты для проверки работы методов программы.

---

# Используемые технологии

- C#
- .NET
- MSTest
- Microsoft Visual Studio

---

# Описание проекта

В рамках данной практической работы был создан класс **BankAccount**, моделирующий банковский счет пользователя.

Класс содержит:
- имя владельца счета
- текущий баланс
- метод снятия средств `Debit()`
- метод пополнения счета `Credit()`

Для проверки корректности работы методов был создан отдельный проект модульного тестирования **BankTests**.

---

# Реализованные тесты

## Тесты метода Debit

- Debit_WithValidAmount_UpdatesBalance
- Debit_WhenAmountIsLessThanZero_ShouldThrowException
- Debit_WhenAmountIsMoreThanBalance_ShouldThrowException

## Тесты метода Credit

- Credit_WithValidAmount_UpdatesBalance
- Credit_WhenAmountIsLessThanZero_ShouldThrowException

---

# Скриншоты работы программы

## Результат

![Результат](https://drive.google.com/file/d/1D6bOs7bxfRJNpOczA5kzaotUni186dj3/view?usp=drive_link)

---

## тест1

![тест1](test1.png)

---

## тест

![тест](test.png)

---

# Результат тестирования

После запуска тестов в **Test Explorer** все тесты выполняются успешно.
