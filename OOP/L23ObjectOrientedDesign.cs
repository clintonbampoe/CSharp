class L23ObjectOrientedDesign {
    public static void Run() {
        AsteroidGame game = new AsteroidGame();
        game.Run1();
    }


    // ASTEROID CLASS
    public class Asteroid {

        // properties
        public float PositionX { get; private set; }
        public float PositionY { get; private set; }
        public float VelocityX { get; private set; }
        public float VelocityY { get; private set; }


        // constructor
        public Asteroid(float positionX, float positionY, float velocityX, float velocityY) {
            PositionX = positionX;
            PositionY = positionY;
            VelocityX = velocityX;
            VelocityY = velocityY;
        }


        // Velocity Method (Changes position of asteroid)
        public void Update() {
            PositionX += VelocityX;
            PositionY += VelocityY;
        }
    }

    public class AsteroidGame {
        private Asteroid[] _asteroids;

        // constructor
        public AsteroidGame() {

            _asteroids = new Asteroid[5];
            _asteroids[0] = new Asteroid(100, 200, -4, -2);
            _asteroids[1] = new Asteroid(-50, 100, -1, +3);
            _asteroids[2] = new Asteroid(0, 0, 2, 1);
            _asteroids[3] = new Asteroid(400, -100, -3, -1);
            _asteroids[4] = new Asteroid(200, -300, 0, 3);
        }

        public void Run1() {
            while (true) {
                foreach (Asteroid asteroid in _asteroids) {
                    asteroid.Update();
                }
            }
        }
    }
    
}