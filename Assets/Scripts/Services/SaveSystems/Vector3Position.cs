namespace Services.SaveSystems
{
    public struct Vector3Position
    {
        public Vector3Position(float positionX, float positionY, float positionZ)
        {
            PositionX = positionX;
            PositionY = positionY;
            PositionZ = positionZ;
        }

        public float PositionX { get; private set; }

        public float PositionY{ get; private set; }

        public float PositionZ{ get; private set; }
    }
}