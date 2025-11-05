// COUNTDOWN
int number = 10;
void countDown(int number) {

    if (number == 0) {
        return;
    }

    Console.WriteLine(number);
    countDown(number - 1);
    return;
}

countDown(10);