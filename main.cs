using System;

class Program {
class Clock
{
private int hh, mm, ss;

public int HH
{
get { return hh; }
set
{
if (value >= 0 && value <= 23) hh = value;
else if (value < 0) hh = 24 - value;

else hh = value % 24;
}
}

public int MM
{
get { return mm; }
set
{
if (value >= 0 && value <= 59) mm = value;
else if (value < 0) mm = 60 + value;
else mm = value % 60;
}
}

public int SS
{
get { return ss; }
set
{
if (value >= 0 && value <= 59) ss = value;
else if (value < 0) ss = 60 + value;
else ss = value % 60;
}
}

public Clock()
{
hh = 0;
mm = 0;
ss = 0;
}


// SetClock() без параметров - сброс часов в 00:00:00
public void SetClock(int h = 0, int m = 0, int s = 0)
{
HH = h; MM = m; SS = s;
}

public void AddTime(int h = 0, int m = 0, int s = 0)
{
if (SS + s > 59) MM++;
else if (SS + s < 0) MM--;
SS += s;
if (MM + m > 59) HH++;
else if (MM + m < 0) HH--;
MM += m;
HH += h;
}


public override string ToString() =>
String.Format($"{HH.ToString().PadLeft(2, '0')}:{MM.ToString().PadLeft(2, '0')}:{SS.ToString().PadLeft(2, '0')}");
}
public static void Main (string[] args) {
Clock clock = new Clock();
Console.WriteLine(clock.ToString()); // 00:00:00

// Установим некорректное время:
clock.SetClock(25, 64, 70);
Console.WriteLine(clock.ToString()); // 01:04:10

// Сбросим часы:
clock.SetClock();
Console.WriteLine(clock.ToString()); // 00:00:00

// Выставим 27 минут:
clock.MM = 27;
Console.WriteLine(clock.ToString()); // 00:27:00

// Добавим 2 часа 30 минут 15 секунд
clock.AddTime(2, 30, 15);
Console.WriteLine(clock.ToString()); // 02:57:15

// Добавим 5 минут
clock.AddTime(0, 5, 0);
Console.WriteLine(clock.ToString()); // 03:02:15

// Отнимем 1 час 5 минут
clock.AddTime(-1, -5, 0);
Console.WriteLine(clock.ToString()); // 01:57:15

Console.ReadKey();
}
}