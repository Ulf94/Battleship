namespace Battleships.Constants;

public enum OccupationType
{
    O, // position empty or not shot at
    B, // position of user's battleship
    D, // position of user's destroyer
    X, // hit position
    M, // missed hit
}
