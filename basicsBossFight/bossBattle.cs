class BossBattle1 {
    public static void Run() {
        // CODE START
        // PLAYER 1
        Console.Title = "BOSS BATTLE";
        Console.WriteLine("Player1: ");
        Console.Write("How far away from the city do you want to station the Manticore? ");
        Console.ForegroundColor = ConsoleColor.Green;
        int manticoreDistance = Convert.ToInt32(Console.ReadLine());
        Console.ForegroundColor = ConsoleColor.White;

        Console.Clear();


        // PLAYER 2
        int round = 0;
        int cityHealth = 15;
        int manticoreHealth = 10;
        bool directHit = false;
        int damageStrength = 0;

        Console.WriteLine("Player 2, it's your turn.");

        do {

            for (int i = 0; i < 80; i++) {
                Console.Write("-");
            }
            Console.WriteLine("\n");

            // GAME STATE
            // 1: Reset Hit Status
            // 2: Increment round
            round++;
            directHit = false;
            Console.WriteLine($"STATUS:     Round: {round}      City: {cityHealth}/15       Manticore: {manticoreHealth}/10");

            // damage
            damageStrength = Damage(round);
            Console.WriteLine($"The cannon is expected to deal {damageStrength} damage this round");
            
            // player2 input
            Console.Write("Enter desired cannon range: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int cannonRange = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            // check if MANTICORE was hit
            Console.WriteLine($"{ConfirmHit(cannonRange)}");

            // call DamageImpact logic
            DamageImpact(directHit);

        } while (cityHealth > 0 &&  manticoreHealth > 0);


        // GAME RESULT
        // check game result
        GameResult();



        // METHODS
        // method1: Damage
        int Damage (int round) {
            if (round % 3 == 0 && round % 5 == 0) {
                return 10;
            }
            else if (round % 3 == 0) {
                return 3;
            }
            else if (round % 5 == 0) {
                return 3;
            }
            else {
                return 1;
            }
        }

        // Method2: ConfirmHit
        string ConfirmHit (int cannonRange){
            if (cannonRange == manticoreDistance) {
                directHit = true;
                return "That round was a DIRECT HIT!";
            }
            else if (cannonRange > manticoreDistance) {
                return "That round OVERSHOT the target.";
            }
            else {
                return "That round FELL SHORT of the target.";
            }
        }

        // Method3: DamageImpact
        void DamageImpact(bool directHit) {
            if (directHit) {
                manticoreHealth -= damageStrength;
            }
            else {
                cityHealth--;
            }
        }

        // Method4: GameResult
        void GameResult() {
            if (cityHealth <= 0) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("GAMEOVER!");
                Console.WriteLine("You failed!!!");
                Console.WriteLine("The MANTICORE DESTROYED THE CITY!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (manticoreHealth <= 0) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The MANTICORE has been destroyed!!!");
                Console.WriteLine("The CITY OF CONSOLAS has been saved!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    }
}